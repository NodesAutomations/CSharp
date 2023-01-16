### Code to Get Double value from User
```csharp
  //Code to update property
  var inputPrompt = editor.GetDouble(new PromptDoubleOptions($"\nEnter New Value for {property.PropertyName}"));

  if (inputPrompt.Status == PromptStatus.OK)
  {
      property.Value = inputPrompt.Value;
  }
```
