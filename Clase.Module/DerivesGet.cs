namespace Clase.Module;





class DerivesGet
{
    public Compile Compile { get; set; }




    private Refer Refer { get; set; }




    private Map Derives { get; set; }




    private object DummyValue { get; set; }






    public bool Init()
    {
        this.Refer = this.Compile.CheckResult.Refer;





        this.Derives = this.Compile.Derives;





        this.DummyValue = new object();




        return true;
    }






    public bool Execute()
    {
        MapIter iter;


        iter = this.Refer.Class.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            CheckClass varClass;


            varClass = (CheckClass)pair.Value;




            this.ExecuteClass(varClass);
        }





        return true;
    }
    





    private bool ExecuteClass(CheckClass varClass)
    {
        if (varClass == null)
        {
            return true;
        }




        this.ExecuteClass(varClass.Base);





        if (!this.Derives.Contain(varClass))
        {
            Pair pair;


            pair = new Pair();


            pair.Init();


            pair.Key = varClass;


            pair.Value = this.DummyValue;



            this.Derives.Add(pair);
        }



        return true;
    }
}