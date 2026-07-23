## Resources
- [C# WPF Tutorial](https://youtube.com/playlist?list=PLih2KERbY1HHOOJ2C6FOrVXIwg4AZ-hk1&si=7oCOEYd-MjBEx346)

## Layouts

### Grid
- This is sample code to create a Grid with 4 rows and 2 columns
- You can use `Grid.Row` and `Grid.Column` properties to set your control to a specific position
- You can also create another Grid inside a Grid cell to create complex layouts

```xml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition/>
        <RowDefinition/>
        <RowDefinition/>
        <RowDefinition/>
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
        <ColumnDefinition/>
        <ColumnDefinition/>
    </Grid.ColumnDefinitions>
    <TextBlock  
        Grid.Row="0" 
        Grid.Column="0"  
        Name="NameTextBlock" 
        Text="Vivek Patel" 
        FontSize="50" 
        HorizontalAlignment="Left" 
        VerticalAlignment="Center"/>
</Grid>
```

### Stack Panel
- Arranges all elements in single line vertically/horizontally
- Perfect when you need single direction layouts like list
```xml
<StackPanel Orientation="Vertical" Margin="10">
    <Button Content="Button 1" Height="40"/>
    <Button Content="Button 2" Height="40"/>
    <Button Content="Button 3" Height="40"/>
</StackPanel>
```
```xml
<StackPanel Orientation="Horizontal" Margin="10">
    <Button Content="Yes" Width="75" Margin="5"/>
    <Button Content="No" Width="75" Margin="5"/>
    <Button Content="Cancel" Width="75" Margin="5"/>
</StackPanel>
```
- You can also use with with other controls like 
  - button with logo & Text
  - Lable with logo & Text
```xml
<Button>
    <StackPanel Orientation="Horizontal">
        <Image Source="save.png" Width="16" Height="16"/>
        <TextBlock Text="Save"/>
    </StackPanel>
</Button>
```
### GroupBox
- It's similar to what we use on windows form for grouping of similar controls
```xml
<GroupBox
    Name="PersonGroupBox"
    Header="Personal Information"
    Width="300"
    Height="200"
    FontSize="14"
    HorizontalAlignment="Left"
    VerticalAlignment="Top">
    <StackPanel Margin="10">
        <TextBox Name="FirstNameTextBox" Margin="0,0,0,10" />
        <TextBox Name="LastNameTextBox" Margin="0,0,0,10" />
        <Button Name="SubmitButton" Content="Submit" Width="100" />
    </StackPanel>
</GroupBox>
```

## Main Controls

### TextBlock
- Used to display text on the screen
- Supports text formatting, wrapping, and inline elements
- You can use it for headings, descriptions, status messages or read only text

```xml
<TextBlock
    Name="NameTextBlock"
    Text="Vivek Patel"
    FontSize="50"
    HorizontalAlignment="Left"
    VerticalAlignment="Center" />
```

### TextBox
```xml
<TextBox
    Name="InputTextBox"
    VerticalContentAlignment="Center"
    FontSize="16"
    FontWeight="Light"
    Background="Transparent" />
```

### Label
- Used to display text on the screen
- You can use `Content` property to set the text of the label
```xml
<Label
    Name="NameLabel"
    Content="Enter Name:"
    FontSize="16"
    HorizontalAlignment="Left"
    VerticalAlignment="Center" />
```

- Label is different from TextBlock in a way that it can be associated with other controls like TextBox, ComboBox, etc. using `Target` property. When the label is clicked, it will focus on the associated control.

```xml
<TextBox Name="NameTextBox" VFontSize="16" />
<Label Content="_Name:" Target="{Binding ElementName=NameTextBox}" />
```
- This Code will create a label with text "Name:" with `Alt + N` as a shortcut key to focus on the associated TextBox.
- From practical point of view use TextBlock for displaying text and Label when you needs keyboad navigation support.

### Button
```xml
<Button 
    Name="HelloButton" 
    Content="Say Hello" 
    Width="240" 
    Height="80" 
    FontSize="50"
    HorizontalAlignment="Left" 
    VerticalAlignment="Center" 
    Click="HelloButton_Click" />
```

- You need to add code for button click event in code behind file
```csharp
private void HelloButton_Click(object sender, RoutedEventArgs e)
{
    MessageBox.Show($"Hello!", "Greeting", MessageBoxButton.OK, MessageBoxImage.Information);
}
```

### Radio Button
```xml
<RadioButton 
    Content="Male" 
    GroupName="Gender"/>
```
### CheckBox
```xml
 <CheckBox 
    Content="Cooking"/>
```

## Advance Controls

### ListBox
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

### ListView
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

### DataGrid
```xml

```

### Menu
```xml
<Menu
    Name="MainMenu"
    HorizontalAlignment="Stretch"
    VerticalAlignment="Top">
    <MenuItem Header="File">
        <MenuItem Header="New" Click="New_Click"/>
        <MenuItem Header="Open" Click="Open_Click"/>
        <MenuItem Header="Save" Click="Save_Click"/>
        <Separator/>
        <MenuItem Header="Exit" Click="Exit_Click"/>
    </MenuItem>
    <MenuItem Header="Edit">
        <MenuItem Header="Cut" Click="Cut_Click"/>
        <MenuItem Header="Copy" Click="Copy_Click"/>
        <MenuItem Header="Paste" Click="Paste_Click"/>
    </MenuItem>
</Menu>
```

## Media

### Image
- Make sure to set image as a resources from properties
```xml
<Image
    Name="DisplayImage"
    Source="Resources/Logo.png"
    Width="200"
    Height="150"
    HorizontalAlignment="Center"
    VerticalAlignment="Center" />
```

## Decorator

### Border
- Used to display border around controls for visuals
```xml
<Border
    Name="ContentBorder"
    BorderBrush="Gray"
    BorderThickness="2"
    CornerRadius="5"
    Padding="10"
    Background="LightBlue">
    <TextBlock
        Text="Content inside border"
        FontSize="16"
        HorizontalAlignment="Center"
        VerticalAlignment="Center" />
</Border>
```