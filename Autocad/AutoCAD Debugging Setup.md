### Debug Configuration

- Go to project properties > Debug > Start Action and Set Start external Program to AutoCAD exe by using below command
    
    ```
    C:\Program Files\Autodesk\AutoCAD 2015\acad.exe
    ```
    
- This command will automatically launch AutoCAD when you click on start debugging, you might need to adjust AutoCAD exe path as per your current version
- Set Command Line arguments
    
    ```
    /nologo /t Acad  /b "C:\Users\Ryzen2600x\source\repos\FirstAutoCADApp\FirstAutoCADApp\StartUp.scr"
    ```
    
- `/nologo` command will make sure that AutoCAD direcly lauch with  blank drawing without any start page
- `/t Acad` will make sure that new Drawing is Created with Acad Template, You can change your Template as per your Requirement here
- `/b "C:\Users\Ryzen2600x\source\repos\FirstAutoCADApp\FirstAutoCADApp\StartUp.scr"`  command will automatically run Startup script after creating new drawing
    - Startup Script automatically netload your dll file for testing, you have to adjust dll file path
    
    ```
    netload
    C:\Users\Ryzen2600x\source\repos\FirstAutoCADApp\FirstAutoCADApp\bin\Debug\FirstAutoCADApp.dll
    ```

### Modification when you're Using AutoCAD Template
- Open your Visual studio project
- From Solution Explorer, switch to Folder View
- Open `StartUp.scr` and Update Dll file Path
- Open `CadApp.csproj.user` file and Update AutoCAD Script file path in Command line Arguments
- Unload and reload whole Project to update Project Properties
