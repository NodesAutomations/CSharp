### References
- https://github.com/NodesAutomations/CSharp/issues/38
- https://spiderinnet1.typepad.com/blog/2012/03/autocad-net-entityjig-jig-line-by-start-and-end-points.html


### Overview
EntityJig is a class in AutoCAD .NET that provides on-screen editing capabilities for an application’s custom entities. It lets the user manipulate the graphical representation of a custom entity, and then applies the user’s input to an actual instance of the entity.

### Sample Code to Draw Line using Entity Jig
```csharp
    public static class Commands
    {
        [CommandMethod("Test")]
        public static void TestEntityJigger12_Method()
        {
            if (LineJigger.Jig())
            {
                ActiveUtil.Editor.WriteMessage("\nA line segment has been successfully jigged and added to the database.\n");
            }
            else
            {
                ActiveUtil.Editor.WriteMessage("\nIt failed to jig and add a line segment to the database.\n");
            }
        }
    }

    public class LineJigger : EntityJig
    {
        public Point3d mEndPoint = new Point3d();

        public LineJigger(Line ent) : base(ent)
        {
        }

        protected override bool Update()
        {
            (Entity as Line).EndPoint = mEndPoint;

            return true;
        }

        protected override SamplerStatus Sampler(JigPrompts prompts)
        {
            JigPromptPointOptions prOptions1 = new JigPromptPointOptions("\nNext point:");
            prOptions1.BasePoint = (Entity as Line).StartPoint;
            prOptions1.UseBasePoint = true;
            prOptions1.UserInputControls = UserInputControls.Accept3dCoordinates | UserInputControls.AnyBlankTerminatesInput
                | UserInputControls.GovernedByOrthoMode | UserInputControls.GovernedByUCSDetect | UserInputControls.UseBasePointElevation
                | UserInputControls.InitialBlankTerminatesInput | UserInputControls.NullResponseAccepted;
            PromptPointResult prResult1 = prompts.AcquirePoint(prOptions1);
            if (prResult1.Status == PromptStatus.Cancel) return SamplerStatus.Cancel;

            if (prResult1.Value.Equals(mEndPoint))
            {
                return SamplerStatus.NoChange;
            }
            else
            {
                mEndPoint = prResult1.Value;
                return SamplerStatus.OK;
            }
        }

        public static bool Jig()
        {
            try
            {
                Database db = HostApplicationServices.WorkingDatabase;

                PromptPointResult ppr = ActiveUtil.Editor.GetPoint("\nStart point");
                if (ppr.Status != PromptStatus.OK) return false;

                Point3d pt = ppr.Value;
                Line ent = new Line(pt, pt);
                ent.TransformBy(ActiveUtil.Editor.CurrentUserCoordinateSystem);
                LineJigger jigger = new LineJigger(ent);
                PromptResult pr = ActiveUtil.Editor.Drag(jigger);

                if (pr.Status == PromptStatus.OK)
                {
                    using (Transaction tr = db.TransactionManager.StartTransaction())
                    {
                        BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                        BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                        btr.AppendEntity(jigger.Entity);
                        tr.AddNewlyCreatedDBObject(jigger.Entity, true);
                        tr.Commit();
                    }
                }
                else
                {
                    ent.Dispose();
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
```
