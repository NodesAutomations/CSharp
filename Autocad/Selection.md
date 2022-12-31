### Code for object selection
```csharp
[CommandMethod(nameof(ObjectSelection))]
        public void ObjectSelection()
        {
            PromptEntityResult per = Application.DocumentManager.MdiActiveDocument.Editor.GetEntity("Select Object");

            if (per.Status==PromptStatus.OK)
            {
                Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("An Object is selected");
            }
            else
            {
                Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("You fool, you have to do it again");
            }
        }
```
