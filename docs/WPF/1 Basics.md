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


### Sample WPF Form
```xml
<Window x:Class="WpfApp.MainWindow"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:local="clr-namespace:WpfApp" mc:Ignorable="d" Title="MainWindow" Height="450" Width="800">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="200"/>
        </Grid.ColumnDefinitions>
        <!-- Add Stack Panel in first column -->
        <StackPanel Grid.Column="0" Background="White">
            <!-- Add List View with 3 columns -->
            <TextBlock Name="NameTextBlock" Text="Name" FontWeight="Bold" Margin="10"/>
            <TextBox Name="NameTextBox" Margin="10"/>
            <TextBlock Name="AgeTextBlock" Text="Age" FontWeight="Bold" Margin="10"/>
            <TextBox Name="AgeTextBox" Margin="10"/>
            <TextBlock Name="BalanceTextBlock" Text="Balance" FontWeight="Bold" Margin="10"/>
            <TextBox Name="BalanceTextBox" Margin="10"/>

        </StackPanel>
        <!-- Add Stack Panel in second  column -->
        <StackPanel Grid.Column="1" Background="LightGray">
            <Button 
                Name="RunButton" Content="Run" Click="RunButton_Click"
                Margin="10"/>
        </StackPanel>
    </Grid>
</Window>
```
```csharp
 public partial class MainWindow : Window
 {
     public MainWindow()
     {
         InitializeComponent();

     }
     private void RunButton_Click(object sender, RoutedEventArgs e)
     {
         MessageBox.Show($"Name: {NameTextBox.Text}\nAge: {AgeTextBox.Text}\nBalance: {BalanceTextBox.Text}");
     }
 }
```

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