## Overview
- WPF provides a wide range of controls that you can use to create your UI. 
- In this document, we will cover some of the most commonly used controls in WPF.

## Common Properties of Controls

| Property | Value | Description |
|----------|--------------|-------------|
| Name | NameTextBlock | The name of the control, used to reference it in code-behind. |
| Width | 200 | The width of the control. |
| Height | 150 | The height of the control. |
| Margin | 5,10,5,10 | The space around the control. You can use a single value for uniform margin or two values for (left-right, top-bottom) or four values for (left, top, right, bottom). |
| Padding | 5,10,5,10 | The space inside the control, between the content and the border. |
| HorizontalAlignment | Center | The horizontal alignment of the control within its parent container. Options are Left, Center, Right, Stretch. |
| VerticalAlignment | Center | The vertical alignment of the control within its parent container. Options are Top, Center, Bottom, Stretch. |

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

## Border
- used to draw border around the control
- Useful when you want to visually group or highlight controls.
- Since a Border accepts only one child, use a layout panel inside it to add multiple controls

```xml
<Border BorderBrush="Black"
        BorderThickness="2"
        Background="LightBlue"
        CornerRadius="10"
        Padding="10">

    <TextBlock Text="Hello WPF"/>
</Border>
```

## Shapes
- Mainly used for drawing simple graphics without using lowlevel drawing APIs
- Shapes are usally used with canvas but you can also use with other layout panels like grid, stackpanel, etc.

### Line 
```xml
<Line X1="0"
    Y1="0"
    X2="200"
    Y2="100"
    Stroke="Blue"
    StrokeThickness="3"/>
```
### Rectangle
- You can use RadiusX and RadiusY properties to create rounded corners
```xml
  <Rectangle Width="100"
               Height="60"
               Fill="LightBlue"
               Stroke="Black"
               StrokeThickness="2"
               Canvas.Left="20"
               Canvas.Top="20"/>
```
### Elipse
- You can also use `Ellipse` to create circle by setting equal width and height
```xml
<Ellipse Width="80"
        Height="80"
        Fill="Orange"
        Stroke="Black"
        StrokeThickness="2"
        Canvas.Left="150"
        Canvas.Top="20"/>
```
### Polygon
- Use `Polygon` to create a shape with multiple sides. You can specify the points of the polygon using the `Points` property.
- Points are separated by space and each point is defined by x,y coordinates separated by comma. For example, `Points="0,0 0,150 150,150"` defines a triangle with three points at (0,0), (0,150), and (150,150).
```xml
<Polygon Points="0,0 0,150 150,150"
    Fill="LightGreen"
    Stroke="Black"
    StrokeThickness="2"/>
```
### Polyline
```xml
<Polyline Points="10,10 100,50 150,20 250,80"
          Stroke="Blue"
          StrokeThickness="2"/>
```
Dashed polyline
```xml
<Polyline Points="50,50 150,50 150,150"
          Stroke="Red"
          StrokeThickness="2"
          StrokeDashArray="5 2"/>
```
### Path
- You can draw any object you like using path
- The `Data` property of the `Path` element defines the geometry of the shape. You can use a combination of lines, curves, and arcs to create complex shapes.
- I can't see any practical use case right now but you can use it to create custom shapes and icons in your application. 
```xml
<Path Stroke="Blue"
StrokeThickness="2"
Data="M 10,10 L 200,100"/>
```
### Adding Shapes via Code Behind
```csharp
Rectangle rect = new Rectangle
{
    Width = 100,
    Height = 50,
    Fill = Brushes.LightBlue,
    Stroke = Brushes.Black,
    StrokeThickness = 2
};

Canvas.SetLeft(rect, 50);
Canvas.SetTop(rect, 50);

MyCanvas.Children.Add(rect);

```
```csharp
//To move shape
double x = Canvas.GetLeft(rect);

Canvas.SetLeft(rect, x + 10);
```
```csharp
//polyline example
Polyline polyline = new Polyline();

polyline.Stroke = Brushes.Blue;
polyline.StrokeThickness = 2;

polyline.Points.Add(new Point(50, 50));
polyline.Points.Add(new Point(150, 50));
polyline.Points.Add(new Point(150, 150));
polyline.Points.Add(new Point(50, 150));

MyCanvas.Children.Add(polyline);
```

