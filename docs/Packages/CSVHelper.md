### Overview
- A .NET library for reading and writing CSV files.
- [Intro to the CsvHelper Library for C#](https://www.youtube.com/watch?v=z3BwMlcGdhg)

### Setup
```csharp
enum ErrorSeverity
{
    Critical,
    Warning,
    Suggestion,
    Unknown
}
``` 

Using Property name matching with CSV file headers
```csharp
internal class StaadError
{
    public ErrorSeverity ErrorType { get; set; }
    public string ErrorMessage { get; set; }
    public string Suggestion { get; set; }
}
```

Using Name Attibute match CSV File header
```csharp
internal class StaadError
{
    public StaadError()
    {
        Severity = ErrorSeverity.Unknown;
    }

    [Name("ErrorType")]
    public ErrorSeverity Severity { get; set; }

    [Name("ErrorMessage")]
    public string Message { get; set; }

    [Name("Suggestion")]
    public string Solution { get; set; }
}
```
### Read Data
```csharp
string csvData = System.IO.File.ReadAllText("ErrorData.csv");

using var reader = new System.IO.StringReader(csvData);
using var csv = new CsvHelper.CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
var records = csv.GetRecords<StaadError>();
var errors = new List<StaadError>();

foreach (StaadError record in records)
{
    Console.WriteLine($"{record.ErrorType},{record.ErrorMessage},{record.Suggestion}");
    errors.Add(record);
}
```
### Write Data
```csharp
var errors = new List<StaadError>();

//Code To populate errors


//Generate new CSV file from the list
using var writer = new System.IO.StreamWriter("GeneratedErrorData.csv");
using var csvWriter = new CsvHelper.CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture);
csvWriter.WriteRecords(errors);
```