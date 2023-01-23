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
### Select Objects in specific region/window
```csharp
 [CommandMethod("SelectObjectsByCrossingWindow")]
 public static void SelectObjectsByCrossingWindow()
 {
     // Get the current document editor
     Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;

     // Create a crossing window from (2,2,0) to (10,8,0)
     PromptSelectionResult  selectionPromptResult = editor.SelectCrossingWindow(new Point3d(2, 2, 0), new Point3d(100, 100, 0));

     // If the prompt status is OK, objects were selected
     if (selectionPromptResult.Status == PromptStatus.OK)
     {
         SelectionSet acSSet = selectionPromptResult.Value;
         Application.ShowAlertDialog("Number of objects selected: " + acSSet.Count.ToString());
     }
     else
     {
         Application.ShowAlertDialog("Number of objects selected: 0");
     }
 }
```
### Code for Single but specific type of Entity selection
- Here in this code we need to specify type of entity that we need to select
```csharp
      [CommandMethod("TEST")]
        public void Test()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;

            var options = new PromptEntityOptions("\nSelect line: ");
            options.SetRejectMessage("\nSelected entity is not a line.");
            options.AddAllowedClass(typeof(Line), true);
            var result = doc.Editor.GetEntity(options);
            if (result.Status != PromptStatus.OK)
            {
                return;
            }

            using (var tr = doc.TransactionManager.StartTransaction())
            {
                var line = (Line)tr.GetObject(result.ObjectId, OpenMode.ForRead);
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
### Code to Merge Selection
```csharp
 [CommandMethod("MergeSelectionSets")]
 public static void MergeSelectionSets()
 {
     // Get the current document editor
     Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;

     // Request for objects to be selected in the drawing area
     PromptSelectionResult selectionPromptResult = editor.GetSelection();

     SelectionSet selectionSet1;
     ObjectIdCollection objectIdCollection = new ObjectIdCollection();

     // If the prompt status is OK, objects were selected
     if (selectionPromptResult.Status == PromptStatus.OK)
     {
         // Get the selected objects
         selectionSet1 = selectionPromptResult.Value;

         // Append the selected objects to the ObjectIdCollection
         objectIdCollection = new ObjectIdCollection(selectionSet1.GetObjectIds());
     }

     // Request for objects to be selected in the drawing area
     selectionPromptResult = editor.GetSelection();

     SelectionSet selectionSet2;

     // If the prompt status is OK, objects were selected
     if (selectionPromptResult.Status == PromptStatus.OK)
     {
         selectionSet2 = selectionPromptResult.Value;

         // Check the size of the ObjectIdCollection, if zero, then initialize it
         if (objectIdCollection.Count == 0)
         {
             objectIdCollection = new ObjectIdCollection(selectionSet2.GetObjectIds());
         }
         else
         {
             // Step through the second selection set
             foreach (ObjectId acObjId in selectionSet2.GetObjectIds())
             {
                 // Add each object id to the ObjectIdCollection
                 objectIdCollection.Add(acObjId);
             }
         }
     }

     Application.ShowAlertDialog("Number of objects selected: " + objectIdCollection.Count.ToString());
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
