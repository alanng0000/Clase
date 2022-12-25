namespace Clase.Module;





public class GenInfra : Object
{
    public Compile Compile { get; set; }




    private GenConstants Constants { get; set; }




    private SystemModule System { get; set; }




    private StringBuilder StringBuilder { get; set; }




    private int IndentWidth { get; set; }

    



    public override bool Init()
    {
        base.Init();




        this.Constants = this.Compile.Constants;



        this.System = this.Compile.SystemModule;



        this.StringBuilder = this.Compile.StringBuilder;



        return true;
    }






    public bool AppendTypeDefName(CheckClass varClass)
    {
        this.Append(this.Constants.Prefix);


        this.Append(this.Constants.Underscore);


        this.Append(varClass.Name);



        return true;
    }





    public bool AppendStructName(CheckClass varClass)
    {
        this.AppendTypeDefName(varClass);



        this.Append(this.Constants.Underscore);



        return true;
    }






    public bool AppendStructPointerTypeName(CheckClass varClass)
    {
        this.AppendTypeDefName(varClass);



        this.Append(this.Constants.Asterisk);



        return true;
    }






    public bool AppendStructBaseFieldName()
    {
        this.Append("Base");



        this.Append(this.Constants.Underscore);




        return true;
    }


    





    public bool AppendObjectClassStructClassFieldName()
    {
        this.Append("Class");



        return true;
    }







    public bool AppendSystemClassStructInfraFieldName()
    {
        this.Append("Infra");



        this.Append(this.Constants.Underscore);




        return true;
    }







    public bool AppendClassClassName(CheckClass varClass)
    {
        this.Append(this.Constants.Prefix);



        this.Append(this.Constants.Underscore);



        this.Append(this.Constants.Underscore);



        this.Append("Class");



        this.Append(this.Constants.Underscore);



        this.Append(varClass.Name);



        return true;
    }










    public bool IntType(CheckClass varClass)
    {
        bool ba;

        ba = (varClass == this.System.Bool);



        bool bb;

        bb = (varClass == this.System.Int);




        bool b;


        b = (ba | bb);



        bool ret;


        ret = b;


        return ret;
    }





    public bool ZeroSize(CheckClass varClass)
    {
        int fieldCount;


        fieldCount = varClass.Fields.Count;



        bool b;


        b = (fieldCount == 0);



        bool ret;


        ret = b;


        return ret;
    }





    public bool AppendTypeName()
    {
        this.Append(this.Constants.ObjectTypeName);




        return true;
    }





    public bool AppendFieldGetFunctionInterface(Field field)
    {
        CheckClass varClass;


        varClass = field.Parent;





        CheckClass resultClass;


        resultClass = field.Class;





        this.AppendTypeName();



        this.Append(this.Constants.Space);



        this.AppendFieldFunctionName(field, false);



        this.Append(this.Constants.LeftBracket);



        this.AppendTypeName();



        this.Append(this.Constants.Space);



        this.Append(this.Constants.ThisVarName);



        this.Append(this.Constants.RightBracket);



        return true;
    }





    public bool AppendFieldSetFunctionInterface(Field field)
    {
        CheckClass varClass;


        varClass = field.Parent;





        CheckClass resultClass;


        resultClass = field.Class;





        this.AppendTypeName();



        this.Append(this.Constants.Space);



        this.AppendFieldFunctionName(field, true);



        this.Append(this.Constants.LeftBracket);



        this.AppendTypeName();



        this.Append(this.Constants.Space);



        this.Append(this.Constants.ThisVarName);



        this.Append(this.Constants.Comma);



        this.Append(this.Constants.Space);



        this.AppendTypeName();



        this.Append(this.Constants.Space);



        this.Append(this.Constants.ValueVarName);



        this.Append(this.Constants.RightBracket);



        return true;
    }




    public bool AppendMethodFunctionInterface(Method method)
    {
        CheckClass varClass;


        varClass = method.Parent;




        CheckClass resultClass;


        resultClass = method.Class;




        VariableMap varParams;


        varParams = method.Params;






        this.AppendTypeName();



        this.Append(this.Constants.Space);




        this.AppendMethodFunctionName(method);




        this.Append(this.Constants.LeftBracket);



        this.AppendTypeName();


        this.Append(this.Constants.Space);


        this.Append(this.Constants.ThisVarName);



        this.AppendFunctionParams(varParams);
        


        this.Append(this.Constants.RightBracket);



        return true;
    }






