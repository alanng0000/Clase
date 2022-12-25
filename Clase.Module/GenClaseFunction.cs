namespace Clase.Module;





class GenClaseFunction : Object
{
    public Compile Compile { get; set; }




    private GenConstants Constants { get; set; }




    private GenInfra Infra { get; set; }




    private SystemModule System { get; set; }




    private Refer Refer { get; set; }





    private CheckClass ObjectClass {get; set; }





    private Map Indexs { get; set; }





    private Map GlobalClass { get; set; }





    private Map Strings { get; set; }





    private Method EntryMethod { get; set; }





    private StringInfra StringInfra { get; set; }






    private GlobalInitGenCall GlobalInitGenCall { get; set; }




    private StringInitGenCall StringInitGenCall { get; set; }




    private StringFieldGenSet StringFieldGenSet { get; set; }




    private StringDataFieldGenSet StringDataFieldGenSet { get; set; }





    private MainInitGenCall MainInitGenCall { get; set; }





    private MainEntryGenCall MainEntryGenCall { get; set; }







    public override bool Init()
    {
        base.Init();




        this.Constants = this.Compile.Constants;



        this.Infra = this.Compile.Infra;



        this.System = this.Compile.SystemModule;



        this.Refer = this.Compile.CheckResult.Refer;




        this.ObjectClass = this.Refer.Class.Get("Object");




        this.Indexs = this.Compile.Indexs;




        this.GlobalClass = this.Compile.GlobalClass;




        this.Strings = this.Compile.Strings;





        this.EntryMethod = this.Compile.EntryMethod;





        this.StringInfra = new StringInfra();



        this.StringInfra.Init();







        this.GlobalInitGenCall = new GlobalInitGenCall();



        this.GlobalInitGenCall.Compile = this.Compile;



        this.GlobalInitGenCall.Init();






        this.StringInitGenCall = new StringInitGenCall();



        this.StringInitGenCall.Compile = this.Compile;



        this.StringInitGenCall.Init();






        this.StringFieldGenSet = new StringFieldGenSet();



        this.StringFieldGenSet.Compile = this.Compile;



        this.StringFieldGenSet.Init();






        this.StringDataFieldGenSet = new StringDataFieldGenSet();



        this.StringDataFieldGenSet.Compile = this.Compile;



        this.StringDataFieldGenSet.Init();
        







        this.MainInitGenCall = new MainInitGenCall();



        this.MainInitGenCall.Compile = this.Compile;



        this.MainInitGenCall.Init();







        this.MainEntryGenCall = new MainEntryGenCall();



        this.MainEntryGenCall.Compile = this.Compile;



        this.MainEntryGenCall.Init();








        this.MainLocalVariableName = "o";






        return true;
    }








    public bool Execute()
    {
        this.ExecuteObject();




        this.ExecuteNew();




        this.ExecuteInit();



        this.ExecuteMain();




        this.ExecuteSysMain();




        return true;
    }







    private bool ExecuteObject()
    {
        MapIter iter;
        
        
        iter = this.ObjectClass.Methods.Iter();



        while(iter.Next())
        {
            Pair pair;

            
            pair = (Pair)iter.Value;



            Method method;


            method = (Method)pair.Value;



            this.ExecuteObjectMethod(method);
        }



        this.Infra.AppendLine();



        return true;
    }




    private bool ExecuteObjectMethod(Method method)
    {
        this.Infra.AppendIndent();




        this.Infra.AppendMethodFunctionInterface(method);



        this.Infra.AppendLine();







        this.Infra.AppendIndent();


        this.Infra.Append(this.Constants.LeftBrace);


        this.Infra.AppendLine();





        this.Infra.IncrementIndent();





        this.Infra.AppendReturnTrueState();





        this.Infra.DecrementIndent();





        this.Infra.AppendIndent();


        this.Infra.Append(this.Constants.RightBrace);


        this.Infra.AppendLine();





        this.Infra.AppendLine();




        return true;
    }








