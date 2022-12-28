namespace Clase.Check;





class ClassTraverse : Traverse
{
    private Class CurrentClass { get; set; }





    public override bool ExecuteClass(NodeClass nodeClass)
    {
        if (this.Null(nodeClass))
        {
            return true;
        }
        



        ClassName name;
        

        name = nodeClass.Name;




        string className;


        className = name.Value;







        ClassMap map;



        map = this.Compile.Refer.Class;




        
        if (!this.Null(map.Get(className)))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeClass);


            return true;
        }




        



        

        Class varClass;



        varClass = new Class();



        varClass.Init();

        



        varClass.Name = className;




        varClass.Struct = new StructMap();



        varClass.Struct.Init();




        varClass.Delegate = new DelegateMap();



        varClass.Delegate.Init();





        varClass.Global = new GlobalMap();



        varClass.Global.Init();





        varClass.Method = new MethodMap();



        varClass.Method.Init();






        varClass.Module = this.Compile.Module;



        varClass.Node = nodeClass;



        varClass.Source = this.Source;



        varClass.Index = this.Source.Index;



        varClass.Id = this.Compile.NewClassId();






        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = varClass.Name;


        pair.Value = varClass;



        map.Add(pair);





        Pair o;


        o = new Pair();


        o.Init();


        o.Key = varClass.Name;


        o.Value = varClass;




        this.Compile.Module.Class.Add(o);
        




        this.Check(nodeClass).Class = varClass;






        this.CurrentClass = varClass;





        base.ExecuteClass(nodeClass);




        return true;
    }






    public override bool ExecuteStruct(NodeStruct nodeStruct)
    {
        if (this.Null(nodeStruct))
        {
            return true;
        }



        TypeName name;


        name = nodeStruct.Name;






        string typeName;


        
        typeName = name.Value;
        




        if (!this.Null(this.Compile.Type(this.CurrentClass, typeName)))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeStruct);


            return true;
        }






        Struct varStruct;



        varStruct = new Struct();



        varStruct.Init();



        varStruct.Name = typeName;



        varStruct.Field = null;



        varStruct.Parent = this.CurrentClass;



        varStruct.Node = nodeStruct;





        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = varStruct.Name;


        pair.Value = varStruct;





        this.CurrentClass.Struct.Add(pair);





        this.Check(nodeStruct).Struct = varStruct;





        return true;
    }







    public override bool ExecuteDelegate(NodeDelegate nodeDelegate)
    {
        if (this.Null(nodeDelegate))
        {
            return true;
        }



        TypeName name;


        name = nodeDelegate.Name;






        string typeName;


        
        typeName = name.Value;
        




        if (!this.Null(this.Compile.Type(this.CurrentClass, typeName)))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeDelegate);


            return true;
        }






        Delegate varDelegate;



        varDelegate = new Delegate();



        varDelegate.Init();



        varDelegate.Name = typeName;



        varDelegate.Type = null;


        
        varDelegate.Param = null;



        varDelegate.Parent = this.CurrentClass;



        varDelegate.Node = nodeDelegate;






        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = varDelegate.Name;


        pair.Value = varDelegate;





        this.CurrentClass.Delegate.Add(pair);





        this.Check(nodeDelegate).Delegate = varDelegate;





        return true;
    }
}