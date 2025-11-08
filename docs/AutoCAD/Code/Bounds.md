### Overview
- Bounds refer to the rectangular area that encloses an object. In this case, the bounds of a circle refer to the rectangular area that encloses the circle. The bounds are defined by two points: the minimum point and the maximum point. The minimum point is the lower-left corner of the rectangle, and the maximum point is the upper-right corner of the rectangle. I hope this helps!
- The GeometricExtents property of an AutoCAD entity represents the rectangular area that encloses the entity. It is defined by two points: the minimum point and the maximum point. The minimum point is the lower-left corner of the rectangle, and the maximum point is the upper-right corner of the rectangle. The GeometricExtents property is an Extents3d object that has MinPoint and MaxPoint properties that define the lower-left and upper-right corners of the rectangle, respectively

### Sample Code to get bounds of selected Circle
```csharp
 [CommandMethod("GetBoundsOfSelectedCircle")]
public void GetBoundsOfSelectedCircle()
{
    // Select a circle
    PromptSelectionResult selRes = ActiveUtil.Editor.GetSelection();
    if (selRes.Status != PromptStatus.OK)
        return;

    // Get the selected circle
    using (Transaction tr = ActiveUtil.Database.TransactionManager.StartTransaction())
    {
        Circle circle = tr.GetObject(selRes.Value[0].ObjectId, OpenMode.ForRead) as Circle;

        // Get the bounds of the circle
        Extents3d bounds = circle.GeometricExtents;

        // Display the bounds
        ActiveUtil.Editor.WriteMessage("\nBounds of selected circle:");
        ActiveUtil.Editor.WriteMessage("\n  Min point: " + bounds.MinPoint.ToString());
        ActiveUtil.Editor.WriteMessage("\n  Max point: " + bounds.MaxPoint.ToString());

        tr.Commit();
    }
}
```
### Sample code to get bounds of selected block reference
```csharp
[CommandMethod("GetBoundsOfSelectedBlockReference")]
public void GetBoundsOfSelectedBlockReference()
{
    // Select a circle
    PromptSelectionResult selRes = ActiveUtil.Editor.GetSelection();
    if (selRes.Status != PromptStatus.OK)
        return;

    // Get the selected circle
    using (Transaction tr = ActiveUtil.Database.TransactionManager.StartTransaction())
    {
        var blockRef = selRes.Value[0].ObjectId.GetObject<BlockReference>();

        // Get the bounds of the circle
        Extents3d bounds = blockRef.GeometricExtents;

        // Display the bounds
        ActiveUtil.Editor.WriteMessage("\nBounds of selected block Reference:");
        ActiveUtil.Editor.WriteMessage("\n  Min point: " + bounds.MinPoint.ToString());
        ActiveUtil.Editor.WriteMessage("\n  Max point: " + bounds.MaxPoint.ToString());

        tr.Commit();
    }
}
```
