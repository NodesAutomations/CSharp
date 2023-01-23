### Code to get user input with custom autocad graphics
```csharp
    public class Main
    {
        [CommandMethod("TEST")]
        public void Test()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;

            var options = new PromptEntityOptions("\nSelect line: ");
            options.SetRejectMessage("\nSelected entity is not a line.");
            options.AddAllowedClass(typeof(Line), true);
            var result = ed.GetEntity(options);
            if (result.Status != PromptStatus.OK)
                return;

            using (var tr = db.TransactionManager.StartTransaction())
            {
                var axis = (Line)tr.GetObject(result.ObjectId, OpenMode.ForRead);
                using (var perp = new Line(Point3d.Origin, axis.GetClosestPointTo(Point3d.Origin, true)))
                {
                    var jig = new PerpendicularJig(perp, axis, ed);
                    var pr = ed.Drag(jig);
                    if (pr.Status == PromptStatus.OK)
                    {
                        var curSpace = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);
                        curSpace.AppendEntity(perp);
                        tr.AddNewlyCreatedDBObject(perp, true);
                    }
                }
                tr.Commit();
            }
        }
    }

    internal class PerpendicularJig : EntityJig
    {
        private Point3d dragPoint;
        Line axis, perp;
        private Vector3d axisDir;
        Editor ed;

        public PerpendicularJig(Line perp, Line axis, Editor ed) : base(perp)
        {
            this.axis = axis;
            this.perp = perp;
            axisDir = axis.StartPoint.GetVectorTo(axis.EndPoint);
            this.ed = ed;
        }

        protected override SamplerStatus Sampler(JigPrompts prompts)
        {
            var options = new JigPromptPointOptions("\nSpecify a point: ");
            options.UserInputControls = UserInputControls.Accept3dCoordinates;
            var result = prompts.AcquirePoint(options);
            if (result.Value.IsEqualTo(dragPoint))
                return SamplerStatus.NoChange;
            dragPoint = result.Value;
            return SamplerStatus.OK;
        }

        protected override bool Update()
        {
            using (var view = ed.GetCurrentView())
            {
                var viewDir = view.ViewDirection;
                perp.StartPoint = dragPoint;
                perp.EndPoint = axis.GetClosestPointTo(dragPoint, viewDir, true);
                var xform = Matrix3d.WorldToPlane(viewDir);
                var v1 = axisDir.ProjectTo(viewDir, viewDir);
                var v2 = perp.EndPoint.GetVectorTo(dragPoint).ProjectTo(viewDir, viewDir);
                perp.ColorIndex = v1.GetAngleTo(v2, viewDir) < Math.PI ? 1 : 3;
            }
            return true;
        }
    }
```
