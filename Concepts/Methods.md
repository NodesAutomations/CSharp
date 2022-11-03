### Singature of Method

- Name of Method
- Number and Type of it's parameters
- In below code Point Class include Method : Move with x,y as it's parameter that is signature of that method

```csharp
public class Point
    {
        public void Move(double x,double y) { }    
    }
```

### Method Overloading

- In below code snippet we have move method with 2 different signatures this is called method overloading
- Compiler will automatically pick Right method based on input parameters

```csharp
public class Point
    {
        public void Move(double x,double y) { }
        public void Move(Point newLocation) { }

    }
```

### Method with Varying number of parameters

- Example 1 : here we have Add method with multiple signature, as you can see this is not Practical or efficient
- Example 2 : we have Add method with Array input which is better than first one but every time we need to use method we have to initiate array which is annoying
- Example 3 : Here we have Add method with Array but `params` modifier  Which lets us put as many inputs as we like without initializing array

```csharp
//Example 1
public class Calculator
    {
        public int Add(int n1, int n2) { }
        public int Add(int n1, int n2,int n3) { }
        public int Add(int n1, int n2,int n3,int n3) { }
    }

//Example 2
public class Calculator
    {
        public int Add(int[] numbers) { }
    }
//We use this var results=Calculator.Add(new int[]{1,2,3,4)});
//Example 3
public class Calculator
    {
        public int Add(params int[] numbers) { }
    }
//We use this var results=Calculator.Add(1,2,3,4);
```

### The Ref Modifier

- Here when we pass variable a to MyMethod value of a will remain same because a is value type and when we pass that to MyMethod it only gets copy of value a
- in DoThings method we are pasing var a as reference so value of a will get updated everytime we use that method

```csharp
public class MyClass
    {
       public void MyMethod(int a)
        {
            a += 2;
        }
			 public void DoThings(ref int a)
        {
            a += 2;
        }
    }
    var a = 1;
    a = MyClass.MyMethod(a);//value of a will remain same after this method
		a = MyClass.DoThings(ref a);//ref of a get pass to DoThings so a value will change
```
