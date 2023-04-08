### Copy item in same drawing
```csharp
[CommandMethod("Test", CommandFlags.UsePickSet)]
public static void Test()
{
    try
    {
        using (Transaction acTrans = ActiveUtil.TransactionManager.StartTransaction())
        {
            // Create a circle that is at 2,3 with a radius of 4.25
            Circle acCirc = new Circle();
            acCirc.SetDatabaseDefaults();
            acCirc.Center = new Point3d(2, 3, 0);
            acCirc.Radius = 4.25;
            // Add the new object to the block table record and the transaction
            ActiveUtil.Database.GetModelSpace(OpenMode.ForWrite).AppendEntity(acCirc);
            acTrans.AddNewlyCreatedDBObject(acCirc, true);


            // Create a copy of the circle and change its radius
            Circle acCircClone = acCirc.Clone() as Circle;
            acCircClone.Radius = 1;
            // Add the cloned circle
            ActiveUtil.Database.GetModelSpace(OpenMode.ForWrite).AppendEntity(acCircClone);
            acTrans.AddNewlyCreatedDBObject(acCircClone, true);
            // Save the new object to the database
            acTrans.Commit();
        }
    }
    catch (System.Exception ex)
    {
        Application.ShowAlertDialog($"Something went wrong error:{ex.Message}");
    }
}
```
