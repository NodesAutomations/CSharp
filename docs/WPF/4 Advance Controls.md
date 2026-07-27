## Overview
- Advance controls are the controls that are used to create more complex and interactive user interfaces.
- This are more interactive controls than the basic controls and use to display large amount of data in a structured way. These controls are used to create more complex and interactive user interfaces.

## ListBox
```xml
<ListBox
    Name="ItemsListBox"
    Width="200"
    Height="150"
    FontSize="14"
    HorizontalAlignment="Left"
    VerticalAlignment="Top">
    <ListBoxItem Content="Item 1"/>
    <ListBoxItem Content="Item 2"/>
    <ListBoxItem Content="Item 3"/>
</ListBox>
```

## ListView
- List view with single column
```xml
<ListView Name="FriendsListView" />
```
```csharp
'Code to populate ListView Item
FriendsListView.Items.Add("Deven");
FriendsListView.Items.Add("Dhruv");
FriendsListView.Items.Add("Yogesh");
```
```csharp
//Code to display Selected item from FriendsListView
MessageBox.Show($"{FriendsListView.SelectedItem.ToString()}");
```
```csharp
//Code to remove selected item from FriendsListView
FriendsListView.Items.Remove(FriendsListView.SelectedItem);
```

- List view with multiple columns
```xml
<ListView Name="FriendsListView" Width="300" Height="150">
    <ListView.View>
        <GridView>
            <GridViewColumn Header="Name" DisplayMemberBinding="{Binding Name}" Width="140" />
            <GridViewColumn Header="Age" DisplayMemberBinding="{Binding Age}" Width="80" />
        </GridView>
    </ListView.View>
</ListView>
```
```csharp
public class Friend
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public override string ToString()
    {
        return $"{Name} ({Age})";
    }
}
````
```csharp
//code to populate ListView Item with multiple columns
FriendsListView.Items.Add(new Friend
{
    Name = "Deven",
    Age = 25
});

FriendsListView.Items.Add(new Friend
{
    Name = "Dhruv",
    Age = 28
});

FriendsListView.Items.Add(new Friend
{
    Name = "Yogesh",
    Age = 30
});
```

## DataGrid
- DataGrid is used to display data in tabular format with rows and columns
- Listview columns are only for presentation purpose, but DataGrid columns are editable and can be bound to data source
```xml
<Window x:Class="WpfApp.MainWindow"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:local="clr-namespace:WpfApp" mc:Ignorable="d" 
    Title="People" Height="450" Width="800">

    <Grid Margin="20">
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition Height="50"/>
        </Grid.RowDefinitions>
        <DataGrid ItemsSource="{Binding People}"
                  AutoGenerateColumns="False"
                  CanUserAddRows="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
                <DataGridTextColumn Header="Age" Binding="{Binding Age}" />
            </DataGrid.Columns>
        </DataGrid>
        <StackPanel Grid.Row="1" Orientation="Horizontal" HorizontalAlignment="Left" VerticalAlignment="Center">
            <Button Name="ShowPersonButton" Content="Show Person" Click="ShowPersonButton_Click" Width="100" Height="30" Margin="0,0,10,0"/>
        </StackPanel>
    </Grid>
</Window>
```
```csharp
public class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
}

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    public List<Person> People { get; } = new()
    {
        new Person { Name = "Alice", Age = 30 },
        new Person { Name = "Bob", Age = 25 },
        new Person { Name = "Charlie", Age = 35 }
    };

    private void ShowPersonButton_Click(object sender, RoutedEventArgs e)
    {
        var result = new StringBuilder();
        foreach (var person in People)
        {
            result.AppendLine($"Name: {person.Name}, Age: {person.Age}");
        }
        MessageBox.Show(result.ToString());
    }
}
```
