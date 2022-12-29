namespace Clase.Check;



class GenSystem : Object
{
    public override bool Init()
    {
        base.Init();





        this.ClassMap = this.Module.Class;



        this.Range = this.Compile.Range;





        return true;
    }






    public Compile Compile { get; set; }





    public Module Module { get; set; }





    private Map ClassMemberStringList { get; set; }




    private List CurrentMemberStringList { get; set; }




    private ClassMap ClassMap { get; set; }




    private RangeInfra Range { get; set; }





    public bool Execute()
    {
        StringCompare compare;


        compare = new StringCompare();


        compare.Init();




        this.ClassMemberStringList = new Map();


        this.ClassMemberStringList.Compare = compare;


        this.ClassMemberStringList.Init();





        this.SetStringMap();




        this.SetClassMap();




        return true;
    }





    private bool SetClassMap()
    {
        this.AddClass();




        this.AddMemberList();



        return true;
    }





    private bool AddClass()
    {
        MapIter iter;


        iter = this.ClassMemberStringList.Iter();



        while (iter.Next())
        {
            Pair pair;

            pair = (Pair)iter.Value;



            string className;

            className = (string)pair.Key;




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



            varClass.Module = this.Module;



            varClass.Index = this.ClassMap.Count;





            Pair d;

            d = new Pair();

            d.Key = varClass.Name;

            d.Value = varClass;



            this.ClassMap.Add(d);
        }



        return true;
    }






    private bool AddMemberList()
    {
        MapIter iter;


        iter = this.ClassMemberStringList.Iter();



        while (iter.Next())
        {
            Pair pair;

            pair = (Pair)iter.Value;



            string className;

            className = (string)pair.Key;



            List memberStringList;

            memberStringList = (List)pair.Value;




            Class varClass;

            varClass = (Class)this.ClassMap.Get(className);




            this.AddClassMemberList(varClass, memberStringList);
        }



        return true;
    }




    private bool AddClassMemberList(Class varClass, List memberStringList)
    {
        ListIter iter;


        iter = memberStringList.Iter();


        while (iter.Next())
        {
            string s;

            s = (string)iter.Value;



            this.AddClassMember(varClass, s);
        }


        return true;
    }





    private bool AddClassMember(Class varClass, string memberString)
    {
        int u;


        u = memberString.IndexOf('(');



        bool isMethod;

        isMethod = !(u < 0);
        


        Range nameRange;

        nameRange = new Range();

        nameRange.Init();



        int o;

        o = 0;



        if (isMethod)
        {
            o = u;
        }


        if (!isMethod)
        {
            o = memberString.Length;
        }



        nameRange.End = o;


        

        u = memberString.IndexOf(' ', 0, nameRange.End);
        

        if (u < 0)
        {
            return false;
        }




        int typeEnd;

        typeEnd = u;




        string s;


        s = memberString.Substring(0, typeEnd);





        Type resultType;


        resultType = this.Compile.GetConstantType(s);



        if (this.Null(resultType))
        {
            return false;
        }

        



        o = typeEnd + 1;



        nameRange.Start = o;





        int k;


        k = this.Range.Count(nameRange);




        string name;


        name = memberString.Substring(nameRange.Start, k);




        VarMap paramList;


        paramList = null;



        if (isMethod)
        {
            int start;

            start = nameRange.End + 1;



            int end;

            end = memberString.Length - 1;




            Range uRange;

            uRange = new Range();

            uRange.Init();

            uRange.Start = start;

            uRange.End = end;




            int count;


            count = this.Range.Count(uRange);




            string paramListString;


            paramListString = memberString.Substring(uRange.Start, count);




            paramList = this.CreateParam();





            this.AddParamListToMap(paramList, paramListString);
        }




        
        if (!isMethod)
        {
            this.AddField(varClass, resultType, name);
        }



        if (isMethod)
        {
            this.AddMethod(varClass, resultType, name, paramList);
        }



        return true;
    }




