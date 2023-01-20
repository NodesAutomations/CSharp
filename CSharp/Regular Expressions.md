### sample code to find all words that start with letter "M"
```csharp
private static void Main()
{
    // Create a pattern for a word that starts with letter "M"
    string pattern = @"\b[M]\w+";
    // Create a Regex
    Regex rg = new Regex(pattern);

    // Long string
    string authors = "Mahesh Chand, Raj Kumar, Mike Gold, Allen O'Neill, Marshal Troll";

    // Get all matches
    MatchCollection matchedAuthors = rg.Matches(authors);
    // Print all matched authors
    for (int i = 0; i < matchedAuthors.Count; i++)
    {
	Console.WriteLine(matchedAuthors[i].Value);
    }

    Console.ReadLine();
}
```

### Main Class

```csharp
using System;
using System.Text.RegularExpressions;

namespace RegExApplication {
   class Program {
      private static void showMatch(string text, string expr) {
         Console.WriteLine("The Expression: " + expr);
         MatchCollection mc = Regex.Matches(text, expr);
         
         foreach (Match m in mc) {
            Console.WriteLine(m);
         }
      }
     
   }
}
```

### Additional Methods in above class

```csharp
static void Main(string[] args) {
         string str = "A Thousand Splendid Suns";
         
         Console.WriteLine("Matching words that start with 'S': ");
         showMatch(str, @"\bS\S*");
         Console.ReadKey();
      }
```

```
Matching words that start with 'S':
The Expression: \bS\S*
Splendid
Suns
```

```csharp
static void Main(string[] args) {
         string str = "make maze and manage to measure it";

         Console.WriteLine("Matching words start with 'm' and ends with 'e':");
         showMatch(str, @"\bm\S*e\b");
         Console.ReadKey();
      }
```

```
Matching words start with 'm' and ends with 'e':
The Expression: \bm\S*e\b
make
maze
manage
measure
```

```csharp
using System;
using System.Text.RegularExpressions;

namespace RegExApplication {
   class Program {
      static void Main(string[] args) {
         string input = "Hello   World   ";
         string pattern = "\\s+";
         string replacement = " ";
         
         Regex rgx = new Regex(pattern);
         string result = rgx.Replace(input, replacement);

         Console.WriteLine("Original String: {0}", input);
         Console.WriteLine("Replacement String: {0}", result);    
         Console.ReadKey();
      }
   }
}
```

```
Original String: Hello World   
Replacement String: Hello World
```
### Code Check if string is valid prefix for file name

```csharp
string[] prefixs = { "M1","1","-" , "M1-"," ","M1_M2", "M1_" };
                foreach (string prefix in prefixs)
                {
					//\W check if string contain any non word character
					//|is used to combine two checks
					//_$ check if string end with Underscore
                    var match = Regex.IsMatch(prefix, @"\W|_$");
                    Console.WriteLine(prefix + " is " + (match ? "InValid" : "Valid"));
                }
```

```csharp
public class PrefixValidationTest
    {
        [Theory]
        [InlineData("M1", true)]
        [InlineData("1", true)]
        [InlineData("-", false)]
        [InlineData("M1-", false)]
        [InlineData("M1_M2", true)]
        [InlineData("M1_", false)]
        public void IsValid(string input, bool expected)
        {
            var actual = PrefixValidation.IsValid(input);
            Assert.Equal(expected, actual);
        }
    }
```

### Coordinate Data validation

```csharp
public static class CoordinateDataValidation
    {
        public static bool IsValid(string data)
        {
            //Must Only Contain one comma
            if (Regex.Matches(data, ",{1}").Count!=1)
            {
                return false;   
            }
            //Must not contain any symbol except comma
            if (Regex.Matches(data, @"[^\d,-]").Count>0)
            {
                return false;
            }
            if (Regex.Matches(data, @"[\d-][\d]*,[\d-][\d]*").Count!=1)
            {
                return false;
            }
            return true;
        }
    }
```

```csharp
public class CoordinateDataValidationTest
    {
        [Theory]
        [InlineData("0,0", true)]
        [InlineData("00", false)]
        [InlineData(",00", false)]
        [InlineData(",", false)]
        [InlineData("0,,0", false)]
        [InlineData("10,10", true)]
        [InlineData("10,-10", true)]
        [InlineData("-10,10", true)]
        [InlineData("+10,10", false)]
        [InlineData("10,+10", false)]
        [InlineData("10.10", false)]
        [InlineData("10*10", false)]
        public void IsValid(string input, bool expected)
        {
            var actual = CoordinateDataValidation.IsValid(input);
            Assert.Equal(expected, actual);
        }
    }
```
