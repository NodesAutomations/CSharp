### What ?

- It's Variable That we Declare At Class Level

### Why?

- To Store Data About Class

### Read Only Fields

- we can declare field with readonly Modifier to make sure that , that field only assign once
- This will provide some safety or robustness to that class

<aside>
✏️ When Using Field which require Initialization, Don't use Empty Constructor for Initialization instead use `private readonly List<string> Hobbies = new List<string>();` for Initialization That way this field only initialize when Needed instead everytime user create new instance.

</aside>

### Example

```csharp
public class Person
    {
        public static int PeopleCount = 0;
        public string Name;
        public readonly int Id;
        public readonly List<string> Hobbies = new List<string>();

        //This is Constor
        //By Default every Person Object is initiated with Name:"Vivek"
        public Person()
        {
            this.Name = "Vivek";
            this.Id = PeopleCount + 1;
         
        }

        //Constructor with Input Parameter
        //this() command will Call Constuctor with empty parameters first
        public Person(string name) : this()
        {
            this.Name = name;//this referes to Active instance
        }

        public Person(int id, string name) : this(name)
        {
            this.Id = id;
            this.Name = name;//this referes to Active instance
        }

        public void Introduce()
        {
            Id = Id + 1;
            Console.WriteLine($"Hello My Name is {this.Id} {this.Name} {this.Hobbies[0]}");
          
        }
    }
//Error on Introduce Method
//A readonly field cannot be assigned to (except in a constructor or a variable initializer)
```
