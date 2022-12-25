namespace Clase.Module;





class GenDeclaration : Object
{
    public Compile Compile { get; set; }



    private GenConstants Constants { get; set; }



    private GenInfra Infra { get; set; }



    private SystemModule System { get; set; }




    private Refer Refer { get; set; }




    private CheckClass ObjectClass { get; set; }




    private Map Derives { get; set; }




    private Map Indexs { get; set; }




    private Map GlobalClass { get; set; }





    private Map Strings { get; set; }





    public override bool Init()
    {
        base.Init();





        this.Constants = this.Compile.Constants;




        this.Infra = this.Compile.Infra;




        this.System = this.Compile.SystemModule;




        this.Refer = this.Compile.CheckResult.Refer;





        this.ObjectClass = this.Refer.Class.Get("Object");





        this.Derives = this.Compile.Derives;





        this.Indexs = this.Compile.Indexs;





        this.GlobalClass = this.Compile.GlobalClass;





        this.Strings = this.Compile.Strings;





        return true;
    }





    public bool Execute()
    {
        this.ExecuteIncludes();





        this.ExecuteClassClass();





        this.ExecuteClassTypeDefs();





        this.ExecuteClassStructs();





        this.ExecuteClassFunctionPointerTypes();





        this.ExecuteGlobalGlobalObjects();





        this.ExecuteGlobalStrings();





        this.ExecuteGlobalOpVars();





        this.ExecuteNew();





        this.ExecuteClaseFunctions();






        return true;
    }





    private bool ExecuteIncludes()
    {
        this.Infra.Append("#include <Infra.h>");




        this.Infra.AppendLine();





        this.Infra.AppendLine();

        



        return true;
    }










    private bool ExecuteClassTypeDefs()
    {
        MapIter iter;


        iter = this.Derives.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            CheckClass varClass;


            varClass = (CheckClass)pair.Key;



            this.ExecuteClassTypeDef(varClass);
        }




