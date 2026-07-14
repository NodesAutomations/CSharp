# NetDxf
## Overview


## Sample Code
```csharp
// your DXF file name
string file = @"C:\Users\Ryzen2600x\Downloads\sample.dxf";

var doc = new DxfDocument(DxfVersion.AutoCad2013);

//Add Circle
Circle circle = new Circle(new Vector2(0, 0), 5);
doc.Entities.Add(circle);

// save to file
doc.Save(file);

Console.WriteLine("DXF file saved successfully.");
```

## Generate Entity
```csharp
//Add Circle
Circle circle = new Circle(new Vector2(0, 0), 5);
doc.Entities.Add(circle);

// Add Simple Line Entity
Line entity = new Line(new Vector2(5, 5), new Vector2(10, 5));
doc.Entities.Add(entity);

//Add polyline entity
Polyline2D polyline = new Polyline2D();
polyline.Vertexes.Add(new Polyline2DVertex(0, 0));
polyline.Vertexes.Add(new Polyline2DVertex(5, 5));
polyline.Vertexes.Add(new Polyline2DVertex(5, 10));
polyline.Vertexes.Add(new Polyline2DVertex(10, 10));
doc.Entities.Add(polyline);

//Rectangle with 100x100
Polyline2D rectangle = new Polyline2D();
rectangle.Vertexes.Add(new Polyline2DVertex(0, 0));
rectangle.Vertexes.Add(new Polyline2DVertex(100, 0));
rectangle.Vertexes.Add(new Polyline2DVertex(100, 100));
rectangle.Vertexes.Add(new Polyline2DVertex(0, 100));
rectangle.IsClosed = true;
doc.Entities.Add(rectangle);

//Rectangle with 100x100 and bulge of 180 degrees on the left and right sides
Polyline2D rectangle = new Polyline2D();
rectangle.Vertexes.Add(new Polyline2DVertex(0, 0));
rectangle.Vertexes.Add(new Polyline2DVertex(100, 0, GetBuldge(180)));
rectangle.Vertexes.Add(new Polyline2DVertex(100, 100));
rectangle.Vertexes.Add(new Polyline2DVertex(0, 100, GetBuldge(180)));
rectangle.IsClosed = true;
doc.Entities.Add(rectangle);

//Arc
Arc arc = new Arc(new Vector2(0, 0), 5, 0, 90);
doc.Entities.Add(arc);
```

## Apply Properties
```csharp
//Circle with yellow color
Circle circle = new Circle(new Vector2(0, 0), 5);
circle.Color = AciColor.Yellow;
doc.Entities.Add(circle);

//Circle with section layer and red color
Layer layer = new Layer("Section");
layer.Color = AciColor.Red;

Circle circle2 = new Circle(new Vector2(10, 10), 5);
circle2.Layer = layer;
doc.Entities.Add(circle2);

//Circle with dashed line type and blue color
Circle circle3 = new Circle(new Vector2(20, 20), 5);
circle3.Color = AciColor.Blue;
circle3.Linetype = Linetype.Dashed; 
circle3.LinetypeScale = 3;
doc.Entities.Add(circle3);
```

## Annotations
```csharp
//Text with Hello World! and red color
Text text = new Text("Hello World!", new Vector2(0, 0), 1);
text.Alignment = TextAlignment.MiddleCenter;
doc.Entities.Add(text);

//MText with Hello World! and red color
MText mtext = new MText("Hello World!", new Vector2(10, 0), 1.5, 10);
mtext.AttachmentPoint = MTextAttachmentPoint.MiddleCenter;
doc.Entities.Add(mtext);

//Linear Dimension horizontal
LinearDimension linearDimension = new LinearDimension(new Vector2(0, 0), new Vector2(10, 10), -12,90);
doc.Entities.Add(linearDimension);

//Align Dimension Horizontal
AlignedDimension alignedDimension = new AlignedDimension(new Vector2(5, -5), new Vector2(15, -15), 2);
doc.Entities.Add(alignedDimension);

```