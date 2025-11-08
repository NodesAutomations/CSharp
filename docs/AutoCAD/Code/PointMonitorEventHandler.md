### Sample code for PointMonitorEventHandler
```csharp
public static class Commands
    {
        [CommandMethod("AddPointMonitor")]
        public static void AddPointMonitor()
        {
            ActiveUtil.Editor.PointMonitor += new PointMonitorEventHandler(MyPointMonitor);
        }

        [CommandMethod("RemovePointMonitor")]
        public static void RemovePointMonitor()
        {
            ActiveUtil.Editor.PointMonitor -= new PointMonitorEventHandler(MyPointMonitor);
        }

        public static void MyPointMonitor(object sender, PointMonitorEventArgs e)
        {
            if (e.Context == null)
            {
                return;
            }

            FullSubentityPath[] fullEntPath = e.Context.GetPickedEntities();

            if (fullEntPath.Length > 0)
            {
                try
                {
                    using (Transaction tr = ActiveUtil.TransactionManager.StartTransaction())
                    {
                        Entity ent = fullEntPath.First().GetObjectIds().First().GetObject<Entity>();
                        if (ent.) { }
                        //e.AppendToolTipText("\n The tool tip is working! yaaay! The Entity is a " + ent.GetType().ToString());
                        ActiveUtil.Editor.WriteMessage("\n" + ent.GetType().ToString());
                        tr.Commit();
                    }
                }
                catch (System.Exception ex)
                {
                    ActiveUtil.Editor.WriteLine(ex.ToString());
                }
            }
        }
    }
```
