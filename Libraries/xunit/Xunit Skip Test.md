```csharp
using UnitTestSample;
using Xunit;

namespace Test
{
    public class CalculatorTestData : TheoryData<int, int, int>
    {
        public CalculatorTestData()
        {
            Add(1, 2, 3);
            Add(-4, -6, -10);
            Add(-2, 2, 0);
            Add(int.MinValue, -1, int.MaxValue);
        }
    }
    public class CalculatorTest
    {
        [Theory(Skip = "Hey this works")]
        [ClassData(typeof(CalculatorTestData))]
        public void CanAdd(int value1, int value2, int expected)
        {
            var result =Calculator.Add(value1, value2);
            Assert.Equal(expected, result);
        }

        [Fact(Skip = "Because I can")]
        public void CheckSum()
        {
            // Arrange
            double expected= 10;

            // Act
            double actual = Calculator.Add(5,5);

            // Assert
            Assert.Equal(expected,actual);
        }      

    }
}
```
