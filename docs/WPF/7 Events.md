## Overview
- Events are actions or occurrences that happen in the application, such as user interactions (clicks, key presses) or system-generated events (timers, data changes).
- In WPF, events are used to handle user interactions and respond to changes in the application

## Click Event
- click event is pretty simple, we can define click event in xaml and then define the event handler in code behind

```xml
<Button Name="RunButton" Content="Run" Click="RunButton_Click" Margin="10"/>
```
```csharp
private void RunButton_Click(object sender, RoutedEventArgs e)
{
    MessageBox.Show("Run button clicked!");
}
```

## Key Down Event
- Define keydown event in xaml for textbox

```xml
<TextBlock Grid.Row="0" Grid.Column="0" Text="Number of bars:" Margin="0,0,10,10" />
<TextBox Grid.Row="0" Grid.Column="1" Text="{Binding Nos}" Margin="0,0,0,10"
        KeyDown="NosTextBox_KeyDown" />

<TextBlock Grid.Row="1" Grid.Column="0" Text="Bar diameter (mm):" Margin="0,0,10,10" />
<TextBox Grid.Row="1" Grid.Column="1" Text="{Binding Dia}" Margin="0,0,0,10"
            KeyDown="DiaTextBox_KeyDown" />
```

- Define keydown event in code behind for textbox

```csharp
private void NosTextBox_KeyDown(object sender, KeyEventArgs e)
{
    TextBox? textBox = sender as TextBox;
    textBox?.KeyDown_Value(e, 1, 2, 1000);
}

private void DiaTextBox_KeyDown(object sender, KeyEventArgs e)
{
    TextBox? textBox = sender as TextBox;
    textBox?.KeyDown_List(e, DesignData.AllowedDia);
}
```

- Define extension methods for textbox keydown event
- I am removing sub method to keep this short

```csharp
public static class TextBoxUtil
{
    public static void KeyDown_List(this TextBox textBox, KeyEventArgs e, List<double> values)
    {
        switch (e.Key)
        {
            case Key.Up:
            case Key.Add:
                textBox.PickNextFromList(values);
                e.Handled = true;
                break;

            case Key.Down:
            case Key.Subtract:
                textBox.PickPreviousFromList(values);
                e.Handled = true;
                break;

            default:
                break;
        }
    }
    public static void KeyDown_Value(this TextBox textBox, KeyEventArgs e, int increment, int minValue, int maxValue)
    {
        switch (e.Key)
        {
            case Key.Up:
            case Key.Add:
                textBox.IncrementNumber(increment, maxValue);
                e.Handled = true;
                break;

            case Key.Down:
            case Key.Subtract:
                textBox.DecrementNumber(increment, minValue);
                e.Handled = true;
                break;

            default:
                break;
        }
    }
}
```

