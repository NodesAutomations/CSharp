# What?

A static class is very similar to a non-static class, however there's one difference: **a static class can’t be instantiated**. In different words, you cannot use the new keyword to make a variable of that class type. As a result, there's no instance variable, you access the static class members by using class name.

```csharp
public static class MathUtility  
{  
    public static int Add(int a, int b)  
    {  
        return a + b;  
    }  
}
//We can call it in the following way:
int result = MathUtility.Add(2,5);
```

A static class will be used as a convenient instrumentation for a set of ways that simply treat input parameters and don't get or set any internal instance fields. For example, in the .NET Framework class Library, the static `System.Math` class contains functions / methods that perform mathematical operations, with none of them demand to store or retrieve knowledge that's distinctive to a specific instance of the Math class.

# Features of Static Class

1. It can only have static members.
2. It cannot have instance members as static class instance cannot be created.
3. **It is a [sealed class](https://www.notion.so/C-Sealed-Class-df74384285714e708753c3f8823cf844).**
4. **As static class is sealed, so no class can inherit from a static class**.
5. We cannot create instance of static class that's the reason we cannot have instance members in static class, as **static means shared so one copy of the class is shared to all**.
6. Static class also **cannot inherit from other classes**.
