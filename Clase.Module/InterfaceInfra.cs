namespace Clase.Module;







class InterfaceInfra : Object
{
    public FieldGetInterface FieldGetInterface(Field field)
    {
        FieldGetInterface o;

        o = new FieldGetInterface();

        o.Init();

        o.Class = field.Class;

        o.Name = field.Name;

        o.Access = field.Access;



        FieldGetInterface ret;

        ret = o;

        return ret;
    }







    public FieldSetInterface FieldSetInterface(Field field)
    {
        FieldSetInterface o;

        o = new FieldSetInterface();

        o.Init();

        o.Class = field.Class;

        o.Name = field.Name;

        o.Access = field.Access;



        FieldSetInterface ret;

        ret = o;

        return ret;
    }







    public MethodCallInterface MethodCallInterface(Method method)
    {
        MethodCallInterface o;


        o = new MethodCallInterface();


        o.Init();


        o.Class = method.Class;


        o.Name = method.Name;


        o.Access = method.Access;





        ListClass list;


        list = new ListClass();




        MapIter iter;


        iter = method.Params.Iter();

        
        while (iter.Next())
        {
            Pair pair;

            pair = (Pair)iter.Value;



            Variable variable;

            variable = (Variable)pair.Value;



            CheckClass paramClass;

            paramClass = variable.Class;




            list.Add(paramClass);
        }




        o.Params = list;





        MethodCallInterface ret;


        ret = o;


        return ret;
    }
}