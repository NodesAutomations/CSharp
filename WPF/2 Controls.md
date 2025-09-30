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

### GroupBox
- Used to group related controls together
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