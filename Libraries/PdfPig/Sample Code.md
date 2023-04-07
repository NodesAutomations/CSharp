### Reference
- https://uglytoad.github.io/PdfPig/
- https://github.com/UglyToad/PdfPig

### Overview
- Read and extract text and other content from PDFs in C# (port of PDFBox)
- Extracts the position and size of letters from any PDF document. This enables access to the text and words in a PDF document.
- Allows the user to retrieve images from the PDF document.
- Allows the user to read PDF annotations, PDF forms, embedded documents and hyperlinks from a PDF.
- Provides access to metadata in the document.
- Exposes the internal structure of the PDF document.
- Creates PDF documents containing text and path operations.
- Read content from encrypted files by providing the password

### Sample Code to read PDF file
```csharp
private static void Main()
        {
            using (PdfDocument document = PdfDocument.Open(@"C:\Users\Ryzen2600x\Downloads\2023-03-20_JPA_Invoice.pdf"))
            {
                foreach (Page page in document.GetPages())
                {
                    IReadOnlyList<Letter> letters = page.Letters;
                    string example = string.Join(string.Empty, letters.Select(x => x.Value));

                    IEnumerable<Word> words = page.GetWords();

                    IEnumerable<IPdfImage> images = page.GetImages();
                }
            }
            Console.WriteLine("Press Any key to continue");
            Console.ReadLine();
        }
```
