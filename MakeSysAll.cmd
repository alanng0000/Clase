@echo off



SET MethodsFilePath=..\Infra\MakeMethods.cmd



SET OutFold=..\..\Out




SET Module=Clase.Sys



CALL %MethodsFilePath% :MakeModule "%Module%" "%Module%" "%OutFold%\Infra.lib"






goto :eof