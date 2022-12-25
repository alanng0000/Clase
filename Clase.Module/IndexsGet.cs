namespace Clase.Module;





class IndexsGet : Object
{
    public Compile Compile { get; set; }




    private Refer Refer { get; set; }




    private InterfaceInfra InterfaceInfra { get; set; }




    private Map Indexs { get; set; }




    private Map Derives { get; set; }





    public override bool Init()
    {
        base.Init();





        this.Refer = this.Compile.CheckResult.Refer;





        this.InterfaceInfra = this.Compile.InterfaceInfra;





        this.Indexs = this.Compile.Indexs;





        this.Derives = this.Compile.Derives;




        return true;
    }





    public bool Execute()
    {
        this.ExecuteAllClass();




        return true;
    }






    private bool ExecuteAllClass()
    {
        MapIter iter;



        iter = this.Derives.Iter();




        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            CheckClass varClass;


            varClass = (CheckClass)pair.Key;




            this.ExecuteOneClass(varClass);
        }





        return true;
    }





    private bool ExecuteOneClass(CheckClass varClass)
    {
        this.ThisIndex = this.AddIndex(varClass);





        if (!(varClass.Base == null))
        {
            ClassIndex baseIndex;


            baseIndex = this.Index(varClass.Base);



            this.CopyIndex(this.ThisIndex, baseIndex);
        }

        



        this.ExecuteClassFields();




        this.ExecuteClassMethods();




        return true;
    }






    private ClassIndex ThisIndex { get; set; }






    private bool ExecuteClassFields()
    {
        CheckClass varClass;

        varClass = this.ThisIndex.Class;




        MapIter iter;


        iter = varClass.Fields.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;



            Field field;


            field = (Field)pair.Value;




            this.ExecuteClassField(field);
        }



        return true;
    }






    private bool ExecuteClassField(Field field)
    {
        this.ExecuteClassFieldGet(field);




        this.ExecuteClassFieldSet(field);






        return true;
    }








    private bool ExecuteClassFieldGet(Field field)
    {
        ClassIndex index;
        
        index = this.ThisIndex;





        FieldGetInterface fgi;


        fgi = this.InterfaceInfra.FieldGetInterface(field);





        FieldGetIndex fieldGetIndex;


        fieldGetIndex = this.FieldGetIndex(index, fgi);





        bool b;


        b = this.Null(fieldGetIndex);




        if (!b)
        {
            fieldGetIndex.Field = field;


            return true;
        }



        
        
        FieldGetIndex o;


        o = new FieldGetIndex();


        o.Init();


        o.Field = field;


        o.Index = index.Members.Count;





        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = fgi;


        pair.Value = o;




        index.Members.Add(pair);
        



        return true;
    }









    private bool ExecuteClassFieldSet(Field field)
    {
        ClassIndex index;
        
        index = this.ThisIndex;





        FieldSetInterface fsi;


        fsi = this.InterfaceInfra.FieldSetInterface(field);





        FieldSetIndex fieldSetIndex;


        fieldSetIndex = this.FieldSetIndex(index, fsi);





        bool b;


        b = this.Null(fieldSetIndex);




        if (!b)
        {
            fieldSetIndex.Field = field;


            return true;
        }



        
        
        FieldSetIndex o;


        o = new FieldSetIndex();


        o.Init();


        o.Field = field;


        o.Index = index.Members.Count;





        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = fsi;


        pair.Value = o;




        index.Members.Add(pair);
        



        return true;
    }











    private bool ExecuteClassMethods()
    {
        CheckClass varClass;

        varClass = this.ThisIndex.Class;




        MapIter iter;


        iter = varClass.Methods.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;



            Method method;


            method = (Method)pair.Value;




            this.ExecuteClassMethod(method);
        }



        return true;
    }






    private bool ExecuteClassMethod(Method method)
    {
        this.ExecuteClassMethodCall(method);



        return true;
    }






    private bool ExecuteClassMethodCall(Method method)
    {
        ClassIndex index;
        
        index = this.ThisIndex;




        MethodCallInterface mci;


        mci = this.InterfaceInfra.MethodCallInterface(method);




        MethodCallIndex methodCallIndex;


        methodCallIndex = this.MethodCallIndex(index, mci);




        bool b;


        b = this.Null(methodCallIndex);




        if (!b)
        {
            methodCallIndex.Method = method;


            return true;
        }



        
        
        MethodCallIndex o;


        o = new MethodCallIndex();


        o.Init();


        o.Method = method;


        o.Index = index.Members.Count;





        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = mci;


        pair.Value = o;




        index.Members.Add(pair);
        



        return true;
    }







    
    



    private FieldGetIndex FieldGetIndex(ClassIndex index, FieldGetInterface fgi)
    {
        FieldGetIndex k;


        k = (FieldGetIndex)index.Members.Get(fgi);





        FieldGetIndex ret;


        ret = k;


        return ret;
    }







    private FieldSetIndex FieldSetIndex(ClassIndex index, FieldSetInterface fsi)
    {
        FieldSetIndex k;


        k = (FieldSetIndex)index.Members.Get(fsi);





        FieldSetIndex ret;


        ret = k;


        return ret;
    }







    private MethodCallIndex MethodCallIndex(ClassIndex index, MethodCallInterface mci)
    {
        MethodCallIndex k;


        k = (MethodCallIndex)index.Members.Get(mci);





        MethodCallIndex ret;


        ret = k;


        return ret;
    }







    private ClassIndex AddIndex(CheckClass varClass)
    {
        ClassIndex t;


        t = new ClassIndex();


        t.Class = varClass;


        t.Init();




        Pair u;


        u = new Pair();


        u.Init();


        u.Key = varClass;


        u.Value = t;




        this.Indexs.Add(u);





        ClassIndex ret;


        ret = t;


        return ret;
    }








    private bool CopyIndex(ClassIndex dest, ClassIndex source)
    {
        MapIter iter;


        iter = source.Members.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            Interface tInterface;


            tInterface = (Interface)pair.Key;




            MemberIndex o;


            o = (MemberIndex)pair.Value;





            MemberIndex index;


            index = this.CreateMemberIndex(o);





            Pair pp;


            pp = new Pair();


            pp.Init();


            pp.Key = tInterface;


            pp.Value = index;



            dest.Members.Add(pp);
        }





        return true;
    }





    private MemberIndex CreateMemberIndex(MemberIndex o)
    {
        if (o is FieldGetIndex)
        {
            FieldGetIndex fg;

            fg = (FieldGetIndex)o;


            return this.CreateFieldGetIndex(fg);
        }



        if (o is FieldSetIndex)
        {
            FieldSetIndex fs;

            fs = (FieldSetIndex)o;


            return this.CreateFieldSetIndex(fs);
        }



        if (o is MethodCallIndex)
        {
            MethodCallIndex mc;

            mc = (MethodCallIndex)o;


            return this.CreateMethodCallIndex(mc);
        }




        return null;
    }




    private FieldGetIndex CreateFieldGetIndex(FieldGetIndex o)
    {
        FieldGetIndex t;


        t = new FieldGetIndex();


        t.Init();


        t.Field = o.Field;


        t.Index = o.Index;




        FieldGetIndex ret;


        ret = t;


        return ret;
    }






    private FieldSetIndex CreateFieldSetIndex(FieldSetIndex o)
    {
        FieldSetIndex t;


        t = new FieldSetIndex();


        t.Init();


        t.Field = o.Field;


        t.Index = o.Index;




        FieldSetIndex ret;


        ret = t;


        return ret;
    }








    private MethodCallIndex CreateMethodCallIndex(MethodCallIndex o)
    {
        MethodCallIndex t;


        t = new MethodCallIndex();


        t.Init();


        t.Method = o.Method;


        t.Index = o.Index;




        MethodCallIndex ret;


        ret = t;


        return ret;
    }







    private ClassIndex Index(CheckClass varClass)
    {
        ClassIndex t;


        t = (ClassIndex)this.Indexs.Get(varClass);





        ClassIndex ret;

        ret = t;


        return ret;
    }






    private bool Null(object o)
    {
        return o == null;
    }
}