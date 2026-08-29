# Mahapps.Icons

## Install
- `Install-Package MahApps.Icons`
- You can also install specific version of icon like material design icons:
- `Install-Package MahApps.Icons.MaterialDesign`
- You can also install other specific icon packs like FontAwesome:
- `Install-Package MahApps.Icons.FontAwesome`

## How To use in wpf form
- You can use the icons in your XAML like this:
- Add xml namespace for the icon packs in your XAML file and use the icons as shown below:
```xml
<Window x:Class="YourNamespace.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:icons="http://metro.mahapps.com/winfx/xaml/iconpacks"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <icons:PackIconMaterial Kind="Home" Width="32" Height="32"/>
    </Grid>
</Window>
```

## Button with Icon
```xml
<Button Width="140" Height="50" HorizontalAlignment="Center" VerticalAlignment="Center">
    <StackPanel Orientation="Horizontal">
        <icons:PackIconMaterial Kind="Calculator" Width="24" Height="24" Margin="0,0,8,0" Foreground="#2563EB" />
        <TextBlock Text="Save" VerticalAlignment="Center" />
    </StackPanel>
</Button>
```
