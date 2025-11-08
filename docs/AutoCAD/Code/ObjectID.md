### Code to Get Object Id from Entity Handle
```csharp
[CommandMethod(nameof(SelectByID))]
static public void SelectByID()
{
    Document doc = Application.DocumentManager.MdiActiveDocument;
    Database database = doc.Database;
    Editor ed = doc.Editor;

    var blockHandle = "2A3";

    //Convert Hexadecimal string to 64 bit integer
    long blockHandleLongInt = Convert.ToInt64(blockHandle,16);

    //Create Handle from long integer
    Handle handle = new Handle(blockHandleLongInt);

    //Get Object Id for Handle
    ObjectId blockObjectId = database.GetObjectId(false,handle,0);

    //Delete object
    var transaction = new CadTransaction();
    DBObject obj = transaction.Transaction.GetObject(blockObjectId, OpenMode.ForWrite);

    obj.Erase();
    transaction.Commit();
}
```
Refer: https://forums.autodesk.com/t5/net/get-and-object-as-implied-selection-by-its-handle/td-p/5767852
