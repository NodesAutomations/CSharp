### Overview
- An extension method in C# is a static method that allows you to add new functionality to an existing class without modifying its source code or inheriting from it.
- Extension methods enable you to "extend" the behavior of a class by providing new methods that can be called on instances of that class as if they were part of the class's original API.
- To define an extension method, you need to create a static class that contains the extension method as a static method. The first parameter of the extension method must be marked with the this keyword followed by the name of the type you want to extend. This tells the C# compiler that the extension method should be treated as a member of the extended type. You can then call the extension method on an instance of the extended type as if it were a regular member method.
Here's an example of an extension method that adds a new method called Increment to the int type:
```csharp
public static class IntExtensions
{
    public static int Increment(this int value)
    {
        return value + 1;
    }
}
```
```csharp
int myInt = 5;
int incrementedInt = myInt.Increment();
Console.WriteLine(incrementedInt); // Outputs: 6
```

### Extension Method for List Of Custom Class
```csharp
namespace ConsoleAppTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var customers = new List<Customer>();
                customers.Add(new Customer(25));
                customers.Add(new Customer(5));
                customers.Add(new Customer(15));

                customers = customers.AboveAge(10);
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Console.WriteLine("Press Any Key to Exit");
                Console.ReadLine();
            }
        }
    }

    internal class Customer
    {
        public int Age { get; set; }

        public Customer(int age)
        {
            Age = age;
        }

        public override string ToString()
        {
            return Age.ToString();
        }
    }
    internal static class CustomerHelper
    {
        public static List<Customer> AboveAge(this List<Customer> customers, int age)
        {
            return customers.FindAll(c => c.Age > age);
        }
    }
}
```
