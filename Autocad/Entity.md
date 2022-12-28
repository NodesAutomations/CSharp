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
### Identifying block Name from the block reference
Reference : https://adndevblog.typepad.com/autocad/2012/05/identifying-block-name-from-the-block-reference.html
```csharp
        [CommandMethod("blockName")]
        static public void blockName()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;

            Database db = doc.Database;

            Editor ed = doc.Editor;

            PromptEntityOptions options = new PromptEntityOptions("\nSelect block reference");

            options.SetRejectMessage("\nSelect only block reference");

            options.AddAllowedClass(typeof(BlockReference), false);

            PromptEntityResult acSSPrompt = ed.GetEntity(options);

            using (Transaction tx = db.TransactionManager.StartTransaction())
            {
                BlockReference blockRef = tx.GetObject(acSSPrompt.ObjectId, OpenMode.ForRead) as BlockReference;

                BlockTableRecord block = null;

                if (blockRef.IsDynamicBlock)
                {
                    //get the real dynamic block name.
                    block = tx.GetObject(blockRef.DynamicBlockTableRecord, OpenMode.ForRead) as BlockTableRecord;
                }
                else
                {
                    block = tx.GetObject(blockRef.BlockTableRecord, OpenMode.ForRead) as BlockTableRecord;
                }
                if (block != null)
                {
                    ed.WriteMessage("Block name is : " + block.Name + "\n");
                }
                tx.Commit();
            }
        }
```

### Code to Edit Block Attribute Value
Refer : https://www.keanw.com/2007/07/updating-a-spec.html
```csharp
public static void SetBlockData()
        {
            //Using Specific Block Name
            //var data = new BlockDataList();
            //data.LoadBlockDataFromExcel();

            Database database = HostApplicationServices.WorkingDatabase;
            //Start Transaction
            var cadTransaction = new CadTransaction();
            BlockTableRecord btRecord = (BlockTableRecord)cadTransaction.Transaction.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(database), OpenMode.ForRead);
            foreach (ObjectId id in btRecord)
            {
                Entity entity = (Entity)cadTransaction.Transaction.GetObject(id, OpenMode.ForRead);

                //Filter Block Entity
                if (entity.Handle.ToString() == "2A3")
                {
                    BlockReference blockRef = cadTransaction.Transaction.GetObject(entity.ObjectId, OpenMode.ForRead) as BlockReference;
                    var attributeCollection = blockRef.AttributeCollection;
                    foreach (ObjectId attributeId in attributeCollection)
                    {
                        AttributeReference attributeReference = (AttributeReference)cadTransaction.Transaction.GetObject(attributeId, OpenMode.ForRead);

                        if (attributeReference.Tag == "SIZE")
                        {
                            attributeReference.UpgradeOpen();
                            attributeReference.TextString = "1000000";
                            attributeReference.DowngradeOpen();
                        }
                    }

                }
            }

            //End Transaction
            cadTransaction.Commit();
        }
```
