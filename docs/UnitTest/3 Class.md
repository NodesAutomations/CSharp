# xUnit Classes

## TheoryData Class
- So TheoryData is a built-in class in xUnit that helps you manage and provide complex data sets for parameterized tests.
- It allows you to create **strongly-typed** collections of data that can be used with the  `[Theory]` attribute.
- This is good replace for using `IEnumerable<object[]>` for complex data sets.

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

