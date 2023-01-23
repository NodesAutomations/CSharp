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
### Code to Get Keyword from User
```csharp
[CommandMethod("GetKeywordFromUser")]
public static void GetKeywordFromUser()
{
    Document doc = Application.DocumentManager.MdiActiveDocument;

    PromptKeywordOptions keywordPromptOptions = new PromptKeywordOptions("");
    keywordPromptOptions.Message = "\nEnter an option ";
    keywordPromptOptions.Keywords.Add("Line");
    keywordPromptOptions.Keywords.Add("Circle");
    keywordPromptOptions.Keywords.Add("Arc");
    keywordPromptOptions.Keywords.Default = "Arc";
    keywordPromptOptions.AllowNone = false;

    PromptResult pKeyRes = doc.Editor.GetKeywords(keywordPromptOptions);

    Application.ShowAlertDialog("Entered keyword: " + pKeyRes.StringResult);
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
[CommandMethod("TEST")]
public void Test()
{
    var doc = Application.DocumentManager.MdiActiveDocument;

    PromptPointOptions promptPointOptions = new PromptPointOptions("Pick Origin Point");
    PromptPointResult pointResult = doc.Editor.GetPoint(promptPointOptions);
    if (pointResult.Status==PromptStatus.OK)
    {
        Point3d point = pointResult.Value;
        doc.Editor.WriteMessage($"\nPoint:{point.X},{point.Y},{point.Z}");
    }

}
```
### Code to get distance from user
```csharp
[CommandMethod("TEST")]
public void Test()
{
    var doc = Application.DocumentManager.MdiActiveDocument;

    PromptDistanceOptions promptDistanceOptions = new PromptDistanceOptions("Pick  Distance : ");
    PromptDoubleResult promptDoubleResult = doc.Editor.GetDistance(promptDistanceOptions);

    if (promptDoubleResult.Status == PromptStatus.OK)
    {

        doc.Editor.WriteMessage($"\nDistance:{promptDoubleResult.Value}");
    }

}
```
