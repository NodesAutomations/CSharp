### Basic Sample

    ```csharp
    private static void Main(string[] args)
            {
                var p = new Point(0, 0);
                var q = new Point(10, 0);
                Console.WriteLine(p.DistanceFrom(q));
            }
    
            public interface IPoint
            {
                double DistanceFrom(Point x);
            }
    
            public class Point : IPoint
            {
                private int x;
                private int y;
    
                public Point(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }
    
                public double DistanceFrom(Point x)
                {
                    return Math.Sqrt((this.x - x.x) * (this.x - x.x) + (this.y - x.y) * (this.y - x.y));
                }
            }
    ```
