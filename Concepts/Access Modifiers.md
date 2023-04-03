### What is Access Modifiers?

- It's Way to Control Access to Class and it's members
- In C#, access modifiers specify the accessibility of types (classes, interfaces, etc) and type members (fields, methods, etc)1. C# provides four types of access modifiers: private,public,protected,internal
- Each of these access modifiers provides a different level of accessibility and visibility, and we can use them to control the behavior of our classes and objects.
- The protected access modifier in C# is used to specify that access is limited to the containing type or types derived from the containing class, so the type or member can only be accessed by code in the same class or in a derived class.

### Why?

- **Encapsulation**
- Provide Safety in a program
- This will used to hide implementation details from user which is one of main point of Object oriented programming

### Example

```csharp
public class Person
    {
        private string Name;

        public Person()
        {
            this.Name = "Vivek";
        }

        public string GetName()
        {
            return Name;
        }
    }
```

In above code we can't get access to Name Field because it is private Variable if We need to retrieve value of Name Variable we need to use GetName Method.
