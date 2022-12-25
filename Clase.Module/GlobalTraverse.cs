namespace Clase.Module;





class GlobalTraverse : Traverse
{
    private Map GlobalClass { get; set; }




    private object DummyValue { get; set; }




    public override bool Init()
    {
        base.Init();



        this.GlobalClass = this.Compile.GlobalClass;




        this.DummyValue = new object();



        return true;
    }





    public override bool ExecuteGlobalExpress(GlobalExpress globalExpress)
    {
        if (this.Null(globalExpress))
        {
            return true;
        }




        CheckClass varClass;
        
        
        varClass = this.Check(globalExpress).GlobalClass;



        bool b;
        
        
        b = (this.GlobalClass.Contain(varClass));
        



        if (!b)
        {
            Pair pair;


            pair = new Pair();


            pair.Init();


            pair.Key = varClass;


            pair.Value = this.DummyValue;



            this.GlobalClass.Add(pair);
        }



        return true;
    }
}