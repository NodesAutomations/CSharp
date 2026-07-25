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
             d:DesignWidth="600" d:DesignHeight="50">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="120"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <TextBlock Grid.Column="0" Name="LabelTextBlock"  Text="Name" FontSize="16" FontWeight="Bold" Margin="10"/>
        <TextBox Grid.Column="1" Name="ValueTextBox" Margin="10"/>
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
        get => LabelTextBlock.Text;
        set => LabelTextBlock.Text = value;
    }
    public string Text
    {
        get => ValueTextBox.Text;
        set => ValueTextBox.Text = value;
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
    xmlns:userControls="clr-namespace:WpfApp.UserControls"
    Title="MainWindow" Height="450" Width="800">
    
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="200"/>
        </Grid.ColumnDefinitions>
        <!-- Add Stack Panel in first column -->
        <StackPanel Grid.Column="0" Background="White">
            <!-- Use InputBox UserControl -->
            <userControls:InputBox x:Name="NameInputBox" Label="Name" Text="John Doe" />
            <userControls:InputBox x:Name="AgeInputBox" Label="Age" Text="30" />
            <userControls:InputBox x:Name="BalanceInputBox" Label="Balance" Text="1000" />
        </StackPanel>
        <!-- Add Stack Panel in second  column -->
        <StackPanel Grid.Column="1" Background="LightGray">
            <Button Name="RunButton" Content="Run" Click="RunButton_Click" Margin="10"/>
        </StackPanel>
    </Grid>
</Window>
```
- Code behind to use this custom control in your main window will have the following code.
```csharp
string name = NameInputBox.Text;
string age = AgeInputBox.Text;
string balance = BalanceInputBox.Text;
MessageBox.Show($"Name: {name}\nAge: {age}\nBalance: {balance}");
```