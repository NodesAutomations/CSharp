using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

namespace CustomDialogs
{
    public class Commands
    {
        private TypeViewerForm tvf;

        public Commands()
        {
            tvf = new TypeViewerForm();
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            ed.PointMonitor += new PointMonitorEventHandler(OnMonitorPoint);
        }
        
        ~Commands()
        {
            try
            {
                tvf.Dispose();
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Editor ed = doc.Editor;
                ed.PointMonitor -= new PointMonitorEventHandler(OnMonitorPoint);
            }
            catch (System.Exception)
            {
                // The editor may no longer
                // be available on unload
            }
        }

        private void OnMonitorPoint(object sender, PointMonitorEventArgs e)
        {
            FullSubentityPath[] paths = e.Context.GetPickedEntities();

            if (paths.Length <= 0)
            {
                tvf.SetObjectId(ObjectId.Null);
                return;
            };

            ObjectId[] objs = paths[0].GetObjectIds();

            if (objs.Length <= 0)
            {
                tvf.SetObjectId(ObjectId.Null);
                return;
            };

            // Set the "selected" object to be the last in the list
            tvf.SetObjectId(objs[objs.Length - 1]);
        }

        [CommandMethod("vt", CommandFlags.UsePickSet)]
        public void ViewType()
        {
            Application.ShowModelessDialog(null, tvf, false);
        }
    }
}