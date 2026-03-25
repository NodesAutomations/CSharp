# Fluent Validation

## How to use Fluent Validation
- Assume you have column class and you'll want to validate its properties before processing it.
- You can create validator class before processing it's data to avoid any exception
- Install Package FluentValidation via Nuget Package Manager

### Original Class
```csharp
 internal class Column
 {
     public string ID { get; set; }
     public double Width { get; set; }
     public double Breadth { get; set; }
     public double Height { get; set; }
     public double Cover { get; set; }
 }
```
### Validator Class
```csharp
    internal class ColumnValidator:AbstractValidator<Column>
    {
        public ColumnValidator()
        {
            RuleFor(x => x.ID).NotEmpty();
            RuleFor(x => x.Width).GreaterThanOrEqualTo(230);
            RuleFor(x => x.Breadth).GreaterThanOrEqualTo(230);
            RuleFor(x => x.Height).GreaterThanOrEqualTo(2800);
            RuleFor(x => x.Cover).GreaterThanOrEqualTo(20);
        }
    }
```
### Validation
- `Validator.Validate(object)` method is used to validate an object. 
- It returns a `ValidationResult` which contains information about whether the validation was successful and any validation errors that occurred.

```csharp
var column = new Column();
column.ID = "C1";
column.Width = 300;
column.Breadth = 600;
column.Height = 3000;
column.Cover = 25;

var validator = new ColumnValidator();
var result = validator.Validate(column);
if (result.IsValid)
{
    Console.WriteLine("Column is valid.");
}
else
{
    foreach (var error in result.Errors)
    {
        Console.WriteLine(error.ErrorMessage);
    }
}
```

## Validation Methods 

### General
- RuleFor: Defines a validation rule for a specific property of the object being validated.
    ```csharp
    RuleFor(x => x.ID).NotEmpty();
    ``` 
- RuleForEach: Validates each element in a collection property(List,array,Dictionary) using a specified rule. 
    ```csharp
    RuleForEach(x => x.CollectionProperty).NotEmpty();
    ```
- NotNull: Validates that a property is not null.
    ```csharp
    RuleFor(x => x.ID).NotNull();
    ```
- Equal/NotEqual: Validates that a property is equal or not equal to a specified value.
    ```csharp
    RuleFor(x => x.ID).NotEqual("C0").WithMessage("Column ID cannot be C0.");
    ```
- Must: Validates that a property satisfies a specified condition.
    ```csharp
    RuleFor(x => x.ID)
    .Must(id => id.StartsWith("C"))
    .WithMessage("Column ID must start with the letter C.");
    ```

### String
- NotEmpty: Validates that a string property is not null or empty.
    ```csharp
    RuleFor(x => x.ID).NotEmpty();
    ```
- NotNull: Validates that a string property is not null.
    ```csharp
    RuleFor(x => x.ID).NotNull();
    ```
- Length: Validates that a string property has a length within a specified range.
    ```csharp
    RuleFor(x => x.ID).Length(2, 4);
    ```
- Matches: Validates that a string property matches a specified regular expression pattern.
    ```csharp
    RuleFor(x => x.ID)
    .NotEmpty()
    .Matches(@"^C[1-9]\d*$")
    .WithMessage("Column ID must start with a letter C followed by digits.");
    ```
### Number
- Number validation are most straight forward, you can use the following methods to validate numeric properties:
    ```csharp
        RuleFor(x => x.Width).GreaterThanOrEqualTo(230);
        RuleFor(x => x.Breadth).GreaterThanOrEqualTo(230);
        RuleFor(x => x.Height).GreaterThanOrEqualTo(2800);
        RuleFor(x => x.Cover).GreaterThanOrEqualTo(20);
    ```
- GreaterThan: Validates that a numeric property is greater than a specified value.
- GreaterThanOrEqualTo: Validates that a numeric property is greater than or equal to a specified value.
- LessThan: Validates that a numeric property is less than a specified value.
- LessThanOrEqualTo: Validates that a numeric property is less than or equal to a specified value.


### Enum
- IsInEnum: Validates that an enum property has a value that is defined in the enum type.
    ```csharp
    public enum ErrorLevel 
    {
    Error = 1,
    Warning = 2,
    Notice = 3
    }

    public class Model
    {
    public ErrorLevel ErrorLevel { get; set; }
    }

    var model = new Model();
    model.ErrorLevel = (ErrorLevel)4;
    ```
    ```csharp
    RuleFor(x => x.ErrorLevel).IsInEnum();
    ```
    
### Class
- SetValidator: Validates a class property using another validator.
    ```csharp
    RuleFor(x => x.Set1)
        .SetValidator(new BarValidator());
    ```
### Conditional
- The When and Unless methods can be used to specify conditions that control when the rule should execute. For example, this rule on the CustomerDiscount property will only execute when IsPreferredCustomer is true:
    ```csharp
    RuleFor(customer => customer.CustomerDiscount)
        .GreaterThan(0)
        .When(customer => customer.IsPreferredCustomer);
    ```
- When: Defines a conditional validation rule that only applies when a specified condition is true.
    ```csharp
    RuleFor(x => x.Cover)
        .GreaterThanOrEqualTo(20)
        .When(x => x.Height > 3000)
        .WithMessage("Cover must be at least 20 when height is greater than 3000.");
    ```
    ```csharp
    When(book => book.Title.Length > 50, () =>
        {
            RuleFor(book => book.Author)
              .NotEmpty()
              .WithMessage("Author is required for long titles.");
        });
    ```
- Otherwise: Defines a conditional validation rule that only applies when a specified condition is false.
    ```csharp
    When(customer => customer.IsPreferred, () => {
        RuleFor(customer => customer.CustomerDiscount).GreaterThan(0);
        RuleFor(customer => customer.CreditCardNumber).NotNull();
    }).Otherwise(() => {
        RuleFor(customer => customer.CustomerDiscount).Equal(0);
    });
    ```
## Validation Configuration

### Custom Message
- WithMessage: Specifies a custom error message for a validation failure.
    ```csharp
    RuleFor(x => x.Width)
    .GreaterThanOrEqualTo(230)
    .WithMessage(x => $"Column {x.ID} width must be at least 230.");
    ```

### Placeholders
- You can use placeholders in your custom error messages to include dynamic values. For example, {PropertyName} will be replaced with the name of the property being validated, and {PropertyValue} will be replaced with the value of that property.
    ```csharp
    RuleFor(x => x.Width)
    .GreaterThanOrEqualTo(230)
    .WithMessage("Column {PropertyName} must be at least 230. Current value: {PropertyValue}");
    ```
- {PropertyName}: The name of the property being validated.
- {PropertyValue}: The value of the property being validated.
- {MinLength}: The minimum length specified in a Length validation rule.
- {MaxLength}: The maximum length specified in a Length validation rule.
- {TotalLength}: The total length of a string being validated in a Length validation rule.
- {ComparisonValue}: The value being compared against in a comparison validation rule (e.g., GreaterThan, LessThan).
- {ComparisonProperty}: The name of the property being compared against in a comparison validation rule.
- {CollectionCount}: The number of elements in a collection being validated when using RuleForEach.
- {CollectionIndex}: The index of the current element being validated in a collection when using RuleForEach.

### WithName
- WithName: Specifies a custom name for the property being validated, which can be used in error messages.
    ```csharp
    RuleFor(x => x.Width)
    .GreaterThanOrEqualTo(230)
    .WithName("Column Width")
    .WithMessage("{PropertyName} must be at least 230. Current value: {PropertyValue}");
    ```

## Sample related to Excel Model

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
