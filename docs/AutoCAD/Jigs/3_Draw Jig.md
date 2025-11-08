### References

### What it is?
- Draw Jig allows you to create jig for multiple entities

### How it work?
- Draw Jig Class is AutoCAD inbuit abstract class, we have to write our own code to create jig using this class
- Similar to Entity Jig, draw jig also contain 3 parts
  - construtor
  - Sampler Method contain code to get jig input from user and return SampleStatus as output
  - WorldDraw method update our Entity if successful results are given by user in Sampler Method

### Sample Code

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

                var circles = new List<CadCircle> { circle1, circle2 };

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