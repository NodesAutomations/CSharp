### Basics
- Tuples Type Provide way to group multiple Data elements into light weight structure

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
