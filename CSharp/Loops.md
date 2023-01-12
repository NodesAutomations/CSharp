### For
        
```csharp
var names = new List<String> { "Vivek", "Ketul" };
foreach (var name in names)
{
    Console.WriteLine(name);
}
for (int i = 0; i < names.Count; i++)
{
    Console.WriteLine(names[i]);
}
```
        
### Do While
        
```csharp
int counter = 0;
do
{
    Console.WriteLine(counter);
    counter++;
}
while (counter < 10);
```
        
### While
        
```csharp
int counter = 0;
while (counter<10)
{
    Console.WriteLine(counter);
    counter++;
}
```
### Skip Loop Itermation
- we canuse `continue` command to skip loop iteration
```csharp
for (int i = 0; i < 10; i++) 
{
  if (i == 4) 
  {
    continue;
  }
  Console.WriteLine(i);
}
```
Output
```
0
1
2
3
5
6
7
8
9
```
### Break out of loop
- we can use `break` command to stop active loop and contine with next execution
```csharp
for (int i = 0; i < 10; i++) 
{
  if (i == 4) 
  {
    break;
  }
  Console.WriteLine(i);
}
```
Output
```
0
1
2
3
```

