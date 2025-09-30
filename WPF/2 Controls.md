### Grid
- This is sample code to create a Grid with 4 rows and 2 columns
- You can use `Grid.Row` and `Grid.Column` properties to set your control to a specific position

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

### TextBlock
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
```xml
<Label
    Name="NameLabel"
    Content="Enter Name:"
    FontSize="16"
    HorizontalAlignment="Left"
    VerticalAlignment="Center" />
```

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