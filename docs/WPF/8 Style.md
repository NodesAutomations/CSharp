## Overview
- Style in WPF is used to define the visual appearance of controls once and reuse it everywhere in the application.
- You can think of style as equivalent to css for HTML. It allows you to define a set of properties and apply them to multiple controls, ensuring consistency in the UI design.
- There are three level of customization in WPF style:
  - Style using specific properties on individual controls
  - Style on all controls of a type on specific group of controls
  - Style using custom control template

## Style using specific properties
- You can define a style for a specific control type by setting the `TargetType` property
- Key is used to give a name to the style so that it can be referenced later in the XAML file.
- You need to define the style in the resources section of your XAML file, and then apply it to the controls using the `Style` property.

```xml
<Window.Resources>
    <Style x:Key="PrimaryButton" TargetType="Button">
        <Setter Property="Width" Value="80"/>
        <Setter Property="Height" Value="30"/>
        <Setter Property="Background" Value="LightBlue"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="FontWeight" Value="Bold"/>
    </Style>
</Window.Resources>

<StackPanel Orientation="Vertical" HorizontalAlignment="Center" VerticalAlignment="Center" >
    <Button Content="Save" Style="{StaticResource PrimaryButton}"/>
    <Button Content="Open" Style="{StaticResource PrimaryButton}"/>
</StackPanel>
```

## Style On all Controls of a Type
- You can define a style for all controls of a specific type by setting the `TargetType` property without specifying a key. This will apply the style to all controls of that type in the scope of the resource dictionary.
```xml
<Window.Resources>
    <Style TargetType="Button">
        <Setter Property="Width" Value="80"/>
        <Setter Property="Height" Value="30"/>
        <Setter Property="Background" Value="LightBlue"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="FontWeight" Value="Bold"/>
    </Style>
</Window.Resources>

<StackPanel Orientation="Vertical" HorizontalAlignment="Center" VerticalAlignment="Center" >
    <Button Content="Save"/>
    <Button Content="Open"/>
</StackPanel>
```
## Style using Custom Control Template
- For more advanced styling like mouse hover effects, you can define a custom control template for the control. This allows you to completely change the visual structure of the control.

```xml
 <Window.Resources>
     <Style TargetType="Button">
         <Setter Property="Template">
             <Setter.Value>
                 <ControlTemplate TargetType="Button">

                     <Border x:Name="border"
                     Background="{TemplateBinding Background}"
                     BorderBrush="Black"
                     BorderThickness="1"
                     Padding="5">
                         <ContentPresenter
                     HorizontalAlignment="Center"
                     VerticalAlignment="Center"/>
                     </Border>

                     <ControlTemplate.Triggers>
                         <Trigger Property="IsMouseOver"
                          Value="True">
                             <Setter TargetName="border"
                             Property="Background"
                             Value="LightGreen"/>
                         </Trigger>
                     </ControlTemplate.Triggers>
                 </ControlTemplate>
             </Setter.Value>
         </Setter>

         <Setter Property="Background" Value="LightPink"/>

     </Style>
 </Window.Resources>
 <StackPanel Orientation="Vertical" HorizontalAlignment="Center" VerticalAlignment="Center" >
     <Button Content="Save"/>
     <Button Content="Open"/>
 </StackPanel>
```
## Style using BasedOn property
- You can define a style that is based on another style using the `BasedOn` property. 
- This allows you to create a new style that inherits the properties of an existing style, while also allowing you to override or add new properties.

```xml
<Window.Resources>
    <Style x:Key="PrimaryButton" TargetType="Button">
        <Setter Property="Width" Value="80"/>
        <Setter Property="Height" Value="30"/>
        <Setter Property="Background" Value="LightBlue"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="FontWeight" Value="Bold"/>
    </Style>
    <Style x:Key="SecondaryButton" TargetType="Button" BasedOn="{StaticResource PrimaryButton}">
        <Setter Property="Background" Value="LightGreen"/>
    </Style>
</Window.Resources>

<StackPanel Orientation="Vertical" HorizontalAlignment="Center" VerticalAlignment="Center" >
    <Button Content="Save" Style="{StaticResource PrimaryButton}"/>
    <Button Content="Open" Style="{StaticResource SecondaryButton}"/>
</StackPanel>
```

## Application wide Style
- You can define a style in the `App.xaml` file to make it available throughout the application. This allows you to maintain a consistent look and feel across all windows and controls in your WPF application.

```xml
<Application.Resources>
    <Style x:Key="PrimaryButton" TargetType="Button">
        <Setter Property="Width" Value="80"/>
        <Setter Property="Height" Value="30"/>
        <Setter Property="Background" Value="LightBlue"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="FontWeight" Value="Bold"/>
    </Style>
    <Style x:Key="SecondaryButton" TargetType="Button" BasedOn="{StaticResource PrimaryButton}">
        <Setter Property="Background" Value="LightGreen"/>
    </Style>
</Application.Resources>
```

## Resource Dictionary for larger applications
- For larger applications, it is a good practice to define styles in separate resource dictionary files..
- You can create a folder named `Styles` in your project and add separate XAML files for different control styles. Then, you can merge these resource dictionaries in your `App.xaml` file.
```
Styles
 ├─ Buttons.xaml
 ├─ TextBoxes.xaml
 ├─ Cards.xaml
 └─ Colors.xaml
```
```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="Styles/Buttons.xaml"/>
            <ResourceDictionary Source="Styles/TextBoxes.xaml"/>
            <ResourceDictionary Source="Styles/Cards.xaml"/>
            <ResourceDictionary Source="Styles/Colors.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

- Sample `Buttons.xaml` file:
```
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Style x:Key="PrimaryButton" TargetType="Button">
        <Setter Property="Width" Value="80"/>
        <Setter Property="Height" Value="30"/>
        <Setter Property="Background" Value="LightBlue"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="FontWeight" Value="Bold"/>
    </Style>
    <Style x:Key="SecondaryButton" TargetType="Button" BasedOn="{StaticResource PrimaryButton}">
        <Setter Property="Background" Value="LightGreen"/>
    </Style>
</ResourceDictionary>
```