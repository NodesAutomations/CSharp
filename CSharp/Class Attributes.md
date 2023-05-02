C# Class Attributes are a way of associating metadata, or declarative information, with code elements such as classes, methods, properties, etc. They can be used to provide additional information or functionality to the code elements. For example, you can use the [Obsolete] attribute to mark a code element as obsolete and generate a warning if it's used¹.

To define an attribute, you need to create a class that inherits from the **System.Attribute** base class¹³. You can then apply the attribute to a code element by placing the name of the attribute enclosed in square brackets ([]) above the declaration of the element¹². For example:

```csharp
[Obsolete]
public class MyClass { }
```

You can also specify arguments for the attribute by using parentheses after the attribute name. For example:

```csharp
[Obsolete("This class is deprecated")]
public class MyClass { }
```

You can use reflection to access the attributes attached to a code element at run time. Reflection provides objects (of type **Type**) that describe assemblies, modules, and types. You can use reflection to dynamically create an instance of a type, bind the type to an existing object, or get the type from an existing object and invoke its methods or access its fields and properties². For example:

```csharp
// Using reflection to get the attributes of a class
Type type = typeof(MyClass);
object[] attributes = type.GetCustomAttributes(true);
foreach (object attribute in attributes)
{
    Console.WriteLine(attribute);
}
```

This will print:

```console
System.ObsoleteAttribute
```

There are many built-in attributes in .NET that provide various features and functionalities. Some common ones are:

- [Serializable]: Indicates that a class can be serialized¹.
- [Conditional]: Specifies that a method call or attribute should be ignored unless a specified conditional compilation symbol is defined¹.
- [DllImport]: Indicates that a method should be implemented by an external DLL².
- [Obsolete]: Marks a program entity as obsolete and generates a warning or an error when it's used¹.
- [Required]: Specifies that an argument must be provided for a parameterless constructor when an attribute is applied to a type³.

You can also create your own custom attributes by defining an attribute class and applying it to your code elements. For more information on how to do that, you can refer to this tutorial¹.

