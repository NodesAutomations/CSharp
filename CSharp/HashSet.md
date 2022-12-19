## Overview

**C# HashSet is an unordered collection of the unique elements.** It was introduced in .NET 3.5 and is found in `System.Collections.Generic` namespace. It is used in a situation where we want to prevent duplicates from being inserted in the collection. **As far as performance is concerned, it is better in comparison to the list.** 

 
> 📢 Note : that the HashSet<T>.Add(T item) method returns a bool -- true if the item was added to the collection; false if the item was already present.
 

```csharp
namespace HashSetDemo {  
    class Program {  
        static void Main(string[] args) {  
            HashSet < string > names = new HashSet < string > {  
                "Rajeev",  
                "Akash",  
                "Amit"  
            };  
            foreach(var name in names) {  
                Console.WriteLine(name);  
            }  
            Console.ReadKey();  
        }  
    }  
}

//Output
Rajeev
Akash
Amit
```

## Basic Usage

Let's begin our example:

In the code, given above, we are creating a simple HashSet of the string type and adding the strings to it. We can also add the string, using the Add method. We will see how we can use the Add method in the snippet, given below. We will now try to add the duplicate string and see what happens.

```csharp
namespace HashSetDemo {  
    class Program {  
        static void Main(string[] args) {  
            HashSet < string > names = new HashSet < string > {  
                "Rajeev",  
                "Akash",  
                "Amit"  
            };  
						names.Add("Rajeev");
            foreach(var name in names) {  
                Console.WriteLine(name);  
            }  
            Console.ReadKey();  
        }  
    }  
}
```

```csharp
//Output
Rajeev
Akash
Amit
```

In the snippet, given above, **even though we try to add a duplicate string, we will not get any error but when we iterate the collection, we cannot find the string.** This shows that **we cannot add the duplicate elements to a HashSet.** 

## Methods

### UnionWith

This method **combines the elements, present in both the collections** into the collection on which it is called.

```csharp
namespace HashSetDemo {  
    class Program {  
        static void Main(string[] args) {  
            HashSet < string > names = new HashSet < string > {  
                "Rajeev",  
                "Akash",  
                "Amit"  
            };  
            HashSet < string > names1 = new HashSet < string > {  
                "Rajeev",  
                "Akash",  
                "Amit",  
                "Deepak",  
                "Mohit"  
            };  
            names.UnionWith(names1);  
            foreach(var name in names) {  
                Console.WriteLine(name);  
            }  
            Console.ReadKey();  
        }  
    }  
}
```

```csharp
//Output
Rajeev
Akash
Amit
Deepak
Mohit
```

### IntersectWith

This method **combines the elements that are common to both the collections**.

```csharp
namespace HashSetDemo {  
    class Program {  
        static void Main(string[] args) {  
            HashSet < string > names = new HashSet < string > {  
                "Rajeev",  
                "Akash",  
                "Amit"  
            };  
            HashSet < string > names1 = new HashSet < string > {  
                "Rajeev",  
                "Akash",  
                "Amit",  
                "Deepak",  
                "Mohit"  
            };  
            names.IntersectWith(names1);  
            foreach(var name in names) {  
                Console.WriteLine(name);  
            }  
            Console.ReadKey();  
        }  
    }  
}
```

```csharp
//Output
Rajeev
Akash
Amit
```

### ExceptWith

This method **removes all the elements that are present in the other collections** from the collection on which it is called.

```csharp
namespace HashSetDemo {  
    class Program {  
        static void Main(string[] args) {  
            HashSet < string > names = new HashSet < string > {  
                "Rajeev",  
                "Akash",  
                "Amit"  
            };  
            HashSet < string > names1 = new HashSet < string > {  
                "Rajeev",  
                "Akash",  
                "Amit",  
                "Deepak",  
                "Mohit"  
            };  
            names1.ExceptWith(names);  
            foreach(var name in names1) {  
                Console.WriteLine(name);  
            }  
            Console.ReadKey();  
        }  
    }  
}
```

```csharp
//Output
Deepak
Mohit
```

## HashSet with Custom Type

```csharp
namespace HashSetDemo {  
    class Program {  
        static void Main(string[] args) {  
            Console.WriteLine("-----Custom HashSet With Duplicates----");  
            HashSet < Employee > employees = new HashSet < Employee > {  
                {  
                    new Employee {  
                        Emp_Id = 1, Emp_name = "Rajeev", Dept_name = "IT"  
                    }  
                },  
                {  
                    new Employee {  
                        Emp_Id = 1, Emp_name = "Rajeev", Dept_name = "IT"  
                    }  
                },  
                {  
                    new Employee {  
                        Emp_Id = 3, Emp_name = "Akash", Dept_name = "IT"  
                    }  
                },  
                {  
                    new Employee {  
                        Emp_Id = 4, Emp_name = "Amit", Dept_name = "IT"  
                    }  
                }  
            };  
            Console.WriteLine("{0,-6}{1,10}{2,-8}", "Emp_Id", "Emp_name", "Dept_name");  
            Console.WriteLine("==============================");  
            foreach(var employee in employees) {  
                Console.WriteLine("{0,-8}{1,-10}{2,5}", employee.Emp_Id, employee.Emp_name, employee.Dept_name);  
            }  
            Console.WriteLine("==============================");  
            Console.ReadKey();  
        }  
    }  
    public class Employee {  
        public int Emp_Id {  
            get;  
            set;  
        }  
        public string Emp_name {  
            get;  
            set;  
        }  
        public string Dept_name {  
            get;  
            set;  
        }  
    }  
}
```

```csharp
-----Custom HashSet With Duplicates----
Emp_Id  Emp_nameDept_name
==============================
1       Rajeev       IT
1       Rajeev       IT
3       Akash        IT
4       Amit         IT
==============================
```

**We know that HashSet will not allow the duplicates into the collection but still in the output we are having the duplicate records. To overcome this drawback, we need to implement IEquatable interface, override Equals and GetHashCode methods.**

```csharp
public class Employee:IEquatable<Employee>
    {
        public int Emp_Id
        {
            get;
            set;
        }
        public string Emp_name
        {
            get;
            set;
        }
        public string Dept_name
        {
            get;
            set;
        }

        public bool Equals(Employee other)
        {
            return this.Emp_Id.Equals(other.Emp_Id);
        }
        public override int GetHashCode()
        {
            return this.Emp_Id.GetHashCode();
        }
    }
```

```csharp
-----Custom HashSet With Duplicates----
Emp_Id  Emp_nameDept_name
==============================
1       Rajeev       IT
3       Akash        IT
4       Amit         IT
==============================
```

Thus, HashSet is a generic collection, that does not allow duplicates. We can use HashSet to remove the duplicates from any collection like the List, using HashSet. For viewing the code, go to the following [link](https://dotnetfiddle.net/wjgKws).
