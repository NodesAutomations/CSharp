```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                var points = new List<Point2D>();
                points.Add(new Point2D(0, 0));
                points.Add(new Point2D(10, 0));
                points.Add(new Point2D(10.123456, 10.123456));
                points.Add(new Point2D(0, 10));
                Console.WriteLine($"{points[2]:6}");
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
   
    public class Point2D:IFormattable
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return ToString(4);
        }
        public string ToString(int numOfDecimal)
        {
            return ToString(numOfDecimal.ToString(), null);
        }
        public string ToString(string format)
        {
            return ToString(format, null);
        }
        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "4";
            if (provider == null) provider = System.Globalization.CultureInfo.CurrentCulture;
            if (!int.TryParse(format, out int numOfDecimal))
            {
                numOfDecimal = 4;
            }
            return $"{X.Format(numOfDecimal)},{Y.Format(numOfDecimal)}";
        }
    }
    internal static class FormatingHelper
    {
        internal static string Format(this double value, int precision = 4)
        {
            return precision switch
            {
                1 => $"{value:0.#}",
                2 => $"{value:0.##}",
                3 => $"{value:0.###}",
                4 => $"{value:0.####}",
                5 => $"{value:0.#####}",
                6 => $"{value:0.######}",
                7 => $"{value:0.#######}",
                8 => $"{value:0.########}",
                _ => value.ToString("N" + precision),
            };
        }
    }
}
```
