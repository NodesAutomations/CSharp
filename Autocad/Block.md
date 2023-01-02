### Code to Loop through each block
```csharp
[CommandMethod(nameof(GetListOfBlocks))]
        public void GetListOfBlocks()
        {
            var blocks = new List<string>();
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database database = doc.Database;
            Editor edt = doc.Editor;

            using (var transaction = doc.TransactionManager.StartTransaction())
            {
                var blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, OpenMode.ForRead);

                //Loop Through Each BlockTable Record
                //The Layout object contains the plot settings and the visual properties of the layout as it appears in the AutoCAD user interface
                foreach (var id in blockTable)
                {
                    var blockTableRecord = (BlockTableRecord)transaction.GetObject(id,OpenMode.ForRead);

                    //Check if Block is not Layout
                    if (blockTableRecord.IsLayout==false)
                    {
                        //Ignore Anonymous blocks
                        //Anonymous in AutoCAD basically means unnamed, so an anonymous block is a block without a name. In reality it does have a name, it just does not make much sense.
                        if (blockTableRecord.IsAnonymous==false)
                        {
                            edt.WriteMessage($"\n{blockTableRecord.Name}");
                            blocks.Add(blockTableRecord.Name);
                        }
                    }
                }

                transaction.Commit();
            }

            blocks.Sort();

        }
```

### Code to Get Atrributes from Block
reference : https://forums.autodesk.com/t5/net/get-attribute-tags-from-block/m-p/8596731#M61531
```csharp
BlockReference br = acTrans.GetObject(acSSObj.ObjectId, OpenMode.ForRead) as BlockReference;
AttributeCollection attCol = br.AttributeCollection;
foreach (ObjectId attId in attCol)
{
    AttributeReference attRef = (AttributeReference)acTrans.GetObject(attId, OpenMode.ForRead);

    string tag = attRef.Tag;
    string value = attRef.TextString;
}
```
