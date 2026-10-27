
## What is MVVM Toolkit
- The CommunityToolkit.Mvvm is a free, open-source library maintained by Microsoft and the .NET community.
- It provides a set of helpers and base classes to implement the MVVM pattern in WPF applications efficiently.
It helps you write cleaner C# code for WPF applications, especially when working with data binding, buttons, commands, and updating the UI when values change.

## RelayCommand

### Overview
- RelayCommand is a simple way to connect a button to a method in your ViewModel without writing a click event in the code-behind.
- This allow as to move the logic from the code-behind to the ViewModel, keeping the UI and business logic separate.
- Relay command is not built into WPF by default. You need to implement it yourself or use a library like MVVM Light or CommunityToolkit.Mvvm.

### Original Button Code
    ```xml
    <Button Content="Save" Click="SaveButton_Click"/> 
    ```
    ```csharp
    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Client saved!");
    }
    ```

### Button with RelayCommand
- Here save button bind to the `SaveCommand` property in the ViewModel.
```xml
<Button Content="Save" Command="{Binding SaveCommand}"/>
```
```csharp
public RelayCommand SaveCommand { get; }

public ViewModel()
{
    SaveCommand = new RelayCommand(SaveClient);
}

private void SaveClient()
{
    MessageBox.Show("Client saved!");
}
```

## RelayCommand<T>

### Overview
- RelayCommand<T> is a generic version of RelayCommand that allows you to pass a parameter to the command.
- The parameter type is specified by the generic type T.

```xml
<Button Content="Save" Command="{Binding SaveCommand}" CommandParameter="{Binding SelectedClient}"/>
```
```csharp
public RelayCommand<Client> SaveCommand { get; }

public ViewModel()
{
    SaveCommand = new RelayCommand<Client>(SaveClient);
}

private void SaveClient(Client client)
{
    MessageBox.Show($"Client {client.Name} saved!");
}
```

## ObservableObject

## ObservableProperty

## ObservableRecipient

## ObservableValidator
