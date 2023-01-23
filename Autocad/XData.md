### Overview
Extended Entity Data (XData) is a legacy mechanism to attach additional information to AutoCAD entities. I say "legacy" as there are limits inherent to using XData, which make other mechanisms more appropriate when storing significant amounts of data. The global XData limit is 16 KBytes per object, and this potentially needs to be shared between multiple applications.
- Reference : https://www.keanw.com/2007/04/adding_xdata_to.html

### Limitation
- You can store up to 16K of data on objects.

### Code
```csharp
[CommandMethod("GXD")]
        static public void GetXData()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;

            // Ask the user to select an entity

            // for which to retrieve XData
            PromptEntityOptions opt = new PromptEntityOptions("\nSelect entity: ");
            PromptEntityResult res = ed.GetEntity(opt);

            if (res.Status == PromptStatus.OK)
            {
                Transaction tr = doc.TransactionManager.StartTransaction();

                using (tr)
                {
                    DBObject obj = tr.GetObject(res.ObjectId, OpenMode.ForRead);
                    ResultBuffer rb = obj.XData;

                    if (rb == null)
                    {
                        ed.WriteMessage("\nEntity does not have XData attached.");
                    }
                    else
                    {
                        int n = 0;

                        foreach (TypedValue tv in rb)
                        {
                            ed.WriteMessage("\nTypedValue {0} - type: {1}, value: {2}", n++, tv.TypeCode, tv.Value);
                        }

                        rb.Dispose();
                    }
                }
            }
        }

        [CommandMethod("SXD")]
        static public void SetXData()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;

            // Ask the user to select an entity
            // for which to set XData
            PromptEntityOptions opt = new PromptEntityOptions("\nSelect entity: ");
            PromptEntityResult res = ed.GetEntity(opt);

            if (res.Status == PromptStatus.OK)
            {
                Transaction tr = doc.TransactionManager.StartTransaction();

                using (tr)
                {
                    DBObject obj = tr.GetObject(res.ObjectId, OpenMode.ForWrite);

                    AddRegAppTableRecord("KEAN");

                    ResultBuffer rb = new ResultBuffer(new TypedValue(1001, "KEAN"), new TypedValue(1000, "This is a test string"));

                    obj.XData = rb;

                    rb.Dispose();

                    tr.Commit();
                }
            }
        }

        private static void AddRegAppTableRecord(string regAppName)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;

            Transaction tr = doc.TransactionManager.StartTransaction();
            using (tr)
            {
                RegAppTable rat = (RegAppTable)tr.GetObject(db.RegAppTableId, OpenMode.ForRead, false);

                if (!rat.Has(regAppName))
                {
                    rat.UpgradeOpen();
                    RegAppTableRecord ratr = new RegAppTableRecord();
                    ratr.Name = regAppName;
                    rat.Add(ratr);
                    tr.AddNewlyCreatedDBObject(ratr, true);
                }
                tr.Commit();
            }
        }
```

### Get and View XDATA for specific App
```csharp
 [CommandMethod("AttachXDataToSelectionSetObjects")]
        public void AttachXDataToSelectionSetObjects()
        {
            // Get the current database and start a transaction
            Database acCurDb;
            acCurDb = Application.DocumentManager.MdiActiveDocument.Database;

            Document acDoc = Application.DocumentManager.MdiActiveDocument;

            string appName = "MY_APP";
            string xdataStr = "This is some xdata";

            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Request objects to be selected in the drawing area
                PromptSelectionResult acSSPrompt = acDoc.Editor.GetSelection();

                // If the prompt status is OK, objects were selected
                if (acSSPrompt.Status == PromptStatus.OK)
                {
                    // Open the Registered Applications table for read
                    RegAppTable acRegAppTbl;
                    acRegAppTbl = acTrans.GetObject(acCurDb.RegAppTableId, OpenMode.ForRead) as RegAppTable;

                    // Check to see if the Registered Applications table record for the custom app exists
                    if (acRegAppTbl.Has(appName) == false)
                    {
                        using (RegAppTableRecord acRegAppTblRec = new RegAppTableRecord())
                        {
                            acRegAppTblRec.Name = appName;

                            acTrans.GetObject(acCurDb.RegAppTableId, OpenMode.ForWrite);
                            acRegAppTbl.Add(acRegAppTblRec);
                            acTrans.AddNewlyCreatedDBObject(acRegAppTblRec, true);
                        }
                    }

                    // Define the Xdata to add to each selected object
                    using (ResultBuffer rb = new ResultBuffer())
                    {
                        rb.Add(new TypedValue((int)DxfCode.ExtendedDataRegAppName, appName));
                        rb.Add(new TypedValue((int)DxfCode.ExtendedDataAsciiString, xdataStr));

                        SelectionSet acSSet = acSSPrompt.Value;

                        // Step through the objects in the selection set
                        foreach (SelectedObject acSSObj in acSSet)
                        {
                            // Open the selected object for write
                            Entity acEnt = acTrans.GetObject(acSSObj.ObjectId,
                                                                OpenMode.ForWrite) as Entity;

                            // Append the extended data to each object
                            acEnt.XData = rb;
                        }
                    }
                }

                // Save the new object to the database
                acTrans.Commit();

                // Dispose of the transaction
            }
        }

        [CommandMethod("ViewXData")]
        public void ViewXData()
        {
            // Get the current database and start a transaction
            Database acCurDb;
            acCurDb = Application.DocumentManager.MdiActiveDocument.Database;

            Document acDoc = Application.DocumentManager.MdiActiveDocument;

            string appName = "MY_APP";
            string msgstr = "";

            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Request objects to be selected in the drawing area
                PromptSelectionResult acSSPrompt = acDoc.Editor.GetSelection();

                // If the prompt status is OK, objects were selected
                if (acSSPrompt.Status == PromptStatus.OK)
                {
                    SelectionSet acSSet = acSSPrompt.Value;

                    // Step through the objects in the selection set
                    foreach (SelectedObject acSSObj in acSSet)
                    {
                        // Open the selected object for read
                        Entity acEnt = acTrans.GetObject(acSSObj.ObjectId,
                                                         OpenMode.ForRead) as Entity;

                        // Get the extended data attached to each object for MY_APP
                        ResultBuffer rb = acEnt.GetXDataForApplication(appName);

                        // Make sure the Xdata is not empty
                        if (rb != null)
                        {
                            // Get the values in the xdata
                            foreach (TypedValue typeVal in rb)
                            {
                                msgstr = msgstr + "\n" + typeVal.TypeCode.ToString() + ":" + typeVal.Value;
                            }
                        }
                        else
                        {
                            msgstr = "NONE";
                        }

                        // Display the values returned
                        Application.ShowAlertDialog(appName + " xdata on " + acEnt.GetType().ToString() + ":\n" + msgstr);

                        msgstr = "";
                    }
                }

                // Ends the transaction and ensures any changes made are ignored
                acTrans.Abort();

                // Dispose of the transaction
            }
        }
```
