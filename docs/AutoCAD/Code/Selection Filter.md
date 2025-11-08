### References
- https://help.autodesk.com/view/OARX/2023/ENU/?guid=GUID-125398A5-184C-4114-9212-A2FF28FC1F1D

### Basic Code to use selection filter
```csharp
[CommandMethod("Test", CommandFlags.UsePickSet)]
        public static void Test()
        {
            try
            {
                using (Transaction tr = ActiveUtil.TransactionManager.StartTransaction())
                {
                    var typeValues = new List<TypedValue>();

                    typeValues.Add(new TypedValue((int)DxfCode.Start,"CIRCLE"));
                    
                    SelectionFilter filter = new SelectionFilter(typeValues.ToArray());
                    //Use Select all to Select all objects with selection Criteria
                    //PromptSelectionResult selectionResult = ActiveUtil.Editor.SelectAll(filter);

                    //Use get selection to only select from selected objects
                    PromptSelectionResult selectionResult = ActiveUtil.Editor.GetSelection(filter);

                    if (selectionResult.Status == PromptStatus.OK)
                    {
                        SelectionSet ss = selectionResult.Value;
                        ActiveUtil.Editor.WriteLine("Number of circles with 1m radius selected: " + ss.Count);
                    }

                    tr.Commit();
                }
            }
            catch (System.Exception ex)
            {
                Application.ShowAlertDialog($"Something went wrong error:{ex.Message}");
            }
        }
```
### Selection filter with multiple criteria
```csharp
[CommandMethod("Test", CommandFlags.UsePickSet)]
        public static void Test()
        {
            try
            {
                using (Transaction tr = ActiveUtil.TransactionManager.StartTransaction())
                {
                    var typeValues = new List<TypedValue>();

                    typeValues.Add(new TypedValue((int)DxfCode.Start,"CIRCLE"));
                    typeValues.Add(new TypedValue((int)DxfCode.Operator, ">="));
                    typeValues.Add(new TypedValue((int)DxfCode.Real, 5));

                    SelectionFilter filter = new SelectionFilter(typeValues.ToArray());
                    //Use Select all to Select all objects with selection Criteria
                    PromptSelectionResult selectionResult = ActiveUtil.Editor.SelectAll(filter);

                    //Use get selection to only select from selected objects
                    //PromptSelectionResult selectionResult = ActiveUtil.Editor.GetSelection(filter);

                    if (selectionResult.Status == PromptStatus.OK)
                    {
                        SelectionSet ss = selectionResult.Value;
                        ActiveUtil.Editor.WriteLine("Number of circles with 1m radius selected: " + ss.Count);
                    }

                    tr.Commit();
                }
            }
            catch (System.Exception ex)
            {
                Application.ShowAlertDialog($"Something went wrong error:{ex.Message}");
            }
        }
```