    public bool AppendFunctionParams(VariableMap variables)
    {
        MapIter iter;


        iter = variables.Iter();


        while (iter.Next())
        {
            Pair pair;

            pair = (Pair)iter.Value;



            Variable variable;


            variable = (Variable)pair.Value;




            this.Append(this.Constants.Comma);


            this.Append(this.Constants.Space);



            this.AppendTypeName();


            this.Append(this.Constants.Space);


            this.Append(variable.Name);
        }




        return true;
    }





    public bool AppendFieldFunctionName(Field field, bool set)
    {
        CheckClass parent;


        parent = field.Parent;






        string t;


        t = this.Constants.FieldGetSuffix;



        if (set)
        {
            t = this.Constants.FieldSetSuffix;
        }





        this.Append(this.Constants.Prefix);



        this.Append(this.Constants.Underscore);



        this.Append(parent.Name);



        this.Append(this.Constants.Underscore);



        this.Append(field.Name);



        this.Append(this.Constants.Underscore);



        this.Append(t);




        return true;
    }






    public bool AppendFieldFunctionPointerTypeName(Field field, bool set)
    {
        this.AppendFieldFunctionName(field, set);



        this.Append(this.Constants.Underscore);



        this.Append("P");



        return true;
    }







    public bool AppendMethodFunctionName(Method method)
    {
        CheckClass parent;


        parent = method.Parent;






        this.Append(this.Constants.Prefix);



        this.Append(this.Constants.Underscore);



        this.Append(parent.Name);



        this.Append(this.Constants.Underscore);



        this.Append(method.Name);



        this.Append(this.Constants.Underscore);



        this.Append(this.Constants.MethodCallSuffix);
        



        return true;
    }






    public bool AppendInfraFieldGetFunctionName(Field field)
    {
        CheckClass parent;


        parent = field.Parent;




        string k;


        k = "Get";





        this.Append(parent.Name);



        this.Append(this.Constants.Underscore);



        this.Append(k);



        this.Append(field.Name);




        return true;
    }








    public bool AppendInfraFieldSetFunctionName(Field field)
    {
        CheckClass parent;


        parent = field.Parent;




        string k;


        k = "Set";





        this.Append(parent.Name);



        this.Append(this.Constants.Underscore);



        this.Append(k);



        this.Append(field.Name);




        return true;
    }







    public bool AppendInfraMethodCallFunctionName(Method method)
    {
        CheckClass parent;


        parent = method.Parent;





        this.Append(parent.Name);



        this.Append(this.Constants.Underscore);



        this.Append(method.Name);



        return true;
    }







    public bool AppendMethodFunctionPointerTypeName(Method method)
    {
        this.AppendMethodFunctionName(method);



        this.Append(this.Constants.Underscore);



        this.Append("P");



        return true;
    }








    public bool AppendNewCall(CheckClass varClass)
    {
        if (varClass == this.System.Bool)
        {
            this.Append(this.Constants.LeftBracket);



            this.Append(this.Constants.FalseWord);



            this.Append(this.Constants.RightBracket);




            return true;
        }





        if (varClass == this.System.Int)
        {
            this.Append(this.Constants.LeftBracket);



            this.Append(this.Constants.Zero);



            this.Append(this.Constants.RightBracket);




            return true;
        }







        this.Append(this.Constants.LeftBracket);






        this.AppendNewFunctionName();





        this.Append(this.Constants.LeftBracket);




        this.AppendClassSize(varClass);




        this.Append(this.Constants.Comma);




        this.Append(this.Constants.Space);




        this.AppendClassClassName(varClass);




        this.Append(this.Constants.RightBracket);
        






        this.Append(this.Constants.RightBracket);





        return true;
    }






    public bool AppendNewFunctionName()
    {
        this.Append(this.Constants.Prefix);



        this.Append(this.Constants.Underscore);



        this.Append(this.Constants.Underscore);



        this.Append("New");




        return true;
    }







