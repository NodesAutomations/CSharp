The basic difference is that generic collections are strongly typed and non-generic collections are not, unless they've been specially written to accept just a single type of data.

In the .NET Framework, the non-generic collections (ArrayList, Hashtable, SortedKist, Queue etc.) store elements internally in 'object' arrays which, can of course, store any type of data.

This means that, in the case of value types (int, double, bool, char etc), they have to be 'boxed' first and then 'unboxed' when you retrieve them which is quite a slow operation.

Whilst you don't have this problem with reference types, you still have to cast them to their actual types before you can use them.

In contrast, generic collections (List<T>, Dictionary<T, U>, SortedList<T, U>, Queue<T> etc) store elements internally in arrays of their actual types and so no boxing or casting is ever required.

This means that generic collections are faster than their non-generic counterparts when using value types and more convenient when using reference types. In short, the latter are now virtually redundant.
