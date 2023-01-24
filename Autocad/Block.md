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
### Code to create new block
```csharp
[CommandMethod("TEST")]
public void Test()
{
    var doc = ActiveUtil.Document;

    using (Transaction transaction=doc.TransactionManager.StartTransaction())
    {
        //Open block table
        BlockTable blockTable = transaction.GetObject(doc.Database.BlockTableId,OpenMode.ForRead) as BlockTable;

        //Check if Block already exist
        if (blockTable.Has("CircleBlock"))
        {
            transaction.Commit();
            transaction.Dispose();
            return;
        }

        //Create new block
        BlockTableRecord blocktableRecord = new BlockTableRecord();
        blocktableRecord.Name = "CircleBlock";

        Circle circle = new Circle();
        circle.Center=new Autodesk.AutoCAD.Geometry.Point3d(0,0,0);
        circle.Radius = 2;

        //Add geometry to block table record
        blocktableRecord.AppendEntity(circle);

        //Open Block table for Write and add block table record
        blockTable.UpgradeOpen();
        blockTable.Add(blocktableRecord);

        //Add Blocktable record to current transaction
        transaction.AddNewlyCreatedDBObject(blocktableRecord, true);

        transaction.Commit();
    }

}
```
### Code to Insert new block reference
```csharp
[CommandMethod("TEST")]
public void Test()
{
    var doc = ActiveUtil.Document;

    using (Transaction transaction = doc.TransactionManager.StartTransaction())
    {
        //Open block table
        BlockTable blockTable = transaction.GetObject(doc.Database.BlockTableId, OpenMode.ForRead) as BlockTable;

        //Create new Block if block didn't exist
        if (!blockTable.Has("CircleBlock")) 
        { //Create new block
            BlockTableRecord blocktableRecord = new BlockTableRecord();
            blocktableRecord.Name = "CircleBlock";

            Circle circle = new Circle();
            circle.Center = new Autodesk.AutoCAD.Geometry.Point3d(0, 0, 0);
            circle.Radius = 2;

            //Add geometry to block table record
            blocktableRecord.AppendEntity(circle);

            //Open Block table for Write and add block table record
            blockTable.UpgradeOpen();
            blockTable.Add(blocktableRecord);

            //Add Blocktable record to current transaction
            transaction.AddNewlyCreatedDBObject(blocktableRecord, true);
        }

        //Open Current Active space for writing
        BlockTableRecord currentActiveSpaceBlockTableRecord = transaction.GetObject(doc.Database.CurrentSpaceId ,OpenMode.ForWrite) as BlockTableRecord;

        //Get Access to CircleBlock
        BlockTableRecord blockTableRecord = transaction.GetObject(blockTable["CircleBlock"], OpenMode.ForRead) as BlockTableRecord;

        //Create new block reference using BlockTableRecord
        BlockReference blockReference = new BlockReference(new Autodesk.AutoCAD.Geometry.Point3d(0, 0, 0), blockTableRecord.ObjectId);

        //Add block reference to active space
        currentActiveSpaceBlockTableRecord.AppendEntity(blockReference);

        //Add blockReference to current transaction
        transaction.AddNewlyCreatedDBObject(blockReference,true);

        transaction.Commit();
    }
}
```
