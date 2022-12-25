#pragma once



#include <windows.h>




#include <Infra.h>






typedef Bool (*Clase____SysMainMethod)(Object arg);





int main(int argc, char** argv);




Bool Main_Execute(int argc, char** argv);




Bool Main_ConsoleWrite(char* s);