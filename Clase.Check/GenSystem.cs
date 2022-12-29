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



            this.AddClassMembers(varClass, memberStringList);
        }



        return true;
    }




    private bool AddClassMembers(Class varClass, List memberStringList)
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
        


        int nameEnd;

        nameEnd = 0;



        if (isMethod)
        {
            nameEnd = u;
        }


        if (!isMethod)
        {
            nameEnd = memberString.Length;
        }


        

        u = memberString.IndexOf(' ', 0, nameEnd);
        

        if (u < 0)
        {
            return false;
        }




        int classEnd;

        classEnd = u;



        string s;

        s = memberString.Substring(0, classEnd);




        Class resultClass;


        resultClass = (Class)this.ClassMap.Get(s);
        



        int nameStart;

        nameStart = classEnd + 1;




        int nameLength;


        nameLength = nameEnd - nameStart;




        string name;


        name = memberString.Substring(nameStart, nameLength);




        VarMap paramList;


        paramList = null;


        if (isMethod)
        {
            int start;

            start = nameEnd + 1;



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




            paramList = new VarMap();

            
            paramList.Init();




            this.AddParamListToMap(paramList, paramListString);
        }




        
        if (!isMethod)
        {
            this.AddField(varClass, resultClass, name);
        }



        if (isMethod)
        {
            this.AddMethod(varClass, resultClass, name, paramList);
        }



        return true;
    }




    private bool AddParamListToMap(VarMap map, string paramListString)
    {
        int paramStart;

        paramStart = 0;



        while (paramStart < paramListString.Length)
        {
            int u;


            u = paramListString.IndexOf(',', paramStart);



            bool b;


            b = (u < 0);



            int paramEnd;

            paramEnd = 0;



            if (b)
            {
                paramEnd = paramListString.Length;
            }


            if (!b)
            {
                paramEnd = u;
            }



            int paramLength;

            paramLength = paramEnd - paramStart;




            string paramString;


            paramString = paramListString.Substring(paramStart, paramLength);




            this.AddParamToMap(map, paramString);

            

            paramStart = paramEnd + 2;

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




        int classEnd;


        classEnd = u;




        string className;


        className = paramString.Substring(0, classEnd);




        int nameStart;

        nameStart = classEnd + 1;



        int nameEnd;


        nameEnd = paramString.Length;



        int nameLength;

        nameLength = nameEnd - nameStart;




        string varName;


        varName = paramString.Substring(nameStart, nameLength);





        Type type;


        type = this.Compile.GetConstantType(className);



        if (this.Null(type))
        {
            return false;
        }





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





    private bool AddField(ClassClass parent, ClassClass varClass, string name)
    {
        Field field;


        field = this.Create.ExecuteField(Accesss.This.Public, varClass, name);


        field.Parent = parent;


        field.Index = parent.Fields.Count;





        Pair pair;


        pair = new Pair();


        pair.Key = field.Name;


        pair.Value = field;



        parent.Fields.Add(pair);



        return true;
    }





    private bool AddMethod(ClassClass parent, ClassClass varClass, string name, VariableMap varParams)
    {
        Method method;


        method = this.Create.ExecuteMethod(Accesss.This.Public, varClass, name, varParams);


        method.Parent = parent;


        method.Index = parent.Methods.Count;





        Pair pair;


        pair = new Pair();


        pair.Key = method.Name;


        pair.Value = method;



        parent.Methods.Add(pair);



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