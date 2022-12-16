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
