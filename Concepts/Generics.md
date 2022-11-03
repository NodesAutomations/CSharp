### What

It is a Class for List of Object.

### Example for List of Integer without using Generics

```csharp
public class IntList
    {
        public void Add(int number)
        {
            throw new NotImplementedException;
        }

        public int this[int index]
        {
            get
            {
                throw new NotImplementedException;
            }
        }
    }
```

```csharp
public class ObjectList
    {
        public void Add(object number)
        {
            throw new NotImplementedException;
        }

        public int this[object index]
        {
            get
            {
                throw new NotImplementedException;
            }
        }
    }
```

Before Generics this Class Need Be created for every Object. 

<aside>
✏️ Note : Another Method is Use Object Variable instead of Specify object type but that is also not very efficient because for evert call we need to use object casting to convert Object which will create performance paneity for large list. Generics came as solution to Solve this Problem.

</aside>

```csharp
public class GenericList<T>
    {
        public void Add(T value)
        {
            throw new NotImplementedException();
        }
        public T this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
```

Generics let use Create List of Object without any performance paneity.
