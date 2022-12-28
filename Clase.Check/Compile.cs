namespace Clase.Check;





public class Compile : ClassCompile
{
    public ErrorKindList ClaseErrorKind { get; set; }





    public override bool Init()
    {
        base.Init();




        this.ClaseErrorKind = (ErrorKindList)this.ErrorKind;







        this.InitSystemModules();



        return true;
    }







    public new Check CreateCheck()
    {
        Check check;



        check = new Check();



        check.Init();




        Check ret;

        ret = check;


        return ret;
    }


    



    private bool InitSystemModules()
    {
        Module m;
        


        m = new Module();



        m.Name = "System";
        




        ClassMap k = new ClassMap();


        k.Init();



        m.Class = k;






        Pair pair;


        pair = new Pair();


        pair.Key = m.Name;


        pair.Value = m;






        ModuleMap t;
        
        

        t = new ModuleMap();


        t.Init();
        


        t.Add(pair);





        this.SystemModules = t;






        GenSystem genSystem;


        genSystem = new GenSystem();


        genSystem.Compile = this;


        genSystem.Module = m;


        genSystem.Init();


        genSystem.Execute();





        return true;
    }









    protected override bool CheckBase(ClassClass varClass)
    {
        bool b;


        b =        
        (
            varClass == this.SystemModule.Bool |
            varClass == this.SystemModule.Int |
            varClass == this.SystemModule.String
        );



        if (b)
        {
            return false;
        }
        


        return true;
    }







    protected override ClassErrorKindList CreateErrorKind()
    {
        ErrorKindList errorKind;


        errorKind = ErrorKindList.This;


        
        
        ClassErrorKindList ret;


        ret = errorKind;


        return ret;
    }





    protected override ClassBaseTraverse InitTraverse()
    {
        InitTraverse traverse;




        traverse = new InitTraverse();




        traverse.Compile = this;




        traverse.Init();




        return traverse;
    }





    protected override ClassBaseTraverse StateTraverse()
    {
        StateTraverse traverse;




        traverse = new StateTraverse();




        traverse.Compile = this;




        traverse.Init();




        return traverse;
    }
}