# Abstract Factory Pattern

## Overview

## Use Case
- When you want to provide family of related objects without specifying their concrete classes.

## Code
Product interface
```csharp

    interface IButton
    {
        void Click();
    }
    interface ICheckbox
    {
        void Check();
    }
    class WinButton : IButton
    {
        public void Click()
        {
            Console.WriteLine("Windows button clicked.");
        }
    }
    class WinCheckbox : ICheckbox
    {
        public void Check()
        {
            Console.WriteLine("Windows checkbox checked.");
        }
    }
    class MacButton : IButton
    {
        public void Click()
        {
            Console.WriteLine("Mac button clicked.");
        }
    }
    class MacCheckbox : ICheckbox
    {
        public void Check()
        {
            Console.WriteLine("Mac checkbox checked.");
        }
    }
```

- Factory interface
```csharp
    interface IGUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }
     class WinFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }
        public ICheckbox CreateCheckbox()
        {
            return new WinCheckbox();
        }
    }

    class MacFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }
        public ICheckbox CreateCheckbox()
        {
            return new MacCheckbox();
        }
    }
```
- Client code
```csharp
    IGUIFactory factory = new MacFactory();
    var button = factory.CreateButton();
    button.Click();
    var checkbox = factory.CreateCheckbox();
    checkbox.Check();
```