<aside>
💡 Using will automatically dispose object when everything in it's block gets executed

</aside>

Provides a convenient syntax that ensures the correct use of IDisposable objects.

```csharp
string manyLines=@"This is line one
This is line two
Here is line three
The penultimate line is line four
This is the final, fifth line.";

using (var reader = new StringReader(manyLines))
{
    string? item;
    do {
        item = reader.ReadLine();
        Console.WriteLine(item);
    } while(item != null);
}
```

Beginning with C# 8.0, you can use the following alternative syntax for the using statement that doesn't require braces:

```csharp
string manyLines=@"This is line one
This is line two
Here is line three
The penultimate line is line four
This is the final, fifth line.";

using var reader = new StringReader(manyLines);
string? item;
do {
    item = reader.ReadLine();
    Console.WriteLine(item);
} while(item != null);
```
