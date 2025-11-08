### References
- https://www.keanw.com/2006/10/perdocument_dat_1.html

### Global Class
- Application level Class
```csharp
    static public class FirstClass
    {
        private static int counter = 0;

        [CommandMethod("glob")]
        public static void global()
        {
            ActiveUtil.Editor.WriteMessage("\nCounter value is: " + counter++);
        }
    }
```
- this class initiated only one time per autocad session
- this will keep increasing counter value even if you open new drawing

### Local Class
- Document level Class
```csharp
    public class SecondClass
    {
        private int counter = 0;

        [CommandMethod("loc")]
        public void local()
        {
            ActiveUtil.Editor.WriteMessage("\nCounter value is: " + counter++);
        }
    }
```
- this class will initited everytime you open new autocad document
- this class will automatically reset counter value for each document, all document will have it's seperate counter value
