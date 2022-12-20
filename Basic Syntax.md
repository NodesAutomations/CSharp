- Basic Variables
    
    ```csharp
                //String Variables
                string aFriend = "Bill";
                Console.WriteLine(aFriend);
                Console.WriteLine("Hello " + aFriend);
                Console.WriteLine($"Hello {aFriend}");
    
                string firstFriend = "Maria";
                string secondFriend = "Sage";
                Console.WriteLine($"My friends are {firstFriend} and {secondFriend}");
    
                //Numbers
                int a = 7;
                int b = 4;
                int c = 3;
                int d = (a + b) / c;
                int e = (a + b) % c;
                Console.WriteLine($"quotient: {d}");
                Console.WriteLine($"remainder: {e}");
                int max = int.MaxValue;
                int min = int.MinValue;
                Console.WriteLine($"The range of integers is {min} to {max}");
                /*
                quotient: 3
                remainder: 2
                The range of integers is -2147483648 to 2147483647
                 */
    
                double a= 19;
                double b= 23;
                double c= 8;
                double d= (a + b) / c;
                Console.WriteLine(d);
                double max = double.MaxValue;
                double min = double.MinValue;
                Console.WriteLine($"The range of double is {min} to {max}");
    
                double a = 1.0;
                double b = 3.0;
                Console.WriteLine(a / b);
    
                decimal c = 1.0M;
                decimal d = 3.0M;
                Console.WriteLine(c / d);
    
    ```
    
- Array
    
    ```csharp
    int[] a = { 0, 1, 2 };
    foreach (var num in a)
    {
        Console.WriteLine(num);
    }
    ```
     
- Methods and Function
    
    
- Loops and Decision
    - If
        
        ```csharp
        //IF
        		int a = 10;
            int b = 20;
            if (a > b)
            {
                Console.WriteLine("A is bigger");
            }
            else
            {
                Console.WriteLine("B is bigger");
            }
        ```
        
    - Switch
        
        ```csharp
        int n = 5;
                    switch (n % 2)
                    {
                        case 0:
                            System.Console.WriteLine("Even");
                            break;
                        default:
                            System.Console.WriteLine("Odd");
                            break;
                    }
        ```
        
        - 
    - For
        
        ```csharp
        var names = new List<String> { "Vivek", "Ketul" };
                    foreach (var name in names)
                    {
                        Console.WriteLine(name);
                    }
                    for (int i = 0; i < names.Count; i++)
                    {
                        Console.WriteLine(names[i]);
                    }
        ```
        
    - Do While
        
        ```csharp
        int counter = 0;
                    do
                    {
                        Console.WriteLine(counter);
                        counter++;
                    }
                    while (counter < 10);
        ```
        
    - While
        
        ```csharp
        int counter = 0;
                    while (counter<10)
                    {
                        Console.WriteLine(counter);
                        counter++;
                    }
        ```
        
- Class
    
    ```csharp
    private static void Main(string[] args)
            {
                var p = new Point(0, 0);
                var q = new Point(10, 0);
                Console.WriteLine(p.DistanceFrom(q));
            }
    
            public class Point
            {
                int x;
                int y;
    
                public Point(int x,int y)
                {
                    this.x = x;
                    this.y = y;
                }
    
                public double DistanceFrom(Point x)
                {
                    return Math.Sqrt((this.x - x.x)*(this.x - x.x) + (this.y - x.y)*(this.y - x.y));
                }
              
            }
    ```
    
- Interfaces
    
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
    
    -
