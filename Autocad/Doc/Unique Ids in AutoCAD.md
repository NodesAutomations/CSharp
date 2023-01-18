### Overview
Each object contain within a database is assigned a several unique ids. The unique ways you can access objects are
- Entity Handle
- Object ID
- Instance Pointer

### Object Ids
- Object is only unique per session
- if you close your draawing and reopen it again new object Ids will get created
- Object is is the most comman way to access an object
- The ObjectId of an object in a database exists only while the database is loaded into memory. Once the database is closed, the ObjectId assigned to an object no longer exist and maybe different the next time the database is opened.
- ObjectIds work well if your projects utilize both COM interop and the managed AutoCAD .NET API.
- If you create custom AutoLISP functions, you may need to work with entity handles.

### Entity Handle
- Entity Handles stays persistent between AutoCAD sessions.
- if you close your drawing and reopen it again even after few years, each object entity handles wills stays sames
- so entity handles are best way if you need to transfer entity data to external files, you can reuse this handle to update data again if required
> The handles of objects change the value when you copy and past a entity to another drawing, for example. (You can do a simple test to confirm).
### Obtain an ObjectId
As you work with objects, you will need to obtain an ObjectId first before you can open the object to query or edit it. An ObjectId is assigned to an existing object in the database when the drawing file is opened, and new objects are assigned an ObjectId when they are first created. An ObjectId is commonly obtained for an existing object in the database by:
- Using a member property of the Database object, such as Clayer which retrieves the Object ID for the current layer
- Iterating a symbol table, such as the Layer symbol table

### Open an Object
Once an Object Id is obtained, the GetObject function is used to open the object assigned the given Object Id. An object can be opened in one of the following modes:
- Read : Opens an object for read
- Write : Opens an object for write if it's not already open
- Notify : Opens an object for notification when it's closed, open for read, or open for write, but not when it is already open for notify.

> You should open an object in the mode that is best for the situation in which the object will be accessed. Opening an object for write introduces additional overhead than you might need due to the creation of undo records. If you are unsure if the object you are opening is the one you want to work with, you should open it for read and then use the UpgradeOpen function to change from read to write mode.
