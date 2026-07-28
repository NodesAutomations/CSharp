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
## Key Press Event
- Key press event mostly used for textbox data entry

## Key Down Event
- Mostly used for add custom functionality for textbox data entry, like incrementing or decrementing a number in the textbox when up or down arrow key is pressed.
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

## Preview Text Input Event
- PreviewTextInput event is used to validate the input in the textbox, for example, we can use this event to allow only numbers and decimal point in the textbox.

```xml
<TextBox Grid.Row="1" Grid.Column="1" Text="{Binding Dia, UpdateSourceTrigger=Explicit}" Margin="0,0,0,10"
    PreviewTextInput="DiaTextBox_PreviewTextInput" />
```
```csharp
private void NosTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
{
    // Allow only numbers and decimal point
    if (!char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != ".")
    {
        e.Handled = true;
    }
}
```

## Lost Focus Event
- LostFocus event is used to validate the input in the textbox when the textbox loses focus, for example, we can use this event to check if the input is a valid number and within a certain range.
- Sample code to validate Bar Diameter input in the textbox when it loses focus, and update the bound property if the input is valid.

```xml
<TextBox Grid.Row="1" Grid.Column="1" Text="{Binding Dia, UpdateSourceTrigger=Explicit}" Margin="0,0,0,10"
    LostFocus="DiaTextBox_LostFocus" />
```
```csharp
private void DiaTextBox_LostFocus(object sender, RoutedEventArgs e)
{
    var textBox = (TextBox)sender;

    if (double.TryParse(textBox.Text, out var diameter)
        && DesignData.AllowedDia.Contains(diameter))
    {
        //Update the bound property if the input is valid
        DesignData.Dia = diameter;
        //Update the text box value from binding to ensure it reflects the bound property
        textBox.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
        return;
    }
    //Reset text box value from binding if the input is invalid
    textBox.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
}
```