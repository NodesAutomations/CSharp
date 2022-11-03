```csharp
using UnitTestSample;
using Xunit;

namespace Test
{
    public class CalculatorTest
    {
        [Theory]
        [ClassData(typeof(CalculatorTestData2))]
        public void Add2(Point point, double expected)
        {
            var result = Calculator.Add(point.X, point.Y);
            Assert.True(expected == result, "Shit Happens");
        }
    }

    public class CalculatorTestData2 : TheoryData<Point, double>
    {
        public CalculatorTestData2()
        {
            Add(new Point(1.5, 2.5), 4);
            Add(new Point(-4, -6), -10);
        }
    }

    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }
    }
}
```
### 

### Using MemberData

```csharp
using Xunit;

namespace Test
{

    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString() => X + "," + Y;
    }
}
```

```csharp
using Xunit;

namespace Test
{
    public static class PointData
    {
        public static TheoryData<Point, string> DataToString
        {
            get
            {
                var data = new TheoryData<Point, string>();
                data.Add(new Point(0, 0), "0,0");
                data.Add(new Point(10, 0), "10,0");
                data.Add(new Point(10, 10), "10,10");
                data.Add(new Point(0, 10), "0,10");
                data.Add(new Point(5, 10), "5,10");
                return data;
            }
        }
        public static TheoryData<Point, string> DataToString2
        {
            get
            {
                var data = new TheoryData<Point, string>();
                data.Add(new Point(0, 0), "0,0");
                data.Add(new Point(10, 0), "10,0");
                data.Add(new Point(10, 10), "10,10");
                data.Add(new Point(0, 10), "0,10");
                data.Add(new Point(5, 10), "5,10");
                return data;
            }
        }
    }
}
```

```csharp
using Xunit;

namespace Test
{
    public class PointTest
    {
        [Theory]
        [MemberData(nameof(PointData.DataToString), MemberType = typeof(PointData))]
        public void Point_ToString(Point point, string expected)
        {
            var actual = point.ToString();
            Assert.Equal(expected, actual);
        }
        [Theory]
        [MemberData(nameof(PointData.DataToString2), MemberType = typeof(PointData))]
        public void Point_ToString2(Point point, string expected)
        {
            var actual = point.ToString();
            Assert.Equal(expected, actual);
        }
    }
}
```
