### Basic Syntax
```csharp
Dictionary<int,string> books= new Dictionary<int,string>();
books.Add(1, "The Way of Kings");
books.Add(2,"Words or Radiance");
books.Add(3, "Oathbringer");
books.Add(4,"Rhythm of War");

//Loop through each item 
foreach (var book in books)
{
    Console.WriteLine( $"{book.Key},{book.Value}" );
}
           
//Loop using Unique ID
for (int i = 1; i < books.Count+1; i++)
{
    Console.WriteLine($"{i},{books[i]}");
}

//Loop Using Index + Linq
for (int i = 0; i < books.Count; i++)
{
    var book = books.ElementAt(i);
    Console.WriteLine($"{book.Key},{book.Value}");
}
```
### Find Key in Dictionary
```csharp
if (!AuthorList.ContainsKey("Mahesh Chand"))
{
    AuthorList["Mahesh Chand"] = 20;
}
```

### Find Value in Dictionary
```csharp
if (!AuthorList.ContainsValue(9))
{
    Console.WriteLine("Item found");
}
```
