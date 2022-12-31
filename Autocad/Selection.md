### Code for object selection
```csharp
        [CommandMethod(nameof(ObjectSelection))]
        public void ObjectSelection()
        {
            Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;

            PromptEntityResult per = editor.GetEntity("Select Object");

            if (per.Status == PromptStatus.OK)
            {
                editor.WriteMessage("An Object is selected");
            }
            else
            {
                editor.WriteMessage("You fool, you have to do it again");
            }
        }
```
### Code to mutiple object Selection
```csharp
// Method for multi Select
        [CommandMethod(nameof(MultipleObjectSelection))]
        public void MultipleObjectSelection()
        {
            Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;

            PromptStatus status = PromptStatus.OK;
            while (status==PromptStatus.OK)
            {
                PromptEntityResult prompt = editor.GetEntity("\nSelect Object");
                editor.WriteMessage("\nAn object is selected");
                status = prompt.Status;
            }
        }
```
