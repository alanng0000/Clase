@echo off



SET DevCmdPath="C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvars64.bat"



SET Module=%~1


%comspec% /c "%DevCmdPath%" "& MakeWindowsModuleAll.cmd "%Module%""