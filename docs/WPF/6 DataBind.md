## Overview
- Databinding is a powerful feature in WPF that allows you to bind UI elements to data sources, enabling automatic updates of the UI when the underlying data changes.
- You can just
- For Databinding you have to implement INotifyPropertyChanged interface
- Which contain PropertyChangedEventHandler, which we can trigger everytime we update our property

## Simple Data Binding
- In this example, we will create a simple WPF application that demonstrates data binding. We will bind a TextBlock and a TextBox to a property called CompanyName in the code-behind.
- This will work but if company name is updated in code-behind, it won't update in UI so keep that in mind.
```xml
<Window x:Class="WpfApp.MainWindow"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:local="clr-namespace:WpfApp" mc:Ignorable="d"

    <Grid>
        <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*"/>
        <ColumnDefinition Width="200"/>
        </Grid.ColumnDefinitions>
        <!-- Add Stack Panel in first column -->
        <StackPanel Grid.Column="0" Background="White">
        <TextBlock Text="{Binding CompanyName}" FontSize="20" FontWeight="Bold" Margin="10" />
        <TextBox Text="{Binding CompanyName}" Margin="10"/>
        </StackPanel>
        <!-- Add Stack Panel in second  column -->
        <StackPanel Grid.Column="1" Background="LightGray">
        <Button Name="RunButton" Content="Run" Click="RunButton_Click" Margin="10"/>
        <Button Name="UpdateButton" Content="Update" Click="UpdateButton_Click" Margin="10"/>
        </StackPanel>
        </Grid>
</Window>
```
```csharp
public partial class MainWindow : Window, INotifyPropertyChanged
{
    public MainWindow()
    {
        DataContext = this;
        CompanyName = "Nodes Automations";
        InitializeComponent();
    }
    private string _companyName;
    public string CompanyName { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void RunButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show($"Company: {CompanyName}");
    }
    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        CompanyName = "Actifab";
    }
}
```

## Databinding with INotifyPropertyChanged
- Inotify PropertyChanged is an interface that allows you to notify the UI when a property value changes, enabling automatic updates of the UI elements bound to that property.
- Without it UI won't update when the property value changes in code-behind.

```xml
Title="Test" Height="250" Width="300">
<Window x:Class="WpfApp.MainWindow"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:local="clr-namespace:WpfApp" mc:Ignorable="d"

    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="200"/>
        </Grid.ColumnDefinitions>
        <!-- Add Stack Panel in first column -->
        <StackPanel Grid.Column="0" Background="White">
            <TextBlock Text="{Binding CompanyName}" FontSize="20" FontWeight="Bold" Margin="10" />
            <TextBox Text="{Binding CompanyName, UpdateSourceTrigger=PropertyChanged}" Margin="10"/>
        </StackPanel>
        <!-- Add Stack Panel in second  column -->
        <StackPanel Grid.Column="1" Background="LightGray">
            <Button Name="RunButton" Content="Run" Click="RunButton_Click" Margin="10"/>
            <Button Name="UpdateButton" Content="Update" Click="UpdateButton_Click" Margin="10"/>
        </StackPanel>
    </Grid>
</Window>
```
```csharp
public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;
            CompanyName = "Nodes Automations";
            InitializeComponent();
        }
        private string _companyName;
        public string CompanyName 
        { 
            get => _companyName;
            set
            {
                if (_companyName != value)
                {
                    _companyName = value;
                    OnPropertyChanged();
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName= null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameInputBox.Text;
            string age = AgeInputBox.Text;
            string address = AddressInputBox.Text;
            MessageBox.Show($"Name: {name}\nAge: {age}\nAddress: {address}\nCompany: {CompanyName}");
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            CompanyName = "Actifab";
        }
    }
```

## DataBinding with ObservableCollection
- List<T> stores data but it doesn't notify the UI when items are added or removed. 
- ObservableCollection<T> stores data and tells UI when items are added or removed, enabling automatic updates of the UI elements bound to that collection.

```xml
<StackPanel>
    <ListBox ItemsSource="{Binding Clients}" />
    <Button Content="Add" Click="Button_Click" />
</StackPanel>
```
```csharp
public MainWindow()
{
    InitializeComponent();
    DataContext = this;
    Clients = new ObservableCollection<string>();
    Clients.Add("Client 1");
}
public ObservableCollection<string> Clients { get; private set; }
private void Button_Click(object sender, RoutedEventArgs e)
{
    Clients.Add("Client 2");
}
```

### How it's different from using INotifyPropertyChanged
- ObservableCollection does not track everything, means if you change the value of an item in the collection, it won't notify the UI. It only notifies when items are added or removed from the collection.
- If you want to notify the UI when an item in the collection changes, you need to implement INotifyPropertyChanged in the item class.
- So use ObservableCollection when you're dealing with collections and INotifyPropertyChanged when you're dealing with individual properties.
- **Use ObservableCollection<T> whenever a collection is bound to a ListBox, ListView, DataGrid, TreeView, or ComboBox and items can be added or removed while the application is running.**

## DataBinding Properties
- Binding : Specifies the source of the binding, which can be a property, a collection, or an object.
- UpdateSourceTrigger : Determines when the binding source is updated. Common values include PropertyChanged, LostFocus, and Explicit.
- Mode : Specifies the direction of the binding. Common values include OneWay, TwoWay, and OneTime.
- Converter : Allows you to specify a value converter that can transform the data between the source and the target.
