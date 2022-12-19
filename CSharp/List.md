## Basic Syntax

```csharp
 //Create New List
var books = new List<String> { "The Way of Kings", "Words of Radiance","Oathbringer","Rhythm of War" };
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
