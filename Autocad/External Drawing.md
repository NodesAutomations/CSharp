### Copy Block References from external drawing
```csharp
[CommandMethod("Test")]
        public void Test()
        {
            try
            {
                //Code to copy block from another drawing to active drawing

                string externalFilePath = @"C:\Users\Ryzen2600x\source\repos\Template_AutoCAD_BasicApp_CSharp\CadApp\Sample.dwg";

                Database tempDatabase = new Database(false, true);
                tempDatabase.ReadDwgFile(externalFilePath, System.IO.FileShare.ReadWrite, true, "");

                ObjectIdCollection blockObjectIdCollection = new ObjectIdCollection();

                using (Transaction transaction = tempDatabase.TransactionManager.StartTransaction())
                {
                    BlockTable blockTable = transaction.GetObject(tempDatabase.BlockTableId, OpenMode.ForRead) as BlockTable;

                    //Check if drawing  contain specific block
                    if (blockTable.Has("Pole"))
                    {
                        blockObjectIdCollection.Add(blockTable["Pole"]);
                    }
                    transaction.Commit();
                }
                if (blockObjectIdCollection.Count == 0)
                {
                    return;
                }
                IdMapping idMapping = new IdMapping();
                ActiveUtil.Database.WblockCloneObjects(blockObjectIdCollection, ActiveUtil.Database.BlockTableId, idMapping, DuplicateRecordCloning.Ignore, false);

                //Code to loop through all block references and Copy Exiting references
                ObjectIdCollection blockRefObjectIdCollection = new ObjectIdCollection();

                using (Transaction transaction = tempDatabase.TransactionManager.StartTransaction())
                {
                    BlockTable blockTable = transaction.GetObject(tempDatabase.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord modelSpaceBlockTable = transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForRead) as BlockTableRecord;

                    foreach (ObjectId objectId in modelSpaceBlockTable)
                    {
                        if (objectId.ObjectClass.IsDerivedFrom(RXObject.GetClass(typeof(BlockReference))))
                        {
                            BlockReference blockReference = transaction.GetObject(objectId, OpenMode.ForRead) as BlockReference;
                            if (blockReference.Name != "Pole")
                            {
                                continue;
                            }

                            //Create new Block Reference on Active Database
                            //Copy Block Attribute values from original 


                            using (Transaction subTransaction = ActiveUtil.Document.TransactionManager.StartTransaction())
                            {
                                //Open block table of active drawing
                                BlockTable activeblockTable = subTransaction.GetObject(ActiveUtil.Database.BlockTableId, OpenMode.ForRead) as BlockTable;
                                //Opem Model Space block table for active drawing
                                BlockTableRecord currentActiveSpaceBlockTableRecord = subTransaction.GetObject(ActiveUtil.Database.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;

                                if (!activeblockTable.Has("Pole"))
                                {
                                    return;
                                }

                                //Get Access to block defination
                                BlockTableRecord activeBlockTableRecord = subTransaction.GetObject(activeblockTable["Pole"], OpenMode.ForRead) as BlockTableRecord;

                                //Create new Block reference
                                BlockReference newBlockReference = new BlockReference(blockReference.Position, activeBlockTableRecord.ObjectId);

                                //Add block reference to active space
                                currentActiveSpaceBlockTableRecord.AppendEntity(newBlockReference);

                                //Add blockReference to current transaction
                                subTransaction.AddNewlyCreatedDBObject(newBlockReference, true);

                                //Iterate block definition to find all non-constant AttributeDefinitions
                                foreach (ObjectId id in activeBlockTableRecord)
                                {
                                    AttributeDefinition attDef = subTransaction.GetObject(id, OpenMode.ForRead) as AttributeDefinition;
                                    if ((attDef != null) && (!attDef.Constant))
                                    {
                                        using (AttributeReference attRef = new AttributeReference())
                                        {
                                            attRef.SetAttributeFromBlock(attDef, newBlockReference.BlockTransform);
                                            attRef.TextString = attDef.TextString;

                                            //Add the AttributeReference to the BlockReference
                                            newBlockReference.AttributeCollection.AppendAttribute(attRef);
                                            subTransaction.AddNewlyCreatedDBObject(attRef, true);
                                        }
                                    }

                                }

                                subTransaction.Commit();
                            }
                        }
                    }

                    transaction.Commit();
                }

                tempDatabase.Dispose();
            }
            catch (System.Exception ex)
            {
                Application.ShowAlertDialog($"Something went wrong error:{ex.Message}");
            }
        }
```
