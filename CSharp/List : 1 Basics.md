### Basic Syntax

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
### Remove Items from list or Remove item from specific Index
```csharp
//Create New List
var books = new List<String> { "The Way of Kings", "Words of Radiance", "Oathbringer", "Rhythm of War" };

//Remove Item from List
books.Remove("Oathbringer");

//Remove First Item
books.RemoveAt(0);

//Remove Range
books.RemoveRange(0, 1);

//Remove All
books.Clear();
```

### Loop Through List Items
```csharp
//Create New List
var books = new List<String> { "The Way of Kings", "Words of Radiance", "Oathbringer", "Rhythm of War" };

//Loop Through List Items 
foreach (var book in books)
{
    Console.WriteLine(book);
}

//Loop using Index
for (int i = 0; i < books.Count; i++)
{
    Console.WriteLine(books[i]);
}
```
