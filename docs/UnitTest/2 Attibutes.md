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