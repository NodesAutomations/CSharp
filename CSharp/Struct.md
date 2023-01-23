Overview
- Struct is value type, so if you create new struct it's value is already assigned by default
- Struct is almost same as class type, it supports access modifiers, constructors, indexers, fields, nested types , operatores and properties.
- Struct Don't support Inheritance like class

### Sample Code
```csharp
using System;
namespace CsharpStruct {
 
  // defining struct
  struct Employee {
    public int id;

    public void getId(int id) {
      Console.WriteLine("Employee Id: " + id);
    }
  }
 
  class Program {
    static void Main(string[] args) {
 
      // declare emp of struct Employee
      Employee emp;
      
      // accesses and sets struct field
      emp.id = 1;

      // accesses struct methods
      emp.getId(emp.id);

      Console.ReadLine();
    }
  }
}
```
- We can also instantiate a struct using the new keyword
### Difference between structs and classes
| structs | classes |
| --- | --- |
| structs are value type | classes are reference type |
| structs are stored in stack or a inline | classes are stored on managed heap |
| structs doesn't support inheritance | classes support inheritance |
| But handing of constructor is different in structs. The complier supplies a default no-parameter constructor, which your are not permitted to replace | Constructors are fully supported in classes |
