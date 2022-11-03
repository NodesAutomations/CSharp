### What?

Sealed classes are used to restrict the inheritance feature of object oriented programming. Once a class is defined as a sealed class, this class cannot be inherited.

### Why?

Sealed classes are used to restrict the inheritance feature of object oriented programming. Once a class is defined as a sealed class, this class cannot be inherited.

### Features

1. Sealed class can be instantiated.
2. It can inherit from other classes.
3. It cannot be inherited.

### Example

Consider the following example in which class SealedClass inherited from class BaseClass but as we have marked SealedClass sealed using `sealed` modifier, it cannot be used as a base class by other classes.

```csharp
Class BaseClass  
{  
  
}   
sealed class SealedClass : BaseClass  
{  
  
}
```

```csharp
using System;  
class Class1  
{  
    static void Main(string[] args)  
    {  
        SealedClass sealedCls = new SealedClass();  
        int total = sealedCls.Add(4, 5);  
        Console.WriteLine("Total = " + total.ToString());  
    }  
}  
// Sealed class  
sealed class SealedClass  
{  
    public int Add(int x, int y)  
    {  
        return x + y;  
    }  
}
```

You can also use the sealed modifier on a method or a property that overrides a virtual method or property in a base class. This enables you to allow classes to derive from your class and prevent other developers that are using your classes from overriding specific virtual methods and properties.

```csharp
class X  
{  
    protected virtual void F()  
    {   
        Console.WriteLine("X.F");   
    }  
    protected virtual void F2()  
    {  
        Console.WriteLine("X.F2");   
    }  
}  
class Y : X  
{  
    sealed protected override void F()  
    {  
        Console.WriteLine("Y.F");  
    }  
    protected override void F2()  
    {  
        Console.WriteLine("X.F3");  
    }  
}  
class Z : Y  
{  
    // Attempting to override F causes compiler error CS0239.  
    //   
    protected override void F()  
    {  
         Console.WriteLine("C.F");   
    }  
    // Overriding F2 is allowed.   
    protected override void F2()  
    {  
        Console.WriteLine("Z.F2");   
    }  
}
```
