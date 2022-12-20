### Numbers 
```Csharp
    //Numbers
    int a = 7;
    int b = 4;
    int c = 3;
    int d = (a + b) / c;
    int e = (a + b) % c;
    Console.WriteLine($"quotient: {d}");
    Console.WriteLine($"remainder: {e}");
    int max = int.MaxValue;
    int min = int.MinValue;
    Console.WriteLine($"The range of integers is {min} to {max}");
    /*
    quotient: 3
    remainder: 2
    The range of integers is -2147483648 to 2147483647
     */

    double a= 19;
    double b= 23;
    double c= 8;
    double d= (a + b) / c;
    Console.WriteLine(d);
    double max = double.MaxValue;
    double min = double.MinValue;
    Console.WriteLine($"The range of double is {min} to {max}");

    double a = 1.0;
    double b = 3.0;
    Console.WriteLine(a / b);

    decimal c = 1.0M;
    decimal d = 3.0M;
    Console.WriteLine(c / d);
```

### Strings
```
    //String Variables
    string aFriend = "Bill";
    Console.WriteLine(aFriend);
    Console.WriteLine("Hello " + aFriend);
    Console.WriteLine($"Hello {aFriend}");

    string firstFriend = "Maria";
    string secondFriend = "Sage";
    Console.WriteLine($"My friends are {firstFriend} and {secondFriend}");
```
