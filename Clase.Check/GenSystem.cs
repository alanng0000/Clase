namespace Clase.Check;



class GenSystem : Object
{
    public override bool Init()
    {
        base.Init();




        this.Create = this.Compile.Create;




        this.ClassMap = this.Module.Class;




        this.BaseClass = this.ClassMap.Get("Object");




        return true;
    }






    public Compile Compile { get; set; }





    public Module Module { get; set; }




    private CreateInfra Create { get; set; }




    private Map StringMap { get; set; }



    private List CurrentMemberStrings { get; set; }




    private ClassMap ClassMap { get; set; }





    private ClassClass BaseClass { get; set; }






    public bool Execute()
    {
        StringCompare compare;


        compare = new StringCompare();


        compare.Init();




        this.StringMap = new Map();


        this.StringMap.Compare = compare;


        this.StringMap.Init();





        this.SetStringMap();




        this.SetClassMap();




        return true;
    }





    private bool SetClassMap()
    {
        this.AddClass();




        this.AddMembers();



        return true;
    }





    private bool AddClass()
    {
        MapIter iter;


        iter = this.StringMap.Iter();



        while (iter.Next())
        {
            Pair pair;

            pair = (Pair)iter.Value;



            string className;

            className = (string)pair.Key;




            ClassClass varClass;



            varClass = this.Create.ExecuteClass(className);



            varClass.Base = this.BaseClass;



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






    private bool AddMembers()
    {
        MapIter iter;


        iter = this.StringMap.Iter();



        while (iter.Next())
        {
            Pair pair;

            pair = (Pair)iter.Value;



            string className;

            className = (string)pair.Key;



            List memberStrings;

            memberStrings = (List)pair.Value;




            ClassClass varClass;

            varClass = this.ClassMap.Get(className);



            this.AddClassMembers(varClass, memberStrings);
        }



        return true;
    }




    private bool AddClassMembers(ClassClass varClass, List memberStrings)
    {
        ListIter iter;


        iter = memberStrings.Iter();


        while (iter.Next())
        {
            string s;

            s = (string)iter.Value;



            this.AddClassMember(varClass, s);
        }


        return true;
    }





    private bool AddClassMember(ClassClass varClass, string memberString)
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




        ClassClass resultClass;


        resultClass = this.ClassMap.Get(s);
        



        int nameStart;

        nameStart = classEnd + 1;




        int nameLength;


        nameLength = nameEnd - nameStart;




        string name;


        name = memberString.Substring(nameStart, nameLength);




        VariableMap varParams;


        varParams = null;


        if (isMethod)
        {
            int paramsStart;

            paramsStart = nameEnd + 1;


            int paramsEnd;

            paramsEnd = memberString.Length - 1;



            int paramsLength;

            paramsLength = paramsEnd - paramsStart;



            string paramsString;


            paramsString = memberString.Substring(paramsStart, paramsLength);



            varParams = this.Create.ExecuteVariableMap();



            this.AddParamsToMap(varParams, paramsString);
        }




        
        if (!isMethod)
        {
            this.AddField(varClass, resultClass, name);
        }



        if (isMethod)
        {
            this.AddMethod(varClass, resultClass, name, varParams);
        }



        return true;
    }




    private bool AddParamsToMap(VariableMap map, string paramsString)
    {
        int paramStart;

        paramStart = 0;



        while (paramStart < paramsString.Length)
        {
            int u;


            u = paramsString.IndexOf(',', paramStart);



            bool b;


            b = (u < 0);



            int paramEnd;

            paramEnd = 0;



            if (b)
            {
                paramEnd = paramsString.Length;
            }


            if (!b)
            {
                paramEnd = u;
            }



            int paramLength;

            paramLength = paramEnd - paramStart;




            string paramString;


            paramString = paramsString.Substring(paramStart, paramLength);




            this.AddParamToMap(map, paramString);

            

            paramStart = paramEnd + 2;

        }




        return true;
    }



    private bool AddParamToMap(VariableMap map, string paramString)
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




        string variableName;


        variableName = paramString.Substring(nameStart, nameLength);





        ClassClass varClass;


        varClass = this.ClassMap.Get(className);





        Variable variable;


        variable = this.Create.ExecuteVariable(varClass, variableName);
        





        Pair pair;

        pair = new Pair();

        pair.Key = variable.Name;

        pair.Value = variable;



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
        Pair pair;

        pair = new Pair();

        pair.Key = className;



        List list;

        list = new List();

        list.Init();


        pair.Value = list;



        this.StringMap.Add(pair);



        this.CurrentMemberStrings = list;



        return true;
    }



    private bool AddMemberString(string memberString)
    {
        this.CurrentMemberStrings.Add(memberString);


        return true;
    }




    private bool Null(object o)
    {
        return o == null;
    }
}