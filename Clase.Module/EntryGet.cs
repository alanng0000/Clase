namespace Clase.Module;






class EntryGet
{
    public Compile Compile { get; set; }



    private Refer Refer { get; set; }



    private SystemModule System { get; set; }



    private Accesss Accesss { get; set; }



    private Method EntryMethod { get; set; }
    



    public bool Init()
    {
        this.Refer = this.Compile.CheckResult.Refer;



        this.System = this.Compile.SystemModule;



        this.Accesss = Accesss.This;



        return true;
    }




    public bool Execute()
    {
        MapIter iter;


        iter = this.Refer.Class.Iter();



        while (this.Null(this.EntryMethod) & iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;



            CheckClass varClass;


            varClass = (CheckClass)pair.Value;



            bool b;


            b = (varClass.Module == this.System.Module);



            if (!b)
            {
                this.ExecuteClass(varClass);
            }
        }        




        if (!this.Null(this.EntryMethod))
        {
            this.Compile.EntryMethod = this.EntryMethod;
        }
        



        return true;
    }





    private bool ExecuteClass(CheckClass varClass)
    {
        MapIter iter;


        iter = varClass.Methods.Iter();


        while (this.Null(this.EntryMethod) & iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;



            Method method;


            method = (Method)pair.Value;



            this.ExecuteMethod(method);
        }



        return true;
    }





    private bool ExecuteMethod(Method method)
    {
        bool ba;


        ba = (method.Access == this.Accesss.Public);




        bool bb;


        bb = (method.Class == this.System.Bool);




        bool bc;


        bc = (method.Name == "Main");





        bool bd;


        bd = false;



        if (method.Params.Count == 1)
        {
            MapIter iter;
            

            iter = method.Params.Iter();


            iter.Next();



            Pair pair;


            pair = (Pair)iter.Value;



            Variable variable;


            variable = (Variable)pair.Value;

            

            if (variable.Class == this.System.String)
            {
                bd = true;
            }
        }





        bool b;


        b = (ba & bb & bc & bd);




        if (b)
        {
            this.EntryMethod = method;
        }




        return true;
    }





    private bool Null(object o)
    {
        return o == null;
    }
}