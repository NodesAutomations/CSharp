## Overview
- NCalc is a fast and lightweight expression evaluator library for .NET
- designed for flexibility and high performance.
- It supports a wide range of mathematical and logical operations.
- Use `dotnet add package NCalcSync` to install nuget package
- Add `using NCalc;` 

## Simple Expression

```csharp
var expression = new Expression("2 + 3 * 5");
Console.WriteLine($"Result: {expression.Evaluate()}");
```
## Equations with variables
```csharp
string exprText = "2 + 3 * x - Sin(y)";

var expr = new Expression(exprText);

expr.Parameters["x"] = 4;
expr.Parameters["y"] = Math.PI / 2;

var result = expr.Evaluate();    // result = 2 + 3*4 - 1 = 13
Console.WriteLine(result);
```

## What do i think
- Tried with `.Net framework 4.8` and it has lot of dependency
- Dependency looks better with  new version of `.Net` 
- Can be usable with project requires it but for minor functionality this is overkill
