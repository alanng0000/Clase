namespace Clase.Check;





public class Compile : ClassCompile
{
    public CreateInfra Create { get; set; }





    public ErrorKinds ClaseErrorKinds { get; set; }





    public override bool Init()
    {
        base.Init();




        this.ClaseErrorKinds = (ErrorKinds)this.ErrorKinds;




        this.Create = new CreateInfra();



        this.Create.Init();






        this.InitSystemModules();



        return true;
    }


    



    private bool InitSystemModules()
    {
        Module m;
        


        m = new Module();



        m.Name = "System";
        


        m.Class = this.Create.ExecuteClassMap();





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
        
        

        t = this.Create.ExecuteModuleMap();



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
    





    protected override ClassErrorKinds CreateErrorKinds()
    {
        ErrorKinds errorKinds;


        errorKinds = new ErrorKinds();


        errorKinds.Init();


        
        
        ClassErrorKinds ret;


        ret = errorKinds;


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