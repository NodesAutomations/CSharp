Reference : [Creating Wix Installation Projects](https://www.add-in-express.com/creating-addins-blog/2012/11/13/wix-installation-vsto-office-addin/)

Creating a new Excel 2010 Add-in project in Visual Studio

We’ll keep things simple as the add-in will only add a new tab to the Excel ribbon with a button. To do this you’ll need to add a new Ribbon to your add-in project.

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/70c0ce2a-f17c-435d-97e2-25b4017c1530/add-ribbon.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/70c0ce2a-f17c-435d-97e2-25b4017c1530/add-ribbon.png)

In the last two articles, I’ve shown you how to [create a WiX installer for Add-in Express based add-ons](https://www.add-in-express.com/creating-addins-blog/2012/10/17/creating-wix-installer-office-addins/) from scratch and how to [convert your existing setup projects (vdproj) to WiX](https://www.add-in-express.com/creating-addins-blog/2012/11/01/convert-vdproj-wix/). In this blog, I’ll show you how to create a WiX installer for Visual Studio Tools for Office (VSTO) based Office add-in projects.

## Creating the VSTO add-in for Office Excel 2010

Before we can build an installer, we need to create a new Excel 2010 Add-in project in Visual Studio.

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/fc784c4b-a156-4db3-815a-518e8bb4130b/excel-addin-visual-studio.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/fc784c4b-a156-4db3-815a-518e8bb4130b/excel-addin-visual-studio.png)

Adding a new Ribbon to your Excel add-in

## Creating the WiX installation project

Before you can create a new WiX setup project, the [WiX Toolset](http://wixtoolset.org/) should be installed first. Once the WiX Toolset is installed you’ll see a list of WiX project types in Visual Studio.

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/05011681-368d-479e-95dd-c6b093039264/wix-installation-types.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/05011681-368d-479e-95dd-c6b093039264/wix-installation-types.png)

WiX project types in Visual Studio

Select the WiX Setup Project and add it to your Visual Studio Solution. The installation package will only contain one file called Product.wxs; this file is what we’ll use to create the installer for our VSTO based Excel add-in.

## Product and Package element

When you open the *Product.wxs* file in Visual Studio you’ll notice that the file already contains the minimum amount of elements in order to build a WiX installer. The first element of importance is the *Product* element, keep the **Id** attributes’ value as it is. If the value is set to an asterisk (*), WiX will generate a new GUID every time the setup project is compiled. Next, change the **Name** attributes’ value to the name of your plug-in and **Manufacturer** to your company name.

Leave the Package element as is, it contains the minimum amount of attributes for the setup project to build.

```
<Product Id="CE2CEA93-9DD3-4724-8FE3-FCBF0A0915C1" 
         Name="My Excel Add-in" 
         Language="1033" 
         Version="1.0.0.0" 
         Manufacturer="My Software Company" 
         UpgradeCode="7b3b630d-c617-419f-8272-95942cf21420">
 
<Package InstallerVersion="200" 
         Compressed="yes" 
         InstallScope="perMachine" />
```

### ComponentGroup and Component elements

The **ComponentGroup** element is where you add all the files you need your add-ins’ installer to copy to the target pc. It is a good rule of thumb to only include one File element inside a **Component** element, reason being that when you set the **File** element’s *KeyPath* attribute to *yes* and the user does a repair the file will be replaced, if more than one file is inside the **Component** element, they will not be replaced by a repair.

The **ComponentGroup/Component** elements for a simple VSTO add-in project would look similar to the following code listing:

