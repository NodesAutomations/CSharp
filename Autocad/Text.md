### Create Single Line Text
```csharp
[CommandMethod("TEST", CommandFlags.UsePickSet)]
public void Test()
{
        using (Transaction acTrans = ActiveUtil.Document.TransactionManager.StartTransaction())
        {
            // Open the Block table for read
            BlockTable blockTable = acTrans.GetObject(ActiveUtil.Database.BlockTableId, OpenMode.ForRead) as BlockTable;

            // Open the Block table record Model space for write
            BlockTableRecord blockTableRecord = acTrans.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

            // Create a single-line text object
            using (DBText acText = new DBText())
            {
                acText.Position = new Point3d(2, 2, 0);
                acText.Height = 0.5;
                acText.TextString = "Hello, World.";

                blockTableRecord.AppendEntity(acText);
                acTrans.AddNewlyCreatedDBObject(acText, true);
            }

            // Save the changes and dispose of the transaction
            acTrans.Commit();
        }      
}
```
