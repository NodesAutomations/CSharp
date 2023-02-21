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

### Finding Specific items from list
```csharp
int[] numbers = { 10, 9, 8, 7, 6 };
int firstNumber = numbers.First(); // 10
int lastNumber = numbers.Last(); // 6
int secondNumber = numbers.ElementAt(1); // 9
int secondLowest = numbers.OrderBy(n=>n).Skip(1).First(); // 7
```
### Where method
- The `Where()` method is part of the LINQ extension methods available in C#. It allows you to filter elements from a collection or sequence based on a specified condition, and returns a new collection or sequence that contains only the elements that satisfy the condition.
- Here's the basic syntax of the `Where()` method:
```
var result = collection.Where(element => condition);
```
- where `collection` is the sequence or collection that you want to filter, `element` is a placeholder for each individual element in the collection, and `condition` is the predicate that determines whether or not an element should be included in the result.
```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
var result = numbers.Where(num => num % 2 == 0);
```
- In this example, the lambda expression `num => num % 2 == 0` is the condition that checks whether a number is even or not. The `Where()` method returns a new `IEnumerable<int>` that contains only the even numbers from the original list, which are `2`, `4`, and `6`.

### Find method
- The Find() method is part of the LINQ extension methods available in C#. It allows you to retrieve the first element in a sequence or collection that satisfies a specified condition.
Here's the basic syntax of the Find() method:
```
var result = collection.Find(element => condition);
```
```
List<string> names = new List<string> { "Alice", "Bob", "Amy", "Ben" };
var result = names.Find(name => name.StartsWith("A"));
```
- In this example, the lambda expression `name => name.StartsWith("A")` is the condition that checks whether a name starts with the letter "A". The `Find()` method returns the first element in the `names` list that satisfies the condition, which is the string "Alice".
- Note that the `Find()` method throws an exception if no element in the collection satisfies the condition. If you want to handle this case, you can use the `FirstOrDefault()` method instead, which returns the default value (usually null) if no element is found.

### FindAll method
- The `FindAll()` method is part of the LINQ extension methods available in C#. It allows you to retrieve all elements in a sequence or collection that satisfy a specified condition, and returns a new collection that contains only those elements.
- Here's the basic syntax of the `FindAll()` method:

```
var result = collection.FindAll(element => condition);
```
```
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
var result = numbers.FindAll(num => num % 2 == 0);
```
In this example, the lambda expression `num => num % 2 == 0` is the condition that checks whether a number is even or not. The `FindAll()` method returns a new `List<int>` that contains only the even numbers from the original list, which are `2`, `4`, and `6`.

### Difference between FindAll and Where Method
- Return Type: Where() method returns IEnumerable<T> while FindAll() returns a List<T>
- Method Chaining: `Where()` can be chained with other methods like `Select()` and `OrderBy()` etc, while `FindAll()` does not support chaining with other LINQ methods.
