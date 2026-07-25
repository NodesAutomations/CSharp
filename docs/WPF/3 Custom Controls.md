# Custom Controls

## Overview
- Custom controls are user-defined controls that can be created to encapsulate specific functionality or behavior.

## Sample code
- Let's assume we are creating custom Input Box Control for our form since we have multiple input fields in our form and we want to have same look and feel for all input fields. So we can create a custom control for input box which will have a label and a textbox.
- So let's create new custom control `InputBox` in UserControls folder and add `User Control WPF` item to it. It will create a new `InputBox.xaml` file and `InputBox.xaml.cs` file.
- Add this code in `InputBox.xaml` file to create a custom input box control with label and textbox.
```xml
<UserControl x:Class="WpfApp.UserControls.InputBox"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:WpfApp.UserControls"
             mc:Ignorable="d" 
             Height="50" d:DesignWidth="600">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="200"/>
            <ColumnDefinition Width="400"/>
        </Grid.ColumnDefinitions>
        <TextBlock Name="InputNameTextBlock" Grid.Column="0" Text="Name" FontSize="16" FontWeight="Bold" Margin="10"/>
        <TextBox Name="InputValueTextBox" Grid.Column="1" Margin="10"/>
    </Grid>
</UserControl>
```
- Code behind file `InputBox.xaml.cs` will have the following code to expose the properties of the custom control.
```csharp
public partial class InputBox : UserControl
{
    public InputBox()
    {
        InitializeComponent();
    }
    public string Label
    {
        get => InputNameTextBlock.Text;
        set => InputNameTextBlock.Text = value;
    }
    public string Text
    {
        get => InputValueTextBox.Text;
        set => InputValueTextBox.Text = value;
    }
}
```
- To use this custom control in your main window, you need to add the control namespace in your main window XAML 
```xml
<Window x:Class="WpfApp.MainWindow"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:local="clr-namespace:WpfApp" mc:Ignorable="d" 
    <!-- Start -->
    xmlns:userControls="clr-namespace:WpfApp.UserControls"
    <!-- End -->
    Title="MainWindow" Height="450" Width="800">
```
- How to use this
```xml
<!-- Use InputBox UserControl -->
<userControls:InputBox x:Name="NameInputBox" Label="Name"/>
<userControls:InputBox x:Name="AgeInputBox" Label="Age"/>
<userControls:InputBox x:Name="AddressInputBox" Label="Address"/>
```
```csharp
string name = NameInputBox.Text;
string age = AgeInputBox.Text;
string address = AddressInputBox.Text;
MessageBox.Show($"Name: {name}\nAge: {age}\nAddress: {address}");
```