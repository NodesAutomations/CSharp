### Use TheoryData class to create statically type inputs

```csharp
using UnitTestSample;
using Xunit;

namespace Test
{
    public class CalculatorTestData : TheoryData<double, double, double>
    {
        public CalculatorTestData()
        {
            Add(1.5, 2.5, 4);
            Add(-4, -6, -10);
        }
    }

    public class CalculatorTest
    {
        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void Add(double value1, double value2, double expected)
        {
            var result = Calculator.Add(value1, value2);
            Assert.True(expected == result, "Shit Happens");
        }
    }
}
```

```csharp
using Xunit;

namespace Test
{
    public class CustomObjectTest
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

        [Theory]
        [MemberData(nameof(DataToString))]
        public void Point_ToString(Point point, string expected)
        {
            var actual = point.ToString();
            Assert.Equal(expected, actual);
        }
    }
   
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
