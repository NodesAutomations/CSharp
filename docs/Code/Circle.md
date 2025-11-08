### Code to Draw simple Circle
```csharp
[CommandMethod("Test")]
        public static void Test()
        {
            try
            {
                using (Transaction transaction=ActiveUtil.TransactionManager.StartTransaction())
                {

                    BlockTable blockTable = (BlockTable)transaction.GetObject(ActiveUtil.Database.BlockTableId, OpenMode.ForRead);
                    BlockTableRecord modelSpaceBlockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                    // Define the circle's center point and radius
                    Point3d center = new Point3d(0, 0, 0);
                    double radius = 5;

                    // Create the circle
                    Circle circle = new Circle(center, Vector3d.ZAxis, radius);
                    modelSpaceBlockTableRecord.AppendEntity(circle);
                    transaction.AddNewlyCreatedDBObject(circle, true);

                    transaction.Commit();
                }
            }
            catch (System.Exception ex)
            {
                Application.ShowAlertDialog($"Something went wrong error:{ex.Message}");
            }
        }
```
