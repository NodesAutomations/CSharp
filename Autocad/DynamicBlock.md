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

### Code to Update Dynamic Property of selected block
```csharp
[CommandMethod("TEST")]
public void Test()
{
    var doc = Application.DocumentManager.MdiActiveDocument;
    var dataBase = doc.Database;
    var editor = doc.Editor;

    //Code to select Block
    PromptEntityResult prompt = editor.GetEntity("Select one Dynamic Block To Update");

    if (prompt.Status != PromptStatus.OK)
    {
        editor.WriteMessage("nothing selected");
        return;
    }

    //Get Block From object Id

    using (Transaction transaction = dataBase.TransactionManager.StartTransaction())
    {
        //Get entity using object id
        Entity entity = (Entity)transaction.GetObject(prompt.ObjectId, OpenMode.ForRead);

        BlockReference blockRef = transaction.GetObject(entity.ObjectId, OpenMode.ForRead) as BlockReference;
        BlockTableRecord block = null;

        if (blockRef.IsDynamicBlock)
        {
            block = transaction.GetObject(blockRef.DynamicBlockTableRecord, OpenMode.ForRead) as BlockTableRecord;

            editor.WriteMessage($"\n{block.Name} Dynamic Block selected");

            foreach (DynamicBlockReferenceProperty property in blockRef.DynamicBlockReferencePropertyCollection)
            {
                //Only Focus on visible properties
                if (property.Show)
                {
                    //Code to update property
                    var inputPrompt = editor.GetDouble(new PromptDoubleOptions($"\nEnter New Value for {property.PropertyName}"));

                    if (inputPrompt.Status == PromptStatus.OK)
                    {
                        property.Value = inputPrompt.Value;
                    }
                }
            }
        }
        transaction.Commit();
    }
}
```
