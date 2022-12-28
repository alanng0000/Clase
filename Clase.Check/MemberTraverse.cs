namespace Clase.Check;




class MemberTraverse : Traverse
{
    private Class CurrentClass { get; set; }





    private Map VarNameKeyList { get; set; }



    private Var Var { get; set; }



    private VarMap ParamVarList { get; set; }






    private Struct Struct { get; set; }





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







    public override bool ExecuteStruct(NodeStruct nodeStruct)
    {
        if (this.Null(nodeStruct))
        {
            return true;
        }




        





        Struct varStruct;
        

        varStruct = this.Check(nodeStruct).Struct;






        StructFieldMap m;


        m = new StructFieldMap();


        m.Init();




        varStruct.Field = m;






        this.Struct = varStruct;





        base.ExecuteStruct(nodeStruct);





        this.Struct = null;




        return true;
    }







    public override bool ExecuteStructField(NodeStructField nodeStructField)
    {
        if (this.Null(nodeStructField))
        {
            return true;
        }





        TypeName nodeType;


        nodeType = nodeStructField.Type;




        FieldName name;


        name = nodeStructField.Name;






        string fieldName;



        fieldName = name.Value;





        string typeName;


        
        typeName = nodeType.Value;
        




        
        if (!this.Null(this.Struct.Field.Get(fieldName)))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeStructField);



            return true;
        }






        Type type;



        
        type = this.Type(this.CurrentClass, typeName);
        




        if (this.Null(type))
        {
            this.Error(this.ClaseErrorKind.TypeUndefined, nodeStructField);



            return true;
        }





        StructField structField;


        structField = new StructField();


        structField.Init();


        structField.Type = type;


        structField.Name = fieldName;


        structField.Parent = this.Struct;


        structField.Node = nodeStructField;


        structField.Index = this.Struct.Field.Count;
        





        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = structField.Name;


        pair.Value = structField;



        this.Struct.Field.Add(pair);






        this.Check(nodeStructField).StructField = structField;







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





        this.VarNameKeyList = this.CurrentClass.Global;




        base.ExecuteGlobal(nodeGlobal);




        this.VarNameKeyList = null;

        




        Var varVar;


        varVar = this.Var;






        Global varGlobal;


        varGlobal = new Global();


        varGlobal.Init();


        varGlobal.Var = varVar;


        varGlobal.Parent = this.CurrentClass;


        varGlobal.Node = nodeGlobal;


        varGlobal.Index = this.CurrentClass.Global.Count;
        



        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = varGlobal.Var.Name;


        pair.Value = varGlobal;



        this.CurrentClass.Global.Add(pair);




        this.Check(nodeGlobal).Global = varGlobal;




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






        this.ParamVarList = o;




        this.VarNameKeyList = this.ParamVarList;





        this.ExecuteClaseParamList(nodeParam);




        this.VarNameKeyList = null;




        this.ParamVarList = null;

        





        Method method;


        method = new Method();


        method.Init();


        method.Name = methodName;


        method.Type = type;


        method.Access = access;


        method.Param = this.ParamVarList;


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







    public override bool ExecuteClaseParam(Param param)
    {
        if (this.Null(param))
        {
            return true;
        }



        base.ExecuteClaseParam(param);




        this.VarMapAdd(this.ParamVarList, this.Var);





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






        if (!this.Null(this.VarNameKeyList.Get(varName)))
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


        varVar.Type = varType;


        varVar.Name = varName;


        varVar.Node = nodeVar;





        this.Check(nodeVar).Var = varVar;





        this.Var = varVar;




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