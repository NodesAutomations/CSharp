### What is object Initializer?

It is syntax for quickly initialize object without  the need to call one of the constructor.

### Why Do we that?

To avoid Creating multiple constructor.

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
```

Here in Above example we have three constructor which will increase in number with more properties. To Avoid these constructor we can use object initializers. Below code require no Constructor call to initialize object Property.

 

```csharp
var p = new Person { Id = 1, Name = "test" };
            p.Introduce();
```
