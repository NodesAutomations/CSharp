### Main Program

```csharp
using System;

namespace ConsoleAppTest
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                MainNameSpace.Print();
                FirstLevel.FirstLevelNameSpace.Print();
                FirstLevel.SecondLevel.SecondLevelNameSpace.Print();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }

    public static class MainNameSpace
    {
        public static void Print()
        {
            Console.WriteLine("Main NameSpace");
        }
    }
}
```

### Main/FirstLevel/FirstLevelNameSpace.cs

```csharp
using System;

namespace ConsoleAppTest.FirstLevel
{
    public static class FirstLevelNameSpace
    {
        public static void Print()
        {
						//We call MainNameSpace directly
            MainNameSpace.Print();
            Console.WriteLine("First level NameSpace");
        }
    }
}
```

### Main/FirstLevel/SecondLevel/SecondLevelNameSpace.cs

```csharp
using System;

namespace ConsoleAppTest.FirstLevel.SecondLevel
{
    public static class SecondLevelNameSpace
    {
        public static void Print()
        {
						//We call MainNameSpace and FirstLevel NameSpace directly
            MainNameSpace.Print();
            FirstLevelNameSpace.Print();
            Console.WriteLine("Third Level NameSpace");
        }
    }
}
```
