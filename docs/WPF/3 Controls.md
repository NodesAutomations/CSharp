## Overview
- WPF provides a wide range of controls that you can use to create your UI. 
- In this document, we will cover some of the most commonly used controls in WPF.

## TextBlock
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

## TextBox
```xml
<TextBox
    Name="InputTextBox"
    VerticalContentAlignment="Center"
    FontSize="16"
    FontWeight="Light"
    Background="Transparent" />
```

## Label
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

## Button
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

## Radio Button
```xml
<RadioButton 
    Content="Male" 
    GroupName="Gender"/>
```
## CheckBox
```xml
 <CheckBox 
    Content="Cooking"/>
```

## Image
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
