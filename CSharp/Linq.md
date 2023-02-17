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
![image](https://user-images.githubusercontent.com/60865708/219751222-d7fce921-2262-4690-9a22-12f9b333b3f5.png)