    private bool ExecuteNew()
    {
        string variableName;


        variableName = "o";








        this.Infra.AppendIndent();



        this.Infra.AppendNewFunctionInterface();



        this.Infra.AppendLine();





        this.Infra.AppendIndent();


        this.Infra.Append(this.Constants.LeftBrace);


        this.Infra.AppendLine();






        this.Infra.IncrementIndent();







        this.Infra.AppendIndent();





        this.Infra.AppendLocalVariableDeclare(variableName);





        this.Infra.AppendLine();







        this.Infra.AppendLine();







        this.Infra.AppendIndent();




        this.Infra.Append(variableName);




        this.Infra.Append(this.Constants.Space);




        this.Infra.Append(this.Constants.EqualSign);




        this.Infra.Append(this.Constants.Space);





        this.Infra.AppendInfraNewFunctionName();




        this.Infra.Append(this.Constants.LeftBracket);





        this.Infra.AppendNewFunctionSizeVariableName();





        this.Infra.Append(this.Constants.RightBracket);




        this.Infra.Append(this.Constants.Semicolon);




        this.Infra.AppendLine();








        this.Infra.AppendLine();







        this.Infra.AppendIndent();





        this.Infra.Append(this.Constants.LeftBracket);




        this.Infra.Append(this.Constants.LeftBracket);




        this.Infra.AppendStructPointerTypeName(this.ObjectClass);




        this.Infra.Append(this.Constants.RightBracket);




        this.Infra.Append(variableName);




        this.Infra.Append(this.Constants.RightBracket);




        this.Infra.Append(this.Constants.Hyphen);




        this.Infra.Append(this.Constants.GreaterThan);




        this.Infra.AppendObjectClassStructClassFieldName();




        this.Infra.Append(this.Constants.Space);




        this.Infra.Append(this.Constants.EqualSign);




        this.Infra.Append(this.Constants.Space);




        this.Infra.AppendNewFunctionClassVariableName();




        this.Infra.Append(this.Constants.Semicolon);




        this.Infra.AppendLine();







        this.Infra.AppendLine();







        this.Infra.AppendIndent();




        this.Infra.Append(this.Constants.ReturnWord);




        this.Infra.Append(this.Constants.Space);




        this.Infra.Append(variableName);




        this.Infra.Append(this.Constants.Semicolon);




        this.Infra.AppendLine();









        this.Infra.DecrementIndent();





        this.Infra.AppendIndent();


        this.Infra.Append(this.Constants.RightBrace);


        this.Infra.AppendLine();





        this.Infra.AppendLine();




        return true;
    }








    private bool ExecuteInit()
    {
        this.Infra.AppendIndent();


        this.Infra.AppendClaseInitFunctionInterface();


        this.Infra.AppendLine();



        

        this.Infra.AppendIndent();


        this.Infra.Append(this.Constants.LeftBrace);


        this.Infra.AppendLine();





        this.Infra.IncrementIndent();






        this.ExecuteInitClass();




        this.ExecuteInitGlobals();




        this.ExecuteInitStrings();
        





        this.Infra.AppendReturnTrueState();






        this.Infra.DecrementIndent();





        this.Infra.AppendIndent();


        this.Infra.Append(this.Constants.RightBrace);


        this.Infra.AppendLine();





        this.Infra.AppendLine();



        return true;
    }









    private bool ExecuteInitClass()
    {
        MapIter iter;


        iter = this.Indexs.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            ClassIndex classIndex;


            classIndex = (ClassIndex)pair.Value;




            this.ExecuteInitClassIndex(classIndex);
        }





        this.Infra.AppendLine();





