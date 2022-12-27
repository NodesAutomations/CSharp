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
                    Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(string.Format("\nHandle: {0},{1}", entity.Handle, entity.BlockName));
                }

                transaction.Commit();
            }
        }
```
