# Interfaces

## ITestOutputHelper output
- The `ITestOutputHelper` interface allows you to capture output during test execution.
- It is commonly used for logging information in tests, which can be helpful for debugging.

```csharp
public class MathUtilTest
{
    private readonly ITestOutputHelper _output;

    public MathUtilTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void TestAdd()
    {
        //Arrange
        var a = 1;
        var b = 2;

        //Act
        var result = MathUtil.Add(a, b);
        _output.WriteLine($"Adding {a} and {b} gives {result}");

        //Assert
        Assert.Equal(3, result);
    }
}
```