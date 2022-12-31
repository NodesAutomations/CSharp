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
