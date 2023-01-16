### Code to get string from user
```csharp
 public static string GetString(string message="\nEnter Text",bool isAllowSpaces=false)
        {
            var doc = DocumentUtil.GetActiveDocument();
            PromptStringOptions pStrOpts = new PromptStringOptions(message);
            pStrOpts.AllowSpaces = isAllowSpaces;
            PromptResult pStrRes = doc.Editor.GetString(pStrOpts);
            if (pStrRes.Status==PromptStatus.Cancel)
            {
                return null;
            }
            return pStrRes.StringResult;
        }
```

### Code to Get Double value from User
```csharp
  //Code to update property
  var inputPrompt = editor.GetDouble(new PromptDoubleOptions($"\nEnter New Value for {property.PropertyName}"));

  if (inputPrompt.Status == PromptStatus.OK)
  {
      property.Value = inputPrompt.Value;
  }
```
