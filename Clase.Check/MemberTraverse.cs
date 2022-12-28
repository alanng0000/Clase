namespace Clase.Check;




class MemberTraverse : Traverse
{
    private Class CurrentClass { get; set; }





    private VarMap ParamVars { get; set; }





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





    public override bool ExecuteClaseMethod(NodeMethod nodeMethod)
    {
        if (this.Null(nodeMethod))
        {
            return true;
        }





        MethodName name;

        name = nodeMethod.Name;




        TypeName nodeType;

        nodeType = nodeMethod.Type;




        NodeAccess nodeAccess;

        nodeAccess = nodeMethod.Access;




        ParamList nodeParam;

        nodeParam = nodeMethod.Param;




        StateList call;

        call = nodeMethod.Call;






        string methodName;



        methodName = name.Value;





        string typeName;


        
        typeName = nodeType.Value;
        




        
        if (this.IsMethodNameDefined(methodName))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeMethod);



            return true;
        }





        Class varClass;



        
        varClass = this.Class(className);
        




        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeMethod);



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






        this.ParamVars = o;





        this.ExecuteParamList(paramList);






        Method method;


        method = new Method();


        method.Init();


        method.Name = methodName;


        method.Class = varClass;


        method.Access = access;


        method.Params = this.ParamVars;


        method.Call = u;


        method.Parent = this.CurrentClass;


        method.Node = nodeMethod;



        method.Index = this.CurrentClass.Method.Count;
        





        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = methodName;


        pair.Value = method;




        this.CurrentClass.Method.Add(pair);




        this.Check(nodeMethod).Method = method;




        return true;
    }





    public override bool ExecuteVar(NodeVar nodeVar)
    {
        if (this.Null(nodeVar))
        {
            return true;
        }





        VarName name;

        name = nodeVar.Name;




        ClassName nodeClass;

        nodeClass = nodeVar.Class;
            




        string varName;


        varName = name.Value;
            




        string className;


        className = null;



        if (!this.Null(nodeClass))
        {
            className = nodeClass.Value;
        }






        if (!this.Null(this.ParamVars.Get(varName)))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeVar);


            return true;
        }





        Class varClass;


        varClass = null;




        if (!this.Null(className))
        {
            varClass = this.Class(className);
        }

        


        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeVar);


            return true;
        }





        Var varVar;


        varVar = new Var();


        varVar.Init();


        varVar.Name = varName;


        varVar.Class = varClass;


        varVar.Node = nodeVar;





        this.VarMapAdd(this.ParamVars, varVar);
        




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






    private bool IsMethodNameDefined(string name)
    {
        bool b;

        b = !this.Null(this.CurrentClass.Method.Get(name));




        bool ret;


        ret = b;


        return ret;
    }
}