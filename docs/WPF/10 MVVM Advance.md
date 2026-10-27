## RelayCommand

### Overview
- RelayCommand is a simple way to connect a button to a method in your ViewModel without writing a click event in the code-behind.
- This allow as to move the logic from the code-behind to the ViewModel, keeping the UI and business logic separate.
- Relay command is not built into WPF by default. You need to implement it yourself or use a library like MVVM Light or CommunityToolkit.Mvvm.

### Code without RelayCommand
    ```xml
    <Button Content="Save" Click="SaveButton_Click"/> 
    ```
    ```csharp
    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Client saved!");
    }
    ```

### Code with RelayCommand
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

### Command with Parameter
- If method has parameter you can use CommandParameter to pass the value.
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