    private bool AddParamListToMap(VarMap map, string paramListString)
    {
        Range range;


        range = new Range();


        range.Init();


        range.Start = 0;



        while (range.Start < paramListString.Length)
        {
            int u;


            u = paramListString.IndexOf(',', range.Start);



            bool b;


            b = (u < 0);



            int o;

            o = 0;



            if (b)
            {
                o = paramListString.Length;
            }


            if (!b)
            {
                o = u;
            }



            range.End = o;




            int k;

            k = this.Range.Count(range);




            string s;


            s = paramListString.Substring(range.Start, k);




            this.AddParamToMap(map, s);

            


            range.Start = range.End + 2;
        }




        return true;
    }






    private bool AddParamToMap(VarMap map, string paramString)
    {
        int u;


        u = paramString.IndexOf(' ');



        if (u < 0)
        {
            return false;
        }




        int typeEnd;


        typeEnd = u;




        string typeName;


        typeName = paramString.Substring(0, typeEnd);





        Type type;


        type = this.Compile.GetConstantType(typeName);



        if (this.Null(type))
        {
            return false;
        }





        Range nameRange;


        nameRange = new Range();


        nameRange.Init();


        nameRange.Start = typeEnd + 1;



        nameRange.End = paramString.Length;




        int k;


        k = this.Range.Count(nameRange);




        string varName;


        varName = paramString.Substring(nameRange.Start, k);






        Var varVar;

        varVar = new Var();

        varVar.Init();

        varVar.Name = varName;

        varVar.Type = type;

        



        Pair pair;

        pair = new Pair();

        pair.Init();

        pair.Key = varVar.Name;

        pair.Value = varVar;




        map.Add(pair);



        return true;
    }





    private bool AddClassMethod(Class varClass, Type resultType, string name, VarMap param)
    {
        Method method;



        method = new Method();
        
        

        method.Init();



        method.Name = name;



        method.Access = this.Compile.Access.Public;



        method.Type = resultType;



        method.Param = param;



        method.Call = new VarMap();



        method.Call.Init();



        method.Parent = varClass;



        method.Index = varClass.Method.Count;





        Pair pair;


        pair = new Pair();


        pair.Key = method.Name;


        pair.Value = method;



        varClass.Method.Add(pair);




        return true;
    }






    private bool AddField(Class varClass, Type resultType, string name)
    {
        string getName;

        getName = "Get" + name;



        string setName;

        setName = "Set" + name;





        VarMap param;




        param = this.CreateParam();



        this.AddClassMethod(varClass, resultType, getName, param);




        param = this.CreateParam();



        this.AddClassMethod(varClass, resultType, setName, param);




        return true;
    }






    private VarMap CreateParam()
    {
        VarMap param;

        param = new VarMap();

        param.Init();



        VarMap ret;

        ret = param;


        return ret;
    }






    private bool AddMethod(Class varClass, Type resultType, string name, VarMap param)
    {
        this.AddClassMethod(varClass, resultType, name, param);



        return true;
    }






    private bool SetStringMap()
    {
        string[] lines;
        
        lines = File.ReadAllLines("SystemClass.txt");




        bool inClass;

        inClass = false;



        int count;

        count = lines.Length;



        int i;

        i = 0;


        while (i < count)
        {
            string line;

            line = lines[i];



            bool b;


            b = (line == "");


            if (b)
            {
                inClass = false;
            }



            if (!b)
            {
                if (!inClass)
                {
                    inClass = true;
                    
                    
                    string className;
                    
                    className = line;


                    this.AddClassString(className);
                }


                if (inClass)
                {
                    string memberString;

                    memberString = line;


                    this.AddMemberString(memberString);
                }
            }




            i = i + 1;
        }


        return true;
    }





    private bool AddClassString(string className)
    {
        List list;

        list = new List();

        list.Init();




        Pair pair;

        pair = new Pair();

        pair.Init();

        pair.Key = className;

        pair.Value = list;



        this.ClassMemberStringList.Add(pair);



        this.CurrentMemberStringList = list;



        return true;
    }





    private bool AddMemberString(string memberString)
    {
        this.CurrentMemberStringList.Add(memberString);


        return true;
    }





    private bool Null(object o)
    {
        return o == null;
    }
}