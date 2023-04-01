### Reference
- https://github.com/NodesAutomations/CSharp/issues/48

### Sample Code to add count function to contex menu
```csharp

namespace CadApp
{
    public class Commands : IExtensionApplication
    {
        public void Initialize()
        {
            CountMenu.Attach();
        }

        public void Terminate()
        {
            CountMenu.Detach();
        }

        [CommandMethod("COUNT", CommandFlags.UsePickSet)]
        static public void CountSelection()
        {
            PromptSelectionResult psr = ActiveUtil.Editor.GetSelection();

            if (psr.Status == PromptStatus.OK)
            {
                ActiveUtil.Editor.WriteMessage($"\nSelected {psr.Value.Count} entities.");
            }
        }

        [CommandMethod("Test")]
        public void Test()
        {
            try
            {
                ActiveUtil.Editor.WriteMessage("Hey this works");
            }
            catch (System.Exception ex)
            {
                Application.ShowAlertDialog($"Something went wrong error:{ex.Message}");
            }
        }
    }

    public class CountMenu
    {
        private static ContextMenuExtension cme;

        public static void Attach()
        {
            MenuItem mi = new MenuItem("Count");
            mi.Click += new EventHandler(OnCount);

            cme = new ContextMenuExtension();
            cme.MenuItems.Add(mi);

            RXClass rxc = Entity.GetClass(typeof(Entity));

            Application.AddObjectContextMenuExtension(rxc, cme);
        }

        public static void Detach()
        {
            RXClass rxc = Entity.GetClass(typeof(Entity));
            Application.RemoveObjectContextMenuExtension(rxc, cme);
        }

        private static void OnCount(Object o, EventArgs e)
        {
            ActiveUtil.Document.SendStringToExecute("_.COUNT ", true, false, false);
        }
    }
}
```
