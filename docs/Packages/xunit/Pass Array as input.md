### 

```csharp
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    public class PointTest
    {
        private readonly ITestOutputHelper output;

        public PointTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [ClassData(typeof(Points_Data))]
        public void Points(double[,] values)
        {
            for (int i = 0; i < values.GetLength(0); i++)
            {
                    var x = values[i, 0];
                    var y = values[i, 1];
                    output.WriteLine($"x:{x},y:{y}");
            }
        }
    }
    public class Points_Data : TheoryData<double[,]>
    {
        public Points_Data()
        {
            double[,] val1 = { { 1,1}, { 1,2 },{ 1,3},{ 1,4}  };
            double[,] val2 = { { 2,1}, {2,2 },{ 2,3},{ 2,4}  };
            Add(val1);
            Add(val2);
        }
    }

}
```
