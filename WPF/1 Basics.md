### What is it?
- It's a platform to create UI similar to Windows Forms.
- WPF is built into the .NET framework, so you don't need to install anything to use it or develop applications for it.
- WPF uses XML language to build user forms.
- WPF works out of the box using Visual Studio, so you don't need any additional setup.

### Advantages Compared to Windows Forms
- It's the latest technology which is already mature and in active development.
- UI is created using XML language, so it's more LLM & Git friendly.
- More functionality compared to Windows Forms.
- Reusable components.


### Calling WPF form from console APP
```csharp
using System;
using System.Windows;

namespace ConsoleApp
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // Initialize WPF Application
            var app = new Application();

            var frm = new AboutForm();
            frm.ShowDialog();
        }
    }
}
```
