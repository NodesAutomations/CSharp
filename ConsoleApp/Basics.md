### Basic Flow

- C# recognizes a method called Main as signaling the default entry point of execution
- so if your console app don’t have any method name `main` then it won’t compile, and compiler will throw error “Program does not contain a static main method suitable for entry point “

```csharp
using System;

namespace ConsoleAppTest
{
    internal static class Program
    {
        private static void Main()
        {
            //Print Message to Console
            Console.WriteLine("Hello");

            //Pause Program so user can read output, pressing any key will exit app
            Console.Read();
        }
    }
}
```