```
<ComponentGroup Id="ProductComponents" Directory="INSTALLFOLDER">
  <Component Id="ExcelAddin1_vsto_Component">
    <File Id="ExcelAddin1_vsto" KeyPath="yes"
          Name="ExcelAddin1.vsto" Source="$(var.AddinFiles)"></File>
  </Component>
  <Component Id="ExcelAddIn1_dll_manifest_Component">
    <File Id="ExcelAddIn1_dll_manifest" KeyPath="yes"
          Name="ExcelAddIn1.dll.manifest" Source="$(var.AddinFiles)"></File>
  </Component>
  <Component Id="MSOfficeToolsCommon_dll_Component">
    <File Id="MSOfficeToolsCommon_dll" KeyPath="yes"
          Name="Microsoft.Office.Tools.Common.v4.0.Utilities.dll" 
          Source="$(var.AddinFiles)"></File>
  </Component>
  <Component Id="MSOfficeToolsExcel_dll_Component">
    <File Id="MSOfficeToolsExcel_dll" KeyPath="yes"
          Name="Microsoft.Office.Tools.Excel.dll"
          Source="$(var.AddinFiles)"></File>
  </Component>
  <Component Id="ExcelAddIn1_dll_Component" >
    <File Id="ExcelAddIn1_dll" KeyPath="yes"
          Name="ExcelAddIn1.dll" Source="$(var.AddinFiles)" />
  </Component>
</ComponentGroup>
```

The *$(var.AddinFiles)* variable is declared by right-clicking on your setup project in the Visual Studio Solution Explorer and selecting *Properties*. You then need to add the following to the **“Define preprocessor variables”** field:

AddinFiles=..\ExcelAddIn1\bin\$(Configuration)\

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/6ce510c7-f5d4-445a-8fdb-1168c80bc28e/preprocessor-variable.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/6ce510c7-f5d4-445a-8fdb-1168c80bc28e/preprocessor-variable.png)

Defining the required preprocessor variable

### Directory element

We’ll keep the default **Directory** element as is, and only change its *Name* attribute to something more descriptive. You’ll also need to add all registry entries inside the Directory element, if this is not done, your VSTO add-in will not load at all!

```
<Directory Id="TARGETDIR" Name="SourceDir">
  <Directory Id="ProgramFilesFolder">
    <Directory Id="INSTALLFOLDER" Name="MyExcelAddin" />
    <Component Id="Registry_FriendlyName">
      <RegistryValue Id="RegKey_FriendlyName" Root="HKCU"
                     Key="Software\Microsoft\Office\Excel\AddIns\ExcelAddIn1"
                     Name="FriendlyName"
                     Value="My Excel Add-In"
                     Type="string" KeyPath="yes" />
    </Component>        
    <Component Id="Registry_Description">
      <RegistryValue Id="RegKey_Description" Root="HKCU"
                     Key="Software\Microsoft\Office\Excel\AddIns\ExcelAddIn1"
                     Name="Description"
                     Value="My very cool Excel Add-In"
                     Type="string" KeyPath="yes" />
    </Component>
    <Component Id="Registry_Manifest">
      <RegistryValue Id="RegKey_Manifest" Root="HKCU"
                     Key="Software\Microsoft\Office\Excel\AddIns\ExcelAddIn1"
                     Name="Manifest" Value="[INSTALLFOLDER]ExcelAddIn1.vsto|vstolocal"
                     Type="string" KeyPath="yes" />
    </Component>
    <Component Id="Registry_LoadBehavior">
      <RegistryValue Id="RegKey_LoadBehavior" Root="HKCU"
                     Key="Software\Microsoft\Office\Excel\AddIns\ExcelAddIn1"
                     Name="LoadBehavior" Value="3"
                     Type="integer" KeyPath="yes" />
    </Component>
  </Directory>
</Directory>
```

The following registry key will be created when the user installs your Office add-in:

HKEY_CURRENT_USER\Software\Microsoft\Office\Excel\AddIns\ExcelAddin1

### Feature element

You can set the **Feature** element’s **Title** attribute’s value to a more friendly human readable value. In this example we’ll rename it to *“My Excel Add-in”.*  We’ll also add the registry components, we’ve added in the **Directory** element, to the **Feature** element.

