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
### Entity Jig to insert new Text
```csharp
 public static class Commands
    {
        [CommandMethod("QT")]
        static public void QuickText()
        {
            PromptStringOptions pso = new PromptStringOptions("\nEnter text string");
            pso.AllowSpaces = true;

            PromptResult pr = ActiveUtil.Editor.GetString(pso);
            if (pr.Status != PromptStatus.OK)
            {
                return;
            }

            using (Transaction transaction = ActiveUtil.TransactionManager.StartTransaction())
            {
                // Create the text object, set its normal and contents
                DBText txt = new DBText
                {
                    Normal = ActiveUtil.Editor.CurrentUserCoordinateSystem.CoordinateSystem3d.Zaxis,
                    TextString = pr.StringResult
                };

                // We'll add the text to the database before jigging
                // it - this allows alignment adjustments to be
                // reflected

                ActiveUtil.Database.GetCurrentSpace(OpenMode.ForWrite).AppendEntity(txt);
                transaction.AddNewlyCreatedDBObject(txt, true);

                // Create our jig
                TextPlacementJig pj = new TextPlacementJig(txt);

                // Loop as we run our jig, as we may have keywords
                PromptStatus stat = PromptStatus.Keyword;

                while (stat == PromptStatus.Keyword)
                {
                    PromptResult res = ActiveUtil.Editor.Drag(pj);
                    stat = res.Status;
                    if (stat != PromptStatus.OK && stat != PromptStatus.Keyword)
                    {
                        return;
                    }
                }
                transaction.Commit();
            }
        }
    }

    internal class TextPlacementJig : EntityJig
    {
        // Declare some internal state
        private Point3d _position;

        private double _angle, _txtSize;

        // Constructor
        public TextPlacementJig(Entity ent) : base(ent)
        {
            _angle = 0;
            _txtSize = 1;
        }

        protected override SamplerStatus Sampler(JigPrompts jp)
        {
            // We acquire a point but with keywords
            JigPromptPointOptions po = new JigPromptPointOptions("\nPosition of text");

            po.UserInputControls =
              (UserInputControls.Accept3dCoordinates |
                UserInputControls.NullResponseAccepted |
                UserInputControls.NoNegativeResponseAccepted |
                UserInputControls.GovernedByOrthoMode);

            po.SetMessageAndKeywords("\nSpecify position of text or [Bold/Italic/Larger/Smaller/Rotate90]: ", "Bold Italic Larger Smaller Rotate90");

            PromptPointResult ppr = jp.AcquirePoint(po);
            if (ppr.Status == PromptStatus.Keyword)
            {
                switch (ppr.StringResult)
                {
                    case "Bold":
                        {
                            // TODO
                            break;
                        }

                    case "Italic":
                        {
                            // TODO
                            break;
                        }

                    case "Larger":
                        {
                            // Multiple the text size by two
                            _txtSize *= 2;
                            break;
                        }

                    case "Smaller":
                        {
                            // Divide the text size by two
                            _txtSize /= 2;
                            break;
                        }

                    case "Rotate90":
                        {
                            // To rotate clockwise we subtract 90 degrees and
                            // then normalise the angle between 0 and 360
                            _angle -= Math.PI / 2;
                            while (_angle < Math.PI * 2)
                            {
                                _angle += Math.PI * 2;
                            }
                            break;
                        }
                }

                return SamplerStatus.OK;
            }
            else if (ppr.Status == PromptStatus.OK)
            {
                // Check if it has changed or not (reduces flicker)
                if (_position.DistanceTo(ppr.Value) < Tolerance.Global.EqualPoint)
                {
                    return SamplerStatus.NoChange;
                }

                _position = ppr.Value;

                return SamplerStatus.OK;
            }

            return SamplerStatus.Cancel;
        }

        protected override bool Update()
        {
            // Set properties on our text object
            DBText txt = (DBText)Entity;
            txt.Position = _position;
            txt.Height = _txtSize;
            txt.Rotation = _angle;
            return true;
        }
    }
```
