### Example 1 : Hashset  with Duplicate Reference and Duplicate Classes

```csharp
using System;
using System.Collections.Generic;

namespace ConsoleAppTest
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                var point = new Point() { X = 10, Y = 10 };
                var point2 = new Point() { X = 10, Y = 10 };
                var point3 = new Point() { X = 100, Y = 100 };
                var points = new HashSet<Point>();
                points.Add(point);
                points.Add(point);
                points.Add(point);
                points.Add(point2);
                points.Add(point3);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }

    internal class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(Point other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * Y.GetHashCode();
        }
    }
}
```

### Example 2

```csharp
using System;
using System.Collections.Generic;

namespace ConsoleAppTest
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                var points = new Point2DHashSet
                {
                    new Point2D(0, 0, "Start"),
                    new Point2D(10, 0, "End")
                };
                Console.WriteLine(points.ToString());
                var points2 = new Point2DHashSet
                {
                    new Point2D(0, 0, "Start2"),
                    new Point2D(10, 10, "End2")
                };
                Console.WriteLine(points2.ToString());
                points.UnionWith(points2);
                Console.WriteLine(points.ToString());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }

    public class Point2DHashSet : HashSet<Point2D>
    {

        public new bool Add(Point2D point)
        {
            var sucess = base.Add(point);
            if (!sucess)
            {
                UpdateTags(point);
            }
            return sucess;
        }

        public void UnionWith(Point2DHashSet points)
        {
            Point2DHashSet copypoints = (Point2DHashSet)points.MemberwiseClone();
            copypoints.IntersectWith(this);
            foreach (var point in copypoints)
            {
                UpdateTags(point);
            }
            base.UnionWith(points);
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            foreach (var pt in this)
            {
                sb.AppendLine(pt.ToString());
            }
            return sb.ToString();
        }
        private void UpdateTags(Point2D point)
        {
            TryGetValue(point, out Point2D pt);
            pt.Tags.UnionWith(point.Tags);
        }
    }

    public class Point2D : IEquatable<Point2D>
    {
        public double X { get; set; }
        public double Y { get; set; }
        public HashSet<string> Tags { get; set; }

        public Point2D()
        {
            Tags = new HashSet<string>();
        }

        public Point2D(double x, double y, string tag) : this()
        {
            X = x;
            Y = y;
            Tags.Add(tag);
        }

        public override string ToString()
        {
            return $"{X:0.####},{Y:0.####},{string.Join(",", Tags)}";
        }

        public bool Equals(Point2D point)
        {
            return this.X == point.X && this.Y == point.Y;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            return obj is Point2D point3D && Equals(point3D);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }
    }
}
```
