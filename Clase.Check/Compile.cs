namespace Clase.Check;





public class Compile : ClassCompile
{
    public ErrorKindList ClaseErrorKinds { get; set; }





    public override bool Init()
    {
        base.Init();




        this.ClaseErrorKinds = (ErrorKindList)this.ErrorKind;







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






        ClassClass objectClass;


        objectClass = this.CreateObjectClass();


        objectClass.Module = m;


        objectClass.Index = 0;

        




        Pair u;


        u = new Pair();


        u.Init();


        u.Key = objectClass.Name;


        u.Value = objectClass;




        m.Class.Add(u);






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





    protected override bool SetObjectClassMembers()
    {
        base.SetObjectClassMembers();



        this.AddObjectClassMethod("Final");
        



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





    protected override ClassTraverse InitTraverse()
    {
        InitTraverse traverse;




        traverse = new InitTraverse();




        traverse.Compile = this;




        traverse.Init();




        return traverse;
    }





    protected override ClassTraverse StateTraverse()
    {
        StateTraverse traverse;




        traverse = new StateTraverse();




        traverse.Compile = this;




        traverse.Init();




        return traverse;
    }
}