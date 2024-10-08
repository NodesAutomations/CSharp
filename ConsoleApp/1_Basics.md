### Basic Flow

- C# recognizes a method called Main as signaling the default entry point of execution
- so, if your console app don’t have any method name `main` then it won’t compile, and compiler will throw error “Program does not contain a static main method suitable for entry point “

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

### Inputs in console Application

- so there are multiple way to give input to console application
    - Give input at run time using `console.Read()` or `console.ReadLine()` commands
    - Using input Parameter with `Main()` Method
    - Using Input output system Based on specific file type
        - Using Text file as input and Output
        - Using excel file as input and Output
        - Using Any other program which support C# api, like Staad, etabs, autocad

### Use Cases

- For any calculative application which don’t require User Interface
- Small automation projects, with trigger at specific time, routine runs for reports
- Application which use other apps for input and output
