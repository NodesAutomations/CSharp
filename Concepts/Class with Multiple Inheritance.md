### Example

Let's Assume we want to inherit Class1 and Class2 to Class3 so we can use Method1 and Method2.

C# Don't allow multiple inheritance so we need to implement separate Interfaces to get access to Class1 and Class2

    
    ```mermaid
    classDiagram
    
     class Class1{
      +Method1() void
          }
    
      class Class2{
      +Method2() void
          }
    
            class Class3{
      +Method3() void
          }
    
    Class1 <|--Class3
    Class2 <|--Class3
    ```
    

### Code

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
                var c3 = new Class3();
                c3.Method1();
                c3.Method2();
                c3.Method3();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }

    internal interface IClass1
    {
        void Method1();
    }

    internal class Class1 : IClass1
    {
        public void Method1()
        {
            Console.WriteLine("This is Method1");
        }
    }

    internal interface IClass2
    {
        void Method2();
    }

    internal class Class2 : IClass2
    {
        public void Method2()
        {
            Console.WriteLine("This is Method2");
        }
    }

    internal class Class3:IClass1,IClass2
    {
        private readonly Class1 c1 = new Class1();
        private readonly Class2 c2 = new Class2();
        public void Method1()
        {
            c1.Method1();
        }

        public void Method2()
        {
            c2.Method2();
        }

        public void Method3()
        {
            Console.WriteLine("This is Method3");
        }
    }
}
```
