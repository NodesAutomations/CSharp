The `Main` method is the entry point of a C# application. (Libraries and services do not require a `Main` method as an entry point.) When the application is started, the `Main` method is the first method that is invoked.

There can only be one entry point in a C# program. If you have more than one class that has a `Main` method, you must compile your program with the `-main` compiler option to specify which `Main` method to use as the entry point. For more information, see [-main (C# Compiler Options)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/main-compiler-option).

```
class TestClass
{
    static void Main(string[] args)
    {
        // Display the number of command line arguments.
        Console.WriteLine(args.Length);
    }
}

```

## Overview

- The `Main` method is the entry point of an executable program; it is where the program control starts and ends.
- `Main` is declared inside a class or struct. `Main` must be [static](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static) and it need not be [public](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/public). (In the earlier example, it receives the default access of [private](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/private).) The enclosing class or struct is not required to be static.
- `Main` can either have a `void`, `int`, or, starting with C# 7.1, `Task`, or `Task<int>` return type.
- If and only if `Main` returns a `Task` or `Task<int>`, the declaration of `Main` may include the `[async](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/async)` modifier. Note that this specifically excludes an `async void Main` method.
- The `Main` method can be declared with or without a `string[]` parameter that contains command-line arguments. When using Visual Studio to create Windows applications, you can add the parameter manually or else use the [GetCommandLineArgs()](https://docs.microsoft.com/en-us/dotnet/api/system.environment.getcommandlineargs) method to obtain the [command-line arguments](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/command-line-arguments). Parameters are read as zero-indexed command-line arguments. Unlike C and C++, the name of the program is not treated as the first command-line argument in the `args` array, but it is the first element of the [GetCommandLineArgs()](https://docs.microsoft.com/en-us/dotnet/api/system.environment.getcommandlineargs) method.

The following is a list of valid `Main` signatures:

```
public static void Main() { }
public static int Main() { }
public static void Main(string[] args) { }
public static int Main(string[] args) { }
public static async Task Main() { }
public static async Task<int> Main() { }
public static async Task Main(string[] args) { }
public static async Task<int> Main(string[] args) { }

```

The preceding examples all use the public accessor modifier. That is typical, but not required.

The addition of `async` and `Task`, `Task<int>` return types simplifies program code when console applications need to start and `await` asynchronous operations in `Main`.
