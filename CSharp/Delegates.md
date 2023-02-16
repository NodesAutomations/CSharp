### Function Type Delegate
In C#, the Func delegate is a built-in generic delegate type that represents a method that takes zero or more input parameters and returns a value of a specified type. The last type parameter of a Func delegate specifies the return type, and the preceding type parameters specify the types of the input parameters.

For example, Func<int, int, int> is a Func delegate that takes two integer parameters and returns an integer value. The first two type parameters, int, int, specify the input parameter types, and the last type parameter, int, specifies the return type.
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

### Action Type Delegate
In C#, the Action delegate is a built-in delegate type that represents a method that takes zero or more input parameters and returns no value (i.e., a void return type). The type parameters of an Action delegate specify the types of the input parameters.

For example, Action<int, string> is an Action delegate that takes an integer and a string parameter and returns no value.
```csharp
 private static void Main()
        {
            SayGreetings(SayHello, "Vivek");
            SayGreetings(SayGoodMorning, "Vivek");
            Console.ReadLine();
        }

        private static void SayGreetings(Action<string> action, string value)
        {
            action(value);
        }

        private static void SayHello(string value)
        {
            Console.WriteLine($"Hello {value}");
        }

        private static void SayGoodMorning(string value)
        {
            Console.WriteLine($"Good Morning, {value}");
        }
```
### Predicate Type Delegates
In C#, a Predicate is a built-in delegate type that represents a method that takes a single input parameter of a specified type and returns a boolean value indicating whether the input satisfies a certain condition.
The Predicate delegate is commonly used to perform filtering operations on collections or sequences of data. 
```csharp
private static void Main()
{
    Console.WriteLine("Original List");
    var list = new List<int>();
    for (int i = 0; i < 10; i++)
    {
        list.Add(i);
        Console.WriteLine(i);
    }

    Console.WriteLine("Printing Even Numbers");
    var evenNumberList = FilterValues(IsEven, list);
    foreach (var item in evenNumberList)
    {
        Console.WriteLine(item);
    }

    Console.WriteLine("Printing Odd Numbers");
    var OddNumberList = FilterValues(IsOdd, list);
    foreach (var item in OddNumberList)
    {
        Console.WriteLine(item);
    }

    Console.ReadLine();
}

private static List<int> FilterValues(Predicate<int> predicate, List<int> numbers)
{
    var result = new List<int>();
    foreach (var item in numbers)
    {
        if (predicate(item))
        {
            result.Add(item);
        }
    }
    return result;
}

private static bool IsEven(int value)
{
    return value % 2 == 0;
}

private static bool IsOdd(int value)
{
    return value % 2 == 1;
}
```
