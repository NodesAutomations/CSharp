## Overview

**C# HashSet is an unordered collection of the unique elements.** It was introduced in .NET 3.5 and is found in `System.Collections.Generic` namespace. It is used in a situation where we want to prevent duplicates from being inserted in the collection. **As far as performance is concerned, it is better in comparison to the list.** 

 
>> 📢 Note that the HashSet<T>.Add(T item) method returns a bool -- true if the item was added to the collection; false if the item was already present.
 

```csharp
namespace HashSetDemo {  
    class Program {  
        static void Main(string[] args) {  
            HashSet < string > names = new HashSet < string > {  
                "Rajeev",  
                "Akash",  
                "Amit"  
            };  
            foreach(var name in names) {  
                Console.WriteLine(name);  
            }  
            Console.ReadKey();  
        }  
    }  
}

//Output
Rajeev
Akash
Amit
```
