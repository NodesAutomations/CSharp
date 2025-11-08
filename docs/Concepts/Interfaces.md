## What?

- It's Language construct that is similar to Class but fundamentally different
- It's Abstract Class without Code or Body, It Only Include Vague implementation details like Field Names and Method Name with Signature

## Example

```csharp
public interface ITaxCalculator
    {
        int Calculate();
    }
```

- It's Syntax is similar to Class as we can see above, only Change is use of interface instead of Class
- Another Change is, Interface Method don't have Access Modifier

## Why?

- To Build Loosely Coupled Application
- Reduce Dependency on Specific Object

### Other Usecase

- let's say we have class1 which implement interface1 interface. Now if we need to add Additional Functionality so we just need to create new interface2 based on interface1 and Add new functionality on it and use newer interface for new class. Later we can get rid of older interface if no class is using it.
- Use can also Add Default implementation for method so you don't have to implement in All Class, this also better if we have same code for 95% time for 5% it Changes so for 95% class we don't have to Repeat that method.

# Predefined Interfaces

## IEquatable<T> Interface

Defines a generalized method that a value type or class implements to create a type-specific method for **determining equality of instances**.

This interface is implemented by types whose values can be equated (for example, the numeric and string classes). A value type or class implements the Equals method to create a type-specific method suitable for determining equality of instances.

```csharp
public bool Equals (T other);
```

<aside>
🔥 The `IComparable<T>` interface defines the `CompareTo` method, which determines the sort order of instances of the implementing type. The `IEquatable<T>` interface defines the `Equals` method, which determines the equality of instances of the implementing type.

</aside>

- Example
    
    ```csharp
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    public class Person : IEquatable<Person>
    {
       private string uniqueSsn;
       private string lName;
    
       public Person(string lastName, string ssn)
       {
          if (Regex.IsMatch(ssn, @"\d{9}"))
            uniqueSsn = $"{ssn.Substring(0, 3)}-{ssn.Substring(3, 2)}-{ssn.Substring(5, 4)}";
          else if (Regex.IsMatch(ssn, @"\d{3}-\d{2}-\d{4}"))
             uniqueSsn = ssn;
          else
             throw new FormatException("The social security number has an invalid format.");
    
          this.LastName = lastName;
       }
    
       public string SSN
       {
          get { return this.uniqueSsn; }
       }
    
       public string LastName
       {
          get { return this.lName; }
          set {
             if (String.IsNullOrEmpty(value))
                throw new ArgumentException("The last name cannot be null or empty.");
             else
                this.lName = value;
          }
       }
    
       public bool Equals(Person other)
       {
          if (other == null)
             return false;
    
          if (this.uniqueSsn == other.uniqueSsn)
             return true;
          else
             return false;
       }
    
       public override bool Equals(Object obj)
       {
          if (obj == null)
             return false;
    
          Person personObj = obj as Person;
          if (personObj == null)
             return false;
          else
             return Equals(personObj);
       }
    
       public override int GetHashCode()
       {
          return this.SSN.GetHashCode();
       }
    
       public static bool operator == (Person person1, Person person2)
       {
          if (((object)person1) == null || ((object)person2) == null)
             return Object.Equals(person1, person2);
    
          return person1.Equals(person2);
       }
    
       public static bool operator != (Person person1, Person person2)
       {
          if (((object)person1) == null || ((object)person2) == null)
             return ! Object.Equals(person1, person2);
    
          return ! (person1.Equals(person2));
       }
    }
    ```
    
    ```csharp
    public class TestIEquatable
    {
       public static void Main()
       {
          // Create a Person object for each job applicant.
          Person applicant1 = new Person("Jones", "099-29-4999");
          Person applicant2 = new Person("Jones", "199-29-3999");
          Person applicant3 = new Person("Jones", "299-49-6999");
    
          // Add applicants to a List object.
          List<Person> applicants = new List<Person>();
          applicants.Add(applicant1);
          applicants.Add(applicant2);
          applicants.Add(applicant3);
    
           // Create a Person object for the final candidate.
           Person candidate = new Person("Jones", "199-29-3999");
           if (applicants.Contains(candidate))
              Console.WriteLine("Found {0} (SSN {1}).",
                                 candidate.LastName, candidate.SSN);
          else
             Console.WriteLine("Applicant {0} not found.", candidate.SSN);
    
          // Call the shared inherited Equals(Object, Object) method.
          // It will in turn call the IEquatable(Of T).Equals implementation.
          Console.WriteLine("{0}({1}) already on file: {2}.",
                            applicant2.LastName,
                            applicant2.SSN,
                            Person.Equals(applicant2, candidate));
       }
    }
    // The example displays the following output:
    //       Found Jones (SSN 199-29-3999).
    //       Jones(199-29-3999) already on file: True.
    ```
    

### **Notes to Implementers**

The I**Equatable<T> interface is used by generic collection objects such as Dictionary<TKey,TValue>, List<T>, and LinkedList<T>** when testing for equality in such methods as Contains, IndexOf, LastIndexOf, and Remove. It **should be implemented for any object that might be stored in a generic collection**.

## IComparable<T> Interface

Defines a generalized comparison method that a value type or class implements to create a type-specific comparison method for ordering or sorting its instances.

```csharp
public int CompareTo(T other)
```

