### Chaining Query Operators
```csharp
 private static void Main()
{
    string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
    IEnumerable<string> query = names
    .Where(n => n.Contains("a"))//Filter
    .OrderBy(n => n.Length)//Sort
    .Select(n => n.ToUpper());//Convert

    foreach (string name in query)
    {
        Console.WriteLine(name);
    }
    Console.ReadLine();
}
```
