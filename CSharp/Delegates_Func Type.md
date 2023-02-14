## Function Type Delegate
In C#, the Func delegate is a built-in generic delegate type that represents a method that takes zero or more input parameters and returns a value of a specified type. The last type parameter of a Func delegate specifies the return type, and the preceding type parameters specify the types of the input parameters.

For example, Func<int, int, int> is a Func delegate that takes two integer parameters and returns an integer value. The first two type parameters, int, int, specify the input parameter types, and the last type parameter, int, specifies the return type.
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


