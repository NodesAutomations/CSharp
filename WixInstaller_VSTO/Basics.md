### Steps to Use Wix Installer from Another Project
- Copy Wix from Similar Project
- Change Reference to Current Project
- Update `Common.wxl` file as per client or Project Requirement
- Update `WixInstaller.wax` file with Current Project
- Unload Project and change Previous Project Paths, Build events and Assembly Location
- Update `Product.wxs`
  - Change Target Dir
  - Change Upgrade Code
  - Update Component Detail
