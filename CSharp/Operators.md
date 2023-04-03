## Arithmetic Operators

- Add `+`
- Subtract `-`
- Multiply`*`
- Divide `/`
- Remainder `%`
- increment `++`
- Decrement `--`

### Post Fix Increment

```csharp
int a=1;
int b=a++ ;//here first b gets value of a then a get incremented

//Output
//a=2,b=1
```

### Pre Fix Increment

```csharp
int a=1;
int b=++a; //here first a gets incremented then value of a get assign to b

//Output
//a=2,b=2
```

## Comparison Operators

- Equal `=`
- Not Equal `!=`
- Greater Than `>`
- Greater or Equal to `>=`
- Less Than `<`
- Less or Equal to `<=`

## Assignment Operators

- Assignment `=`
- Addition Assignment `+=`
- Subtraction Assignment `-+`
- Multiplication Assignment `*=`
- Division Assignment `/=`

## Logical Operators

- And `&&`
- Or `||`
- Not `!`

### Ternary operator (?:)

- Condition ? valueIfTrue : valueIfFalse
- Assign one value if true and the other if false

### Null-conditional operator (?.)
- To call or not to call?
- Call if not null
- Doesn’t work for assignments
In C#, you can use the null-conditional operator (?.) to check for null before accessing a member⁴. 

For example, if you have an object called `person` and you want to check if the `Name` property is null before accessing it, you can use the following code:

```
string name = person?.Name;
```

This will assign `null` to `name` if `person` is null, otherwise it will assign the value of `person.Name` to `name`.

### Null Forgiving Operator(!)

Available in C# 8.0 and later, the unary postfix ! operator is the null-forgiving operator. In an enabled nullable annotation context, you use the null-forgiving operator to declare that expression x of a reference type isn't null: x!. The unary prefix ! operator is the logical negation operator.

### Null-Coalescing operator(??)(??=)

- Value ?? defaultValue
- Take the value as-is if not null or use a default value (left of ??)
- Available in C# 8.0 and later, the null-coalescing assignment operator ??= assigns the value of its right-hand operand to its left-hand operand only if the left-hand operand evaluates to null. The ??= operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null.

### Lamda (=>) operator

In lambda expressions, the lambda operator => separates the input parameters on the left side from the lambda body on the right side.

```csharp
string[] words = { "bot", "apple", "apricot" };
int minimalLength = words
  .Where(w => w.StartsWith("a"))
  .Min(w => w.Length);
Console.WriteLine(minimalLength);   // output: 5

int[] numbers = { 4, 7, 10 };
int product = numbers.Aggregate(1, (interim, next) => interim * next);
Console.WriteLine(product);   // output: 280
```

### Expression body definition (=>) operator

```csharp
member => expression;
```

The following example shows an expression body definition for a Person.ToString method:

```csharp
public override string ToString() => $"{fname} {lname}".Trim();
```

It's a shorthand version of the following method definition:

```csharp
public override string ToString()
{
   return $"{fname} {lname}".Trim();
}
```

### Nullable value types

Any nullable value type is an instance of the generic System.Nullable<T> structure. You can refer to a nullable value type with an underlying type T in any of the following interchangeable forms: Nullable<T> or T?.

You typically use a nullable value type when you need to represent the undefined value of an underlying value type. For example, a Boolean, or bool, variable can only be either true or false. However, in some applications a variable value can be undefined or missing. For example, a database field may contain true or false, or it may contain no value at all, that is, NULL. You can use the bool? type in that scenario.

### property initializers

If only we could set initial values to properties without going to a constructor…

```csharp
public string Name { get; set; } = "Joe";
public string Name { get; } = "Joe";
```

### Pattern Matching

Patterns test that a value has a certain shape, and can extract information from the value when it has the matching shape. Pattern matching provides more concise syntax for algorithms you already use today.

```csharp
public static double ComputeArea(object shape)
{
    if (shape is Square)
    {
        var s = (Square)shape;
        return s.Side * s.Side;
    }
    else if (shape is Circle)
    {
        var c = (Circle)shape;
        return c.Radius * c.Radius * Math.PI;
    }
    // elided
    throw new ArgumentException(
        message: "shape is not a recognized shape",
        paramName: nameof(shape));
}
public class Square
{
    public double Side { get; }

    public Square(double side)
    {
        Side = side;
    }
}
public class Circle
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }
}
public struct Rectangle
{
    public double Length { get; }
    public double Height { get; }

    public Rectangle(double length, double height)
    {
        Length = length;
        Height = height;
    }
}
public class Triangle
{
    public double Base { get; }
    public double Height { get; }

    public Triangle(double @base, double height)
    {
        Base = @base;
        Height = height;
    }
}
```

```csharp
public static string GenerateMessage(params string[] parts)
{
    switch (parts.Length)
    {
        case 0:
            return "No elements to the input";
        case 1:
            return $"One element: {parts[0]}";
        case 2:
            return $"Two elements: {parts[0]}, {parts[1]}";
        default:
            return $"Many elements. Too many to write";
    }
}
```
