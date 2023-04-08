### Use Color Index to Apply custom color
```csharp
Circle circle = new Circle();
circle.ColorIndex = 1;
```
- Autocad has different color index for each color
- red color has index of 1
- if you don't want to remember color index you can use CadColor Enum from cadhelper
```csharp
Circle circle = new Circle();
circle.ColorIndex = (int)CadColor.Yellow;
```
### USE RGB to specify Color
```csharp
circle.Color = Autodesk.AutoCAD.Colors.Color.FromRgb(255, 0, 0);
```
- (255,0,0) represent red color in rgb value
