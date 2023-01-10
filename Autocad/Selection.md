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
### Code to select Entity by Entity Handle or Object ID
```csharp
 [CommandMethod(nameof(SelectByID))]
static public void SelectByID()
{
    Document doc = Application.DocumentManager.MdiActiveDocument;
    Database database = doc.Database;
    Editor editor = doc.Editor;

    var blockHandle = "2A3";

    //Convert Hexadecimal string to 64 bit integer
    long blockHandleLongInt = Convert.ToInt64(blockHandle, 16);

    //Create Handle from long integer
    Handle handle = new Handle(blockHandleLongInt);

    //Get Object Id for Handle
    ObjectId blockObjectId = database.GetObjectId(false, handle, 0);

    ////Code to select Object
    var objects = new List<ObjectId>();

    //Clear exiting selection
    editor.SetImpliedSelection(objects.ToArray());

    //Add new objectId to list
    objects.Add(blockObjectId);

    //Select objects
    editor.SetImpliedSelection(objects.ToArray());

}
```
