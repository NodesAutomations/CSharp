### Code to Add Linear Dimension
```csharp
using (Transaction transaction = ActiveUtil.TransactionManager.StartTransaction())
{
    // Open the current space for write
    BlockTableRecord currentSpaceBlockTableRecord = (BlockTableRecord)transaction.GetObject(ActiveUtil.Database.CurrentSpaceId, OpenMode.ForWrite);

    // Create a new dimension entity
    RotatedDimension dimensionline = new RotatedDimension
    {
        XLine1Point = new Point3d(0, 0, 0),
        XLine2Point = new Point3d(5000, 0, 0),
        TextPosition = new Point3d(2500, 500, 0),
        Rotation = 0,
        DimensionStyle = ActiveUtil.Database.Dimstyle
    };
    // Add the dimension to the block table record and the transaction
    currentSpaceBlockTableRecord.AppendEntity(dimensionline);
    transaction.AddNewlyCreatedDBObject(dimensionline, true);

    // Commit the transaction
    transaction.Commit();
}
```

### Code to Add Align Dimension 
```csharp
[CommandMethod("Test")]
public void Test()
{
    using (Transaction transaction = ActiveUtil.TransactionManager.StartTransaction())
    {
        // Open the current space for write
        BlockTableRecord currentSpaceBlockTableRecord = (BlockTableRecord)transaction.GetObject(ActiveUtil.Database.CurrentSpaceId, OpenMode.ForWrite);

        // Create a new dimension entity
        AlignedDimension dimensionline = new AlignedDimension
        {
            XLine1Point = new Point3d(0, 0, 0),
            XLine2Point = new Point3d(5000, 0, 0),
            DimLinePoint = new Point3d(2500, 250, 0),
            TextPosition = new Point3d(2500, 500, 0)
        };
        // Add the dimension to the block table record and the transaction
        currentSpaceBlockTableRecord.AppendEntity(dimensionline);
        transaction.AddNewlyCreatedDBObject(dimensionline, true);

        // Commit the transaction
        transaction.Commit();
    }
}
```
