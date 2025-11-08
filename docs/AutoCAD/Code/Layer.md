### Loop through all layers
```csharp
[CommandMethod("ListLayers")]
public static void IterateLayers()
{
    // Get the current document and database, and start a transaction
    Document doc = Application.DocumentManager.MdiActiveDocument;

    using (Transaction transaction = doc.TransactionManager.StartTransaction())
    {
        // This example returns the layer table for the current database
        LayerTable layerTable = transaction.GetObject(doc.Database.LayerTableId, OpenMode.ForRead) as LayerTable;

        // Step through the Layer table and print each layer name
        foreach (ObjectId objectId in layerTable)
        {
            LayerTableRecord layerTableRecord = transaction.GetObject(objectId, OpenMode.ForRead) as LayerTableRecord;
            doc.Editor.WriteMessage("\n" + layerTableRecord.Name);
        }

        // Dispose of the transaction
    }
}
```
### Check if Layer Exist
```csharp
[CommandMethod("FindMyLayer")]
public static void FindMyLayer()
{
    // Get the current document and database, and start a transaction
    Document doc = Application.DocumentManager.MdiActiveDocument;

    using (Transaction transaction = doc.TransactionManager.StartTransaction())
    {
        // Returns the layer table for the current database
        LayerTable layerTable = transaction.GetObject(doc.Database.LayerTableId, OpenMode.ForRead) as LayerTable;

        // Check to see if MyLayer exists in the Layer table
        if (layerTable.Has("MyLayer") != true)
        {
            doc.Editor.WriteMessage("\n'MyLayer' does not exist");
        }
        else
        {
            doc.Editor.WriteMessage("\n'MyLayer' exists");
        }

        // Dispose of the transaction
    }
}
```
