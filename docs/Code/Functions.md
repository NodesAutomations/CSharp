### Recursive function

```csharp
private static void Main()
{
    Console.Write(Factorial(5).ToString());
    Console.ReadLine();
}

//Recursive function
public static double Factorial(int number)
{
    //0!=1
    if (number == 0)
    {
        return 1;
    }

    return number * Factorial(number - 1);
}

//regular Function
public static double FactorialSimple(int number)
{
    //0!=1
    if (number == 0)
    {
        return 1;
    }

    double factorial = 1;
    for (int i = number; i >= 1; i--)
    {
        factorial = factorial * i;
    }
    return factorial;
}
```
