### Get Access to Software
- Repo : https://github.com/mkaring/ConfuserEx
- You can download latest version from release
  - ConfuserEx-CLI contain console app
  - ConfuserEx-GUI contain Exe with GUI
  - ConfuserEx Cointain console app as well as GUI exe (we prefer to use this)
  - There's also nuget package for Confuser.MsBuild but currently i don't know how to use it
  - If you have any query or question you can find answer from issues or discussion tab of repo, you can also look into base repo

### How to use software
- You can directly run CLI with project file as input that will automatically run everything without any user intervention
- With GUI you can run this manually and it will also let you crete project file
- So first step is to create project file using gui version

#### Create Project file usig GUI
![image](https://user-images.githubusercontent.com/60865708/213906572-f478639f-c3b1-4739-9952-f7d0e57084a0.png)
- As per above screenshot, you can drop your dll files on drag input modules here area and it should automatically pick up all dll files, this will also automatically update base Directory and Output Directory input
- Output directory location is important because it will decide where all new dll files will get generated
- If you're dealing with AutoCAD addin you have to provide probe path from advance setting button, second rectangle 

![image](https://user-images.githubusercontent.com/60865708/213906649-a4689f9b-a91f-4089-8096-6054521ea96e.png)
- In Probepath input, provide autocad folder which contain all references for autocad.net development, without this setting program will throw errors

![image](https://user-images.githubusercontent.com/60865708/213906726-48100bba-a239-4e2c-bb82-e899b65c1253.png)
- Now from settings tab, you have to crete protection rule for each dll, you can also create global gettins for all dll but i prefer more control
- That's it,Just go to protect tab and click on Protect button to generate obsucated dlls
- to test this dll files just use dot peek software



