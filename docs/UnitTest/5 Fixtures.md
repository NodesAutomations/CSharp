# xUnit Fixtures

## Overview
- Fixtures in xUnit are used to set up a shared context for multiple tests.
- Shared context in xUnit allows you to share setup and teardown code across multiple test classes.
- This is useful for reducing code duplication and improving test maintainability.
- For example reading data from csv, json files or setting up database connections.

## Traditional Shared Context
- You can create a static class or use static members in your test class to hold shared data.
- You can Also use constructors for setup and `IDisposable` for teardown.

```csharp title="Traditional Shared Context"
public class MathUtilTest
{
    public static List<(int, int)> Data { get; } = new List<(int, int)>()
    {
        (5, 3),
        (10, 4),
        (0, 0)
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void TestAdd(int a, int b)
    {
        //Act
        var result = MathUtil.Add(a, b);
        //Assert
        Assert.Equal(a + b, result);
    }
    [Theory]
    [MemberData(nameof(Data))]
    public void TestSubtract(int a, int b)
    {
        //Act
        var result = MathUtil.Subtract(a, b);
        //Assert
        Assert.Equal(a - b, result);
    }
}
```

## Using IClassFixture<T>
- xUnit provides `IClassFixture<T>` interface to share context between tests in a class.
- Create a fixture class that contains the shared context.
 
```csharp title="Using IClassFixture<T>"
public class Point2DTest : IClassFixture<PointFixture>
{
    public Point2DTest(PointFixture pointFixture)
    {
        _Points = pointFixture.Points;
    }
    private List<(Point2D, Point2D, double)> _Points { get; }

    [Fact]
    public void TestDistanceTo_WithMemberData()
    {
        foreach (var (pointA, pointB, expectedDistance) in _Points)
        {
            //Act
            var distance = pointA.DistanceTo(pointB);
            //Assert
            Assert.Equal(expectedDistance, distance,3);
        }
    }
}
public class PointFixture
{
    public PointFixture()
    {
        Points = new List<(Point2D, Point2D, double)>
        {
            (new Point2D(0,0), new Point2D(10,0), 10),
            (new Point2D(0,0), new Point2D(10,10), 14.1421),
            (new Point2D(1,2), new Point2D(3,4), 2.8284)
        };
    }
    public List<(Point2D, Point2D, double)> Points { get; set; }

}
```