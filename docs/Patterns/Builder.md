# Builder

## Overview
- The Builder pattern is a creational design pattern that allows for the step-by-step construction of complex objects. 
- It separates the construction of an object from its representation, enabling the same construction process to create different representations.

## Use case
- Get rid of large constructors with many parameters.
- Create different representations of some product using the same construction process.
- You can also use Composite class with internal builders to construct complex objects.
- Build your own API for your library and hide the implementation details from the user.

## Code
```csharp
//Product Class
internal class ETabsModel
{
    public string ModelName { get; set; }
    public int NumberOfStories { get; set; }
    public double StoryHeight { get; set; }
    public double GridX { get; set; }
    public double GridY { get; set; }
}
```
```csharp
//Builder Class
internal class ETabsModelBuilder
{
    private readonly ETabsModel _model;
    public ETabsModelBuilder()
    {
        _model = new ETabsModel();
    }
    public ETabsModelBuilder WithModelName(string modelName)
    {
        _model.ModelName = modelName;
        return this;
    }
    public ETabsModelBuilder WithNumberOfStories(int numberOfStories)
    {
        _model.NumberOfStories = numberOfStories;
        return this;
    }
    public ETabsModelBuilder WithStoryHeight(double storyHeight)
    {
        _model.StoryHeight = storyHeight;
        return this;
    }
    public ETabsModelBuilder WithGridX(double gridX)
    {
        _model.GridX = gridX;
        return this;
    }
    public ETabsModelBuilder WithGridY(double gridY)
    {
        _model.GridY = gridY;
        return this;
    }
    public ETabsModel Build()
    {
        return _model;
    }
}
```
```csharp
//Client Code
 var model = new ETabsModelBuilder()
     .WithModelName("My ETABS Model")
     .WithNumberOfStories(10)
     .WithStoryHeight(3.0)
     .WithGridX(5.0)
     .WithGridY(5.0)
     .Build();
```
