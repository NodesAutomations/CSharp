### Code to Select Object On Screen
```csharp
 [CommandMethod("SelectObjectsOnscreen")]
public static void SelectObjectsOnscreen()
{
    // Get the current document and database
    Document doc = Application.DocumentManager.MdiActiveDocument;

    // Start a transaction
    using (Transaction transaction = doc.TransactionManager.StartTransaction())
    {
        // Request for objects to be selected in the drawing area
        PromptSelectionResult selectionPromptResult = doc.Editor.GetSelection();

        // If the prompt status is OK, objects were selected
        if (selectionPromptResult.Status == PromptStatus.OK)
        {
            SelectionSet selectionSet = selectionPromptResult.Value;

            // Step through the objects in the selection set
            foreach (SelectedObject selectedObj in selectionSet)
            {
                // Check to make sure a valid SelectedObject object was returned
                if (selectedObj != null)
                {
                    // Open the selected object for write
                    Entity entity = transaction.GetObject(selectedObj.ObjectId,
                                                     OpenMode.ForWrite) as Entity;

                    if (entity != null)
                    {
                        // Change the object's color to Green
                        entity.ColorIndex = 3;
                    }
                }
            }

            // Save the new object to the database
            transaction.Commit();
        }

        // Dispose of the transaction
    }
}
```

### Code for Single Entity selection
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
### Code to use Existing Selection
The PickFirst selection set is created when you select objects prior to starting a command. Several conditions must be present in order to obtain the objects of a PickFirst selection set, these conditions are:
- PICKFIRST system variable must be set to 1
- UsePickSet command flag must be defined with the command that should use the Pickfirst selection set
- Call the SelectImplied method to obtain the PickFirst selection set
The SetImpliedSelection method is used to clear the current PickFirst selection set.
```csharp
[CommandMethod("TEST", CommandFlags.UsePickSet)]
        public void Test()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;

            // Check if objects are already selected
            PromptSelectionResult selectionPrompt = doc.Editor.SelectImplied();

            SelectionSet selectionSet;

            // If the prompt status is OK, objects were selected before
            // the command was started
            if (selectionPrompt.Status == PromptStatus.OK)
            {
                selectionSet = selectionPrompt.Value;

                Application.ShowAlertDialog("Number of objects in Pickfirst selection: " +
                                            selectionSet.Count.ToString());
            }
            else
            {
                // Code to select Block
                PromptEntityResult prompt = doc.Editor.GetEntity("Select Any Block");

                if (prompt.Status != PromptStatus.OK)
                {
                    doc.Editor.WriteMessage("nothing selected");
                    return;
                }
                
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
