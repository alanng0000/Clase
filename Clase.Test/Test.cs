namespace Clase.Test;




public class Test : ClassTest
{
    protected override ClassClass CreateClass()
    {
        ClaseClase t;



        t = new ClaseClase();



        t.Init();





        ClassClass ret;


        ret = t;


        return ret;
    }




    protected override string LanguageName()
    {
        return "Clase";
    }




    protected override bool CompileSystemModules()
    {
        return true;
    }



    protected override bool AddSets()
    {
        return true;
    }




    protected override bool AddFoldSets()
    {
        this.AddFoldSet("Node", true, false, false);



        this.AddFoldSet("Check", false, true, false);



        return true;
    }




    protected override string CurrentDirectory()
    {
        return "../../../../Clase.Test";
    }
}