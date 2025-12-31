# Unit Testing

## Overview?
- Unit testing is a software testing technique where individual units or components of a software application are tested in isolation to ensure they function as intended.
- A Unit is the smallest testable part of an application, typically a function, method or class.

## Benefits of Unit Testing
- It helps identify bugs early in the development process
- improves code quality
- ensures that changes or additions to the codebase do not introduce new issues.
- Documentation of code behavior through test cases.

## What not to do in Unit Tests?
- Interact with UI elements
- Call External API like AutoCAD, Excel, STAAD, ETABS etc
- Depend on file systems

## Unit Testing Frameworks
- XUnit is most commonly used framework for unit testing in .NET applications.
- You can also use other frameworks like NUnit or MSTest based on your preference.

### How to write Unit Tests?
- Most unit tests follow the Arrange-Act-Assert (AAA) pattern:
- **Arrange**: Set up the necessary preconditions and inputs.
- **Act**: Execute the unit of work being tested.
- **Assert**: Verify that the outcome is as expected.

