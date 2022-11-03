## Class

- Building Block of Software Application

### Anatomy of Class

- Data : Represented by field
- Behavior : Represented by Methods and Functions

---

### UML(Unifying Modeling Language)

- Used to illustrate a class
- It Consist of three part
    - Class Name
    - Class Properties
    - Class Methods or Function
    
    ### Class Example
    
    ```csharp
    internal class Program
        {
            private static void Main(string[] args)
            {
                var p = new Person();
                    p.Name = "Vivek";
                p.Introduce();
    
            }
        }
    
        public class Person
        {
            public string Name;
    
            public void Introduce()
            {
                Console.WriteLine($"Hello My Name is {Name}");
            }
        }
    ```
    
    ### Class Members
    
    - Instance Type :  Accessible with instance of object
        - Sample Code
            
            ```csharp
                      var p = new Person();
                            p.Name = "Vivek";
                        p.Introduce();
            ```
            
    - Static Type : Accessible from  Class
        - Sample Code
            
            ```csharp
            console.writeline();
            ```
            
        
    
    ### Why Use Static Type Members
    
    - To Represent Concept such as singleton
    - for example Current Day time
