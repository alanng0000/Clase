namespace Clase.Module;







class GenSystemFunction : Object
{
    public Compile Compile { get; set; }




    private GenConstants Constants { get; set; }




    private GenInfra Infra { get; set; }




    private SystemModule System { get; set; }




    private Refer Refer { get; set; }





    private CheckClass ObjectClass { get; set; }







    public override bool Init()
    {
        base.Init();




        this.Constants = this.Compile.Constants;



        this.Infra = this.Compile.Infra;



        this.System = this.Compile.SystemModule;



        this.Refer = this.Compile.CheckResult.Refer;




        this.ObjectClass = this.Refer.Class.Get("Object");




        return true;
    }






    public bool Execute()
    {
        MapIter iter;


        iter = this.System.Module.Class.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            CheckClass varClass;


            varClass = (CheckClass)pair.Value;




            bool b;


            b = (varClass == this.ObjectClass);



            if (!b)
            {
                this.ExecuteClass(varClass);
            }
        }





        return true;
    }






    private bool ExecuteClass(CheckClass varClass)
    {
        this.ExecuteFields(varClass.Fields);
        


        this.ExecuteMethods(varClass.Methods);



        
        return true;
    }





    private bool ExecuteFields(FieldMap fields)
    {
        MapIter iter;


        iter = fields.Iter();



        while (iter.Next())
        {
            Pair pair;

            pair = (Pair)iter.Value;



            Field field;

            field = (Field)pair.Value;



            this.ExecuteField(field);
        }




        return true;
    }





    private bool ExecuteMethods(MethodMap methods)
    {
        MapIter iter;


        iter = methods.Iter();



        while (iter.Next())
        {
            Pair pair;

            pair = (Pair)iter.Value;



            Method method;

            method = (Method)pair.Value;



            this.ExecuteMethod(method);
        }




        return true;
    }


    



    private bool ExecuteField(Field field)
    {
        this.ExecuteFieldGet(field);




        this.ExecuteFieldSet(field);





        return true;
    }






    private bool ExecuteMethod(Method method)
    {
        this.ExecuteMethodCall(method);




        return true;
    }






    private bool ExecuteFieldGet(Field field)
    {
        return true;
    }





    private bool ExecuteFieldSet(Field field)
    {
        return true;
    }







    private bool ExecuteMethodCall(Method method)
    {
        bool b;


        b = this.Infra.IntType(method.Parent);





        this.Infra.AppendIndent();



        
        this.Infra.AppendMethodFunctionInterface(method);
        



        this.Infra.AppendLine();





        this.Infra.AppendIndent();


        this.Infra.Append(this.Constants.LeftBrace);


        this.Infra.AppendLine();





        this.Infra.IncrementIndent();













        this.Infra.DecrementIndent();





        this.Infra.AppendIndent();


        this.Infra.Append(this.Constants.RightBrace);


        this.Infra.AppendLine();





        this.Infra.AppendLine();







        return true;
    }
}