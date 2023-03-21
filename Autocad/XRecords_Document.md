### Store Custom Data in Drawing file
- Ref : https://adndevblog.typepad.com/autocad/2012/05/how-can-i-store-my-custom-information-in-a-dwg-file.html
- 
Q: _I need to store some information in a dwg file, which would describe this drawing and let to integrate it with another software system. Can I write such custom information into a drawing and read it later? Can it be done without opening the drawing in AutoCAD?_

A: You may use so called **Named Object Dictionary** (NOD) to store custom data in a drawing. NOD is an essential part of an AutoCAD drawing database and it is created automatically when the drawing is created.  

As always with database operations, your program may open a dwg file invisibly to the user via Database.ReadDwgFile() method, i.e. it does not have to be the drawing in the active AutoCAD window.  

Here is an example:
```csharp
// Write some data to the NOD

//============================

\[CommandMethod("WNOD")\]

public void WriteToNOD()

{

 Database db = new Database();

 try

 {

 // We will write to C:\\Temp\\Test.dwg. Make sure it exists!

 // Load it into AutoCAD

 db.ReadDwgFile(@"C:\\Temp\\Test.dwg",

 System.IO.FileShare.ReadWrite, false, null);

 using( Transaction trans =

 db.TransactionManager.StartTransaction() )

 {

 // Find the NOD in the database

 DBDictionary nod = (DBDictionary)trans.GetObject(

 db.NamedObjectsDictionaryId, OpenMode.ForWrite);

 // We use Xrecord class to store data in Dictionaries

 Xrecord myXrecord = new Xrecord();

 myXrecord.Data = new ResultBuffer(

 new TypedValue((int)DxfCode.Int16, 1234),

 new TypedValue((int)DxfCode.Text,

 "This drawing has been processed"));

 // Create the entry in the Named Object Dictionary

 nod.SetAt("MyData", myXrecord);

 trans.AddNewlyCreatedDBObject(myXrecord, true);

 // Now let's read the data back and print them out

 //  to the Visual Studio's Output window

 ObjectId myDataId = nod.GetAt("MyData");

 Xrecord readBack = (Xrecord)trans.GetObject(

 myDataId, OpenMode.ForRead);

 foreach (TypedValue value in readBack.Data)

 System.Diagnostics.Debug.Print(

 "===== OUR DATA: " + value.TypeCode.ToString()

 + ". " + value.Value.ToString());

 trans.Commit();

 } // using

 db.SaveAs(@"C:\\Temp\\Test.dwg", DwgVersion.Current);

 }

 catch( Exception e )

 {

 System.Diagnostics.Debug.Print(e.ToString());

 }

 finally

 {

 db.Dispose();

 }

} // End of WriteToNOD()
```
