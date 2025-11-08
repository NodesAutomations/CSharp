### References
- http://docs.autodesk.com/ACD/2011/ENU/filesMDG/WS1a9193826455f5ff2566ffd511ff6f8c7ca-3626.htm

### Sample Code
```csharp

        static Polyline acPoly = null;
        [CommandMethod("AddPlObjEvent")]
        public static void AddPlObjEvent()
        {
            // Get the current document and database, and start a transaction
            using (Transaction acTrans = ActiveUtil.TransactionManager.StartTransaction())
            {
                // Create a closed polyline
                acPoly = new Polyline();
                acPoly.SetDatabaseDefaults();
                acPoly.AddVertexAt(0, new Point2d(1, 1), 0, 0, 0);
                acPoly.AddVertexAt(1, new Point2d(1, 2), 0, 0, 0);
                acPoly.AddVertexAt(2, new Point2d(2, 2), 0, 0, 0);
                acPoly.AddVertexAt(3, new Point2d(3, 3), 0, 0, 0);
                acPoly.AddVertexAt(4, new Point2d(3, 2), 0, 0, 0);
                acPoly.Closed = true;

                // Add the new object to the block table record and the transaction
                ActiveUtil.Database.GetModelSpace(OpenMode.ForWrite).AppendEntity(acPoly);
                acTrans.AddNewlyCreatedDBObject(acPoly, true);
                acPoly.Modified += new EventHandler(acPolyMod);
                // Save the new object to the database
                acTrans.Commit();
            }
        }
        [CommandMethod("RemovePlObjEvent")]
        public static void RemovePlObjEvent()
        {
            if (acPoly != null)
            {
                // Get the current document and database, and start a transaction
                Document acDoc = Application.DocumentManager.MdiActiveDocument;
                Database acCurDb = acDoc.Database;
                using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                {
                    // Open the polyline for read
                    acPoly = acTrans.GetObject(acPoly.ObjectId,
                                               OpenMode.ForRead) as Polyline;
                    if (acPoly.IsWriteEnabled == false)
                    {
                        acPoly.UpgradeOpen();
                    }
                    acPoly.Modified -= new EventHandler(acPolyMod);
                    acPoly = null;
                }
            }
        }
        public static void acPolyMod(object senderObj,
                              EventArgs evtArgs)
        {
            Application.ShowAlertDialog("The area of " +
                                          acPoly.ToString() + " is: " +
                                          acPoly.Area);
        }
```
