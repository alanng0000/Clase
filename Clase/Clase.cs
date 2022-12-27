namespace Clase;




public class Clase : ClassClass
{
    public Task CreateTask(string[] args)
    {
        TaskCreate a;

        a = new TaskCreate();

        a.Init();




        Task d;

        d = a.Task(args);




        Task ret;

        ret = d;


        return ret;
    }





    protected override string ClassFold()
    {
        return this.SourceFold;
    }




    protected override bool ReadPort()
    {
        string t;


        t = Path.GetFileName(this.SourceFold);




        this.ModuleName = t;




        return true;
    }





    protected override ClassCompile CreateCompile()
    {
        Compile compile;




        compile = new Compile();




        compile.Class = this;




        compile.Init();
        




        ClassCompile ret;



        ret = compile;



        return ret;
    }
}