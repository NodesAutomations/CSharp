### What it is?
- Command groups allows  you to organize commands using group name
- I mostly prefer to use company name or App name for command group name
- For example sample code for using command group is given below
  - Here you can either use short `RC` command to create red circle
  - Or use full `Nodes.RC` command to create red circle
  - Second option will make sure that your command won't conflict with existing command

```csharp
[CommandMethod("Nodes",nameof(RC))]
public void RC() 
{
    //Create Red Circle
}
```
