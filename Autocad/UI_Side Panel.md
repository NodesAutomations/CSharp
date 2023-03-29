
### Basic Overview
- Create custom windows User Control, Add any windows form control you like on it
- Use Below code to initialize palette set

```csharp
public class Commands
    {
        internal static PaletteSet ps = new PaletteSet("My First Palette");

        [CommandMethod("Test")]
        public void Test()
        {
            try
            {
                //To Avoid Creating Duplicate Palettes
                if (ps.Count > 0)
                {
                    ps.Visible = true;
                    return;
                }

                var container = new Containner1();
                ps.Add("Test", container);
                ps.Visible = true;
            }
            catch (System.Exception ex)
            {
                Application.ShowAlertDialog($"Something went wrong error:{ex.Message}");
            }
        }
    }
```
### References
- https://github.com/NodesAutomations/CSharp/issues/51
