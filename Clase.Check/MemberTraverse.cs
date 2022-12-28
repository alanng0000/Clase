namespace Clase.Check;




class MemberTraverse : Traverse
{
    private Class CurrentClass { get; set; }





    private Map Vars { get; set; }





    public override bool ExecuteClass(NodeClass nodeClass)
    {
        if (this.Null(nodeClass))
        {
            return true;
        }




        this.CurrentClass = this.Check(nodeClass).Class;




        if (this.Null(this.CurrentClass))
        {
            return true;
        }




        base.ExecuteClass(nodeClass);




        return true;
    }





    public override bool ExecuteField(NodeField nodeField)
    {
        if (this.Null(nodeField))
        {
            return true;
        }




        FieldName name;

        name = nodeField.Name;




        ClassName nodeClass;
            
        nodeClass = nodeField.Class;




        NodeAccess nodeAccess;

        nodeAccess = nodeField.Access;




        StateList nodeGet;

        nodeGet = nodeField.Get;




        StateList nodeSet;

        nodeSet = nodeField.Set;






        string fieldName;


        fieldName = name.Value;





        string className;

        
        className = nodeClass.Value;
               






        if (this.IsMemberNameDefined(fieldName))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeField);


            return true;
        }
        





        Class varClass;



        
        varClass = this.Class(className);
        




        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeField);


            return true;
        }





        Access access;



        access = this.GetAccess(nodeAccess);







        VarMap varGet;


        

        varGet = new VarMap();




        varGet.Init();
        





        VarMap varSet;


        
        
        varSet = new VarMap();




        varSet.Init();







        Field field;
            

        field = new Field();


        field.Init();
            

        field.Name = fieldName;
            

        field.Class = varClass;


        field.Access = access;


        field.Get = varGet;


        field.Set = varSet;


        field.Parent = this.CurrentClass;


        field.Node = nodeField;




        field.Index = this.CurrentClass.Field.Count;





        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = fieldName;


        pair.Value = field;



        this.CurrentClass.Field.Add(pair);





        this.Check(nodeField).Field = field;




        return true;
    }






    public override bool ExecuteGlobal(NodeGlobal nodeGlobal)
    {
        if (this.Null(nodeGlobal))
        {
            return true;
        }




        NodeVar nodeVar;

        nodeVar = nodeGlobal.Var;



        





        return true;
    }






    public override bool ExecuteClaseMethod(NodeMethod nodeMethod)
    {
        if (this.Null(nodeMethod))
        {
            return true;
        }






        NodeAccess nodeAccess;

        nodeAccess = nodeMethod.Access;




        TypeName nodeType;

        nodeType = nodeMethod.Type;




        MethodName name;

        name = nodeMethod.Name;




        ParamList nodeParam;

        nodeParam = nodeMethod.Param;




        StateList call;

        call = nodeMethod.Call;






        string methodName;



        methodName = name.Value;





        string typeName;


        
        typeName = nodeType.Value;
        




        
        if (!this.Null(this.Method(this.CurrentClass, methodName)))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeMethod);



            return true;
        }






        Type type;



        
        type = this.Type(this.CurrentClass, typeName);
        




        if (this.Null(type))
        {
            this.Error(this.ClaseErrorKind.TypeUndefined, nodeMethod);



            return true;
        }





        Access access;



        access = this.GetAccess(nodeAccess);






        VarMap o;



        o = new VarMap();



        o.Init();





        VarMap u;



        u = new VarMap();



        u.Init();






        this.Vars = o;





        this.ExecuteClaseParamList(nodeParam);




        this.VarMapAdd(this.Vars, varVar);
        





        Method method;


        method = new Method();


        method.Init();


        method.Name = methodName;


        method.Type = type;


        method.Access = access;


        method.Param = this.ParamVars;


        method.Call = u;


        method.Parent = this.CurrentClass;


        method.Node = nodeMethod;


        method.Index = this.CurrentClass.Method.Count;
        





        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = method.Name;


        pair.Value = method;




        this.CurrentClass.Method.Add(pair);




        this.Check(nodeMethod).Method = method;




        return true;
    }





    public override bool ExecuteClaseVar(NodeVar nodeVar)
    {
        if (this.Null(nodeVar))
        {
            return true;
        }






        TypeName type;

        type = nodeVar.Type;





        VarName name;

        name = nodeVar.Name;






        string varName;


        varName = name.Value;
        




        string typeName;


        typeName = type.Value;






        if (!this.Null(this.Vars.Get(varName)))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeVar);


            return true;
        }





        Type varType;


        varType = this.Type(this.CurrentClass, typeName);


        


        if (this.Null(varType))
        {
            this.Error(this.ClaseErrorKind.TypeUndefined, nodeVar);


            return true;
        }





        Var varVar;


        varVar = new Var();


        varVar.Init();


        varVar.Name = varName;


        varVar.Type = varType;


        varVar.Node = nodeVar;







        this.Check(nodeVar).Var = varVar;




        return true;
    }





    private bool VarMapAdd(VarMap map, Var varVar)
    {
        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = varVar.Name;


        pair.Value = varVar;




        map.Add(pair);



        return true;
    }





    private bool VarMapMapAdd(VarMap map, VarMap other)
    {
        MapIter iter;


        iter = other.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            Var varVar;


            varVar = (Var)pair.Value;




            this.VarMapAdd(map, varVar);
        }



        return true;
    }






    private Method Method(Class varClass, string name)
    {
        object o;


        o = varClass.Method.Get(name);



        if (this.Null(o))
        {
            return null;
        }




        Method m;


        m = (Method)o;





        Method ret;


        ret = m;


        return ret;
    }
}