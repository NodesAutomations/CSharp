## Enums

Enums are really useful if you want to, well, enumerate the possible values for a field. An example of enumeration is the list of movie genres:

```csharp
public enum MovieGenre
{
    Action,
    Comedy,
    Drama,
    Musical,
    Thriller,
    Horror
}
public class Movie
{
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public MovieGenre Genre { get; set; }
}
new Movie()
{
    Name = "My movie",
    ReleaseDate = DateTime.Now,
    Genre = MovieGenre.Drama
};
```

## Flagged enums

What if an enum fields must allow multiple values? After all, a movie can have more than one genre, right?

You could implement it as a list (or an array) of flags, or... you can use the **Flags attribute**. This flag allows to easily apply OR operations on enums, making the code cleaner and more readable. The downside is that now enums values can't have custom values, but **must be a power of 2**, so 1, 2, 4, 8 and so on.

```csharp
[Flags]
public enum MovieGenre
{
    Action = 1,
    Comedy = 2,
    Drama = 4,
    Musical = 8,
    Thriller = 16,
    Horror = 32
}
```

So now we can create an action-comedy movie

```csharp
var movie = new Movie()
{
    Name = "Bad Boys",
    ReleaseDate = new DateTime(1995, 4, 7),
    Genre = MovieGenre.Action | MovieGenre.Comedy
};
```

Now that you have flags on enums, whatcha gonna do? You can use the HasFlag method to, well, check if a value has a certain flag

```csharp
MovieGenre mg = MovieGenre.Action | MovieGenre.Comedy;

if (mg.HasFlag(MovieGenre.Comedy))
{
    // Do something
}
```

This is more performant than looping though a list of enums, since now we're working directly on bits.

## Enums combination within the definition

If you set each element's value as a power of 2, like you did for Flags

```csharp
enum Beverage
{
    Water = 1,
    Beer = 2,
    Tea = 4,
    RedWine = 8,
    WhiteWine = 16
}
```

you can write something like

```csharp
var beverage = Beverage.RedWine | Beverage.WhiteWine;

if(beverage.HasFlag(Beverage.RedWine) || beverage.HasFlag(Beverage.WhiteWine)){
    Console.WriteLine("This is wine");
}
```

Now imagine that you have to check many times if a beverage is a wine: you can repeat the check, or extract it to a separate method.

Or you can add a value to the enum:

```csharp
[Flags]
enum Beverage
{
    Water = 1,
    Beer = 2,
    Tea = 4,
    RedWine = 8,
    WhiteWine = 16,
    Wine = RedWine | WhiteWine
}
```

This simplifies your code to

```csharp
var beverage = Beverage.RedWine | Beverage.WhiteWine;

if(beverage.HasFlag(Beverage.Wine)){
    Console.WriteLine("This is wine");
}
```

## **Enum best practices**

As always, there are some best practices to follow. The following ones are suggested directly on the [Microsoft documentation](https://docs.microsoft.com/en-us/dotnet/api/system.enum?view=netcore-3.1#enumeration-best-practices):

1. If you have a default value for the enumeration, set its value to 0;
2. If there isn't an obvious default value, create a value (set to 0) that represents the fallback case (for example, create a *None* value and set it to 0);
3. Validate inputs for methods that allow enums as parameters, since enums are nothing but numbers, so a simple cast can cause unexpected results;

Let me explain the third point: do you remember the *Status* enum?

Here's a method that tells if the input is valid:

```csharp
string printValidity(Status status){
    switch (status)
    {
        case Status.Failed:  
        case Status.OK:  
        case Status.Waiting:
            return "Valid input";
        default:
            return "Invalid input";
    }
}
```

and well, you can imagine how it works.

What happens if you do this?

```csharp
var validity = printValidity((Status) 1234);
```

Exactly, the value is Invalid input. So, remember to validate inputs!

## **Conclusion**

In this article, we've seen that

- enums are just numbers in disguise;
- you can format an enum as a string, a hexadecimal value or a numeric value;
- you can use flags to define multiple values;
- you should follow best practices: remember to define a default value and to validate inputs;
