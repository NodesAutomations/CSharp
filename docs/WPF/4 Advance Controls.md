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

```
