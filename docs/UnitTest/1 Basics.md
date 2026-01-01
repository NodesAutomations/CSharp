# XUnit Basics

## Overview
- XUnit is a popular open-source unit testing framework for .NET applications.
- Good support for modern .NET features and is widely adopted in the .NET community.
- [XUnit](https://xunit.net/)

## Setting up XUnit in your project
- Create .Net 8 Class Library project with `MathUtil` class.
- XUnit test project from Visual Studio template.
- Remove Old XUnit package
- Add ` xunit.v3` Nuget package to test project.
- Update `xunit.runner.visualstudio` to latest version.
- Update `Microsoft.NET.Test.Sdk` to latest version.
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