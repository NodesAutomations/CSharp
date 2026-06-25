# Singleton Class

## Overview
- A Singleton class is a class that guarantees exactly one instance exists and provide a global access point to that instance. 
- It has Private Constructor so user cannot create an instance of the class using new keyword.
- It has a static property that returns the single instance of the class. The instance is created when the class is loaded for the first time.
- `sealed` keyword is used to prevent inheritance of the Singleton class. so other classes cannot inherit from it and create multiple instances.

## Use case
- Logging
- Configuration Settings
- License Manager

## How it Different From Static Class?
| Singleton Class | Static Class |
|-----------------|--------------|
| Can be inherited | Cannot be inherited |
| Can implement interfaces | Cannot implement interfaces |
| Can be passed as parameter | Cannot be passed as parameter |
| Can be used as a reference type | Cannot be used as a reference type |

## Code

```csharp
//Define Singleton Class
 internal sealed class Configuration
 {
     private Configuration()
     {
     }
     public static Configuration Instance { get; } = new Configuration();
     public string FloorName { get; set; }
     public int NumberOfFloors { get; set; }
     public override string ToString()
     {
         return $"Floor Name: {FloorName}, Number of Floors: {NumberOfFloors}";
     }
 }
```
```csharp
//Use Singleton Class
 private static void Main()
 {
     var config = Configuration.Instance;
     config.FloorName = "Ground Floor";
     config.NumberOfFloors = 5;
     Console.WriteLine(config);

     var config2 = Configuration.Instance;
     config2.FloorName = "First Floor";
     config2.NumberOfFloors = 10;

     //Print original config to see if it has changed
     Console.WriteLine(config);
 }
```