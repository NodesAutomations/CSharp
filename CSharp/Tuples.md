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
