<aside>
💡 Use Discards when you need to extract some information from another Object but you don't want to store all parameters just few of them. This will Improve readability of Code as well as Performance. for example With TryParse() method you can discard as out parameter if you don't need to use that.

</aside>

### Overview

Starting with C# 7.0, C# supports discards, which are temporary, dummy variables that are intentionally unused in application code. Discards are equivalent to unassigned variables; they do not have a value. Because there is only a single discard variable, and that variable may not even be allocated storage, discards can reduce memory allocations. Because they make the intent of your code clear, they enhance its readability and maintainability.

You indicate that a variable is a discard by assigning it the underscore (`_`) as its name. For example, the following method call returns a 3-tuple in which the first and second values are discards and *area* is a previously declared variable to be set to the corresponding third component returned by *GetCityInformation*:

```csharp
(_, _, area) = city.GetCityInformation(cityName);
```

### Example

```csharp
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);

        Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");
    }

    private static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
    {
        int population1 = 0, population2 = 0;
        double area = 0;

        if (name == "New York City")
        {
            area = 468.48;
            if (year1 == 1960)
            {
                population1 = 7781984;
            }
            if (year2 == 2010)
            {
                population2 = 8175133;
            }
            return (name, area, year1, population1, year2, population2);
        }

        return ("", 0, 0, 0, 0, 0);
    }
}
// The example displays the following output:
//      Population change, 1960 to 2010: 393,149
```
