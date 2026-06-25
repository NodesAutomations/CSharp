# Singleton Design Pattern

## Overview
- The Singleton Design Pattern is a design pattern that restricts the instantiation of a class to one single instance and provides a global point of access to that instance.
- It is used when exactly one object is needed to coordinate actions across the system.

## Use case
- Same as Singleton Class
- Logging
- Configuration Settings
- License Manager

## Downside
- Violates the Single Responsibility Principle because it controls both the creation and the behavior of the instance.
- Not suiteable for multi-threaded applications because it can create multiple instances of the class if two threads access the instance at the same time.
- Difficult to unit test because it introduces global state into an application.
- Can lead to tight coupling between classes because they rely on the singleton instance.

## Downside
- Don't overuse it because it can create overhead because it's instantiated once and used throughout the application. 
It can also make unit testing difficult because it introduces global state into an application.

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

## References
- [Singleton Design Pattern](https://youtu.be/ggqjVuJ0g_8?si=IC1QHNKlYoL7wD8n)