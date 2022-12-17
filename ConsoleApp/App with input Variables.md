****Console App with Command-Line Arguments****

The Main method is the entry point of a C# console application or windows application. When the application is started, the Main method is the first method that is invoked.

There can only be one entry point in a C# program. If you have more than one class that has a Main method, you must compile your program with the **`/main`** compiler option to specify which Main method to use as the entry point. For more information, see [/main (Specify Location of Main Method) (C# Compiler Options)](https://learn.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2008/x3eht538(v=vs.90))
.

```csharp
class TestClass
{
    static void Main(string[] args)
    {
        // Display the number of command line arguments:
        System.Console.WriteLine(args.Length);
    }
}
```

## **Overview**

- The Main method is the entry point of an .exe program; it is where the program control starts and ends.
- Main is declared inside a class or struct. Main must be static and it should not be [public](https://learn.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2008/yzh058ae(v=vs.90)). (In the earlier example, it receives the default access of [private](https://learn.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2008/st6sy9xe(v=vs.90)).) The enclosing class or struct is not required to be static.
- Main can either have a void or int return type.
- The Main method can be declared with or without a string[] parameter that contains command-line arguments. When using Visual Studio to create Windows Forms applications, you can add the parameter manually or else use the [Environment](https://msdn.microsoft.com/en-us/library/z8te35sa) class to obtain the command-line arguments. Parameters are read as zero-indexed command-line arguments. Unlike C and C++, the name of the program is not treated as the first command-line argument.

## **Example**

The following example shows how to use command-line arguments in a console application. The program takes one argument at run time, converts the argument to an integer, and calculates the factorial of the number. If no arguments are supplied, the program issues a message that explains the correct usage of the program.

- To run this application in visual studio you have to set command line arguments in visual studio debug page
    
    > Just Open Project Properties > Debug Page > Startup Options > Command Line Arguments
    > 
- to run this application using CMD just use below command

```
C:\Users\Ryzen2600x\source\repos\Template_ConsoleApp_CSharp\ConsoleAppTest\bin\Debug>ConsoleAppTest.exe 3
The Factorial of 3 is 6.
Press any key to exit.
```

```csharp
public class Functions
{
    public static long Factorial(int n)
    {
        // Test for invalid input 
        if ((n < 0) || (n > 20))
        {
            return -1;
        }

        // Calculate the factorial iteratively rather than recursively: 
        long tempResult = 1;
        for (int i = 1; i <= n; i+)
        {
            tempResult *= i;
        }
        return tempResult;
    }
}

class MainClass
{
    static int Main(string[] args)
    {
        // Test if input arguments were supplied: 
        if (args.Length == 0)
        {
            System.Console.WriteLine("Please enter a numeric argument.");
            System.Console.WriteLine("Usage: Factorial <num>");
            return 1;
        }

        // Try to convert the input arguments to numbers. This will throw 
        // an exception if the argument is not a number. 
        // num = int.Parse(args[0]); 
        int num;
        bool test = int.TryParse(args[0], out num);
        if (test == false)
        {
            System.Console.WriteLine("Please enter a numeric argument.");
            System.Console.WriteLine("Usage: Factorial <num>");
            return 1;
        }

        // Calculate factorial. 
        long result = Functions.Factorial(num);

        // Print result. 
        if (result == -1)
            System.Console.WriteLine("Input must be >= 0 and <= 20.");
        else
            System.Console.WriteLine("The Factorial of {0} is {1}.", num, result);

        return 0;
    }
}
// If 3 is entered on command line, the 
// output reads: The factorial of 3 is 6.
```
