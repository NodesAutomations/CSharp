### How to divide a line (or arc or polyline) into 5 parts
- With existing Curve class (from which Line/Arc/Polyline is derived), you can easily obtain the dividing points on the curve with Curve.GetPointAtDist() method. So, simply divide the length of the curve by 5, and then calculate each of the dividing point.

```csharp
public List<Point3d> GetDividingPoint(Curve curve, int segCount)
{
  var length=curve.GetDistanceArParameter(curve.EndParam);
  var increment=length/segCount;
  var dist=increment;
  var points=new List<Point3d>();
  while(dist<length)
  {
    var pt=curve.GetPointAtDist(dist, false);
    points.Add(pt);
    dist+=increment;
  }
  return points;
}
```