        return true;
    }









    private bool ExecuteClassTypeDef(CheckClass varClass)
    {
        this.Infra.Append(this.Constants.StructWord);



        this.Infra.Append(this.Constants.Space);



        this.Infra.AppendStructName(varClass);



        this.Infra.Append(this.Constants.Semicolon);



        this.Infra.AppendLine();





        this.Infra.Append(this.Constants.TypeDefWord);



        this.Infra.Append(this.Constants.Space);


        
        this.Infra.Append(this.Constants.StructWord);



        this.Infra.Append(this.Constants.Space);



        this.Infra.AppendStructName(varClass);



        this.Infra.Append(this.Constants.Space);



        this.Infra.AppendTypeDefName(varClass);



        this.Infra.Append(this.Constants.Semicolon);



        this.Infra.AppendLine();




        this.Infra.AppendLine();




        return true;
    }














    private bool ExecuteClassStructs()
    {
        MapIter iter;


        iter = this.Derives.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            CheckClass varClass;


            varClass = (CheckClass)pair.Key;





            this.ExecuteClassStruct(varClass);
        }
        



        return true;
    }










    private bool ExecuteClassStruct(CheckClass varClass)
    {
        if (varClass == this.ObjectClass)
        {
            this.ExecuteObjectClassStruct();



            return true;
        }





        bool b;



        b = this.Infra.SystemClass(varClass);





        CheckClass baseClass;


        baseClass = varClass.Base;






        this.Infra.Append(this.Constants.StructWord);



        this.Infra.Append(this.Constants.Space);


        
        this.Infra.AppendStructName(varClass);



        this.Infra.AppendLine();






        this.Infra.Append(this.Constants.LeftBrace);



        this.Infra.AppendLine();





        this.Infra.IncrementIndent();






        this.Infra.AppendIndent();




        this.Infra.AppendTypeDefName(baseClass);




        this.Infra.Append(this.Constants.Space);




        this.Infra.AppendStructBaseFieldName();




        this.Infra.Append(this.Constants.Semicolon);




        this.Infra.AppendLine();







        MapIter iter;


        iter = varClass.Fields.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;



            Field field;


            field = (Field)pair.Value;





            this.Infra.AppendIndent();




            this.Infra.AppendTypeName();




            this.Infra.Append(this.Constants.Space);




            this.Infra.Append(field.Name);




            this.Infra.Append(this.Constants.Semicolon);




            this.Infra.AppendLine();
        }







        if (b)
        {
            this.Infra.AppendIndent();




            this.Infra.AppendTypeName();




            this.Infra.Append(this.Constants.Space);




            this.Infra.AppendSystemClassStructInfraFieldName();




            this.Infra.Append(this.Constants.Semicolon);




            this.Infra.AppendLine();
        }








        this.Infra.DecrementIndent();





        this.Infra.Append(this.Constants.RightBrace);



        this.Infra.Append(this.Constants.Semicolon);



        this.Infra.AppendLine();



        this.Infra.AppendLine();




        return true;
    }











    private bool ExecuteObjectClassStruct()
    {
        this.Infra.Append(this.Constants.StructWord);



        this.Infra.Append(this.Constants.Space);


        
        this.Infra.AppendStructName(this.ObjectClass);



        this.Infra.AppendLine();






        this.Infra.Append(this.Constants.LeftBrace);



        this.Infra.AppendLine();





        this.Infra.IncrementIndent();






        this.Infra.AppendIndent();




        this.Infra.Append(this.Constants.IntTypeName);




        this.Infra.Append(this.Constants.Asterisk);




        this.Infra.Append(this.Constants.Space);




        this.Infra.AppendObjectClassStructClassFieldName();




        this.Infra.Append(this.Constants.Semicolon);




        this.Infra.AppendLine();







        this.Infra.DecrementIndent();





        this.Infra.Append(this.Constants.RightBrace);



        this.Infra.Append(this.Constants.Semicolon);



        this.Infra.AppendLine();



        this.Infra.AppendLine();



        return true;
    }











    private bool ExecuteClassClass()
    {
        MapIter iter;


        iter = this.Indexs.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            ClassIndex index;


            index = (ClassIndex)pair.Value;



            this.ExecuteClassClassOne(index);
        }
        



        return true;
    }










    private bool ExecuteClassClassOne(ClassIndex index)
    {
        CheckClass varClass;



        varClass = index.Class;






        int memberIndexCount;


        memberIndexCount = index.Members.Count;




        string s;


        s = memberIndexCount.ToString();







        this.Infra.Append(this.Constants.IntTypeName);




        this.Infra.Append(this.Constants.Space);





        this.Infra.AppendClassClassName(varClass);





        this.Infra.Append(this.Constants.LeftSquare);





        this.Infra.Append(s);
        




        this.Infra.Append(this.Constants.RightSquare);






        this.Infra.Append(this.Constants.Semicolon);




        this.Infra.AppendLine();








        this.Infra.AppendLine();






        return true;
    }








    private bool ExecuteClassFunctionPointerTypes()
    {
        MapIter iter;


        iter = this.Refer.Class.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            CheckClass varClass;


            varClass = (CheckClass)pair.Value;



            
            
            this.ExecuteOneClassFunctionPointerTypes(varClass);
        }
        



        return true;
    }








    private bool ExecuteOneClassFunctionPointerTypes(CheckClass varClass)
    {
        this.ExecuteFieldsFunctionPointerTypes(varClass.Fields);



        this.ExecuteMethodsFunctionPointerTypes(varClass.Methods);



        return true;
    }


    




    private bool ExecuteFieldsFunctionPointerTypes(FieldMap fields)
    {
        MapIter iter;


        iter = fields.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;



            Field field;


            field = (Field)pair.Value;




            this.ExecuteFieldFunctionPointerTypes(field);
        }



        return true;
    }





    private bool ExecuteMethodsFunctionPointerTypes(MethodMap methods)
    {
        MapIter iter;


        iter = methods.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;



            Method method;


            method = (Method)pair.Value;




            this.ExecuteMethodFunctionPointerTypes(method);
        }



        return true;
    }





    private bool ExecuteFieldFunctionPointerTypes(Field field)
    {
        this.ExecuteFieldGetFunctionPointerType(field);



        this.ExecuteFieldSetFunctionPointerType(field);



        return true;
    }






    private bool ExecuteFieldGetFunctionPointerType(Field field)
    {
        this.Infra.Append(this.Constants.TypeDefWord);



        this.Infra.Append(this.Constants.Space);


        
        this.Infra.AppendTypeName();



        this.Infra.Append(this.Constants.Space);






        this.Infra.Append(this.Constants.LeftBracket);



        this.Infra.Append(this.Constants.Asterisk);



        this.Infra.Append(this.Constants.Space);



        this.Infra.AppendFieldFunctionPointerTypeName(field, false);



        this.Infra.Append(this.Constants.RightBracket);






        this.Infra.Append(this.Constants.LeftBracket);



        this.Infra.AppendTypeName();



        this.Infra.Append(this.Constants.Space);

        

        this.Infra.Append(this.Constants.ThisVarName);



        this.Infra.Append(this.Constants.RightBracket);





        this.Infra.Append(this.Constants.Semicolon);

        


        this.Infra.AppendLine();





        this.Infra.AppendLine();




        return true;
    }






    private bool ExecuteFieldSetFunctionPointerType(Field field)
    {
        this.Infra.Append(this.Constants.TypeDefWord);



        this.Infra.Append(this.Constants.Space);


        
        this.Infra.AppendTypeName();



        this.Infra.Append(this.Constants.Space);






        this.Infra.Append(this.Constants.LeftBracket);




        this.Infra.Append(this.Constants.Asterisk);



        this.Infra.Append(this.Constants.Space);



        this.Infra.AppendFieldFunctionPointerTypeName(field, true);




        this.Infra.Append(this.Constants.RightBracket);







        this.Infra.Append(this.Constants.LeftBracket);





        this.Infra.AppendTypeName();



        this.Infra.Append(this.Constants.Space);

        

        this.Infra.Append(this.Constants.ThisVarName);




        this.Infra.Append(this.Constants.Comma);



        this.Infra.Append(this.Constants.Space);




        this.Infra.AppendTypeName();



        this.Infra.Append(this.Constants.Space);



        this.Infra.Append(this.Constants.ValueVarName);





        this.Infra.Append(this.Constants.RightBracket);





        this.Infra.Append(this.Constants.Semicolon);

        


        this.Infra.AppendLine();





        this.Infra.AppendLine();
        



        return true;
    }







    private bool ExecuteMethodFunctionPointerTypes(Method method)
    {
        this.ExecuteMethodCallFunctionPointerType(method);



        return true;
    }






    private bool ExecuteMethodCallFunctionPointerType(Method method)
    {
        this.Infra.Append(this.Constants.TypeDefWord);



        this.Infra.Append(this.Constants.Space);


        
        this.Infra.AppendTypeName();



        this.Infra.Append(this.Constants.Space);






        this.Infra.Append(this.Constants.LeftBracket);



        this.Infra.Append(this.Constants.Asterisk);



        this.Infra.Append(this.Constants.Space);



        this.Infra.AppendMethodFunctionPointerTypeName(method);



        this.Infra.Append(this.Constants.RightBracket);






        this.Infra.Append(this.Constants.LeftBracket);




        this.Infra.AppendTypeName();



        this.Infra.Append(this.Constants.Space);



        this.Infra.Append(this.Constants.ThisVarName);




        this.Infra.AppendFunctionParams(method.Params);




        this.Infra.Append(this.Constants.RightBracket);





        this.Infra.Append(this.Constants.Semicolon);

        


        this.Infra.AppendLine();





        this.Infra.AppendLine();




        return true;
    }







    private bool ExecuteGlobalGlobalObjects()
    {
        MapIter iter;


        iter = this.GlobalClass.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            CheckClass varClass;


            varClass = (CheckClass)pair.Key;





            this.Infra.AppendTypeName();



            this.Infra.Append(this.Constants.Space);



            this.Infra.AppendGlobalGlobalObjectVarName(varClass);



            this.Infra.Append(this.Constants.Semicolon);



            this.Infra.AppendLine();





            this.Infra.AppendLine();
        }




        return true;
    }







    private bool ExecuteGlobalStrings()
    {
        MapIter iter;


        iter = this.Strings.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            StringValue stringValue;


            stringValue = (StringValue)pair.Value;





            this.Infra.AppendTypeName();



            this.Infra.Append(this.Constants.Space);



            this.Infra.AppendGlobalStringVarName(stringValue.Index);



            this.Infra.Append(this.Constants.Semicolon);



            this.Infra.AppendLine();
        }




        this.Infra.AppendLine();




        return true;
    }






    private bool ExecuteGlobalOpVars()
    {
        this.Infra.AppendTypeName();



        this.Infra.Append(this.Constants.Space);



        this.Infra.AppendGlobalOpExpressLeftVarName();



        this.Infra.Append(this.Constants.Semicolon);



        this.Infra.AppendLine();






        this.Infra.AppendTypeName();



        this.Infra.Append(this.Constants.Space);



        this.Infra.AppendGlobalOpExpressRightVarName();



        this.Infra.Append(this.Constants.Semicolon);



        this.Infra.AppendLine();








        this.Infra.AppendTypeName();



        this.Infra.Append(this.Constants.Space);



        this.Infra.AppendGlobalGetSetCallThisVarName();



        this.Infra.Append(this.Constants.Semicolon);



        this.Infra.AppendLine();







        this.Infra.AppendLine();





        return true;
    }








    private bool ExecuteNew()
    {
        this.Infra.AppendNewFunctionInterface();




        this.Infra.Append(this.Constants.Semicolon);



        this.Infra.AppendLine();






        this.Infra.AppendLine();




        return true;
    }











    private bool ExecuteClaseFunctions()
    {
        this.ExecuteClaseInitFunction();



        this.ExecuteClaseMainFunction();




        this.ExecuteClaseSysMainFunction();




        return true;
    }





    private bool ExecuteClaseInitFunction()
    {
        this.Infra.AppendClaseInitFunctionInterface();




        this.Infra.Append(this.Constants.Semicolon);




        this.Infra.AppendLine();



        this.Infra.AppendLine();




        return true;
    }




    private bool ExecuteClaseMainFunction()
    {
        this.Infra.AppendClaseMainFunctionInterface();




        this.Infra.Append(this.Constants.Semicolon);




        this.Infra.AppendLine();



        this.Infra.AppendLine();




        return true;
    }





    public bool ExecuteClaseSysMainFunction()
    {
        this.Infra.AppendExportSpecifier();



        this.Infra.Append(this.Constants.Space);



        this.Infra.AppendClaseSysMainFunctionInterface();




        this.Infra.Append(this.Constants.Semicolon);




        this.Infra.AppendLine();



        this.Infra.AppendLine();



        return true;
    }
}