        return true;
    }







    private bool ExecuteInitClassIndex(ClassIndex classIndex)
    {
        CheckClass varClass;


        varClass = classIndex.Class;





        MapIter iter;


        iter = classIndex.Members.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            MemberIndex memberIndex;


            memberIndex = (MemberIndex)pair.Value;





            int u;
            
            u = memberIndex.Index;
            

            

            string indexString;


            indexString = u.ToString();








            this.Infra.AppendIndent();






            this.Infra.AppendClassClassName(varClass);




            this.Infra.Append(this.Constants.LeftSquare);




            this.Infra.Append(indexString);




            this.Infra.Append(this.Constants.RightSquare);





            this.Infra.Append(this.Constants.Space);



            this.Infra.Append(this.Constants.EqualSign);



            this.Infra.Append(this.Constants.Space);





            this.Infra.Append(this.Constants.LeftBracket);



            this.Infra.Append(this.Constants.IntTypeName);



            this.Infra.Append(this.Constants.RightBracket);




            this.GetSetCallFunctionPointer(memberIndex);





            this.Infra.Append(this.Constants.Semicolon);





            this.Infra.AppendLine();
        }






        this.Infra.AppendLine();






        return true;
    }







    private bool GetSetCallFunctionPointer(MemberIndex memberIndex)
    {
        if (memberIndex is FieldGetIndex)
        {
            FieldGetIndex fg;

            fg = (FieldGetIndex)memberIndex;




            Field field;

            field = fg.Field;
            


            this.Infra.AppendFieldFunctionName(field, false);            
        }




        if (memberIndex is FieldSetIndex)
        {
            FieldSetIndex fs;

            fs = (FieldSetIndex)memberIndex;



            Field field;

            field = fs.Field;
            


            this.Infra.AppendFieldFunctionName(field, true);
        }




        if (memberIndex is MethodCallIndex)
        {
            MethodCallIndex mc;

            mc = (MethodCallIndex)memberIndex;



            Method method;

            method = mc.Method;



            this.Infra.AppendMethodFunctionName(method);
        }




        return true;
    }






    private bool ExecuteInitGlobals()
    {
        MapIter iter;


        iter = this.GlobalClass.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            CheckClass varClass;


            varClass = (CheckClass)pair.Key;





            
            this.Infra.AppendIndent();




            this.Infra.AppendGlobalGlobalObjectVarName(varClass);



            this.Infra.Append(this.Constants.Space);



            this.Infra.Append(this.Constants.EqualSign);



            this.Infra.Append(this.Constants.Space);



            this.Infra.AppendNewCall(varClass);




            this.Infra.Append(this.Constants.Semicolon);




            this.Infra.AppendLine();







            this.Infra.AppendIndent();





            this.GlobalInitGenCall.GlobalClass = varClass;




            this.GlobalInitGenCall.Execute();





            this.Infra.Append(this.Constants.Semicolon);




            this.Infra.AppendLine();
            




            this.Infra.AppendLine();
        }




        this.Infra.AppendLine();



        return true;
    }









    private bool ExecuteInitStrings()
    {
        MapIter iter;


        iter = this.Strings.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;





            StringValue stringValue;


            stringValue = (StringValue)pair.Value;





            ulong index;


            index = stringValue.Index;




            string value;


            value = stringValue.Value;





            string lengthString;


            lengthString = value.Length.ToString();





            string escapedValue;


            escapedValue = this.StringInfra.EscapeString(value);




            string valueLiteral;
            
            
            valueLiteral = this.Constants.Quote + escapedValue + this.Constants.Quote;





            Field lengthField;


            lengthField = this.System.String.Fields.Get("Length");




            Field dataField;


            dataField = this.System.String.Fields.Get("Data");
            





            this.Infra.AppendIndent();




            this.Infra.AppendGlobalStringVarName(index);



            this.Infra.Append(this.Constants.Space);



            this.Infra.Append(this.Constants.EqualSign);



            this.Infra.Append(this.Constants.Space);



            this.Infra.AppendNewCall(this.System.String);




            this.Infra.Append(this.Constants.Semicolon);




            this.Infra.AppendLine();








            this.Infra.AppendIndent();






            this.StringInitGenCall.Index = index;




            this.StringInitGenCall.Execute();






            this.Infra.Append(this.Constants.Semicolon);




            this.Infra.AppendLine();









            this.Infra.AppendIndent();






            this.StringFieldGenSet.Index = index;



            this.StringFieldGenSet.SetField = lengthField;



            this.StringFieldGenSet.ValueString = lengthString;



            this.StringFieldGenSet.Execute();







            this.Infra.Append(this.Constants.Semicolon);




            this.Infra.AppendLine();









            this.Infra.AppendIndent();







            this.StringDataFieldGenSet.Index = index;



            this.StringDataFieldGenSet.SetField = dataField;



            this.StringDataFieldGenSet.ValueString = valueLiteral;



            this.StringDataFieldGenSet.Execute();








            this.Infra.Append(this.Constants.Semicolon);




            this.Infra.AppendLine();




            




            this.Infra.AppendLine();
        }


        




        this.Infra.AppendLine();




        return true;
    }






    private bool ExecuteMain()
    {
        bool b;


        b = (this.EntryMethod == null);





        this.Infra.AppendIndent();


        this.Infra.AppendClaseMainFunctionInterface();


        this.Infra.AppendLine();



        

        this.Infra.AppendIndent();


        this.Infra.Append(this.Constants.LeftBrace);


        this.Infra.AppendLine();





        this.Infra.IncrementIndent();




        
        if (!b)
        {
            this.ExecuteMainNew();



            this.ExecuteMainInit();



            this.ExecuteMainCall();
        }
        





        this.Infra.AppendReturnTrueState();






        this.Infra.DecrementIndent();





        this.Infra.AppendIndent();


        this.Infra.Append(this.Constants.RightBrace);


        this.Infra.AppendLine();





        this.Infra.AppendLine();



        return true;
    }





    private string MainLocalVariableName { get; set; }





    private bool ExecuteMainNew()
    {
        CheckClass varClass;



        varClass = this.EntryMethod.Parent;






        this.Infra.AppendIndent();




        this.Infra.AppendTypeName();



        this.Infra.Append(this.Constants.Space);



        this.Infra.Append(this.MainLocalVariableName);



        this.Infra.Append(this.Constants.Space);



        this.Infra.Append(this.Constants.EqualSign);



        this.Infra.Append(this.Constants.Space);





        this.Infra.AppendNewCall(varClass);





        this.Infra.Append(this.Constants.Semicolon);



        this.Infra.AppendLine();






        this.Infra.AppendLine();



        return true;
    }





    private bool ExecuteMainInit()
    {
        this.Infra.AppendIndent();




        

        this.MainInitGenCall.VariableName = this.MainLocalVariableName;




        this.MainInitGenCall.Execute();






        this.Infra.Append(this.Constants.Semicolon);




        this.Infra.AppendLine();






        this.Infra.AppendLine();





        return true;
    }





    private bool ExecuteMainCall()
    {
        this.Infra.AppendIndent();





        this.MainEntryGenCall.VariableName = this.MainLocalVariableName;




        this.MainEntryGenCall.EntryMethod = this.EntryMethod;




        this.MainEntryGenCall.Execute();






        this.Infra.Append(this.Constants.Semicolon);




        this.Infra.AppendLine();




        this.Infra.AppendLine();




        return true;
    }






    private bool ExecuteSysMain()
    {
        this.Infra.AppendIndent();




        this.Infra.AppendClaseSysMainFunctionInterface();



        this.Infra.AppendLine();





        this.Infra.AppendIndent();


        this.Infra.Append(this.Constants.LeftBrace);


        this.Infra.AppendLine();





        this.Infra.IncrementIndent();




        
        

        this.ExecuteSysMainCallInit();



        this.ExecuteSysMainCallMain();
        






        this.Infra.AppendReturnTrueState();






        this.Infra.DecrementIndent();





        this.Infra.AppendIndent();


        this.Infra.Append(this.Constants.RightBrace);


        this.Infra.AppendLine();





        this.Infra.AppendLine();






        return true;
    }









    private bool ExecuteSysMainCallInit()
    {
        this.Infra.AppendIndent();




        this.Infra.AppendClaseInitFunctionName();




        this.Infra.Append(this.Constants.LeftBracket);



        this.Infra.Append(this.Constants.RightBracket);




        this.Infra.Append(this.Constants.Semicolon);



        this.Infra.AppendLine();




        this.Infra.AppendLine();



        return true;
    }





    private bool ExecuteSysMainCallMain()
    {
        this.Infra.AppendIndent();




        this.Infra.AppendClaseMainFunctionName();




        this.Infra.Append(this.Constants.LeftBracket);




        this.Infra.AppendClaseSysArgVariableName();




        this.Infra.Append(this.Constants.RightBracket);




        this.Infra.Append(this.Constants.Semicolon);



        this.Infra.AppendLine();




        this.Infra.AppendLine();



        return true;
    }
}