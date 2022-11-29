### Code to Loop Through each value in Table range

```csharp
Microsoft.Office.Tools.Excel.ListObject tbl = Globals.StaadSheet.SpanTable;

            for (int i = 0; i < tbl.Range.Rows.Count; i++)
            {
                for (int j = 0; j < tbl.Range.Columns.Count; j++)
                {
                    Range rng = Globals.StaadSheet.SpanTable.Range.get_Range("A1").get_Offset(i, j);
                    string str = Convert.ToString(rng.Value);
                    Debug.WriteLine(str);
                }
            }
```
