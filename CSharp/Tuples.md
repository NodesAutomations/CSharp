### Basics
- Tuples Type Provide way to group multiple Data elements into light weight structure
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
