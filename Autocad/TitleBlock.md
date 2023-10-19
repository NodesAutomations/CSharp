### Sample code to update title block attibute in paperspace
```csharp
 [CommandMethod("UpdateTitleBlock")]
        public static void UpdateTitleBlock()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                BlockTableRecord ms = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.PaperSpace], OpenMode.ForWrite);

                foreach (ObjectId id in ms)
                {
                    Entity ent = tr.GetObject(id, OpenMode.ForWrite) as Entity;
                    if (ent != null && ent is BlockReference)
                    {
                        BlockReference br = ent as BlockReference;

                        if (br.Name == "XXXXXX__TITLE_BLOCK_D")
                        {
                            foreach (ObjectId arId in br.AttributeCollection)
                            {
                                DBObject obj = tr.GetObject(arId, OpenMode.ForWrite);
                                AttributeReference ar = obj as AttributeReference;
                                if (ar != null && ar.Tag == "TITLE1")
                                {
                                    ar.UpgradeOpen();
                                    ar.TextString = "Test Drawing";
                                    ar.DowngradeOpen();
                                }
                            }
                        }
                    }
                }
                tr.Commit();
            }
        }
```
