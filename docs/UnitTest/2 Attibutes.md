# Xunit Attributes

## Overview
- XUnit provides various attributes to define and control the behavior of test methods.
- The most commonly used attributes are `[Fact]` and `[Theory]`.

## Fact Attribute
- The `[Fact]` attribute is used to denote a test method that takes no parameters.
- It is a simple test case that is always true.
  
```csharp
[Fact]
public void TestAdd()
{
    //Arrange
    var a = 1;
    var b = 2;

    //Act
    var result = MathUtil.Add(a, b);

    //Assert
    Assert.Equal(3, result);
}
```

## Theory Attribute
- The `[Theory]` attribute is used for parameterized tests.
- It allows you to run the same test method with different sets of data.
- You can provide data using attributes like `[InlineData]`, `[MemberData]`, or `[ClassData]`.

### InlineData Attribute
- The `[InlineData]` attribute allows you to specify the data directly in the attribute.
```csharp
[Theory]
[InlineData(5, 3, 2)]
[InlineData(10, 4, 6)]
[InlineData(0, 0, 0)]
public void TestSubtract(int a, int b, int expected)
{
    //Act
    var result = MathUtil.Subtract(a, b);
    //Assert
    Assert.Equal(expected, result);
}
```

### MemberData Attribute
- The `[MemberData]` attribute allows you to specify a property or method that returns the data for the test.
- This is useful for more complex data sets.

```csharp
 [Theory]
 [MemberData(nameof(GetDistanceTestData))]
 public void TestDistanceTo_WithMemberData(Point2D pointA, Point2D pointB, double expectedDistance)
 {
     //Act
     var distance = pointA.DistanceTo(pointB);
     //Assert
     Assert.Equal(expectedDistance, distance, 5);
 }

 public static IEnumerable<object[]> GetDistanceTestData()
 {
     yield return new object[] { new Point2D(0, 0), new Point2D(3, 4), 5.0 };
     yield return new object[] { new Point2D(1, 1), new Point2D(4, 5), 5.0 };
     yield return new object[] { new Point2D(-1, -1), new Point2D(2, 3), 5.0 };
 }
```

- For class with multiple test methods, you can organize the `MemberData` like this:

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
      public static IEnumerable<object[]> Distance()
      {
          yield return new object[] { new Point2D(0, 0), new Point2D(10, 0), 10 };
          yield return new object[] { new Point2D(0, 0), new Point2D(10, 10), 14.1421 };
          yield return new object[] { new Point2D(1, 2), new Point2D(3, 4), 2.8284 };
      }
  }
```

### ClassData Attribute
- The `[ClassData]` attribute allows you to specify a class that implements `IEnumerable <object[]>` to provide the data for the test.

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

public class DistanceTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new Point2D(0, 0), new Point2D(3, 4), 5.0 };
        yield return new object[] { new Point2D(1, 1), new Point2D(4, 5), 5.0 };
        yield return new object[] { new Point2D(-1, -1), new Point2D(2, 3), 5.0 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
```

