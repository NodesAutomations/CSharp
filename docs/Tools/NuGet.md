### To Create package for Net Framework Library

- Download nuget.exe from [https://www.nuget.org/](https://www.nuget.org/)
- Put nuget.exe to Project Folder(not solution)
- Create *.nuspec file using command `nuget spec ProjectName.vbproj`
- Set Default Config to Release in Project File
- Create NuGet package using `nuget pack` Command

<aside>
💡 PowerShell use  start-process nuget pack command

</aside>

### To Create package from Net Standard Class Library

- Go to Project Properties > Package To Fill All Details
- To Create NuGet package right click on Project and select Pack
 
