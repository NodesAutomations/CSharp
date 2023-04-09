### References
- https://benkoshy.github.io/2018/01/24/what-is-a-jig.html
- https://cupocadnet.blogspot.com/2009/03/jigging-multiple-entities-with-drawjig.html

### Overview
- There are 2 kinds of jigs : entityJig and DrawJig
- The EntityJig only allows us to jig one entity at the time
- DrawJig Support multiple entity

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
