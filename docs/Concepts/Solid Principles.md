# Solid Principles

## Overview
- SOLID is five design principles intended to make software designs more understandable, flexible, and maintainable.
- As everything in life, using these principles mindlessly can cause more harm than good. The cost of applying these principles into program's architecture might be making it more complicated than it should be.

## S - Single Responsibility Principle
- **A class should have one, and only one, reason to change.**
- Try to make every class responsible for single part of the functionality makes responsibility entirely encapsulated by the class.
- The main goal of this principle is reducing complexity. You don't need to invent sophisticated design for a program that only has about 200 lines of code. 
- When program constantly grows and changes, classes become so big that you can no longer remember their details. Code navigation slows to crawl, and you have to scan through whole classes or even an entire program to find specific things. The number of entities in program overflows your brain stack, and you feel that you're losing control over the code.
- If a classes too many things, everytime you have to change it you might break other parts fo the class which you didn't even intend to change.

## O - Open/Closed Principle
- **Classes should be open for extension but closed for modification.**
- The main idea of this principle is to keep existing code from breaking when you mplement new features.

## L - Liskov Substitution Principle
- **When extending a class, remember that you should be able to pass objects of subclass in pace fo objects of the parent class without breaking the client code.**
- This means that sublcass should remain compatible with the behavior of the superclass. When overridding method, extend the base behavior rather than replacing it with something else entirely.

## I - Interface Segregation Principle
- **Clients should not be forced to depend on methods they do not use.**
- Try to make your interfaces narrow enogh that client classes don't have to implement behavious they don't need. 

## D - Dependency Inversion Principle
- ** High-level classes should not depend on low-level classes. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions.**
