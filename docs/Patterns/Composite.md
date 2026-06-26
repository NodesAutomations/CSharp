# Composite 

## Overview
- Composite is structural design pattern that let ou compose objects into tree structure and then work with them as if they were individual objects.

## Use Case
- Tree like structure of objects (StaadModel, File System, etc.)
- Organization of objects in a hierarchy (Company, Department, Military, etc.)

## Code
```csharp
public class Node
{
    public Node(string data)
    {
        NodeData = data;
    }

    public string NodeData { get; private set; }
    public List<Node> Nodes { get; private set; } = new List<Node>();

    public override string ToString()
    {
        // Implementation for computing nodes
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("Start");
        sb.AppendLine(NodeData);
        foreach (var node in Nodes)
        {
            sb.AppendLine(node.ToString());
        }
        sb.AppendLine("End");
        return sb.ToString();
    }
}
```
```csharp
 private static void Main()
 {
     //Composite Pattern
     var top = new Node("Top");
     top.Nodes.Add(new Node("2nd Level 1"));
     top.Nodes.Add(new Node("2nd Level 2"));

     var secondLevel3 = new Node("2nd Level 3");
     top.Nodes.Add(secondLevel3);

     secondLevel3.Nodes.Add(new Node("3rd Level 1"));
     secondLevel3.Nodes.Add(new Node("3rd Level 2"));
     secondLevel3.Nodes.Add(new Node("3rd Level 3"));

     Console.WriteLine(top); 
 }
```

