# xUnit Classes

## TheoryData Class
- So TheoryData is a built-in class in xUnit that helps you manage and provide complex data sets for parameterized tests.
- It allows you to create **strongly-typed** collections of data that can be used with the  `[Theory]` attribute.
- This is good replace for using `IEnumerable<object[]>` for complex data sets.
- Advantages of using `TheoryData` over `IEnumerable<object[]>`:
  - **Type Safety**: Since `TheoryData` is strongly typed, it helps catch type-related errors at compile time rather than at runtime.
  - **Readability**: The structure of `TheoryData` makes it easier to understand the data being provided to the test methods.
  - **Intellisense Support**: When using `TheoryData`, you get better IntelliSense support in IDEs, making it easier to work with the data.

### MemberData with TheoryData
```csharp
[Theory]
[MemberData(nameof(GetDistanceTestData))]
public void TestDistanceTo_WithMemberData(Point2D pointA, Point2D pointB, double expectedDistance)
{
    //Act
    var distance = pointA.DistanceTo(pointB);
    //Assert
    Assert.Equal(expectedDistance, distance, 3);
}

public static TheoryData<Point2D, Point2D, double> GetDistanceTestData()
{
    var data = new TheoryData<Point2D, Point2D, double>
    {
        { new Point2D(0, 0), new Point2D(6, 8), 10.0 },
        { new Point2D(2, 3), new Point2D(5, 7), 5.0 },
        { new Point2D(-2, -3), new Point2D(-5, -7), 5.0 }
    };
    return data;
}
```

```csharp
public class Point2DTest
{
    [Theory]
    [MemberData(nameof(TestDataPoint2D.Distance), MemberType = typeof(TestDataPoint2D))]
    public void TestDistanceTo_WithMemberData(Point2D pointA, Point2D pointB, double expectedDistance)
    {
        //Act
        var distance = pointA.DistanceTo(pointB);
        //Assert
        Assert.Equal(expectedDistance, distance, 3);
    }
}
public static class TestDataPoint2D
{
    public static TheoryData<Point2D, Point2D, double> Distance()
    {
        var data = new TheoryData<Point2D, Point2D, double>();
        data.Add(new Point2D(0, 0), new Point2D(10, 0), 10);
        data.Add(new Point2D(0, 0), new Point2D(10, 10), 14.1421);
        data.Add(new Point2D(1, 2), new Point2D(3, 4), 2.8284);
        return data;
    }
}
```

### ClassData with TheoryData
```csharp
public class Point2DTest
{
    [Theory]
    [ClassData(typeof(DistanceTestData))]
    public void TestDistanceTo_WithMemberData(Point2D pointA, Point2D pointB, double expectedDistance)
    {
        //Act
        var distance = pointA.DistanceTo(pointB);
        //Assert
        Assert.Equal(expectedDistance, distance, 3);
    }
}

public class DistanceTestData : TheoryData<Point2D, Point2D, double>
{
    public DistanceTestData()
    {
        Add(new Point2D(0, 0), new Point2D(3, 4), 5.0);
        Add(new Point2D(1, 1), new Point2D(4, 5), 5.0);
        Add(new Point2D(-1, -1), new Point2D(2, 3), 5.0);
    }
}
```

### Matrix TheoryData
- MatrixTheoryData is a custom class that extends TheoryData to allow adding data in a matrix-like format.
- This can make it easier to visualize and manage test data, especially when dealing with multiple parameters.
- AddCombinations method generates all possible combinations of the provided data sets and adds them to the TheoryData.

```csharp
public class Point2DTest
{
    [Theory]
    [ClassData(typeof(DistanceTestData))]
    public void TestDistanceTo_WithMemberData(Point2D pointA, Point2D pointB, double expectedDistance)
    {
        //Act
        var distance = pointA.DistanceTo(pointB);
        //Assert
        Assert.Equal(expectedDistance, distance, 3);
    }
}

 public class DistanceTestData : MatrixTheoryData<Point2D, Point2D, double>
{
    public DistanceTestData()
    {
        var points = new List<Point2D>
        {
            new Point2D(0, 0),
            new Point2D(3, 4),
            new Point2D(1, 1),
            new Point2D(1, 0)
        };
        AddCombinations(points, points, (a, b) => a.DistanceTo(b));
    }
}
```