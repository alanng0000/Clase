namespace Clase.Module;





class Traverse : CheckTraverse
{
    public new Compile Compile { get; set; }





    public override bool Init()
    {
        this.Refer = this.Compile.CheckResult.Refer;


        
        return true;
    }





    public bool ExecuteClass(CheckClass varClass)
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






    protected virtual bool ExecuteFieldGet(Field field)
    {
        NodeField nodeField;


        nodeField = field.Node;





        if (this.Null(nodeField))
        {
            return true;
        }



        

        States nodeGet;


        nodeGet = nodeField.Get;




        this.ExecuteStates(nodeGet);




        return true;
    }





    protected virtual bool ExecuteFieldSet(Field field)
    {
        NodeField nodeField;


        nodeField = field.Node;





        if (this.Null(nodeField))
        {
            return true;
        }



        

        States nodeSet;


        nodeSet = nodeField.Set;




        this.ExecuteStates(nodeSet);




        return true;
    }





    protected virtual bool ExecuteMethodCall(Method method)
    {
        NodeMethod nodeMethod;


        nodeMethod = method.Node;




        
        if (this.Null(nodeMethod))
        {
            return true;
        }





        States nodeCall;


        nodeCall = nodeMethod.Call;




        this.ExecuteStates(nodeCall);




        return true;
    }







    protected override CheckCheck Check(NodeNode node)
    {
        return this.Compile.CheckResult.Checks.Get(node);
    }




    

    internal CheckCheck LocalCheck(NodeNode node)
    {
        return this.Check(node);
    }
}