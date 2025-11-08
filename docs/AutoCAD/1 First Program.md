# First AutoCAD App

- Create new C# Class library targetting `.NET Framework 4.8`
- Add AutoCAD Reference : `AcCoreMgd.dll`, `AcDBMgd.dll`, `AcMgd.dll`
    - You can Add this autocad Reference manually and setting property Copy to local to false
    - My favourite method is just add nuget package `AutoCAD.NET`  from [Nuget.org](http://Nuget.org) or Nodes Nuget Repo
- Now Delete existing class from C# project and Add new Hello.cs with below code, make sure class will remain public
    
    ```csharp
    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.EditorInput;
    using Autodesk.AutoCAD.Runtime;
    
    namespace FirstAutoCADApp
    {
        public class Hello
        {
            [CommandMethod("Hello")]
            public void HelloAutocad()
            {
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Database database = doc.Database;
                Editor edt = doc.Editor;
    
                edt.WriteMessage("Hello Vivek");
            }
        }
    }
    ```
    
- Compile this app to generate dll file
- Open AutoCAD app and Enter `netload` command and Select this dll file to load
- Try `Hello` command to see if it’s working as expected
- Next Do [Debug Setup](https://github.com/NodesAutomations/CSharp/blob/master/Autocad/AutoCAD%20Debugging%20Setup.md) for easier Testing
