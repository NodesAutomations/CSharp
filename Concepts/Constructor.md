### What is Constructor?

Constructor is method in class is called when instance of class is Created

### Why We need Constructor?

- Initialize some of field in Class
- To Put object in Early State
- Provide Multiple Way to initialize new Object

### Example

```csharp
public class Person
    {
        public static int PeopleCount = 0;
        public string Name;
        public int Id;

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
            Console.WriteLine($"Hello My Name is {this.Id} {this.Name}");
        }
    }
```

### Constructor Overloading

- Overloading means methods with Same name but with different signatures
- Overloading works with any method or function
- When we use Overloading with Constructor it is called Constructor Overloading

<aside>
✏️ **Note :** Calling Constructor from another constructor is generally bad practice because it will create methods with multiple dependency. If you need to initiate any list or class object just initiate in empty constructor and call empty construct only in all constructor to avoid repetitive code.

</aside>
