@echo off



SET MethodsFilePath=..\Infra\MakeMethods.cmd



SET OutFold=..\..\Out






SET Module=%~1



SET SourceFold=Gen






CALL %MethodsFilePath% :MakeModule "%Module%" "%SourceFold%" "%OutFold%\Infra.lib %OutFold%\Infra.Form.Infra.lib %OutFold%\Infra.Form.Windows.lib"






goto :eof