- Example
    
    ```csharp
    using System;
    using System.Collections.Generic;
    
    public class Temperature : IComparable<Temperature>
    {
        // Implement the generic CompareTo method with the Temperature
        // class as the Type parameter.
        //
        public int CompareTo(Temperature other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
    
            // The temperature comparison depends on the comparison of
            // the underlying Double values.
            return m_value.CompareTo(other.m_value);
        }
    
        // Define the is greater than operator.
        public static bool operator >  (Temperature operand1, Temperature operand2)
        {
           return operand1.CompareTo(operand2) == 1;
        }
    
        // Define the is less than operator.
        public static bool operator <  (Temperature operand1, Temperature operand2)
        {
           return operand1.CompareTo(operand2) == -1;
        }
    
        // Define the is greater than or equal to operator.
        public static bool operator >=  (Temperature operand1, Temperature operand2)
        {
           return operand1.CompareTo(operand2) >= 0;
        }
    
        // Define the is less than or equal to operator.
        public static bool operator <=  (Temperature operand1, Temperature operand2)
        {
           return operand1.CompareTo(operand2) <= 0;
        }
    
        // The underlying temperature value.
        protected double m_value = 0.0;
    
        public double Celsius
        {
            get
            {
                return m_value - 273.15;
            }
        }
    
        public double Kelvin
        {
            get
            {
                return m_value;
            }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentException("Temperature cannot be less than absolute zero.");
                }
                else
                {
                    m_value = value;
                }
            }
        }
    
        public Temperature(double kelvins)
        {
            this.Kelvin = kelvins;
        }
    }
    
    public class Example
    {
        public static void Main()
        {
            SortedList<Temperature, string> temps =
                new SortedList<Temperature, string>();
    
            // Add entries to the sorted list, out of order.
            temps.Add(new Temperature(2017.15), "Boiling point of Lead");
            temps.Add(new Temperature(0), "Absolute zero");
            temps.Add(new Temperature(273.15), "Freezing point of water");
            temps.Add(new Temperature(5100.15), "Boiling point of Carbon");
            temps.Add(new Temperature(373.15), "Boiling point of water");
            temps.Add(new Temperature(600.65), "Melting point of Lead");
    
            foreach( KeyValuePair<Temperature, string> kvp in temps )
            {
                Console.WriteLine("{0} is {1} degrees Celsius.", kvp.Value, kvp.Key.Celsius);
            }
        }
    }
    /* This example displays the following output:
          Absolute zero is -273.15 degrees Celsius.
          Freezing point of water is 0 degrees Celsius.
          Boiling point of water is 100 degrees Celsius.
          Melting point of Lead is 327.5 degrees Celsius.
          Boiling point of Lead is 1744 degrees Celsius.
          Boiling point of Carbon is 4827 degrees Celsius.
    */
    ```
    

This interface is implemented by types whose values can be ordered or sorted and provides a strongly typed comparison method for ordering members of a generic collection object. For example, one number can be larger than a second number, and one string can appear in alphabetical order before another. It requires that implementing types define a single method, CompareTo(T), that indicates whether the position of the current instance in the sort order is before, after, or the same as a second object of the same type. Typically, the method is not called directly from developer code. Instead, it is called automatically by methods such as List<T>.Sort() and Add.

The implementation of the [CompareTo(T)](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1.compareto?view=netcore-3.1#System_IComparable_1_CompareTo__0_) method must return an [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=netcore-3.1) that has one of three values, as shown in the following table.

[Untitled](https://www.notion.so/0288405eaf324336974c3a8f6d63306e)

### **Notes to Implementers**

Replace the type parameter of the [IComparable<T>](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1?view=netcore-3.1) interface with the type that is implementing this interface.

If you implement [IComparable<T>](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1?view=netcore-3.1), you should overload the `op_GreaterThan`, `op_GreaterThanOrEqual`, `op_LessThan`, and `op_LessThanOrEqual` operators to return values that are consistent with [CompareTo(T)](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1.compareto?view=netcore-3.1#System_IComparable_1_CompareTo__0_). In addition, you should also implement [IEquatable<T>](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1?view=netcore-3.1).

## ICloneable Interface

Supports cloning, which creates a new instance of a class with the same value as an existing instance.

```
public interface ICloneable
```

The ICloneable interface enables you to provide a customized implementation that creates a copy of an existing object. **The ICloneable interface contains one member, the Clone method, which is intended to provide cloning support beyond that supplied by Object.MemberwiseClone.**

### **Notes to Implementers**

The [ICloneable](https://docs.microsoft.com/en-us/dotnet/api/system.icloneable?view=netcore-3.1) interface simply requires that your implementation of the [Clone()](https://docs.microsoft.com/en-us/dotnet/api/system.icloneable.clone?view=netcore-3.1#System_ICloneable_Clone) method return a copy of the current object instance. **It does not specify whether the cloning operation performs a deep copy, a shallow copy, or something in between.** Nor does it require all property values of the original instance to be copied to the new instance. For example, the [Clone()](https://docs.microsoft.com/en-us/dotnet/api/system.globalization.numberformatinfo.clone?view=netcore-3.1#System_Globalization_NumberFormatInfo_Clone) method performs a shallow copy of all properties except the [IsReadOnly](https://docs.microsoft.com/en-us/dotnet/api/system.globalization.numberformatinfo.isreadonly?view=netcore-3.1#System_Globalization_NumberFormatInfo_IsReadOnly) property; it always sets this property value to `false` in the cloned object. Because callers of [Clone()](https://docs.microsoft.com/en-us/dotnet/api/system.icloneable.clone?view=netcore-3.1#System_ICloneable_Clone) cannot depend on the method performing a predictable cloning operation, we recommend that [ICloneable](https://docs.microsoft.com/en-us/dotnet/api/system.icloneable?view=netcore-3.1) not be implemented in public APIs.

### Clone Method

```csharp
public object Clone ();
```
