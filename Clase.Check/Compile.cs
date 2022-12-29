namespace Clase.Check;





public class Compile : ClassCompile
{
    public ErrorKindList ClaseErrorKind { get; set; }




    public ConstantType ConstantType { get; set; }





    public override bool Init()
    {
        base.Init();




        this.ClaseErrorKind = (ErrorKindList)this.ErrorKind;




        this.ConstantType = new ConstantType();


        this.ConstantType.Init();





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







    protected override bool ExecuteClassBase()
    {
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
        return null;
    }






    public Type GetConstantType(string name)
    {
        Type type;

        type = null;




        ConstantType a;

        a = this.ConstantType;




        type = this.ConstantTypeName(type, a.Bool, name);



        type = this.ConstantTypeName(type, a.Int, name);




        Type ret;

        ret = type;


        return ret;
    }





    private Type ConstantTypeName(Type type, Type constantType, string name)
    {
        if (this.Null(type))
        {
            if (constantType.Name == name)
            {
                type = constantType;
            }
        }



        Type ret;

        ret = type;


        return ret;
    }






    public new Class Class(string name)
    {
        Class varClass;


        
        varClass = (Class)this.Refer.Class.Get(name);
        



        Class ret;


        ret = varClass;


        return ret;
    }





    public Type Type(Class varClass, string name)
    {
        Type h;


        h = null;




        if (this.Null(h))
        {
            h = this.GetConstantType(name);
        }




        if (this.Null(h))
        {
            object o;
            
            
            o = varClass.Struct.Get(name);



            if (!this.Null(o))
            {
                h = (Type)o;
            }
        }




        if (this.Null(h))
        {
            object o;
            
            
            o = varClass.Delegate.Get(name);



            if (!this.Null(o))
            {
                h = (Type)o;
            }
        }




        Type ret;

        ret = h;


        return ret;
    }





    private bool Null(object o)
    {
        return o == null;
    }
}