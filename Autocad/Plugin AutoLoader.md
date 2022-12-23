### Basics


### Xml Package to Load Dll file



### xml Package to Load Dll file but only Activate using Specific Commands
```xml
<?xml version="1.0" encoding="UTF-8"?>
<ApplicationPackage SchemaVersion="1.0" ProductType="Application" Name="CadApp" AppVersion="0.1.0" Description="Introduction to C#" Author="Autodesk" ProductCode="{3CC17D2D-234D-42E9-BE58-A6AEF6C7AB64}" UpgradeCode="{F7A26ED4-AC80-47FF-9E5F-EDECC4446EF2}">
   <CompanyDetails Name="Autodesk University" Phone="+1 (123) 345-6789" Url="http://www.au.autodesk.com" Email="joshua.modglin@inmotioncon.com" />
   <Components>
      <RuntimeRequirements OS="Win64" SeriesMin="20.0" SeriesMax="R23.0" />
      <ComponentEntry ModuleName="/CadApp.dll" AppName="CadApp" AppType="Dependency">
         <RuntimeRequirements SupportPath=".\Contents\" />
      </ComponentEntry>
      <ComponentEntry AppName="CadApp" ModuleName="/CadApp.dll" AppDescription="AU Solutions" LoadOnCommandInvocation="True">
         <Commands GroupName="NodesAutomations">
            <Command Global="LoadCadApp" Local="LoadCadApp" />
         </Commands>
      </ComponentEntry>
   </Components>
</ApplicationPackage>
```
