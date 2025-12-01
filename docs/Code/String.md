# C# String Methods Guide

## Searching and Checking

### Contain
```csharp
// Contains - Checks if a substring exists within the string
string text = "Hello World";
bool hasWorld = text.Contains("World"); // true
bool hasJava = text.Contains("Java"); // false
```
### StartsWith
```csharp
// StartsWith - Checks if string begins with specified text
string text = "Hello World";
bool startsWithHello = text.StartsWith("Hello"); // true
bool startsWithHi = text.StartsWith("Hi"); // false
```
### EndsWith
```csharp
// EndsWith - Checks if string ends with specified text
string text = "Hello World";
bool endsWithWorld = text.EndsWith("World"); // true
bool endsWithEarth = text.EndsWith("Earth"); // false
```
### IndexOf
```csharp
// IndexOf - Returns the zero-based position of first occurrence
string sentence = "The quick brown fox jumps over the lazy dog";
int pos = sentence.IndexOf("fox"); // 16
int notFound = sentence.IndexOf("cat"); // -1
```
### LastIndexOf
```csharp
// LastIndexOf - Returns position of last occurrence
string repeated = "hello world hello";
int lastPos = repeated.LastIndexOf("hello"); // 12
```
## Modifying Strings

### Replace
```csharp
// Replace - Replaces all occurrences of a substring
string original = "I like cats and cats like me";
string replaced = original.Replace("cats", "dogs");
// "I like dogs and dogs like me"
```
### Remove
```csharp
// Remove - Removes characters starting at specified position
string phrase = "Hello World";
string removed = phrase.Remove(5, 6); // "Hello" (removes " World")
```

## Extracting and Splitting

### Substring
```csharp
// Substring - Extracts a portion of the string
string fullText = "Hello World";
string sub1 = fullText.Substring(0, 5); // "Hello"
string sub2 = fullText.Substring(6); // "World"
```

### Split
```csharp
// Split - Divides string into array based on delimiter
string csv = "apple,banana,orange";
string[] fruits = csv.Split(',');
// ["apple", "banana", "orange"]
```

### Format

```csharp
// Format - Static method for formatted string creation
string formatted = string.Format("Hello {0}, you are {1} years old", "Alice", 25);
// "Hello Alice, you are 25 years old"
```

C# String.Format() method formats strings in a desired format by inserting objects and variables with specified space and alignments into other strings. It is often used to also format strings into specific formats.

String.Format() manages formatting including the position, alignment, and format type. String.Format method has 8 overloaded formats to provide options to format various objects and variables that allows various variables to format strings. The simplest form of String.Format is the following:

```
String.Format("{index[,alignment][:formatString]}", **object**);
```

Where,

- index - The zero-based index of the argument whose string representation is to be included at this position in the string. If this argument is null, an empty string will be included at this position in the string.
- alignment - Optional. A signed integer that indicates the total length of the field into which the argument is inserted and whether it is right-aligned (a positive integer) or left-aligned (a negative integer). If you omit alignment, the string representation of the corresponding argument is inserted in a field with no leading or trailing spaces.
- If the value of alignment is less than the length of the argument to be inserted, alignment is ignored and the length of the string representation of the argument is used as the field width.
- formatString - Optional. A string that specifies the format of the corresponding argument's result string. If you omit formatString, the corresponding argument's parameterless ToString method is called to produce its string representation. If you specify formatString, the argument referenced by the format item must implement the IFormattable interface.

### Alignment and spacing

By default, strings are right-aligned within their field if you specify a field width. To left-align strings in a field, you preface the field width with a negative sign, such as {0,-12} to define a 12-character right-aligned field.

### Example

```csharp
using System;
using System.Collections.Generic;

namespace ConsoleAppTest
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var emp = new List<Employee>()
            {
                new Employee(1,"Vivek","CEO"),
                new Employee(2,"Deven","Designer"),
                new Employee(3,"Dhruv","Research")
        };
            System.Console.WriteLine("Employee List");
            Console.WriteLine($"{nameof(Employee.Id),-5}{nameof(Employee.Name),-10}{nameof(Employee.Dept)}");
            foreach (var item in emp)
            {
                Console.WriteLine($"{item.Id,-5}{item.Name,-10}{item.Dept,-10}");
            }

            Console.ReadKey();
        }
    }

    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Dept { get; set; }

        public Employee(int id, string name, string dept)
        {
            Id = id;
            Name = name;
            Dept = dept;
        }
    }
}

```

Output

```
Employee List
Id   Name      Dept
1    Vivek     CEO
2    Deven     Designer
3    Dhruv     Research
```