    public bool AppendNewFunctionInterface()
    {
        this.AppendTypeName();





        this.Append(this.Constants.Space);





        this.AppendNewFunctionName();






        this.Append(this.Constants.LeftBracket);







        this.Append(this.Constants.IntTypeName);





        this.Append(this.Constants.Space);





        this.AppendNewFunctionSizeVariableName();






        this.Append(this.Constants.Comma);





        this.Append(this.Constants.Space);







        this.Append(this.Constants.IntTypeName);





        this.Append(this.Constants.Asterisk);





        this.Append(this.Constants.Space);





        this.AppendNewFunctionClassVariableName();







        this.Append(this.Constants.RightBracket);






        return true;
    }







    public bool AppendNewFunctionSizeVariableName()
    {
        this.Append("size");


        return true;
    }






    public bool AppendNewFunctionClassVariableName()
    {
        this.Append("class");


        return true;
    }








    public bool AppendLocalVariableDeclare(string variableName)
    {
        this.AppendTypeName();


        this.Append(this.Constants.Space);


        this.Append(variableName);


        this.Append(this.Constants.Space);


        this.Append(this.Constants.EqualSign);


        this.Append(this.Constants.Space);


        this.Append(this.Constants.NullWord);


        this.Append(this.Constants.Semicolon);



        return true;
    }








    public bool AppendClaseInitFunctionInterface()
    {
        this.Append(this.Constants.BoolTypeName);



        this.Append(this.Constants.Space);





        this.AppendClaseInitFunctionName();





        this.Append(this.Constants.LeftBracket);




        this.Append(this.Constants.RightBracket);


        return true;
    }





    public bool AppendClaseInitFunctionName()
    {
        this.Append(this.Constants.Prefix);



        this.Append(this.Constants.Underscore);



        this.Append(this.Constants.Underscore);



        this.Append(this.Constants.Underscore);



        this.Append("Init");



        return true;
    }





    public bool AppendClaseMainFunctionInterface()
    {
        this.Append(this.Constants.BoolTypeName);



        this.Append(this.Constants.Space);





        this.AppendClaseMainFunctionName();





        this.Append(this.Constants.LeftBracket);




        this.AppendTypeName();




        this.Append(this.Constants.Space);




        this.AppendClaseMainArgVariableName();




        this.Append(this.Constants.RightBracket);




        return true;
    }





    public bool AppendClaseMainFunctionName()
    {
        this.Append(this.Constants.Prefix);



        this.Append(this.Constants.Underscore);



        this.Append(this.Constants.Underscore);



        this.Append(this.Constants.Underscore);



        this.Append("Main");



        return true;
    }






    public bool AppendClaseMainArgVariableName()
    {
        this.Append("arg");


        return true;
    }





    public bool AppendClaseSysMainFunctionInterface()
    {
        this.Append(this.Constants.BoolTypeName);





        this.Append(this.Constants.Space);





        this.AppendClaseSysMainFunctionName();





        this.Append(this.Constants.LeftBracket);





        this.AppendTypeName();



        this.Append(this.Constants.Space);



        this.AppendClaseSysArgVariableName();





        this.Append(this.Constants.RightBracket);




        return true;
    }







    public bool AppendClaseSysMainFunctionName()
    {
        this.Append(this.Constants.Prefix);



        this.Append(this.Constants.Underscore);



        this.Append(this.Constants.Underscore);



        this.Append(this.Constants.Underscore);



        this.Append("SysMain");



        return true;
    }





    public bool AppendClaseSysArgVariableName()
    {
        this.Append("arg");


        return true;
    }







    public bool AppendExportSpecifier()
    {
        this.Append("__declspec(dllexport)");



        return true;
    }







    public bool AppendInfraNewFunctionName()
    {
        this.Append("New");


        return true;
    }






    public bool AppendClaseDeleteFunctionName()
    {
        this.Append("Delete");


        return true;
    }







