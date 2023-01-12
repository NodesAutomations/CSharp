### IF Else
 ```csharp
      //IF
          int a = 10;
          int b = 20;
          if (a > b)
          {
              Console.WriteLine("A is bigger");
          }
          else
          {
              Console.WriteLine("B is bigger");
          }
```
### Nested If Else
```csharp
int number = 12;

if (number < 5)
{
	Console.WriteLine("{0} is less than 5", number);
}
else if (number > 5)
{
	Console.WriteLine("{0} is greater than 5", number);
}
else
{
	Console.WriteLine("{0} is equal to 5");
}
```

### Switch
### Overview

The switch expression provides for switch-like semantics in an expression context. It provides a concise syntax when the switch arms produce a value. The following example shows the structure of a switch expression. It translates values from an enum representing visual directions in an online map to the corresponding cardinal direction:

### Example

```csharp
int n = 5;
switch (n % 2)
{
    case 0:
        System.Console.WriteLine("Even");
        break;
    default:
        System.Console.WriteLine("Odd");
        break;
}
```
```csharp
public static class SwitchExample
{
    public enum Directions
    {
        Up,
        Down,
        Right,
        Left
    }

    public enum Orientation
    {
        North,
        South,
        East,
        West
    }

    public static void Main()
    {
        var direction = Directions.Right;
        Console.WriteLine($"Map view direction is {direction}");

        var orientation = direction switch
        {
            Directions.Up    => Orientation.North,
            Directions.Right => Orientation.East,
            Directions.Down  => Orientation.South,
            Directions.Left  => Orientation.West,
        };
        Console.WriteLine($"Cardinal orientation is {orientation}");
    }
}
```
        
