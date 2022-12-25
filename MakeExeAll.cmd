@echo off



SET MethodsFilePath=..\Infra\MakeMethods.cmd



SET OutFold=..\..\Out





CALL %MethodsFilePath% :MakeModule Exe Exe "Kernel32.lib %OutFold%\Infra.lib %OutFold%\Infra.Form.Infra.lib %OutFold%\Infra.Form.Windows.lib" exe






goto :eof