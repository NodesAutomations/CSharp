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
### Code to get Point from user
```csharp
 public static Point2D GetPoint2D(string message = "\nSpecify Base Point")
        {
            var doc = DocumentUtil.GetActiveDocument();
            var pPtRes = doc.Editor.GetPoint(new PromptPointOptions(message));
            // Exit if the user presses ESC or cancels the command
            if (pPtRes.Status == PromptStatus.Cancel)
            {
                return null;
            }
            return new Point2D(pPtRes.Value.X, pPtRes.Value.Y);
        }
```
