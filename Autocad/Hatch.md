### Sample Code to Draw hatch
```csharp
[CommandMethod("Test", CommandFlags.UsePickSet)]
public static void Test()
{
    Document doc = Application.DocumentManager.MdiActiveDocument;
    Database db = doc.Database;

    using (Transaction tr = db.TransactionManager.StartTransaction())
    {
        BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
        BlockTableRecord btr = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

        // Define the center point, major axis, and minor axis
        Point3d centerBottom = new Point3d(0, 0, 0);
        Point3d centerTop = new Point3d(0, 1000, 0);
        Vector3d majorAxis = new Vector3d(500, 0, 0);
        double minorAxisLength = 300;
        double radiusRatio = minorAxisLength / majorAxis.Length;

        // Create the ellipse at bottom
        Ellipse ellipseBottom = new Ellipse(centerBottom, Vector3d.ZAxis, majorAxis, radiusRatio, Math.PI, 2 * Math.PI);
        btr.AppendEntity(ellipseBottom);
        tr.AddNewlyCreatedDBObject(ellipseBottom, true);

        // Create the ellipse at top
        Ellipse ellipseTop = new Ellipse(centerTop, Vector3d.ZAxis, majorAxis, radiusRatio, Math.PI, 2 * Math.PI);
        btr.AppendEntity(ellipseTop);
        tr.AddNewlyCreatedDBObject(ellipseTop, true);

        Line leftLine = new Line(ellipseTop.StartPoint, ellipseBottom.StartPoint);
        btr.AppendEntity(leftLine);
        tr.AddNewlyCreatedDBObject(leftLine, true);

        Line rightLine = new Line(ellipseTop.EndPoint, ellipseBottom.EndPoint);
        btr.AppendEntity(rightLine);
        tr.AddNewlyCreatedDBObject(rightLine, true);

        ObjectIdCollection acObjIdColl = new ObjectIdCollection();
        acObjIdColl.Add(ellipseBottom.ObjectId);
        acObjIdColl.Add(leftLine.ObjectId);
        acObjIdColl.Add(ellipseTop.ObjectId);
        acObjIdColl.Add(rightLine.ObjectId);

        // Create the hatch object and append it to the block table record
        using (Hatch acHatch = new Hatch())
        {
            btr.AppendEntity(acHatch);
            tr.AddNewlyCreatedDBObject(acHatch, true);

            // Set the properties of the hatch object
            // Associative must be set after the hatch object is appended to the 
            // block table record and before AppendLoop
            acHatch.SetHatchPattern(HatchPatternType.PreDefined, "ANSI31");
            acHatch.Associative = true;
            acHatch.PatternScale = 500;
            acHatch.AppendLoop(HatchLoopTypes.Outermost, acObjIdColl);
            acHatch.EvaluateHatch(true);
        }
        // Commit the transaction
        tr.Commit();
    }
}
```