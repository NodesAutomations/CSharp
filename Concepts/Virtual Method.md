<aside>
💡 For every object ToString() ,GetHashCode(),Equals() and GetType() Method is virtual methods

</aside>

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
