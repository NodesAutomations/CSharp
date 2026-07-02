# Command Pattern

## Overview

## Use Case
- Need separate command classes for each functionality to be executed
- Reversible operations and undo functionality
- Queue operations and execute them at a later time
- Button with multiple funtionality like cut, copy, paste, undo, redo
- Eliminate need of if else or switch case statements to execute different commands

## Code
- Assume we are creating console app to generate reports with different types


```csharp
public interface ICommand
{
    public string Name { get; }
    void Execute();
    void Undo();
}

public class ExtractEtabsDataCommand : ICommand
{
    public string Name => "Extract Etabs Data";
    public void Execute()
    {
        Console.WriteLine("Extracting Etabs data...");
        // Implementation for extracting Etabs data
    }
    public void Undo()
    {
        Console.WriteLine("Undoing Etabs data extraction...");
        // Implementation for undoing Etabs data extraction
    }
}

public class  ExportExcelCommand : ICommand
{
    public string Name => "Export Excel";
    public void Execute()
    {
        Console.WriteLine("Exporting to Excel...");
        // Implementation for exporting to Excel
    }
    public void Undo()
    {
        Console.WriteLine("Undoing Excel export...");
        // Implementation for undoing Excel export
    }
}

public class GenerateReportCommand : ICommand
{
    public string Name => "Generate Report";
    public void Execute()
    {
        Console.WriteLine("Generating report...");
        // Implementation for generating report
    }
    public void Undo()
    {
        Console.WriteLine("Undoing report generation...");
        // Implementation for undoing report generation
    }
}
```
```csharp
//Client code
private static void Main()
{
    //Command Pattern
    var commands = new List<ICommand>();
    commands.Add(new ExtractEtabsDataCommand());
    commands.Add(new ExportExcelCommand());
    commands.Add(new GenerateReportCommand());

    //Print list of commands for user to select
    Console.WriteLine("Available Commands:");
    for (int i = 0; i < commands.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {commands[i].Name}");
    }

    //Prompt user to select a command
    int choice = int.Parse(Console.ReadLine());

    if (choice > 0 && choice <= commands.Count)
    {
        var selectedCommand = commands[choice - 1];
        Console.WriteLine($"Executing command: {selectedCommand.Name}");
        selectedCommand.Execute();
    }
    else
    {
        Console.WriteLine("Invalid choice.");
    }
}
```