## Overview
- All controls in group help you with adjusting the layout of your application
- You can think of it as a container for your controls, which helps you to arrange them in a specific way
 

## Window
- Title bar consule around 30-40 pixels of height so adjust your window height accordingly so all your controls are visible
- Side border is around 8-10 pixels of width so adjust your window width accordingly so all your controls are visible

## Grid
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

## Stack Panel
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
## Grid Splitter
- GridSplitter is used to resize the grid columns or rows at runtime
- You have to add extra row or column in your grid to add GridSplitter control with `5-10` thickness to make it visible and resizable
```xml
 <GridSplitter Grid.Column="1" Width="10" HorizontalAlignment="Stretch" VerticalAlignment="Stretch"/>
```

## Expander
- Expander is used to show/hide the content on click of header
- You can use it to create collapsible sections in your UI
```xml
<Expander Header="More Options" Width="200" Height="100">
    <StackPanel>
        <CheckBox Content="Option 1"/>
        <CheckBox Content="Option 2"/>
        <CheckBox Content="Option 3"/>
    </StackPanel>
</Expander>
```
## GroupBox
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

## Border
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
 
## Menu
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