    public bool AppendClassSize(CheckClass varClass)
    {
        if (this.IntType(varClass))
        {
            int size;


            size = sizeof(ulong);



            this.Append(size.ToString());



            return true;
        }





        this.Append(this.Constants.SizeOfWord);




        this.Append(this.Constants.LeftBracket);



        this.AppendTypeDefName(varClass);



        this.Append(this.Constants.RightBracket);






        return true;
    }






    public bool AppendReturnNullState()
    {
        this.AppendIndent();




        this.Append(this.Constants.ReturnWord);



        this.Append(this.Constants.Space);



        this.Append(this.Constants.NullWord);



        this.Append(this.Constants.Semicolon);



        this.AppendLine();



        return true;
    }






    public bool AppendReturnTrueState()
    {
        this.AppendIndent();




        this.Append(this.Constants.ReturnWord);



        this.Append(this.Constants.Space);



        this.Append(this.Constants.TrueWord);



        this.Append(this.Constants.Semicolon);



        this.AppendLine();



        return true;
    }

    




    public bool AppendReturnZeroState()
    {
        this.AppendIndent();




        this.Append(this.Constants.ReturnWord);



        this.Append(this.Constants.Space);



        this.Append(this.Constants.Zero);



        this.Append(this.Constants.Semicolon);



        this.AppendLine();



        return true;
    }









    public bool AppendGlobalGlobalObjectVarName(CheckClass globalClass)
    {
        this.Append(this.Constants.Prefix);



        this.Append(this.Constants.Underscore);



        this.Append(this.Constants.Underscore);



        this.Append("Global");



        this.Append(this.Constants.Underscore);



        this.Append(globalClass.Name);




        return true;
    }






    public bool AppendGlobalStringVarName(ulong index)
    {
        string s;

        s = index.ToString("x16");




        this.Append(this.Constants.Prefix);



        this.Append(this.Constants.Underscore);



        this.Append(this.Constants.Underscore);



        this.Append("String");



        this.Append(this.Constants.Underscore);



        this.Append(s);
        



        return true;
    }






    public bool AppendGlobalOpExpressLeftVarName()
    {
        this.Append(this.Constants.Prefix);



        this.Append(this.Constants.Underscore);



        this.Append(this.Constants.Underscore);



        this.Append("Op");
        


        this.Append(this.Constants.Underscore);

        
        
        this.Append("Left");



        return true;
    }





    public bool AppendGlobalOpExpressRightVarName()
    {
        this.Append(this.Constants.Prefix);



        this.Append(this.Constants.Underscore);



        this.Append(this.Constants.Underscore);



        this.Append("Op");
        


        this.Append(this.Constants.Underscore);

        
        
        this.Append("Right");



        return true;
    }








    public bool AppendGlobalGetSetCallThisVarName()
    {
        this.Append(this.Constants.Prefix);



        this.Append(this.Constants.Underscore);



        this.Append(this.Constants.Underscore);



        this.Append("This");





        return true;
    }










    public bool AppendSystemClassNewFunctionName(CheckClass varClass)
    {
        this.Append(varClass.Name);



        this.Append(this.Constants.Underscore);



        this.Append("New");



        return true;
    }





    public bool AppendSystemClassDeleteFunctionName(CheckClass varClass)
    {
        this.Append(varClass.Name);



        this.Append(this.Constants.Underscore);



        this.Append("Delete");



        return true;
    }






    public bool SystemClass(CheckClass varClass)
    {
        return this.Compile.SystemClass(varClass);
    }





    public bool ResetIndent()
    {
        this.IndentWidth = 0;


        return true;
    }




    public bool IncrementIndent()
    {
        this.IndentWidth = this.IndentWidth + 1;


        return true;
    }




    public bool DecrementIndent()
    {
        if (this.IndentWidth < 1)
        {
            return true;
        }




        this.IndentWidth = this.IndentWidth - 1;


        return true;
    }




    public bool AppendIndent()
    {
        int count;


        count = this.IndentWidth;



        int i;

        i = 0;



        while (i < count)
        {
            this.Append(this.Constants.IndentUnit);


            i = i + 1;
        }


        return true;
    }




    public bool Append(string s)
    {
        this.StringBuilder.Append(s);


        return true;
    }




    public bool AppendLine()
    {
        this.Append(this.Constants.NewLine);


        return true;
    }
}