### Code to loop through each entity
```csharp
[CommandMethod("ModelSpaceIterator")]
        public static void ModelSpaceIterator_Method()
        {
            Database database = HostApplicationServices.WorkingDatabase;
            using (Transaction transaction = database.TransactionManager.StartTransaction())
            {
                BlockTableRecord btRecord = (BlockTableRecord)transaction.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(database), OpenMode.ForRead);
                foreach (ObjectId id in btRecord)
                {
                    Entity entity = (Entity)transaction.GetObject(id, OpenMode.ForRead);

                    //Access to the entity

                    Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(string.Format("\nHandle: {0},{1}", entity.Handle, entity.GetType()));

                    BlockReference blockRef = transaction.GetObject(entity.ObjectId, OpenMode.ForRead) as BlockReference;
                    BlockTableRecord block = null;

                    if (blockRef.IsDynamicBlock)
                    {
                        //get the real dynamic block name.
                        block = transaction.GetObject(blockRef.DynamicBlockTableRecord, OpenMode.ForRead) as BlockTableRecord;
                    }
                    else
                    {
                        block = transaction.GetObject(blockRef.BlockTableRecord, OpenMode.ForRead) as BlockTableRecord;
                    }
                    if (block != null)
                    {
                        Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("Block name is : " + block.Name + "\n");
                    }
                }
                transaction.Commit();
            }
        }
```
