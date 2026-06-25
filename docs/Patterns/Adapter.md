# Adapter Pattern

## Overview
- Adapter is a structural design pattern that allows objects with incompatible interfaces to work together.

## Use case
- When you need to make new code work with existing code that has a different interface.
- It's way to make new class compatible with existing class without changing the existing class or new class.
- For example for license management when you want to switch to xml to json format for license management. You can use adapter pattern to convert xml to json and vice versa. so app stay compatible with both formats.

## Code
```csharp
public class ModelData
{
    public string Name { get; set; }
    public int GridX { get; set; }
    public int GridY { get; set; }
}
public interface IModelProvider
{
    public ModelData ModelData { get; set; }
    public void OpenModel();
}
public class StaadModelProvider : IModelProvider
{
    public StaadModelProvider(ModelData modelData)
    {
        ModelData = modelData;
    }
    public ModelData ModelData { get; set; }
    public void OpenModel()
    {
        Console.WriteLine($"StaadModel {ModelData.Name} opened");
    }
}
public class MidasModelProvider : IModelProvider
{
    public ModelData ModelData { get; set; }
    public void OpenModel()
    {
        Console.WriteLine($"MidasModel {ModelData.Name} opened");
    }
}
public class StaadToMidasAdapter : IModelProvider
{
    private readonly StaadModelProvider _staadModel;
    public StaadToMidasAdapter(StaadModelProvider staadModel)
    {
        _staadModel = staadModel;
    }
    public ModelData ModelData
    {
        get => _staadModel.ModelData;
        set => _staadModel.ModelData = value;
    }
    public void OpenModel()
    {
        var model = new MidasModelProvider();
        model.ModelData = ModelData;
        model.OpenModel();
    }
}
```
```csharp
//Client code
var modelData = new ModelData
{
    Name = "Box Model",
    GridX = 3,
    GridY = 2
};
IModelProvider modelProvider = new StaadModelProvider(modelData);
modelProvider.OpenModel();

//Open staad model data in Midas model provider using adapter
modelProvider = new StaadToMidasAdapter((StaadModelProvider)modelProvider);
modelProvider.OpenModel();
```