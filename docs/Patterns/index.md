# Patterns

## What are Design Patterns?
- Design pattern are typical solutions to common problems in software design.
- Each pattern is like a blueprint that you can customize to solve a particular design problem in your code.

## Benefits of Using Design Patterns
- It's solution to common problems that software design.
- They also define common language for developers, making it easier to communicate ideas and solutions.

## Classification of Design Patterns
- All patterns can be categorized by their purpose. The three main categories are:
- **Creational Patterns**: provide object creation mechanisms that increase flexibility and reuse of existing code. Examples include Singleton, Factory Method, and Abstract Factory.
  - **Structural Patterns**: explain how to assemble objects and classes into larger structures. While keeping these structure flexible and efficient. Examples include Adapter, Composite, and Decorator.
  - **Behavioral Patterns**: takes care of effective communication and the assignment of responsibilities between objects. Examples include Observer, Strategy, and Command.

### Creational Patterns
- **Factory Method** : Provide an interface for creating objects in a superclass, but allow subclasses to alter the type of objects that will be created.
- **Abstract Factory** : Lets you produce families of related objects without specifying their concrete classes.
- **Builder** : Lets you construct complex objects step by step. The construction process can create different representations and provides a high level of control over the construction process.
- **Prototype** : Lets you copy existing objects without making your code dependent on their classes.
- **Singleton** : Lets you ensure that a class has only one instance, while providing a global access point to this instance.

### Structural Patterns
- **Adapter** : Provide a unified interface that allows objects with incompatible interfaces to work together.
- **Bridge** : Lets you split a large class or a set of closely related classes into two separate hierarchies—abstraction and implementation—which can be developed independently of each other.
- **Composite** : Lets you compose objects into tree structures and then work with these structures as if they were individual objects.
- **Decorator** : Lets you attach new behaviors to objects by placing them inside special wrapper objects that contain the behaviors.
- **Facade** : Provides a simplified interface to a larger body of code, such as a class library.
- **Flyweight** : Lets you fit more objects into the available amount of RAM by sharing common parts of state between multiple objects instead of keeping all of the data in each object.
- **Proxy** : Lets you provide a substitute or placeholder for another object. A proxy controls access to the original object, allowing you to perform something either before or after the request gets through to the original object.

### Behavioral Patterns
- **Chain of Responsibility** : Lets you pass requests along a chain of handlers. Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain.
- **Command** : Turns a request into a stand-alone object that contains all information about the request. This transformation lets you parameterize methods with different requests, delay or queue a request’s execution, and support undoable operations.
- **Iterator** : Let you transverse elements of a collection without exposing its underlying representation (list, stack, tree, etc.).
- **Mediator** : Lets you reduce chaotic dependencies between objects. The pattern restricts direct communications between the objects and forces them to collaborate only via a mediator object.
- **Memento** : Lets you save and restore the previous state of an object without revealing the details of its implementation.
- **Observer** : Lets you define a subscription mechanism to notify multiple objects about any events that happen to the object they’re observing.
- **State** : Lets an object alter its behavior when its internal state changes. It appears as if the object changed its class.
- **Strategy** : Lets you define a family of algorithms, put each of them into a separate class, and make their objects interchangeable.
- **Template Method** : Defines the skeleton of an algorithm in the superclass but lets subclasses override specific steps of the algorithm without changing its structure.
- **Visitor** : Lets you separate algorithms from the objects on which they operate.

## Resources
- [Design Patterns in C#](https://www.dofactory.com/net/design-patterns)
- [Refactoring Guru](https://refactoring.guru/design-patterns/catalog)
- [C# Design Pattern](https://www.youtube.com/playlist?list=PLOeFnOV9YBa4ary9fvCULLn7ohNKR6Ees)
- [Frustrated with learning all of the design patterns](https://www.reddit.com/r/developersIndia/comments/1mfydex/frustrated_with_learning_all_of_the_design)