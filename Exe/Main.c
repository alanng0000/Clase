#include "Main.h"





int main(int argc, char** argv)
{
    Infra_Form_Init();





    Main_Execute(argc, argv);




    return 0;
}








Bool Main_Execute(int argc, char** argv)
{
    Main_ConsoleWrite("Main_Execute START\n");



    if (!(argc == 3))
    {
        Main_ConsoleWrite("Error: argc is not 3\n");


        return false;
    }





    char* u;


    u = argv[1];






    Int p;

    p = CastInt(u);





    Int pLength;


    pLength = String_ConstantLength(p);





    Int pa;


    pa = CastInt(".\\");




    Int paLength;


    paLength = String_ConstantLength(pa);



    

    Int pb;


    pb = CastInt(".dll");




    Int pbLength;


    pbLength = String_ConstantLength(pb) + 1;






    Int pathLength;


    pathLength = paLength + pLength + pbLength;


    


    Int pathData;


    pathData = New(pathLength);








    
    Int h;


    h = pathData;



    Copy(h, pa, paLength);

    

    h = h + paLength;



    Copy(h, p, pLength);



    h = h + pLength;



    Copy(h, pb, pbLength);

    

    h = h + pbLength;






    char* argU;


    argU = argv[2];




    p = CastInt(argU);




    pLength = String_ConstantLength(p);






    Object arg;



    arg = String_New();



    String_Init(arg);



    String_SetLength(arg, pLength);



    String_SetData(arg, p);




    



    u = (char*)pathData;




    Main_ConsoleWrite("Main_Execute LoadLibraryA\n");




    HMODULE hmodule;


    hmodule = LoadLibraryA(u);



    if (hmodule == NULL)
    {
        Main_ConsoleWrite("Error: Windows API LoadLibraryA fail\n");


        return false;
    }






    char* function;
    
    
    function = "Clase___SysMain";




    Main_ConsoleWrite("Main_Execute GetProcAddress\n");




    FARPROC uu;


    uu = GetProcAddress(hmodule, function);



    if (uu == NULL)
    {
        Main_ConsoleWrite("Error: Windows API GetProcAddress fail\n");



        return false;
    }






    Main_ConsoleWrite("Main_Execute Clase___SysMain START\n");




    Clase____SysMainMethod method;



    method = (Clase____SysMainMethod)uu;




    method(arg);





    Main_ConsoleWrite("Main_Execute Clase___SysMain END\n");






    String_Final(arg);



    String_Delete(arg);





    Delete(pathData);





    return true;
}







Bool ConsoleWrite(char* s)
{
    Object console;


    console = Console_New();



    Console_Init(console);






    Int p;


    p = CastInt(s);




    Int pLength;


    pLength = String_ConstantLength(p);





    Object string;



    string = String_New();



    String_Init(string);


    
    String_SetLength(string, pLength);


    String_SetData(string, p);




    Console_Write(console, string);





    String_Final(string);



    String_Delete(string);





    Console_Final(console);


    Console_Delete(console);


    return true;
}