## Overview
- A .NET library for creating PDF documents using a fluent API.
- [QuestPDF](https://www.questpdf.com/)
- [Generate Beautiful PDF Reports with QuestPDF in C#](https://osamadev.medium.com/generate-beautiful-pdf-reports-with-questpdf-in-c-fd0055e07e46)

### Setup
- C# .Net 8.0 Console Application
- Install the QuestPDF NuGet package
  
```csharp
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

// Set QuestPDF license (Community license for non-commercial use)
QuestPDF.Settings.License = LicenseType.Community;

```

### Sample Code
```csharp
// Generate A4 document
Document.Create(container =>
{
    container.Page(page =>
    {
        // Set page to A4 size
        page.Size(PageSizes.A4);
        page.Margin(2, Unit.Centimetre);
        page.PageColor(Colors.White);
        page.DefaultTextStyle(x => x.FontSize(12));

        // Header
        page.Header()
            .Text("A4 Document Sample with QuestPDF")
            .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

        // Content
        page.Content()
            .PaddingVertical(1, Unit.Centimetre)
            .Column(column =>
            {
                column.Spacing(10);

                column.Item().Text("Introduction").FontSize(16).Bold();
                
                column.Item().Text(text =>
                {
                    text.Span("This is a sample A4 document generated using ");
                    text.Span("QuestPDF").Bold();
                    text.Span(". QuestPDF is a modern open-source .NET library for PDF document generation.");
                });

                column.Item().PaddingTop(10).Text("Document Information").FontSize(16).Bold();
                
                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(150);
                        columns.RelativeColumn();
                    });

                    table.Cell().Border(1).Padding(5)
                        .Text("Page Size:").Bold();
                    table.Cell().Border(1).Padding(5)
                        .Text("A4 (210mm × 297mm)");

                    table.Cell().Border(1).Padding(5)
                        .Text("Orientation:").Bold();
                    table.Cell().Border(1).Padding(5)
                        .Text("Portrait");

                    table.Cell().Border(1).Padding(5)
                        .Text("Created Date:").Bold();
                    table.Cell().Border(1).Padding(5)
                        .Text(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                });

                column.Item().PaddingTop(10).Text("Sample Features").FontSize(16).Bold();
                
                column.Item().Text("This document demonstrates:");
                column.Item().PaddingLeft(20).Text("• A4 page size configuration");
                column.Item().PaddingLeft(20).Text("• Header and footer sections");
                column.Item().PaddingLeft(20).Text("• Text formatting (bold, colors, sizes)");
                column.Item().PaddingLeft(20).Text("• Tables with borders");
                column.Item().PaddingLeft(20).Text("• Page numbering");

                column.Item().PaddingTop(10).Text("Lorem Ipsum").FontSize(16).Bold();
                column.Item().Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                    "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                    "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                    "nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in " +
                    "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.");
            });

        // Footer
        page.Footer()
            .AlignCenter()
            .Text(text =>
            {
                text.Span("Page ");
                text.CurrentPageNumber();
                text.Span(" of ");
                text.TotalPages();
            });
    });
})
.GeneratePdf("A4_Sample_Document.pdf");

Console.WriteLine("A4 document generated successfully: A4_Sample_Document.pdf");
Console.WriteLine($"File location: {Path.GetFullPath("A4_Sample_Document.pdf")}");
```

### Sample Code 2
```csharp
GeneratePdf("SalesReport.pdf");
Console.WriteLine("PDF Generated Successfully.");

static void GeneratePdf(string fileName)
{
    var base64Image = GetBase64Image(); // Get chart image in Base64 format
    Document.Create(container =>
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(30);
            // Header with Image
            page.Header()
                .Column(column =>
                {
                    if (!string.IsNullOrEmpty(base64Image))
                    {
                        column.Item().AlignCenter().Image(base64Image).FitWidth();
                    }
                    column.Item().Text("Monthly Sales Report")
                        .Bold().FontSize(24).AlignCenter().FontColor(Colors.Blue.Darken2);
                });
            page.Content()
                .PaddingVertical(20)
                .Column(column =>
                {
                    column.Spacing(15);
                    // Sales Summary Table
                    column.Item().Text("Sales Summary").FontSize(18).Bold().FontColor(Colors.Green.Darken2);
                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        table.Header(header =>
                        {
                            header.Cell().Text("Product").Bold();
                            header.Cell().Text("Quantity Sold").Bold();
                            header.Cell().Text("Revenue").Bold();
                            header.Cell().Text("Profit").Bold();
                        });
                        AddTableRow(table, "Laptop", "120", "$120,000", "$30,000", Colors.White);
                        AddTableRow(table, "Smartphone", "250", "$75,000", "$20,000", Colors.Grey.Lighten3);
                        AddTableRow(table, "Tablet", "80", "$40,000", "$10,000", Colors.White);
                        AddTableRow(table, "Monitor", "60", "$18,000", "$5,000", Colors.Grey.Lighten3);
                    });
                    // Top Performers Table
                    column.Item().Text("Top Performers").FontSize(18).Bold().FontColor(Colors.Red.Darken2);
                    column.Item().Table(nestedTable =>
                    {
                        nestedTable.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        nestedTable.Header(header =>
                        {
                            header.Cell().Text("Product").Bold();
                            header.Cell().Text("Revenue").Bold();
                        });
                        AddNestedTableRow(nestedTable, "Laptop", "$120,000", Colors.White);
                        AddNestedTableRow(nestedTable, "Smartphone", "$75,000", Colors.Grey.Lighten3);
                        AddNestedTableRow(nestedTable, "Tablet", "$40,000", Colors.White);
                    });
                    // Chart Image (Base64)
                    if (!string.IsNullOrEmpty(base64Image))
                    {
                        column.Item().Text("Company Sales Chart").FontSize(16).Bold().FontColor(Colors.Purple.Darken2);
                        column.Item().Image(base64Image).FitWidth();
                    }
                    // Disclaimer
                    column.Item().Text("Disclaimer: This report is for internal use only. Data may change after final audits.")
                        .FontSize(10).Italic().FontColor(Colors.Grey.Darken1);
                });
            // Footer with Page Numbering
            page.Footer()
                .AlignCenter()
                .Text(text =>
                {
                    text.Span("Page ").FontColor(Colors.Grey.Darken2);
                    text.CurrentPageNumber().FontColor(Colors.Blue.Darken2);
                    text.Span(" of ").FontColor(Colors.Grey.Darken2);
                    text.TotalPages().FontColor(Colors.Blue.Darken2);
                });
        });
    }).GeneratePdf(fileName);
}

static void AddTableRow(TableDescriptor table, string product, string quantity, string revenue, string profit, string backgroundColor)
{
    table.Cell().Background(backgroundColor).Text(product).FontSize(12);
    table.Cell().Background(backgroundColor).Text(quantity).FontSize(12);
    table.Cell().Background(backgroundColor).Text(revenue).FontSize(12).FontColor(Colors.Green.Darken2);
    table.Cell().Background(backgroundColor).Text(profit).FontSize(12).FontColor(Colors.Green.Darken2);
}

static void AddNestedTableRow(TableDescriptor table, string product, string revenue, string backgroundColor)
{
    table.Cell().Background(backgroundColor).Text(product).FontSize(12);
    table.Cell().Background(backgroundColor).Text(revenue).FontSize(12).FontColor(Colors.Green.Darken2);
}

static string GetBase64Image()
{
    const string imagePath = "chart.png"; // Change this to your image path
    if (!File.Exists(imagePath))
    {
        Console.WriteLine("Image file not found, using placeholder.");
        return string.Empty;
    }
    var imageBytes = File.ReadAllBytes(imagePath);
    return $"data:image/png;base64,{Convert.ToBase64String(imageBytes)}";
}
```