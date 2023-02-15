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
