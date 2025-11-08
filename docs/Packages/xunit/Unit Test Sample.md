```csharp
using Geometry.Entities;
using System.Collections.Generic;
using Xunit;

namespace Geometry.Tests
{
    public class Point2DTest
    {
        [Fact]
        public void Ctor_Empty()
        {
            var actualPoint = new Point2D();
            var expectedPoint = new Point2D(0, 0);
            Assert.Equal(expectedPoint, actualPoint);
        }

        [Theory]
        [MemberData(nameof(TestDataPoint2D.Move), MemberType = typeof(TestDataPoint2D))]
        public void Move(double radius, double angle, Point2D expectedPoint)
        {
            var point = new Point2D();
            point.Move(radius, new Unit.Angle(angle, Unit.AngleType.Degrees));
            Assert.Equal(expectedPoint, point);
        }

        [Theory]
        [MemberData(nameof(TestDataPoint2D.Distance), MemberType = typeof(TestDataPoint2D))]
        public void Distance(Point2D point1, Point2D point2, double expected)
        {
            var actual = point1.DistanceFrom(point2);
            Assert.Equal(expected, actual, 4);
        }
    }

    public static class TestDataPoint2D
    {
        public static IEnumerable<object[]> Move()
        {
            yield return new object[] { 10, 0, new Point2D(10, 0) };
            yield return new object[] { 5, 90, new Point2D(0, 5) };
            yield return new object[] { 1, -90, new Point2D(0, -1) };
            yield return new object[] { 0, 90, new Point2D(0, 0) };
        }

        public static IEnumerable<object[]> Distance()
        {
            yield return new object[] { new Point2D(0, 0), new Point2D(10, 0), 10 };
            yield return new object[] { new Point2D(0, 0), new Point2D(10, 10), 14.1421 };
            yield return new object[] { new Point2D(1, 2), new Point2D(3, 4), 2.8284 };
        }
    }
}
```
