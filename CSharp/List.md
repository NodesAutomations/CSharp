## Basic Syntax

```csharp
 //Create New List
var books = new List<String> { "The Way of Kings", "Words of Radiance","Oathbringer","Rhythm of War" };
```

### Add New Item or New List
```csharp
//Create New List
var books = new List<String> { "The Way of Kings", "Words of Radiance", "Oathbringer", "Rhythm of War" };

//Add new Items
books.Add("Skyward");

//Add item at Specific Position
// List Start at 0
books.Insert(0,"Mistborn");

//2nd List
var funBooks = new List<string> { "Cradle","Mother of Learning","Poppy War"};

//Add one List to another
books.AddRange(funBooks);

//3rd List
var selfHelpBooks = new List<string> { "Atomic Habits", "Power of Habits" };

//Insert new list at start
books.InsertRange(0, selfHelpBooks);
```

### Loop Through List Items
```csharp
//Create New List
var books = new List<String> { "The Way of Kings", "Words of Radiance","Oathbringer","Rhythm of War" };

//Loop Through List Items
foreach (var book in books)
{
    Console.WriteLine(book);
}
```

## Linq Quaries

### Find Specific Item From List

```csharp
var names = new List<string> { };
names.Add("Vivek");
names.Add("Nodes Automations");

foreach (var name in names)
{
    Console.WriteLine(name);
}

Console.WriteLine(names.Find(x => x.Contains("V")));
```
