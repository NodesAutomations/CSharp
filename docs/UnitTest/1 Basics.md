# xUnit Basics

## Overview
- xUnit is a popular open-source unit testing framework for .NET applications.
- Good support for modern .NET features and is widely adopted in the .NET community.
- [xUnit](https://xunit.net/)

## Setting up xUnit in your project
- Create .Net Class Library project with `MathUtil` class.
- xUnit test project from Visual Studio template.
- Remove Old xUnit package
- Add ` xunit.v3` Nuget package to test project. this will provide the test framework, attributes, assertions, and xUnit execution logic.
- Update `xunit.runner.visualstudio` to latest version. This is to use the xUnit adapter used by Visual Studio Test Explorer and the .NET test platform.
- Update `Microsoft.NET.Test.Sdk` to latest version. This provides the test platform infrastructure, including the test host, test discovery, execution protocol, and reporting integration.
- Add Project Reference which you're going to test.
- Add `MathUtilTest` class to test project.

```csharp title="MathUtil Class"
public  static class MathUtil
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
    public static int Subtract(int a, int b)
    {
        return a - b;
    }
    public static int Multiply(int a, int b)
    {
        return a * b;
    }
    public static double Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Denominator cannot be zero.");
        }
        return (double)a / b;
    }
}
```

```csharp title="MathUtilTests Class"
public class MathUtilTest
{
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
}
```

### Naming Conventions
- Class Naming: Use the name of the class being tested followed by "Tests". For example, `MathUtilTests`.
- Test Method Naming: Use descriptive names that indicate the method being tested and the expected outcome. For example
  - `<MethodName>_Should<ExpectedBehavior>_When<Condition>`
  - `Add_ShouldReturnSum_WhenGivenTwoIntegers`


### Keyboard Shortcuts
| Action | Keyboard Shortcut | IDE |
|---|---|---|
| Run Selected Test | `Ctrl + R, T` | Visual Studio |
| Debug Tests | `Ctrl + R, Ctrl + T` | Visual Studio |
| Run Tests | `Ctrl + R, A` | Visual Studio |
| Navigate to Test Explorer | `Ctrl + E, T` | Visual Studio |