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
