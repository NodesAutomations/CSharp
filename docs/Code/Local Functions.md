Local functions in C# allow you to declare functions inside other functions, also known as the containing function. These local functions are only accessible within the containing function and can't be accessed outside of it.

Here's an example of a local function in C#:
```csharp
void ContainingFunction()
{
    int x = 10;

    void LocalFunction()
    {
        Console.WriteLine("The value of x is: " + x);
    }

    LocalFunction();
}
```
In this example, the `ContainingFunction()` contains a local function called `LocalFunction()`. The `LocalFunction()` accesses the variable `x` from the containing function, and then prints out the value of `x` to the console.

When `ContainingFunction()` is called, it will execute the `LocalFunction()` by calling it inside the containing function. The output to the console would be "The value of x is: 10".

Local functions can be useful for reducing code duplication and improving code organization, especially when the same code is needed multiple times within a function. They can also help make the code more readable and easier to understand.
