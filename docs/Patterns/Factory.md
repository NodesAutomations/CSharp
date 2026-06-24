# Factory Pattern

## Overview
- Factory Pattern is a **creational design pattern** that provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created.

## Use Case
- When you want to create objects without exposing the creation logic to the client and refer to the newly created object using a common interface.

## Code
- Suppose we're writing a report exporter.
```csharp
 public interface IExporter
 {
     void Export(string data);
 }

 public class PdfExporter :IExporter
 {
     public void Export(string data)
     {
         Console.WriteLine("Exporting data to PDF: " + data);
     }
 }
 public class CsvExporter : IExporter
 {
     public void Export(string data)
     {
         Console.WriteLine("Exporting data to CSV: " + data);
     }
 }
 public class ExcelExporter : IExporter
 {
     public void Export(string data)
     {
         Console.WriteLine("Exporting data to Excel: " + data);
     }
 }
```

- Then our main method look like this
```csharp
private static void Main()
{
    // This could be dynamically set based on user input or configuration
    string format = "pdf"; 
    IExporter exporter;

    if (format == "pdf")
    {
        exporter = new PdfExporter();
    }
    else if (format == "csv")
    {
        exporter = new CsvExporter();
    }
    else if (format == "excel")
    {
        exporter = new ExcelExporter();
    }
    else
    {
        throw new ArgumentException("Invalid export format");
    }
    exporter.Export("Sample Data");
}
```

- Using factory pattern, we can refactor the code to remove the conditional logic to factory class

```csharp
 public class ExporterFactory
 {
     public static IExporter GetExporter(string format)
     {
         return format.ToLower() switch
         {
             "pdf" => new PdfExporter(),
             "csv" => new CsvExporter(),
             "excel" => new ExcelExporter(),
             _ => throw new ArgumentException("Invalid export format")
         };
     }
 }
 ```

 - So now our main method can be simplified to:
```csharp
private static void Main()
{
    // This could be dynamically set based on user input or configuration
    string format = "pdf"; 
    IExporter exporter = ExporterFactory.GetExporter(format);
    exporter.Export("Sample Data");
}
```