## Function Type Delegate

### Code
```csharp
        private static void Main()
        {
            Console.WriteLine(Calculate(Sum, 20, 10));
            Console.WriteLine(Calculate(Multiply, 20, 10));
        }

        private static double Calculate(Func<double, double, double> function, double a, double b)
        {
            return function(a, b);
        }

        private static double Sum(double a, double b)
        {
            return a + b;
        }

        private static double Multiply(double a, double b)
        {
            return a * b;
        }
```


