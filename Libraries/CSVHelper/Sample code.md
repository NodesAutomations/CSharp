### Overview
- Library to read data from CSV file using Class structure

### Sample Code
```csharp
internal static class Program
{
    private static void Main()
    {
        var csvFilePath = @"C:\Users\Intel7500\Downloads\raw.csv";

        using (var reader = new StreamReader(csvFilePath))
        {
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Sales>();

                foreach (var record in records)
                {
                    Console.WriteLine(record.ItemId + "," + record.Type + "," + record.QuantitySold + "," + record.Price);
                }
            }
        }
        Console.WriteLine("Hey");
    }
}

public class Sales
{
    [NumberStyles(NumberStyles.Number | NumberStyles.AllowExponent)]
    [Name("item_id")]
    public long ItemId { get; set; }

    [Name("variation-sku")]
    public string Type { get; set; }

    [Name("variation-quantity_sold")]
    public int? QuantitySold { get; set; }

    [Name("variation-price")]
    public decimal? Price { get; set; }
}
```
