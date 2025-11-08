### What?

An abstract class is an incomplete class or special class we can't be instantiated. The purpose of an abstract class is to provide a blueprint for derived classes and set some rules what the derived classes must implement when they inherit an abstract class.

**The purpose of an abstract class is to provide a common definition of the base class that multiple derived classes can share and can be used only as a base class and never want to create the object of this class.** Any class can be converted into an abstract class by adding the abstract modifier to it.

We can use an abstract class as a base class and all derived classes must implement abstract definitions. An abstract method must be implemented in all non-abstract classes using the override keyword. After overriding the abstract method is in the non-Abstract class. We can derive this class in another class and again we can override the same abstract method with it.

### C# Abstract Class Features

- An abstract class can inherit from a class and one or more interfaces.
- An abstract class can implement code with non-Abstract methods.
- An Abstract class can have modifiers for methods, properties etc.
- An Abstract class can have constants and fields.
- An abstract class can implement a property.
- An abstract class can have constructors or destructors.
- An abstract class cannot be inherited from by structures.
- An abstract class cannot support multiple inheritance.

### Example

```csharp
abstract class Demo
    {
        public int Int1 { get; set; } //Non Abstract property  

        public abstract int Int2  //Abstract Property  
        {
            get;
            set;
        }

        public Demo()  //Constructor  
        {
            Console.WriteLine("Demo Constructor");
        }

        public void Method1()   //Non Abstract Method  
        {
            Console.WriteLine("Demo Method1");
        }

        public abstract void Method2();  //Abstract Method  

        ~Demo()  //Destructor  
        {
            Console.WriteLine("Demo Destructor");
        }

    }

    class Drived : Demo
    {
        public int Val;
        public override int Int2
        {
            get
            {
                return Val;
            }
            set
            {
                Val = value;
            }
        }

        public override void Method2()
        {
            Console.WriteLine("Drived Method2");
        }
    }
    class Program
    {
        static unsafe void Main(string[] args)
        {

            Drived Dr = new Drived();
            Dr.Int1 = 10;
            Dr.Int2 = 20;
            Dr.Method1();
            Dr.Method2();
            Console.ReadLine();
        }

    }
```
