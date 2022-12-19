### Find Items from List
```csharp
//Create New List
var books = new List<String> { "The Way of Kings", "Words of Radiance", "Oathbringer", "Rhythm of War" };

//Find Item from List using Item Name
int id = books.IndexOf("Oathbringer");

Console.WriteLine(books[id]);

//Find Item using Linq Quary
var result =books.Find(x=>x.Contains("Kings"));

Console.WriteLine(result);
```
