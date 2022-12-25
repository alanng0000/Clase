namespace Clase;




class Compile : ClassCompile
{
    protected override ClassNodeCompile CreateNode()
    {
        NodeCompile compile;




        compile = new NodeCompile();




        compile.Init();





        ClassNodeCompile ret;



        ret = compile;



        return ret;
    }







    protected override ClassCheckCompile CreateCheck()
    {
        CheckCompile compile;




        compile = new CheckCompile();




        compile.Init();





        ClassCheckCompile ret;



        ret = compile;



        return ret;
    }






    protected override ClassModuleCompile CreateModule()
    {
        ModuleCompile compile;




        compile = new ModuleCompile();




        compile.Init();





        ClassModuleCompile ret;



        ret = compile;



        return ret;
    }
}