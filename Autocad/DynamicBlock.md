### Code to Update Dynamic Block
```csharp
        [CommandMethod("TEST")]
        public void Test()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;

            using (var tr = db.TransactionManager.StartTransaction())
            {
                var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                // if the bloc table has the block definition
                if (bt.Has("Table"))
                {
                    // create a new block reference
                    var br = new BlockReference(Point3d.Origin, bt["Table"]);

                    // add the block reference to the curentSpace and the transaction
                    var curSpace = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);
                    curSpace.AppendEntity(br);
                    tr.AddNewlyCreatedDBObject(br, true);

                    // set the dynamic property value1
                    foreach (DynamicBlockReferenceProperty prop in br.DynamicBlockReferencePropertyCollection)
                    {
                        if (prop.PropertyName == "Length")
                        {
                            prop.Value = 50.0;
                        }
                    }
                }
                // save changes
                tr.Commit();
            } // <- end using: disposing the transaction and all objects opened with it (block table) or added to it (block reference)
        }
```
