### Ref

- Ref allows **even value types to be passed by reference**
- Normally, passing an int to a method and changing the value inside would not keep it outside
- However, **using ref keyword that keeping a value that was changed within a method is possible**

### In

- In behaves exactly like ref
- The only difference is that **it doesn’t let the parameter to be modified inside the method**
- In is mostly useful for memory optimizations, when pass a struct often and passing copying all the values all the time is not worth it (when CPU is more needed than RAM)

### Out

- Sometimes we need to return multiple values from a single method
- We normally return to the context with a value using return keyword
- In C#, we can **return multiple values using ``out`` keyword**

### When should you use ref, out or in?

- Almost never.
- For now, just be familiar with official requirements of framework and don’t get intimidated when you need to apply it (for calling some api)
- Out of the 3, out has a reasonable use, in bool TrySomething(string input, out result) pattern
