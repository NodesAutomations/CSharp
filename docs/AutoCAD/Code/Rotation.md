### Vector
- A vector is a quantity that has both magnitude and direction. It is represented by an arrow whose length represents the magnitude of the vector and whose direction represents the direction of the vector1.
### Normal Vector
- A normal vector is a vector that is perpendicular or orthogonal to another vector or plane. If we talk about the technical aspect of the matter, there are an infinite number of normal vectors to any given vector as the only standard for any vector to be regarded as a normal vector is that they are inclined at an angle of 90° to the vector2.

### Code to Rotate any entity along z axis passing through given point
```csharp
[CommandMethod("DrawRectangle")]
public static void DrawRectangle()
{
    using (Transaction tr = ActiveUtil.TransactionManager.StartTransaction())
    {
        Polyline pline = new Polyline();
        pline.AddVertexAt(0, new Point2d(0, 0), 0, 0, 0);
        pline.AddVertexAt(1, new Point2d(10, 0), 0, 0, 0);
        pline.AddVertexAt(2, new Point2d(10, 5), 0, 0, 0);
        pline.AddVertexAt(3, new Point2d(0, 5), 0, 0, 0);
        pline.Closed = true;

        //vector representing z axis
        Vector3d normal = new Vector3d(0, 0, 1);

        //here entity will get rotated around z axis passing through chosen point
        pline.TransformBy(Matrix3d.Rotation(30 * (Math.PI / 180), normal,new Point3d(0,0,0)));

        ActiveUtil.Database.GetModelSpace(OpenMode.ForWrite).AppendEntity(pline);
        tr.AddNewlyCreatedDBObject(pline, true);

        tr.Commit();
    }
}
```
