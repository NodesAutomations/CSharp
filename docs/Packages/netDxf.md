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

//Arc
Arc arc = new Arc(new Vector2(0, 0), 5, 0, 90);
doc.Entities.Add(arc);
```

## Apply Properties
```csharp
```