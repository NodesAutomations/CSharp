### Print Value to Range
```Csharp
Range rng = Globals.Sheet1.get_Range("A1");
rng.CurrentRegion.Clear();
try
{
    rng.Offset[0,0].Value2 = "Nodes";
    rng.Offset[1, 0].Value2 = "Beams";

}
catch (System.Exception)
{

    rng.Value2 = "Staad is not Detected";
}
```

### Name Range
```CSharp
NumberOfSpan = (int)Globals.StaadSheet.StaadSheet_NumberOfSpan.Value2;
```

### Loop Through Range
