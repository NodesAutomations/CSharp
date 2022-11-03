### General Sample

```csharp
using FluentValidation;
using FluentValidation.Results;
using System;

namespace ConsoleAppTest
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                Customer customer = new Customer();

                CustomerValidator validator = new CustomerValidator();

                //If you Need to Throw Exeption
                // validator.ValidateAndThrow(customer);

                //If you need to store/display results
                ValidationResult results = validator.Validate(customer);
                if (results.IsValid)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Invalid Inputs");

                    foreach (var failure in results.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
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

    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Surname).NotNull().NotEqual("foo");
            RuleFor(x => x.Forename).NotEmpty().WithMessage("Please specify a first name");
            RuleFor(x => x.Discount).NotEqual(0).When(x => x.HasDiscount);
            RuleFor(x => x.Address).Length(20, 250);
            RuleFor(x => x.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
        }
        private bool BeAValidPostcode(string postcode)
        {
            return true;
            // custom postcode validating logic goes here
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public decimal Discount { get; set; }
        public string Address { get; set; }
        public string Postcode { get; internal set; }
        public bool HasDiscount { get; internal set; }
    }
}
```

### Sample related to Excel Model

```csharp
using FluentValidation;
using FluentValidation.Results;
using System;

namespace ConsoleAppTest
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                var input = new Input
                {
                    Prefix = "M1",
                    NodeStartId = 10
                };

                var inputValidator = new InputValidator();

                ValidationResult results = inputValidator.Validate(input);

                if (results.IsValid)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Invalid Inputs");

                    foreach (var failure in results.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
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
    internal class Input
    {
        public string Prefix { get; set; }
        public int NodeStartId { get; set; }

    }

    internal class InputValidator : AbstractValidator<Input>
    {
        public InputValidator()
        {
            RuleFor(input => input.Prefix).NotEmpty();
            RuleFor(input => input.NodeStartId).GreaterThan(0);
        }
    }
}
```

### Validation with List

```csharp
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace ConsoleAppTest
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                var input = new Input
                {
                    Prefix = "M1",
                    NodeStartId = 1
                };
                input.Spacing.Add(0);
                input.Spacing.Add(-10);
                var inputValidator = new InputValidator();

                ValidationResult results = inputValidator.Validate(input);

                if (results.IsValid)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Invalid Inputs");

                    foreach (var failure in results.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
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
    internal class Input
    {
        public string Prefix { get; set; }
        public int NodeStartId { get; set; }

        public List<double> Spacing { get; set; } = new List<double>();

    }

    internal class InputValidator : AbstractValidator<Input>
    {
        public InputValidator()
        {
            RuleFor(input => input.Prefix).NotEmpty();
            RuleFor(input => input.NodeStartId).GreaterThan(0);
            RuleForEach(input => input.Spacing).GreaterThan(0);
        }
    }
}
```

### With Tuples

```csharp
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleAppTest
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                var input = new Input
                {
                    Prefix = "M1",
                    NodeStartId = 1
                };
                input.Spacing1=(0,0);
                input.Spacing.Add((10,-10));
                input.Spacing.Add((0,-10));
                var inputValidator = new InputValidator();

                ValidationResult results = inputValidator.Validate(input);

                if (results.IsValid)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Invalid Inputs");

                    foreach (var failure in results.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }
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
    internal class Input
    {
        public string Prefix { get; set; }
        public int NodeStartId { get; set; }

        public (double Start, double End) Spacing1 { get; set; }  
        public List<(double Start, double End)> Spacing { get; set; } = new List<(double Start, double End)>();

    }

    internal class InputValidator : AbstractValidator<Input>
    {
        public InputValidator()
        {
            RuleFor(input => input.Prefix).NotEmpty();
            RuleFor(input => input.NodeStartId).GreaterThan(0);
            RuleFor(input => input.Spacing1.Start).GreaterThan(0);
            RuleFor(input => input.Spacing1.End).GreaterThan(0);
            RuleForEach(Input => Input.Spacing)
                .ChildRules(spacing => {
                spacing.RuleFor(x => x.Start).GreaterThan(0);
                spacing.RuleFor(x => x.End).GreaterThan(0);
                }); 
        }
    }
}
```

### Complex Properties

```csharp
public string Name { get; set; }
  public Address Address { get; set; }
}

public class Address {
  public string Line1 { get; set; }
  public string Line2 { get; set; }
  public string Town { get; set; }
  public string County { get; set; }
  public string Postcode { get; set; }
}
```

and you define an AddressValidator:

```csharp
public class AddressValidator : AbstractValidator<Address> {
  public AddressValidator() {
    RuleFor(address => address.Postcode).NotNull();
    //etc
  }
}
```

you can then re-use the AddressValidator in the CustomerValidator definition

```csharp
public class CustomerValidator : AbstractValidator<Customer> {
  public CustomerValidator() {
    RuleFor(customer => customer.Name).NotNull();
    RuleFor(customer => customer.Address).SetValidator(new AddressValidator());
  }
}
```
