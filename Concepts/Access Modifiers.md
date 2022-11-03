### What is Access Modifiers?

- It's Way to Control Access to Class and it's members

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
