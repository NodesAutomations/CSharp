### Moving Selected Polylines with DrawJig
- This is equivalent of Move command in autocad
- To Inherit DrawJig you have to override 2 Method : Sampler and WorldDraw
- Sampler simply tell the Jig to sample the needed data, and check if anything needs a redraw
- WorldDraw you can then update the enities so that the changes detected in the sampler method are shown on screen
- Here in below code in Sample method we are looking for the current mouse position, and we will remember the difference of the current postition with the new postion. we are also reterning samper states matching the outcome of the current prompt.
- In worldDraw function, we can now edit the polylines with the calculated vector and draw these changes to the screen.

```csharp
public static class Commands
{
    [CommandMethod("Test", CommandFlags.UsePickSet)]
    public static void Test()
    {
        try
        {
            using (Transaction transaction = ActiveUtil.TransactionManager.StartTransaction())
            {
                PromptSelectionOptions promptSelection = new PromptSelectionOptions();
                PromptSelectionResult result = ActiveUtil.Editor.GetSelection(promptSelection);

                if (result.Status != PromptStatus.OK)
                {
                    return;
                }
                // Iterate results to find polylines (I know filters are smarter..)
                List<Polyline> polylines = new List<Polyline>();

                foreach (ObjectId objectId in result.Value.GetObjectIds())
                {
                    if (objectId.IsValidObjectType(typeof(Polyline)))
                    {
                        var polyline = objectId.GetObject<Polyline>(OpenMode.ForWrite);
                        polylines.Add(polyline);
                    }
                }

                // prompt refernce point
                PromptPointOptions promptPoint = new PromptPointOptions("select reference point");
                PromptPointResult promptPointResult = ActiveUtil.Editor.GetPoint(promptPoint);

                if (promptPointResult.Status != PromptStatus.OK)
                {
                    return;
                }

                // Jig It.
                SimpleGeometryJig jig = new SimpleGeometryJig(polylines, promptPointResult.Value);
                PromptResult res = ActiveUtil.Editor.Drag(jig);

                transaction.Commit();
            }
        }
        catch (System.Exception ex)
        {
            Application.ShowAlertDialog($"Something went wrong error:{ex.Message}");
        }
    }
}

public class SimpleGeometryJig : DrawJig
{
    private List<Polyline> _polylines;
    private Point3d _currentPosition;
    private Vector2d _currentVector;

    public SimpleGeometryJig(List<Polyline> polylines, Point3d referencePoint)
    {
        _polylines = polylines;
        _currentPosition = referencePoint;
        _currentVector = new Vector2d(0, 0);
    }

    protected override SamplerStatus Sampler(JigPrompts prompts)
    {
        JigPromptPointOptions jigOpt = new JigPromptPointOptions("select insertion point");
        jigOpt.UserInputControls = UserInputControls.Accept3dCoordinates;

        PromptPointResult res = prompts.AcquirePoint(jigOpt);

        if (res.Status != PromptStatus.OK)
        {
            return SamplerStatus.Cancel;
        }
        if (res.Value.IsEqualTo(_currentPosition, new Tolerance(0.1, 0.1)))
        {
            return SamplerStatus.NoChange;
        }
        Vector3d v3d = _currentPosition.GetVectorTo(res.Value);
        _currentVector = new Vector2d(v3d.X, v3d.Y);

        _currentPosition = res.Value;
        return SamplerStatus.OK;
    }

    protected override bool WorldDraw(Autodesk.AutoCAD.GraphicsInterface.WorldDraw draw)
    {
        try
        {
            foreach (var pl in _polylines)
            {
                for (int i = 0; i < pl.NumberOfVertices; i++)
                {
                    pl.SetPointAt(i, pl.GetPoint2dAt(i).Add(_currentVector));
                }
                draw.Geometry.Draw(pl);
            }
        }
        catch (System.Exception)
        {
            return false;
        }
        return true;
    }
}
```
### Code to Insert Two Circles with DrawJig
```csharp
public static class Commands
{
[CommandMethod("Test", CommandFlags.UsePickSet)]
public static void Test()
{
    try
    {
        using (Transaction transaction = ActiveUtil.TransactionManager.StartTransaction())
        {
            //Code to draw two circles based on base point
            var basePoint = new Geometry.Entities.Point2D();
            var circle1 = new CadCircle(basePoint, 10);
            circle1.Append();

            var circle2 = new CadCircle(basePoint, 20);
            circle2.Append();

            var circles = new List<CadCircle>
            {
                circle1,
                circle2
            };

            // Jig It.
            SimpleGeometryJig jig = new SimpleGeometryJig(circles, basePoint);
            PromptResult res = ActiveUtil.Editor.Drag(jig);

            //code to adjust it's position
            transaction.Commit();
        }
    }
    catch (System.Exception ex)
    {
        Application.ShowAlertDialog($"Something went wrong error:{ex.Message}");
    }
}
}

public class SimpleGeometryJig : DrawJig
{
private List<CadCircle> _circles;
private Point2D _basePoint;
private Point3d _currentPosition;

public SimpleGeometryJig(List<CadCircle> circles, Point2D basePoint)
{
    _circles = circles;
    _currentPosition = new Point3d(basePoint.X, basePoint.Y, 0);
}

protected override SamplerStatus Sampler(JigPrompts prompts)
{
    JigPromptPointOptions jigOpt = new JigPromptPointOptions("select insertion point");
    jigOpt.UserInputControls = UserInputControls.Accept3dCoordinates;

    PromptPointResult res = prompts.AcquirePoint(jigOpt);
    if (res.Status != PromptStatus.OK)
    {
        return SamplerStatus.Cancel;
    }
    if (res.Value.IsEqualTo(_currentPosition, new Tolerance(0.1, 0.1)))
    {
        return SamplerStatus.NoChange;
    }
    _currentPosition = res.Value;
    return SamplerStatus.OK;
}

protected override bool WorldDraw(WorldDraw draw)
{
    try
    {
        foreach (var circle in _circles)
        {
            circle.Circle.Center = _currentPosition;
            draw.Geometry.Draw(circle.Entity);
        }
        return true;
    }
    catch (System.Exception)
    {
        return false;
    }
}
}
```
### Code to Create Rectangle using Two Corner Point with DrawJig
```csharp
public class Commands
{
    [CommandMethod("Test", CommandFlags.UsePickSet)]
    public static void Test()
    {
        PromptPointResult pr = ActiveUtil.Editor.GetPoint("\nSelect First Corner of Rectangle:");
        if (pr.Status != PromptStatus.OK)
        {
            return;
        }

        var jigger = new RectangleDrawJig(pr.Value);
        ActiveUtil.Editor.Drag(jigger);

        using (Transaction transaction = ActiveUtil.TransactionManager.StartTransaction())
        {
            Polyline ent = new Polyline();
            ent.SetDatabaseDefaults();
            var cornerPoints = jigger.GetCornerPoints();
            var counter = new Counter(0);
            foreach (var point in cornerPoints)
            {
                ent.AddVertexAt(counter.CreateId(), new Point2d(point.X, point.Y), 0, 0, 0);
            }
            ent.Closed = true;
            ActiveUtil.Database.GetModelSpace(OpenMode.ForWrite).AppendEntity(ent);
            transaction.AddNewlyCreatedDBObject(ent, true);
            transaction.Commit();
        }
    }
}

public class RectangleDrawJig : DrawJig
{
    private Point3d _CornerPoint1;
    private Point3d _CornerPoint2;

    public RectangleDrawJig(Point3d basePt)
    {
        _CornerPoint1 = basePt;
    }

    public List<Point3d> GetCornerPoints()
    {
        var points = new List<Point3d>();
        points.Add(_CornerPoint1);
        points.Add(new Point3d(_CornerPoint1.X, _CornerPoint2.Y, 0));
        points.Add(_CornerPoint2);
        points.Add(new Point3d(_CornerPoint2.X, _CornerPoint1.Y, 0));
        return points;
    }

    protected override SamplerStatus Sampler(JigPrompts prompts)
    {
        JigPromptPointOptions prOptions2 = new JigPromptPointOptions("\nCorner2:");
        prOptions2.UseBasePoint = false;

        PromptPointResult prResult2 = prompts.AcquirePoint(prOptions2);
        if (prResult2.Status == PromptStatus.Cancel || prResult2.Status == PromptStatus.Error)
        {
            return SamplerStatus.Cancel;
        }

        Point3d tmpPt = prResult2.Value.TransformBy(ActiveUtil.Editor.CurrentUserCoordinateSystem.Inverse());
        if (!_CornerPoint2.IsEqualTo(tmpPt, new Tolerance(10e-10, 10e-10)))
        {
            _CornerPoint2 = tmpPt;
            return SamplerStatus.OK;
        }
        else
        {
            return SamplerStatus.NoChange;
        }
    }

    protected override bool WorldDraw(Autodesk.AutoCAD.GraphicsInterface.WorldDraw draw)
    {
        draw.Geometry?.Polygon(new Point3dCollection(GetCornerPoints().ToArray()));
        return true;
    }
}
```
### Sample code to draw rectangle with two corner point or one corner point + rotation angle
```csharp
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using static System.Math;
using AcAp = Autodesk.AutoCAD.ApplicationServices.Core.Application;
using AcGi = Autodesk.AutoCAD.GraphicsInterface;

namespace CADHelperTest
{
    public class Commands
    {
        [CommandMethod("TEST")]
        public void Test()
        {
            var doc = AcAp.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;
            var ppr = ed.GetPoint("\nSpecify first corner point: ");
            if (ppr.Status != PromptStatus.OK)
                return;
            var pt = ppr.Value;
            using (var tr = db.TransactionManager.StartTransaction())
            using (var pline = new Polyline(4))
            {
                pline.AddVertexAt(0, new Point2d(pt.X, pt.Y), 0.0, 0.0, 0.0);
                pline.AddVertexAt(1, new Point2d(pt.X + 1.0, pt.Y), 0.0, 0.0, 0.0);
                pline.AddVertexAt(2, new Point2d(pt.X + 1.0, pt.Y + 1.0), 0.0, 0.0, 0.0);
                pline.AddVertexAt(3, new Point2d(pt.X, pt.Y + 1.0), 0.0, 0.0, 0.0);
                pline.Closed = true;
                pline.Elevation = pt.Z;
                var ucs = ed.CurrentUserCoordinateSystem;
                pline.TransformBy(ucs);

                // create a RectangleJig
                var rectJig = new RectangleJig(pline, 0.0);

                // Loop while the user specify other corner or cancel
                while (true)
                {
                    var pr = ed.Drag(rectJig);
                    // Other corner is specified
                    if (pr.Status == PromptStatus.OK)
                    {
                        var curSpace = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);
                        curSpace.AppendEntity(pline);
                        tr.AddNewlyCreatedDBObject(pline, true);
                        break;
                    }
                    // Rotation option
                    if (pr.Status == PromptStatus.Keyword)
                    {
                        // use a RotationJig to get the rectangle rotation
                        var rotJig = new RotationJig(pline, pline.GetPoint3dAt(0), pline.Normal);
                        var result = ed.Drag(rotJig);
                        if (result.Status == PromptStatus.OK)
                            rectJig = new RectangleJig(pline, rotJig.Rotation);
                        else
                            break;
                    }
                    // Cancel
                    else
                        break;
                }
                tr.Commit();
            }
        }
    }

    public struct Rectangle
    {
        public Point2d Point0 { get; }
        public Point2d Point1 { get; }
        public Point2d Point2 { get; }
        public Point2d Point3 { get; }

        public Rectangle(Point2d firstCorner, Point2d oppositeCorner, double rotation)
        {
            Vector2d u = new Vector2d(Cos(rotation), Sin(rotation));
            Vector2d v = new Vector2d(-Sin(rotation), Cos(rotation));
            Vector2d diag = firstCorner.GetVectorTo(oppositeCorner);
            Point0 = firstCorner;
            Point1 = firstCorner + u * u.DotProduct(diag);
            Point2 = oppositeCorner;
            Point3 = firstCorner + v * v.DotProduct(diag);
        }
    }

    public class RectangleJig : EntityJig
    {
        private Polyline pline;
        double ucsRot, rotation;
        Plane plane;
        Point3d dragPt, basePt;
        private Point2d pt2D;
        Editor ed;
        CoordinateSystem3d ucs;

        public RectangleJig(Polyline pline, double rotation) : base(pline)
        {
            this.pline = pline;
            this.rotation = rotation;
            plane = new Plane(Point3d.Origin, pline.Normal);
            basePt = pline.GetPoint3dAt(0);
            pt2D = pline.GetPoint2dAt(0);
            ed = AcAp.DocumentManager.MdiActiveDocument.Editor;
            ucs = ed.CurrentUserCoordinateSystem.CoordinateSystem3d;
            Matrix3d mat = Matrix3d.WorldToPlane(plane);
            ucsRot = Vector3d.XAxis.GetAngleTo(ucs.Xaxis.TransformBy(mat), Vector3d.ZAxis);
        }

        protected override SamplerStatus Sampler(JigPrompts prompts)
        {
            var msg = "\nSpecify other corner point or [Rotation]: ";
            var options = new JigPromptPointOptions(msg, "Rotation");
            options.AppendKeywordsToMessage = true;
            options.UseBasePoint = true;
            options.BasePoint = basePt;
            options.UserInputControls =
                UserInputControls.Accept3dCoordinates |
                UserInputControls.UseBasePointElevation;
            PromptPointResult result = prompts.AcquirePoint(options);
            if (result.Status == PromptStatus.Keyword)
            {
                pline.TransformBy(Matrix3d.Rotation(-rotation, pline.Normal, basePt));
                return SamplerStatus.OK;
            }
            if (result.Value.IsEqualTo(dragPt))
                return SamplerStatus.NoChange;

            dragPt = result.Value;
            return SamplerStatus.OK;
        }

        protected override bool Update()
        {
            var rectangle = new Rectangle(pt2D, dragPt.Convert2d(plane), rotation + ucsRot);
            pline.SetPointAt(1, rectangle.Point1);
            pline.SetPointAt(2, rectangle.Point2);
            pline.SetPointAt(3, rectangle.Point3);
            return true;
        }
    }

    public class RotationJig : DrawJig
    {
        private Entity entity;
        double rotation;
        Point3d basePoint;
        Vector3d normal;

        public double Rotation => rotation;

        public RotationJig(Entity entity, Point3d basePoint, Vector3d normal)
        {
            this.entity = entity;
            this.basePoint = basePoint;
            this.normal = normal;
        }

        protected override SamplerStatus Sampler(JigPrompts prompts)
        {
            var options = new JigPromptAngleOptions("\nSpecify rotation angle: ");
            options.BasePoint = basePoint;
            options.UseBasePoint = true;
            options.Cursor = CursorType.RubberBand;
            options.UserInputControls =
                UserInputControls.Accept3dCoordinates |
                UserInputControls.UseBasePointElevation;
            var result = prompts.AcquireAngle(options);
            if (result.Value == rotation)
                return SamplerStatus.NoChange;
            rotation = result.Value;
            return SamplerStatus.OK;
        }

        protected override bool WorldDraw(AcGi.WorldDraw draw)
        {
            AcGi.WorldGeometry geom = draw.Geometry;
            if (geom != null)
            {
                geom.PushModelTransform(Matrix3d.Rotation(rotation, normal, basePoint));
                geom.Draw(entity);
                geom.PopModelTransform();
            }
            return true;
        }
    }
}
```
