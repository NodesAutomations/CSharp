### Basics
- AutoCAD has functionality to Automatically load Plugings without using any registery editing or Modifying it's Starup Lisp File
- This Involves creating application bundle packgage and puttint it in Application Plugin Folder

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
