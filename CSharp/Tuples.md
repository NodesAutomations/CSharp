### Basics
- Tuples Type Provide way to group multiple Data elements into light weight structure
- Tuples are very usefull as method return type, when you need to return multiple value instead of one
- Tuples can also implemented as replacement for light classes to reduce code clutter and simplicity
- One of my favorite use case is storing Tabular data using List of Tuple with Field Names. for Example storing List of books, with each book having Unique ID, Name, no of pages, Author... etc

#### Example Tuples without Field names
```csharp
(int, string, int) Book;

Book.Item1 = 1;
Book.Item2 = "The Way of Kings";
Book.Item3 = 1200;

Console.WriteLine($"{Book.Item1}-{Book.Item2}-{Book.Item3}");
```

#### Example Tuple with Field Names
```csharp
(int Id, string Name,int Pages) Book=(1,"The Way of King",1200);

Console.WriteLine($"{Book.Id}-{Book.Name}-{Book.Pages}");
```
```csharp
(int Id, string Name, int Pages) Book;

Book.Id = 1;
Book.Name = "The Way of Kings";
Book.Pages = 1200;

Console.WriteLine($"{Book.Id}-{Book.Name}-{Book.Pages}");
```
```csharp
var sum = 4.5;
var count = 3;
var t = (sum, count);
Console.WriteLine($"Sum of {t.count} elements is {t.sum}.");
```
#### Example: Method with Tuple Return
```csharp
var xs = new[] { 4, 7, 9 };
var limits = FindMinMax(xs);
Console.WriteLine($"Limits of [{string.Join(" ", xs)}] are {limits.min} and {limits.max}");
// Output:
// Limits of [4 7 9] are 4 and 9

var ys = new[] { -9, 0, 67, 100 };
var (minimum, maximum) = FindMinMax(ys);
Console.WriteLine($"Limits of [{string.Join(" ", ys)}] are {minimum} and {maximum}");
// Output:
// Limits of [-9 0 67 100] are -9 and 100

(int min, int max) FindMinMax(int[] input)
{
    if (input is null || input.Length == 0)
    {
        throw new ArgumentException("Cannot find minimum and maximum of a null or empty array.");
    }

    var min = int.MaxValue;
    var max = int.MinValue;
    foreach (var i in input)
    {
        if (i < min)
        {
            min = i;
        }
        if (i > max)
        {
            max = i;
        }
    }
    return (min, max);
}
```
