### Singature of Method

- Name of Method
- Number and Type of it's parameters
- In below code Point Class include Method : Move with x,y as it's parameter that is signature of that method

```csharp
public class Point
    {
        public void Move(double x,double y) { }    
    }
```

### Method Overloading

- In below code snippet we have move method with 2 different signatures this is called method overloading
- Compiler will automatically pick Right method based on input parameters

```csharp
public class Point
    {
        public void Move(double x,double y) { }
        public void Move(Point newLocation) { }

    }
```

### Method with Varying number of parameters

- Example 1 : here we have Add method with multiple signature, as you can see this is not Practical or efficient
- Example 2 : we have Add method with Array input which is better than first one but every time we need to use method we have to initiate array which is annoying
- Example 3 : Here we have Add method with Array but `params` modifier  Which lets us put as many inputs as we like without initializing array

```csharp
//Example 1
public class Calculator
    {
        public int Add(int n1, int n2) { }
        public int Add(int n1, int n2,int n3) { }
        public int Add(int n1, int n2,int n3,int n3) { }
    }

//Example 2
public class Calculator
    {
        public int Add(int[] numbers) { }
    }
//We use this var results=Calculator.Add(new int[]{1,2,3,4)});
//Example 3
public class Calculator
    {
        public int Add(params int[] numbers) { }
    }
//We use this var results=Calculator.Add(1,2,3,4);
```

### The Ref Modifier

- Here when we pass variable a to MyMethod value of a will remain same because a is value type and when we pass that to MyMethod it only gets copy of value a
- in DoThings method we are pasing var a as reference so value of a will get updated everytime we use that method

```csharp
public class MyClass
    {
       public void MyMethod(int a)
        {
            a += 2;
        }
			 public void DoThings(ref int a)
        {
            a += 2;
        }
    }
    var a = 1;
    a = MyClass.MyMethod(a);//value of a will remain same after this method
		a = MyClass.DoThings(ref a);//ref of a get pass to DoThings so a value will change
```
### Virtual Method
### Overview
For every object ToString() ,GetHashCode(),Equals() and GetType() Method is virtual methods
A virtual method is a method that can be redefined in derived classes. A virtual method has an implementation in a base class as well as derived the class. It is used when a method's basic functionality is the same but sometimes more functionality is needed in the derived class. A virtual method is created in the base class that can be overriden in the derived class. We create a virtual method in the base class using the `virtual` keyword and that method is overriden in the derived class using the `override` keyword.

When a method is declared as a virtual method in a base class then that method can be defined in a base class and it is optional for the derived class to override that method. The overriding method also provides more than one form for a method. Hence it is also an example for polymorphism.

### Virtual Method in C#

- By default, methods are non-virtual. We can't override a non-virtual method.
- We can't use the virtual modifier with the static, abstract, private or override modifiers.

### Example

```csharp
using System;  
  
namespace VirtualExample  
{     
    class Shape  
    {     
       public double length=0.0;  
       public double width =0.0;  
       public double radius =0.0;   
  
       public Shape(double length, double width)  
       {  
           this.length = length;  
           this.width = width;            
       }  
  
       public Shape(double radius)  
       {  
           this.radius = radius;  
       }  
  
       public  virtual void Area()  
       {            
           double area = 0.0;  
           area = Math.PI * Math.Pow(radius, 2);  
           Console.WriteLine("Area of Shape is :{0:0.00} ", area);  
       }  
    }   
  
    class Rectangle  : Shape  
    {  
  
        public Rectangle(double length, double width): base(length, width)  
        {  
        }      
  
        public override void Area()  
        {  
            double area = 0.0;  
            area = length * width;  
            Console.WriteLine("Area of Rectangle is :{0:0.00} ", area);  
        }  
    }  
     class Circle : Shape  
    {  
        public Circle(double radius)  
            : base(radius)  
        {  
        }  
    }    
  
    class Program  
    {  
        static void Main(string[] args)  
        {  
             double length,width,radius=0.0;  
             Console.WriteLine("Enter the Length");  
             length = Double.Parse(Console.ReadLine());  
             Console.WriteLine("Enter the Width");  
             width = Double.Parse(Console.ReadLine());  
             Rectangle objRectangle = new Rectangle(length, width);  
              objRectangle.Area();  
             Console.WriteLine("Enter the Radius");  
             radius = Double.Parse(Console.ReadLine());  
             Circle objCircle = new Circle(radius);  
             objCircle.Area();  
            Console.Read();  
        }         
    }  
}
```

### Abstract methods
In C#, an abstract method is a method that does not have a body and is declared with the abstract keyword1. An abstract method can only be present inside an abstract class. If a class contains an abstract method, then it must be declared as an abstract class. An abstract class can have both abstract and non-abstract methods.

An abstract method can be overridden by the derived class. When an abstract class inherits a virtual method from a base class, the abstract class can override the virtual method with an abstract method.

