Overview
- Struct is value type, so if you create new struct it's value is already assigned by default
- Struct is almost same as class type, it supports access modifiers, constructors, indexers, fields, nested types , operatores and properties.
- Struct Don't support Inheritance like class

### Define new Struct
```csharp
public struct Student {  
    int id;  
    int zipcode;  
    double salary;  
}  
```

### Difference between structs and classes
| structs | classes |
| --- | --- |
| structs are value type | classes are reference type |
| structs are stored in stack or a inline | classes are stored on managed heap |
| structs doesn't support inheritance | classes support inheritance |
| But handing of constructor is different in structs. The complier supplies a default no-parameter constructor, which your are not permitted to replace | Constructors are fully supported in classes |
