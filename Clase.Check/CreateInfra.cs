namespace Clase.Check;




public class CreateInfra
{
    public bool Init()
    {
        return true;
    }






    public ClassClass ExecuteClass(string name)
    {
        ClassClass varClass;


        varClass = new ClassClass();



        varClass.Name = name;



        varClass.Base = null;



        varClass.Fields = this.ExecuteFieldMap();



        varClass.Methods = this.ExecuteMethodMap();





        ClassClass ret;


        ret = varClass;


        return ret;
    }






    public Field ExecuteField(Access access, ClassClass varClass, string name)
    {
        Field field;


        field = new Field();


        field.Name = name;


        field.Class = varClass;


        field.Access = access;


        field.Get = this.ExecuteVariableMap();


        field.Set = this.ExecuteVariableMap();




        Field ret;

        ret = field;


        return ret;
    }





    public Method ExecuteMethod(Access access, ClassClass varClass, string name, VariableMap varParams)
    {
        Method method;


        method = new Method();


        method.Name = name;


        method.Class = varClass;


        method.Access = access;


        method.Params = varParams;


        method.Call = this.ExecuteVariableMap();
        




        Method ret;


        ret = method;


        return ret;
    }




    public Variable ExecuteVariable(ClassClass varClass, string name)
    {
        Variable t;


        t = new Variable();


        t.Class = varClass;

        
        t.Name = name;
        



        Variable ret;

        ret = t;


        return ret;
    }




    public ModuleMap ExecuteModuleMap()
    {
        ModuleMap t;
        
        
        t = new ModuleMap();


        t.Compare = this.ExecuteStringCompare();


        t.Init();




        ModuleMap ret;

        ret = t;


        return ret;
    }





    public ClassMap ExecuteClassMap()
    {
        ClassMap t;


        t = new ClassMap();


        t.Compare = this.ExecuteStringCompare();


        t.Init();




        ClassMap ret;

        ret = t;

        return ret;
    }





    public FieldMap ExecuteFieldMap()
    {
        FieldMap t;



        t = new FieldMap();



        t.Compare = this.ExecuteStringCompare();



        t.Init();




        FieldMap ret;


        ret = t;


        return ret;
    }






    public MethodMap ExecuteMethodMap()
    {
        MethodMap t;



        t = new MethodMap();



        t.Compare = this.ExecuteStringCompare();



        t.Init();




        MethodMap ret;


        ret = t;


        return ret;
    }






    public VariableMap ExecuteVariableMap()
    {
        VariableMap t;


        t = new VariableMap();

        
        t.Compare = this.ExecuteStringCompare();

        
        t.Init();



        VariableMap ret;


        ret = t;


        return ret;
    }





    private StringCompare ExecuteStringCompare()
    {
        StringCompare t;

        t = new StringCompare();

        t.Init();




        StringCompare ret;

        ret = t;

        return ret;
    }
}