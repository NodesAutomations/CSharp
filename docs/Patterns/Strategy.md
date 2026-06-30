# Strategy Pattern

## Overview
- Strategy is a behavioral design pattern that lets you define a family of algorithms, put each of them into a separate class, and make their objects interchangeable.

## Use Case
- When  your class has massive conditional operator that switches between different variants of an algorithm.
- When you want to use different variants of an algorithm within an object and switch from one algorithm to another during runtime.
- When you have a lot of similar classes that only differ in the way they execute some behavior.

## Code
- Assume we are building shipping management system.
- We have an order that needs to be shipped to the customer by specific shipping method.

```csharp
//Class to store order details
public class Order
{
    public int Id { get; set; }
    public double Weight { get; set; }
    public double Amount { get; set; }
}
```
```csharp
//Interface to define the strategy for shipping
public interface IShippingStrategy
{
    string ProviderName { get; set; }
    double CalculateCost(Order order);
}
public class FedExShippingStrategy : IShippingStrategy
{
    public string ProviderName { get; set; } = "FedEx";
    public double CalculateCost(Order order)
    {
        return order.Weight * 0.5 + order.Amount * 0.1;
    }
}

public class UPSShippingStrategy : IShippingStrategy
{
    public string ProviderName { get; set; } = "UPS";
    public double CalculateCost(Order order)
    {
        return order.Weight * 0.6 + order.Amount * 0.2;
    }
}
public class AmazoneShippingStrategy : IShippingStrategy
{
    public string ProviderName { get; set; } = "Amazone";
    public double CalculateCost(Order order)
    {
        return order.Weight * 0.4 + order.Amount * 0.15;
    }
}
```
```csharp
//Class to process oroder shipping using strategy pattern
public class OrderProcessor
{
     private readonly Dictionary<string, IShippingStrategy> _shippingStrategies;

    public OrderProcessor(List<IShippingStrategy> shippingStrategies)
    {
        _shippingStrategies = new Dictionary<string, IShippingStrategy>();
        foreach (var strategy in shippingStrategies)
        {
            _shippingStrategies[strategy.ProviderName] = strategy;
        }
    }
    public void CalculateShippingCost(Order order, string providerName)
    {
        if (_shippingStrategies.TryGetValue(providerName, out var strategy))
        {
            double shippingCost = strategy.CalculateCost(order);
            Console.WriteLine($"Order ID: {order.Id}, Shipping Provider: {strategy.ProviderName}, Shipping Cost: {shippingCost}");
        }
        else
        {
            Console.WriteLine($"Shipping provider '{providerName}' not found.");
        }
    }
}
```
```csharp
//Client Code
private static void Main()
{
        //Strategy Pattern sample
        var order = new Order { Id = 1, Weight = 10.5, Amount = 100.0 };
        var orderProcessor = new OrderProcessor(new List<IShippingStrategy>
        {
            new FedExShippingStrategy(),
            new UPSShippingStrategy(),
            new AmazoneShippingStrategy()
        });

        orderProcessor.CalculateShippingCost(order, "FedEx");
        orderProcessor.CalculateShippingCost(order, "UPS");
        orderProcessor.CalculateShippingCost(order, "Amazone");
}
```
