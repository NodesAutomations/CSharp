### Example

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
                var point = new Point() { X = 1000, Y = 10};
                var point2 = new Point() { X = 10, Y = 100 };
                var point3 = new Point() { X = 100, Y = 1000 };

                var points = new List<Point>() { point, point2, point3 };

                points.ForEach(Point.Print);

                Console.WriteLine("Find Method");
                var pt = points.Find(Point.FindMe);
                Console.WriteLine(pt);

                Console.WriteLine("Sort by x");
                points.Sort(Point.SortByX);
                points.ForEach(Point.Print);

                Console.WriteLine("Sort by y");
                points.Sort(Point.SortByY);
                points.ForEach(Point.Print);

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

    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Action<Point> Print = x => Console.WriteLine(x);

        public static Predicate<Point> FindMe = x => x.X == 100;

        public static Comparison<Point> SortByX=((x,y)=> x.X.CompareTo(y.X));
        public static Comparison<Point> SortByY=((x,y)=> x.Y.CompareTo(y.Y));
        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
```
