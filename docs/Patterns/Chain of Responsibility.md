# Chain of Responsibility

## Overview
- Chain of Responsibility is a behavioral design pattern that lets you pass requests along a chain of handlers. Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain.

## Use Case
- When we have sequential processing of requests/Checks that can be handled by different handlers.
- Something like UI when Button -> Panel -> Window -> Application. Each of them can handle the event or pass it to the next one.

## Code
- Assume that we are building software ticket management system. We have different levels of support: Low, Medium, and High. Each level can handle certain types of tickets, and if a ticket cannot be handled at the current level, it is passed to the next level.

```csharp
//Object data class
public class Ticket
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string AssignedTo { get; set; }
}
```
```csharp
//Handler interface/class
public abstract class TicketHandler
{
    protected TicketHandler NextHandler;
    public void SetNext(TicketHandler nextHandler)
    {
        NextHandler = nextHandler;
    }
    public abstract void Handle(Ticket ticket);
}

public class LowPriorityHandler : TicketHandler
{
    public override void Handle(Ticket ticket)
    {
        if (ticket.Priority == "Low")
        {
            Console.WriteLine($"Low priority ticket handled: {ticket.Title}");
        }
        else if (NextHandler != null)
        {
            NextHandler.Handle(ticket);
        }
    }
}
public class MediumPriorityHandler : TicketHandler
{
    public override void Handle(Ticket ticket)
    {
        if (ticket.Priority == "Medium")
        {
            Console.WriteLine($"Medium priority ticket handled: {ticket.Title}");
        }
        else if (NextHandler != null)
        {
            NextHandler.Handle(ticket);
        }
    }
}

public class HighPriorityHandler : TicketHandler
{
    public override void Handle(Ticket ticket)
    {
        if (ticket.Priority == "High")
        {
            Console.WriteLine($"High priority ticket handled: {ticket.Title}");
        }
        else if (NextHandler != null)
        {
            NextHandler.Handle(ticket);
        }
    }
}
```
```csharp
private static void Main()
{
    //Ticket management system with chain
    var lowPriorityHandler = new LowPriorityHandler();
    var mediumPriorityHandler = new MediumPriorityHandler();
    var highPriorityHandler = new HighPriorityHandler();

    lowPriorityHandler.SetNext(mediumPriorityHandler);
    mediumPriorityHandler.SetNext(highPriorityHandler);

    var ticket1 = new Ticket { Title = "Low priority issue", Description = "This is a low priority issue.", Status = "Open", Priority = "Low", AssignedTo = "John" };
    var ticket2 = new Ticket { Title = "Medium priority issue", Description = "This is a medium priority issue.", Status = "Open", Priority = "Medium", AssignedTo = "Jane" };
    var ticket3 = new Ticket { Title = "High priority issue", Description = "This is a high priority issue.", Status = "Open", Priority = "High", AssignedTo = "Bob" };

    lowPriorityHandler.Handle(ticket1);
    lowPriorityHandler.Handle(ticket2);
    lowPriorityHandler.Handle(ticket3);
}
```