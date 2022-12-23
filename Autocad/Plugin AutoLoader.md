### Basics
- AutoCAD has functionality to Automatically load Plugings without using any registery editing or Modifying it's Starup Lisp File
- This Involves creating application bundle packgage and puttint it in Application Plugin Folder

### Build your Plugin Bundle
- Just Create new folder in Application Plugin with `AppName.bundle`
- A plug-in can be deployed by placing it in one of the ApplicationPlugins or ApplicationAddins folders on a local drive.
	- General Installation folder
		- Windows: %PROGRAMFILES%\Autodesk\ApplicationPlugins
		- Mac OS: /Applications/Autodesk/ApplicationAddins
	- All Users Profile folders
		- Windows: %ALLUSERSPROFILE%\Autodesk\ApplicationPlugins
		- Mac OS: N/A
	- User Profile folders
		- Windows: %APPDATA%\Autodesk\ApplicationPlugins
		- Mac OS: ~/Library/Application Support/Autodesk/ApplicationAddins
- Create Package.xml file using below Code snippets
- Add your application dll files and package.xml file in this folder
- Start AutoCAD and Your package should be loaded automatically
 

### Xml Package
- `<RuntimeRequirements OS="Win64" SeriesMin="20.0" SeriesMax="R23.0" />`
   - specify Os and Min and Max AutoCAD version for your Plugin, if this requirement is not met plugin won't load
- `<ComponentEntry AppName="CadApp" ModuleName="/CadApp.dll" AppDescription="CadApp" />`
   - you can specify your main Dll file here, You only need to specify your starting dll file, all other dependent dll file will load automatically
   - Additionally you can also use `LoadOnCommandInvocation="True"` argument to only active plugin when required using specific command
- for Product Code and Upgrade Code, match it with installer if possible otherwise create new one from Visual studio

### Xml Package to Load Dll file
```xml
<?xml version="1.0" encoding="UTF-8"?>
<ApplicationPackage SchemaVersion="1.0" ProductType="Application" Name="CadApp" AppVersion="0.1.0" Description="AutoCAD Sample Plugin" Author="Vivek Patel" ProductCode="{3CC17D2D-234D-42E9-BE58-A6AEF6C7AB64}" UpgradeCode="{F7A26ED4-AC80-47FF-9E5F-EDECC4446EF2}">
   <CompanyDetails Name="Nodes Automations" Url="https://linktr.ee/NodesAutomations" Email="vivek@nodesautomations.com" />
   <Components>
      <RuntimeRequirements OS="Win64" SeriesMin="20.0" SeriesMax="R23.0" />
      <ComponentEntry AppName="CadApp" ModuleName="/CadApp.dll" AppDescription="CadApp" />
   </Components>
</ApplicationPackage>
```

### xml Package to Load Dll file but only Activate using Specific Commands
```xml
<?xml version="1.0" encoding="UTF-8"?>
<ApplicationPackage SchemaVersion="1.0" ProductType="Application" Name="CadApp" AppVersion="0.1.0" Description="AutoCAD Sample Plugin" Author="Vivek Patel" ProductCode="{3CC17D2D-234D-42E9-BE58-A6AEF6C7AB64}" UpgradeCode="{F7A26ED4-AC80-47FF-9E5F-EDECC4446EF2}">
   <CompanyDetails Name="Nodes Automations" Url="https://linktr.ee/NodesAutomations" Email="vivek@nodesautomations.com" />
   <Components>
      <RuntimeRequirements OS="Win64" SeriesMin="20.0" SeriesMax="R23.0" />
      <ComponentEntry AppName="CadApp" ModuleName="/CadApp.dll" AppDescription="CadApp" LoadOnCommandInvocation="True">
         <Commands GroupName="NodesAutomations">
            <Command Global="LoadCadApp" Local="LoadCadApp" />
         </Commands>
      </ComponentEntry>
   </Components>
</ApplicationPackage>
```
### Simplified version of Package xml
```xml
<?xml version="1.0" encoding="UTF-8"?>
<ApplicationPackage 
    SchemaVersion="1.0" 
    ProductType="Application" 
    Name="CadApp" 
    AppVersion="0.1.0" 
    Description="AutoCAD Sample Plugin" 
    Author="Vivek Patel" 
    ProductCode="{3CC17D2D-234D-42E9-BE58-A6AEF6C7AB64}" 
    UpgradeCode="{F7A26ED4-AC80-47FF-9E5F-EDECC4446EF2}">
	<CompanyDetails 
        Name="Nodes Automations" 
        Url="https://linktr.ee/NodesAutomations" 
        Email="vivek@nodesautomations.com" />
	<Components>
		<RuntimeRequirements 
            OS="Win64" 
            SeriesMin="20.0" 
            SeriesMax="R23.0" />
		<ComponentEntry 
            AppName="CadApp" 
            ModuleName="/CadApp.dll" 
            AppDescription="CadApp" />
	</Components>
</ApplicationPackage>
```
![image](https://user-images.githubusercontent.com/60865708/209293207-25a07f6e-e8f6-4e19-aeae-b8e2e29da5f7.png)

Additional References
- [Autodesk Autoloader](https://adndevblog.typepad.com/autocad/2013/01/autodesk-autoloader-white-paper.html)
- [AutoCAD Package Contents.xml Reference](https://help.autodesk.com/view/ACD/2023/ENU/?guid=GUID-BC76355D-682B-46ED-B9B7-66C95EEF2BD0)
- [Develop your own command in AutoCAD e09: AutoLoader mechanism (part 1)](https://youtu.be/w_SQ-b72jUw)
- [About Installing and Uninstalling Plug-In Applications](http://docs.autodesk.com/ACD/2013/ENU/index.html?url=files/GUID-5E50A846-C80B-4FFD-8DD3-C20B22098008.htm,topicNumber=d30e503195)