```
<Feature Id="ProductFeature" Title="My Excel Add-in" Level="1">
  <ComponentGroupRef Id="ProductComponents" />
  <ComponentRef Id="Registry_FriendlyName" />
  <ComponentRef Id="Registry_Description" />
  <ComponentRef Id="Registry_Manifest" />
  <ComponentRef Id="Registry_LoadBehavior" />
</Feature>
```

### Media element

Since we only want one Cab file, we only need to add one Media element to the WiX source file. Make sure you set the **EmbedCab** attribute’s value to *yes*.

```
<Media Id="1" Cabinet="ExcelAddin1.cab" EmbedCab="yes"/>
```

### Defining Prerequisites

We need to check whether the Microsoft .Net Framework and the Visual Studio 2010 Tools for Office Runtime are installed on the target PC or our Excel add-in will not work. To do this, you’ll need to add two *Conditions*:

1. To check whether the VSTO Office Runtime is installed, we’ll add condition and two RegistrySearch elements. **RegistrySearch**, does exactly what the name implies, it searches the target machines’ registry for a specific key and value.

```
<Property Id="VSTORUNTIMEREDIST">
  <RegistrySearch 
    Id="VSTORuntimeRedist" 
    Root="HKLM" 
    Key="SOFTWARE\Microsoft\VSTO Runtime Setup\v4R" 
    Name="Version" 
    Type="raw" />
</Property>
<Condition 
  Message="The Visual Studio 2010 Tools for Office Runtime is not installed. 
  Please download and install from 
  http://www.microsoft.com/en-us/download/details.aspx?id=20479.">
  <![CDATA[Installed OR VSTORUNTIMEREDIST>="10.0.30319"]]>
</Condition>
```

To check whether .Net Framework 4 is installed, we need to add a *PropertyRef* element and another condition.

```
<PropertyRef Id="NETFRAMEWORK40FULL"/>
<Condition Message="This application requires .NET Framework 4.0.">
  <![CDATA[Installed OR NETFRAMEWORK40FULL]]>
</Condition>
```

You’ll also need to add a reference to the WixNetFxExtension.dll assembly, you can read more about *WixNetFxExtension* and how it can help you on its [SourceForge page](http://wix.sourceforge.net/manual-wix3/wixnetfxextension.htm).

### Setting the User Interface and License agreement text of the WiX installation package

Finally, we need to add two elements to our installation; one will specify which UI to use for our setup and the other which file the installer should use for our End-User License Agreement (EULA).

We’ll use the simplest UI available to us called WiXUI_Minimal:

```
<UIRef Id="WixUI_Minimal" />
```

To use your own license agreement, add a new Rich Text file (.rtf) to the setup project of your addin that contains the licensing text you require and add the following element to your WiX source file:

```
<WixVariable Id="WixUILicenseRtf" Value="EULA.rtf" />
```

Before you build and test your setup project you’ll need to add a reference to the WiXUIExtension.dll file, which you’ll find in the WiX install folders’ bin folder.

### Building and running the setup

With the necessary configuration in place, you can build your WiX setup project. It should produce a .msi file, which when run will display the following screen:

![https://s3-us-west-2.amazonaws.com/secure.notion-static.com/39510dfb-4196-4587-af0b-0130d986386b/wix-setup.png](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/39510dfb-4196-4587-af0b-0130d986386b/wix-setup.png)

The setup wizard in action

There you have it; you’re VSTO add-in will be installed and with the correct registry keys in place, it will be registered with Microsoft Excel 2010.

Thank you for reading. Until next time, keep coding!

*Updated on 21-Feb-2013:*

If you want to change your existing Visual Studio setup projects to WiX, check out our new tool – [VDProj to WiX Converter](https://www.add-in-express.com/vdproj-wix-converter/index.php). This extension for Visual Studio 2012-2005 lets you convert your vdproj setups to WiX in 1 click!

### Available downloads:

A sample [WiX installation project for Excel add-in](https://www.add-in-express.com/creating-addins-blog/wp-upload/samples/WiXInstallationProject.zip).
