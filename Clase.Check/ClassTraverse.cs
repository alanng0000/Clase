namespace Clase.Check;





class ClassTraverse : Traverse
{
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





        varClass.Global = new VarMap();



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


        pair.Key = className;


        pair.Value = varClass;



        map.Add(pair);





        Pair o;


        o = new Pair();


        o.Init();


        o.Key = className;


        o.Value = varClass;




        this.Compile.Module.Class.Add(o);
        




        this.Check(nodeClass).Class = varClass;




        return true;
    }
}