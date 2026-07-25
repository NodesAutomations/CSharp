### Databinding
- For Databinding you have to implement INotifyPropertyChanged interface
- Which contain PropertyChangedEventHandler, which we can trigger everytime we update our property

### Sample Code
```xml
Title="Test" Height="250" Width="300">
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition/>
        <RowDefinition/>
        <RowDefinition/>
        <RowDefinition/>
    </Grid.RowDefinitions>
    <TextBox Grid.Row="0" Name="NameTextBox" Height="40" Width="250" Text="{Binding ClientName,UpdateSourceTrigger=PropertyChanged}"/>
    <Button Grid.Row="1" Name="SubmitButton" Height="40" Width="100" Content="Submit" Click="SubmitButton_Click"/>
    <TextBlock Grid.Row="2" Name="ResultTextBlock" Height="40" Width="250" Text="{Binding ClientName}"/>
    <Button Grid.Row="3" Name="UpdateButton" Height="40" Width="100" Content="Update Name" Click="UpdateNameButton_Click"/>
</Grid>
```
```csharp
 public partial class Test : Window, INotifyPropertyChanged
 {
     public Test()
     {
         DataContext = this;
         InitializeComponent();
     }

     private string _name = string.Empty;
     public string ClientName
     {
         get { return _name; }
         set
         {
             _name = value;
             OnPropertyChanged(nameof(ClientName));
         }
     }

     public event PropertyChangedEventHandler PropertyChanged;

     protected virtual void OnPropertyChanged(string propertyName)
     {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
     }
     private void SubmitButton_Click(object sender, RoutedEventArgs e)
     {
         MessageBox.Show($"Hello, {ClientName}!");
     }
     private void UpdateNameButton_Click(object sender, RoutedEventArgs e)
     {
         ClientName = "Nodes Automations";
     }
 }
```
