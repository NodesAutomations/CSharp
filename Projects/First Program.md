```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hello World
            Console.WriteLine("Hello World");

            //First Class
            Point2D p1 = new Point2D();
            Console.WriteLine(p1.ToString());
            Point2D p2 = new Point2D();
            p2.X = 10;
            p2.Y = 20;
            Console.WriteLine(p2.ToString());
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            //First Array
            int[] a = { 1, 2, 3 };
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            //First List
            List<string> names = new List<string>();
            names.Add("Vivek");
            names.Add("Nodes Automations");
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            //Static Class
            Console.WriteLine(Calculator.Add(10,3));
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }
    }

    class Point2D
    {
        public static int Id{ get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Point2D()
        {
            Id = Id + 1;
            this.X = 10;
            this.Y = 10;
        }
        public override string ToString()
        {
            return $"(x,y)=[{Id}]({this.X},{this.Y})";
        }
    }

    static class Calculator
    {
        public  static int Add(int x,int y)
        {
            return x + y;
        }
    }

}
```
