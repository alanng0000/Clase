@echo off



SET DevCmdPath="C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvars64.bat"



%comspec% /c "%DevCmdPath%" "& MakeSysAll.cmd"