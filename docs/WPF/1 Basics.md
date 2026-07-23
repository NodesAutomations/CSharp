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

### To Add WPF Form to existing project 
- Add this references
```
<Reference Include="System.Xaml">
  <RequiredTargetFramework>4.0</RequiredTargetFramework>
</Reference>
<Reference Include="PresentationCore" />
<Reference Include="PresentationFramework" />
<Reference Include="WindowsBase" />
```    

### XML Basics

#### General Rules
- XML is case sensitive, so `<Button>` and `<button>` are different tags.
- All tags must be closed, either with a closing tag or self-closing tag. for example, `<Button></Button>` and `<Button />` are valid, but `<Button>` is not valid.
- All attributes must be quoted, either with single or double quotes. For example, `<Button Content="Click Me" />` is valid, but `<Button Content=Click Me />` is not valid.
- XML have only one root tag, so you can have only one top level tag. For example, `<Button /><TextBlock />` is not valid, but `<StackPanel><Button /><TextBlock /></StackPanel>` is valid.
- XML is hierarchical, so you can have nested tags. For example, `<Button><TextBlock Text="Click Me" /></Button>` is valid 

#### Close tag without children
- For tag without children you can use either of the following syntax
```xml
<!-- Open and Close tag -->
<Button Content="Click Me"></Button>
```
```xml
<!-- Self Closing tag -->
<Button Content="Click Me" />
```
- This is more readable and preferred way to write XML tag without children

#### Close tag with children
- You must follow this syntax to close tag with children
```xml
<Button>
    <Button.Content>
        Click Me
    </Button.Content>
</Button>
```

#### Namespaces matter in XML
- WPF uses XML namespaces to differentiate between different types of controls and elements. For example, the `Button` control is defined in the `http://schemas.microsoft.com/winfx/2006/xaml/presentation` namespace, while the `TextBlock` control is defined in the `http://schemas.microsoft.com/winfx/2006/xaml/presentation` namespace.
- If namespaces are wrong, controls may not be recognized.
