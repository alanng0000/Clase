namespace Clase.Node;





public class Compile : ClassCompile
{
    public override bool Init()
    {
        base.Init();




        this.ClaseKeywords = (Keyword)this.Keyword;




        this.ClaseErrorKinds = (ErrorKinds)this.ErrorKinds;





        return true;
    }





    protected override ClassKeyword CreateKeyword()
    {
        Keyword keywords;


        keywords = global::Clase.Infra.Keyword.Instance;
        




        ClassKeyword ret;

        ret = keywords;


        return ret;
    }






    protected override ClassErrorKinds CreateErrorKinds()
    {
        ErrorKinds errorKinds;


        errorKinds = global::Clase.Node.ErrorKinds.This;




        ClassErrorKinds ret;

        ret = errorKinds;


        return ret;
    }





    private Keyword ClaseKeyword { get; set; }




    private ErrorKinds ClaseErrorKinds { get; set; }






    protected override bool InitNodeMethodList()
    {
        base.InitNodeMethodList();





        this.SetNodeMethod(nameof(this.Class), this.ClaseClass);




        this.AddNodeMethod(nameof(this.Struct), this.Struct);




        this.AddNodeMethod(nameof(this.StructFields), this.StructFields);




        this.AddNodeMethod(nameof(this.StructField), this.StructField);





        this.AddNodeMethod(nameof(this.Delegate), this.Delegate);





        this.SetNodeMethod(nameof(this.Method), this.ClaseMethod);





        this.SetNodeMethod(nameof(this.ParamList), this.ClaseParams);




        this.SetNodeMethod(nameof(this.Param), this.ClaseParam);





        this.AddNodeMethod(nameof(this.Global), this.Global);





        this.SetNodeMethod(nameof(this.Variable), this.ClaseVariable);





        this.SetNodeMethod(nameof(this.DeclareState), this.ClaseDeclareState);





        this.AddNodeMethod(nameof(this.DelegateCallExpress), this.DelegateCallExpress);




        this.SetNodeMethod(nameof(this.CastExpress), this.ClaseCastExpress);




        this.SetNodeMethod(nameof(this.CallExpress), this.ClaseCallExpress);


        

        this.AddNodeMethod(nameof(this.SizeExpress), this.SizeExpress);





        this.AddNodeMethod(nameof(this.VariableAddressExpress), this.VariableAddressExpress);





        this.AddNodeMethod(nameof(this.MethodAddressExpress), this.MethodAddressExpress);






        return true;
    }








    private Class ClaseClass(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        Token classToken;


        classToken = this.Token(this.Keyword.Class, this.IndexRange(range.Start));



        if (this.NullToken(classToken))
        {
            return null;
        }





        Range nameRange;


        nameRange = this.ClassNameRange(this.Range(classToken.Range.End, range.End));



        if (this.NullRange(nameRange))
        {
            return null;
        }





        if (this.Zero(this.Count(this.Range(nameRange.End, range.End))))
        {
            return null;
        }






        Token leftBrace;


        leftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(nameRange.End));



        if (this.NullToken(leftBrace))
        {
            return null;
        }





        Token rightBrace;


        rightBrace = this.TokenMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));




        if (this.NullToken(rightBrace))
        {
            return null;
        }




        if (!this.Zero(this.Count(this.Range(rightBrace.Range.End, range.End))))
        {
            return null;
        }





        ClassName name;


        name = this.ClassName(nameRange);



        if (this.Null(name))
        {
            this.Error(this.ErrorKinds.NameInvalid, range);
        }





        Members members;


        members = this.Members(this.Range(leftBrace.Range.End, rightBrace.Range.Start));



        if (this.Null(name))
        {
            this.Error(this.ErrorKinds.MembersInvalid, range);
        }






        Class ret;


        ret = new Class();


        ret.Init();

        
        ret.Name = name;


        ret.Members = members;
        

        this.NodeInfo(ret, range);
        

        return ret;
    }






    protected override ClassClass Class(Range range)
    {
        return null;
    }








    protected override Member Member(Range range)
    {
        Member ret;


        ret = null;





        if (this.Null(ret))
        {
            ret = this.Struct(range);
        }




        if (this.Null(ret))
        {
            ret = this.Delegate(range);
        }




        if (this.Null(ret))
        {
            ret = this.Global(range);
        }




        if (this.Null(ret))
        {
            ret = this.ClaseMethod(range);
        }





        return ret;
    }







    private Struct Struct(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        Token structToken;


        structToken = this.Token(this.ClaseKeyword.Struct, this.IndexRange(range.Start));




        if (this.NullToken(structToken))
        {
            return null;
        }





        Range nameRange;


        nameRange = this.TypeNameRange(this.Range(structToken.Range.End, range.End));




        if (this.NullRange(nameRange))
        {
            return null;
        }





        if (this.Zero(this.Count(this.Range(nameRange.End, range.End))))
        {
            return null;
        }




        Token leftBracket;


        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(nameRange.End));



        if (this.NullToken(leftBracket))
        {
            return null;
        }




        Token rightBracket;


        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));



        if (this.NullToken(rightBracket))
        {
            return null;
        }





        if (!this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }






        TypeName name;


        name = this.TypeName(nameRange);


        if (this.Null(name))
        {
            this.Error(this.ErrorKinds.NameInvalid, range);
        }




        StructFields fields;


        fields = this.StructFields(this.Range(leftBracket.Range.End, rightBracket.Range.Start));



        if (this.Null(fields))
        {
            this.Error(this.ClaseErrorKinds.FieldsInvalid, range);
        }





        


        Struct ret;


        ret = new Struct();


        ret.Init();

        
        ret.Name = name;


        ret.Fields = fields;
        

        this.NodeInfo(ret, range);
        

        return ret;
    }









    private StructFields StructFields(Range range)
    {
        NodeList list;
        
        list = this.NodeList(this.StructField, this.TypeFieldRange, range, null);




        if (this.Null(list))
        {
            return null;
        }





        StructFields ret;


        ret = new StructFields();


        ret.Init();

        
        ret.Values = list;
        

        this.NodeInfo(ret, range);
        

        return ret;
    }







    private StructField StructField(Range range)
    {
        Range typeRange;


        typeRange = this.TypeNameRange(range);



        if (this.NullRange(typeRange))
        {
            return null;
        }





        Range nameRange;


        nameRange = this.FieldNameRange(this.Range(typeRange.End, range.End));



        if (this.NullRange(nameRange))
        {
            return null;
        }






        if (this.Zero(this.Count(this.Range(nameRange.End, range.End))))
        {
            return null;
        }







        Token semicolon;


        semicolon = this.Token(this.Delimiter.StateSign, this.IndexRange(nameRange.End));




        if (this.Null(semicolon))
        {
            return null;
        }





        if (!this.Zero(this.Count(this.Range(semicolon.Range.End, range.End))))
        {
            return null;
        }







        TypeName type;



        type = this.TypeName(typeRange);





        if (this.Null(type))
        {
            this.Error(this.ClaseErrorKinds.TypeInvalid, range);
        }







        FieldName name;



        name = this.FieldName(nameRange);





        if (this.Null(name))
        {
            this.Error(this.ErrorKinds.NameInvalid, range);
        }
        









        StructField ret;


        ret = new StructField();


        ret.Init();


        ret.Type = type;

        
        ret.Name = name;


        this.NodeInfo(ret, range);


        return ret;
    }







    private Delegate Delegate(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        Token delegateToken;


        delegateToken = this.Token(this.ClaseKeyword.Delegate, this.IndexRange(range.Start));



        if (this.NullToken(delegateToken))
        {
            return null;
        }





        Range nameRange;


        nameRange = this.TypeNameRange(this.Range(delegateToken.Range.End, range.End));




        if (this.NullRange(nameRange))
        {
            return null;
        }






        Range typeRange;


        typeRange = this.TypeNameRange(this.Range(nameRange.End, range.End));




        if (this.NullRange(typeRange))
        {
            return null;
        }




        if (this.Zero(this.Count(this.Range(typeRange.End, range.End))))
        {
            return null;
        }





        Token leftBracket;


        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(typeRange.End));



        if (this.NullToken(leftBracket))
        {
            return null;
        }





        Token rightBracket;


        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));



        if (this.NullToken(rightBracket))
        {
            return null;
        }





        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }





        Token semicolon;


        semicolon = this.Token(this.Delimiter.StateSign, this.IndexRange(rightBracket.Range.End));



        if (this.NullToken(semicolon))
        {
            return null;
        }





        if (!this.Zero(this.Count(this.Range(semicolon.Range.End, range.End))))
        {
            return null;
        }







        TypeName name;


        name = this.TypeName(nameRange);



        if (this.Null(name))
        {
            this.Error(this.ErrorKinds.NameInvalid, range);
        }




        TypeName type;


        type = this.TypeName(typeRange);




        if (this.Null(type))
        {
            this.Error(this.ClaseErrorKinds.TypeInvalid, range);
        }






        ParamList varParam;


        varParam = this.ClaseParams(this.Range(leftBracket.Range.End, rightBracket.Range.Start));




        if (this.Null(varParam))
        {
            this.Error(this.ErrorKinds.ParamsInvalid, range);
        }






        Delegate ret;
        

        ret = new Delegate();


        ret.Init();
        

        ret.Name = name;
        

        ret.Type = type;


        ret.Param = varParam;



        this.NodeInfo(ret, range);


        return ret;
    }
    










    private ParamList ClaseParams(Range range)
    {
        List list;
        


        list = this.List(this.ClaseParam, this.ClaseParamRange, range, this.Delimiter.PauseSign);




        if (this.Null(list))
        {
            return null;
        }




        ParamList ret;


        ret = new ParamList();


        ret.Init();

        
        ret.Values = list;
        

        this.NodeInfo(ret, range);

        return ret;
    }







    protected override ClassParams ParamList(Range range)
    {
        return null;
    }








    private Param ClaseParam(Range range)
    {
        Variable variable;


        variable = this.ClaseVariable(range);



        if (this.Null(variable))
        {
            return null;
        }





        Param ret;


        ret = new Param();


        ret.Init();
        
        
        ret.Variable = variable;
        
        
        this.NodeInfo(ret, range);


        return ret;
    }








    protected override ClassParam Param(Range range)
    {
        return null;
    }









    private Global Global(Range range)
    {
        Range variableRange;


        variableRange = this.ClaseVariableRange(range);




        if (this.NullRange(variableRange))
        {
            return null;
        }





        if (this.Zero(this.Count(this.Range(variableRange.End, range.End))))
        {
            return null;
        }







        Token semicolon;


        semicolon = this.Token(this.Delimiter.StateSign, this.IndexRange(variableRange.End));




        if (this.NullToken(semicolon))
        {
            return null;
        }






        if (!this.Zero(this.Count(this.Range(semicolon.Range.End, range.End))))
        {
            return null;
        }






        Variable variable;


        variable = this.ClaseVariable(variableRange);




        if (this.Null(variable))
        {
            this.Error(this.ErrorKinds.VariableInvalid, range);
        }







        Global ret;

        ret = new Global();

        ret.Init();

        ret.Variable = variable;


        this.NodeInfo(ret, range);


        return ret;
    }












    private Variable ClaseVariable(Range range)
    {
        Range typeRange;



        typeRange = this.TypeNameRange(range);





        if (this.NullRange(typeRange))
        {
            return null;
        }







        Range nameRange;



        nameRange = this.VariableNameRange(this.Range(typeRange.End, range.End));






        if (this.NullRange(nameRange))
        {
            return null;
        }







        if (!this.Zero(this.Count(this.Range(nameRange.End, range.End))))
        {
            return null;
        }









        TypeName type;



        type = this.TypeName(typeRange);





        if (this.Null(type))
        {
            this.Error(this.ClaseErrorKinds.TypeInvalid, range);
        }







        VariableName name;



        name = this.VariableName(nameRange);





        if (this.Null(name))
        {
            this.Error(this.ErrorKinds.NameInvalid, range);
        }
        









        Variable ret;


        ret = new Variable();


        ret.Init();


        ret.Type = type;

        
        ret.Name = name;


        this.NodeInfo(ret, range);


        return ret;
    }








    protected override ClassVariable Variable(Range range)
    {
        return null;
    }








    private Method ClaseMethod(Range range)
    {
        Range accessRange;



        accessRange = this.AccessRange(range);






        if (this.NullRange(accessRange))
        {
            return null;
        }







        Range typeRange;



        typeRange = this.TypeNameRange(this.Range(accessRange.End, range.End));






        if (this.NullRange(typeRange))
        {
            return null;
        }






        Range nameRange;



        nameRange = this.MethodNameRange(this.Range(typeRange.End, range.End));






        if (this.NullRange(nameRange))
        {
            return null;
        }




            


        if (this.Zero(this.Count(this.Range(nameRange.End, range.End))))
        {
            return null;
        }






        Token leftBracket;



        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(nameRange.End));




        if (this.NullToken(leftBracket))
        {
            return null;
        }





        Token rightBracket;



        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));




        if (this.NullToken(rightBracket))
        {
            return null;
        }






        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }






        Token leftBrace;



        leftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(rightBracket.Range.End));




        if (this.NullToken(leftBrace))
        {
            return null;
        }





        Token rightBrace;



        rightBrace = this.TokenMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));




        if (this.NullToken(rightBrace))
        {
            return null;
        }





        if (!this.Zero(this.Count(this.Range(rightBrace.Range.End, range.End))))
        {
            return null;
        }






        Access access;



        access = this.Access(accessRange);




        if (this.Null(access))
        {
            this.Error(this.ErrorKinds.AccessInvalid, range);
        }





        TypeName type;



        type = this.TypeName(typeRange);




        if (this.Null(type))
        {
            this.Error(this.ClaseErrorKinds.TypeInvalid, range);
        }





        MethodName name;



        name = this.MethodName(nameRange);




        if (this.Null(name))
        {
            this.Error(this.ErrorKinds.NameInvalid, range);
        }






        ParamList varParam;


        varParam = this.ClaseParams(this.Range(leftBracket.Range.End, rightBracket.Range.Start));




        if (this.Null(varParam))
        {
            this.Error(this.ErrorKinds.ParamsInvalid, range);
        }






        StateList call;


        call = this.States(this.Range(leftBrace.Range.End, rightBrace.Range.Start));




        if (this.Null(call))
        {
            this.Error(this.ErrorKinds.CallInvalid, range);
        }






        Method ret;
        

        ret = new Method();


        ret.Init();
        

        ret.Name = name;
        

        ret.Type = type;


        ret.Param = varParam;


        ret.Call = call;
        

        ret.Access = access;


        this.NodeInfo(ret, range);


        return ret;
    }









    protected override ClassField Field(Range range)
    {
        return null;
    }








    protected override ClassMethod Method(Range range)
    {
        return null;
    }








    protected override LocalAccess LocalAccess(Range range)
    {
        return null;
    }





    protected override DeriveAccess DeriveAccess(Range range)
    {
        return null;
    }











    protected override State State(Range range)
    {
        State ret;


        ret = null;





        if (this.Null(ret))
        {
            ret = this.ClaseDeclareState(range);
        }




        if (this.Null(ret))
        {
            ret = base.State(range);
        }





        return ret;
    }










    private DeclareState ClaseDeclareState(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        int lastIndex;


        lastIndex = range.End - 1;




        Token semicolon;


        semicolon = this.Token(this.Delimiter.StateSign, this.IndexRange(lastIndex));



        if (this.NullToken(semicolon))
        {
            return null;
        }




        Variable variable;
        


        variable = this.ClaseVariable(this.Range(range.Start, semicolon.Range.Start));
        



        if (this.Null(variable))
        {
            return null;
        }





        DeclareState ret;


        ret = new DeclareState();


        ret.Init();

        
        ret.Variable = variable;
        
        
        this.NodeInfo(ret, range);


        return ret;
    }








    protected override ClassDeclareState DeclareState(Range range)
    {
        return null;
    }









    protected override Express Express(Range range)
    {
        Express ret;

        ret = null;
        



        if (this.Null(ret))
        {
            ret = this.ClaseCastExpress(range);
        }




        if (this.Null(ret))
        {
            ret = this.ClaseCallExpress(range);
        }




        if (this.Null(ret))
        {
            ret = this.DelegateCallExpress(range);
        }




        if (this.Null(ret))
        {
            ret = this.SizeExpress(range);
        }





        if (this.Null(ret))
        {
            ret = this.VariableAddressExpress(range);
        }




        if (this.Null(ret))
        {
            ret = this.MethodAddressExpress(range);
        }



        
        
        if (this.Null(ret))
        {
            ret = base.Express(range);
        }



        return ret;
    }







    private CastExpress ClaseCastExpress(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }





        Token castToken;


        castToken = this.Token(this.Keyword.Cast, this.IndexRange(range.Start));




        if (this.NullToken(castToken))
        {
            return null;
        }






        Range typeRange;


        typeRange = this.TypeNameRange(this.Range(castToken.Range.End, range.End));



        if (this.NullRange(typeRange))
        {
            return null;
        }






        if (this.Zero(this.Count(this.Range(typeRange.End, range.End))))
        {
            return null;
        }





        Token leftBracket;


        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(typeRange.End));




        if (this.NullToken(leftBracket))
        {
            return null;
        }





        Token rightBracket;


        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));



        if (this.NullToken(rightBracket))
        {
            return null;
        }





        if (!this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }







        TypeName type;


        type = this.TypeName(typeRange);




        if (this.Null(type))
        {
            this.Error(this.ClaseErrorKinds.TypeInvalid, range);
        }





        Express varObject;


        varObject = this.Express(this.Range(leftBracket.Range.End, rightBracket.Range.Start));




        if (this.Null(varObject))
        {
            this.Error(this.ErrorKinds.ObjectInvalid, range);
        }






        
        CastExpress ret;

        ret = new CastExpress();

        ret.Init();
        
        ret.Type = type;
        
        ret.Object = varObject;
        

        this.NodeInfo(ret, range);
        
        return ret;
    }








    private CallExpress ClaseCallExpress(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }





        Token rightBracket;
        


        rightBracket = this.Token(this.Delimiter.RightBracket, this.IndexRange(range.End - 1));




        if (this.NullToken(rightBracket))
        {
            return null;
        }




        Token leftBracket;
        
        

        leftBracket = this.TokenMatchRightBracket(this.Range(range.Start, rightBracket.Range.Start));




        if (this.NullToken(leftBracket))
        {
            return null;
        }





        Token dot;
        


        dot = this.TokenBackward(this.Delimiter.StopSign, this.Range(range.Start, leftBracket.Range.Start));
            



        if (this.NullToken(dot))
        {
            return null;
        }





        ClassName varClass;
        
        
        
        varClass = this.ClassName(this.Range(range.Start, dot.Range.Start));
        



        if (this.Null(varClass))
        {
            this.Error(this.ErrorKinds.ClassInvalid, range);
        }

            



        MethodName method;



        method = this.MethodName(this.Range(dot.Range.End, leftBracket.Range.Start));
            



        if (this.Null(method))
        {
            this.Error(this.ErrorKinds.MethodInvalid, range);
        }

            



        ArgueList argues;



        argues = this.Argues(this.Range(leftBracket.Range.End, rightBracket.Range.Start));
            



        if (this.Null(argues))
        {
            this.Error(this.ErrorKinds.ArguesInvalid, range);
        }




        CallExpress ret;

        ret = new CallExpress();

        ret.Init();
            
        ret.Class = varClass;
            
        ret.Method = method;
            
        ret.Argue = argues;
            
        this.NodeInfo(ret, range);
            
        return ret;
    }








    private DelegateCallExpress DelegateCallExpress(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }





        Token callToken;


        callToken = this.Token(this.ClaseKeyword.Call, this.IndexRange(range.Start));





        if (this.NullToken(callToken))
        {
            return null;
        }

        



        if (this.Zero(this.Count(this.Range(callToken.Range.End, range.End))))
        {
            return null;
        }





        Range variableRange;


        variableRange = this.VariableNameRange(this.Range(callToken.Range.End, range.End));



        if (this.NullRange(variableRange))
        {
            return null;
        }




        if (this.Zero(this.Count(this.Range(variableRange.End, range.End))))
        {
            return null;
        }
    




        Token leftBracket;


        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(variableRange.End));




        if (this.NullToken(leftBracket))
        {
            return null;
        }





        Token rightBracket;


        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));



        if (this.NullToken(rightBracket))
        {
            return null;
        }





        if (!this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return null;
        }






        VariableName variable;


        variable = this.VariableName(variableRange);



        if (this.Null(variable))
        {
            this.Error(this.ErrorKinds.VariableInvalid, range);
        }



            


        ArgueList argues;



        argues = this.Argues(this.Range(leftBracket.Range.End, rightBracket.Range.Start));
            



        if (this.Null(argues))
        {
            this.Error(this.ErrorKinds.ArguesInvalid, range);
        }





        DelegateCallExpress ret;

        ret = new DelegateCallExpress();

        ret.Init();
            
        ret.Variable = variable;
            
        ret.Argue = argues;
            
        this.NodeInfo(ret, range);
            
        return ret;
    }




    





    private SizeExpress SizeExpress(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }





        Token sizeToken;


        sizeToken = this.Token(this.ClaseKeyword.Size, this.IndexRange(range.Start));




        if (this.NullToken(sizeToken))
        {
            return null;
        }







        Range typeRange;


        typeRange = this.TypeNameRange(this.Range(sizeToken.Range.End, range.End));




        if (this.NullRange(typeRange))
        {
            return null;
        }





        if (!this.Zero(this.Count(this.Range(typeRange.End, range.End))))
        {
            return null;
        }






        TypeName type;


        type = this.TypeName(typeRange);





        if (this.Null(type))
        {
            this.Error(this.ClaseErrorKinds.TypeInvalid, range);
        }








        SizeExpress ret;

        ret = new SizeExpress();

        ret.Init();

        ret.Type = type;


        this.NodeInfo(ret, range);
        
        return ret;
    }






    private VariableAddressExpress VariableAddressExpress(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }





        Token varToken;


        varToken = this.Token(this.ClaseKeyword.Var, this.IndexRange(range.Start));




        if (this.NullToken(varToken))
        {
            return null;
        }






        Range variableRange;


        variableRange = this.VariableNameRange(this.Range(varToken.Range.End, range.End));




        if (this.NullRange(variableRange))
        {
            return null;
        }





        if (!this.Zero(this.Count(this.Range(variableRange.End, range.End))))
        {
            return null;
        }






        VariableName variable;


        variable = this.VariableName(variableRange);





        if (this.Null(variable))
        {
            this.Error(this.ClaseErrorKinds.VariableInvalid, range);
        }








        VariableAddressExpress ret;

        ret = new VariableAddressExpress();

        ret.Init();

        ret.Variable = variable;


        this.NodeInfo(ret, range);
        
        return ret;
    }










    private MethodAddressExpress MethodAddressExpress(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }





        Token methodToken;


        methodToken = this.Token(this.ClaseKeyword.Method, this.IndexRange(range.Start));




        if (this.NullToken(methodToken))
        {
            return null;
        }






        Range classRange;


        classRange = this.ClassNameRange(this.Range(methodToken.Range.End, range.End));



        if (this.NullRange(classRange))
        {
            return null;
        }





        if (this.Zero(this.Count(this.Range(classRange.End, range.End))))
        {
            return null;
        }






        Token dot;


        dot = this.Token(this.Delimiter.PauseSign, this.IndexRange(classRange.End));



        if (this.NullToken(dot))
        {
            return null;
        }





        Range methodRange;


        methodRange = this.MethodNameRange(this.Range(dot.Range.End, range.End));



        if (this.NullRange(methodRange))
        {
            return null;
        }






        if (!this.Zero(this.Count(this.Range(methodRange.End, range.End))))
        {
            return null;
        }








        ClassName varClass;


        varClass = this.ClassName(classRange);





        if (this.Null(varClass))
        {
            this.Error(this.ClaseErrorKinds.ClassInvalid, range);
        }






        MethodName method;


        method = this.MethodName(methodRange);





        if (this.Null(method))
        {
            this.Error(this.ClaseErrorKinds.MethodInvalid, range);
        }








        MethodAddressExpress ret;

        ret = new MethodAddressExpress();

        ret.Init();

        ret.Class = varClass;

        ret.Method = method;


        this.NodeInfo(ret, range);
        
        return ret;
    }











    protected override NewExpress NewExpress(Range range)
    {
        return null;
    }




    protected override GlobalExpress GlobalExpress(Range range)
    {
        return null;
    }





    protected override JoinExpress JoinExpress(Range range)
    {
        return null;
    }





    protected override ClassCastExpress CastExpress(Range range)
    {
        return null;
    }





    protected override ClassCallExpress CallExpress(Range range)
    {
        return null;
    }






    protected override StringConstant StringConstant(Range range)
    {
        return null;
    }






    private TypeName TypeName(Range range)
    {
        string value;

        value = this.NameValue(range);


        if (this.Null(value))
        {
            return null;
        }


        TypeName ret;
        
        ret = new TypeName();

        ret.Init();
        
        ret.Value = value;
        
        this.NodeInfo(ret, range);

        return ret;
    }






    private Range TypeNameRange(Range range)
    {
        return this.NameRange(range);
    }





    private Range ClaseParamRange(Range range)
    {
        return this.EndAtCommaRange(range);
    }










    private Range TypeFieldRange(Range range)
    {
        Range typeRange;


        typeRange = this.TypeNameRange(range);



        if (this.NullRange(typeRange))
        {
            return this.RangeNull;
        }





        Range nameRange;


        nameRange = this.FieldNameRange(this.Range(typeRange.End, range.End));



        if (this.NullRange(nameRange))
        {
            return this.RangeNull;
        }






        if (this.Zero(this.Count(this.Range(nameRange.End, range.End))))
        {
            return this.RangeNull;
        }







        Token semicolon;


        semicolon = this.Token(this.Delimiter.StateSign, this.IndexRange(nameRange.End));




        if (this.Null(semicolon))
        {
            return this.RangeNull;
        }





        return this.Range(range.Start, semicolon.Range.End);
    }







    private Range ClaseVariableRange(Range range)
    {
        Range typeRange;


        typeRange = this.TypeNameRange(range);



        if (this.NullRange(typeRange))
        {
            return this.RangeNull;
        }




        Range nameRange;


        nameRange = this.VariableNameRange(this.Range(typeRange.End, range.End));



        if (this.NullRange(nameRange))
        {
            return this.RangeNull;
        }




        return this.Range(range.Start, nameRange.End);
    }









    protected override Range MemberRange(Range range)
    {
        Range structRange;


        structRange = this.StructRange(range);




        if (!this.NullRange(structRange))
        {
            return structRange;
        }






        Range delegateRange;


        delegateRange = this.DelegateRange(range);




        if (!this.NullRange(delegateRange))
        {
            return delegateRange;
        }







       Range globalRange;


        globalRange = this.GlobalRange(range);




        if (!this.NullRange(globalRange))
        {
            return globalRange;
        }







        Range methodRange;


        methodRange = this.ClaseMethodRange(range);




        if (!this.NullRange(methodRange))
        {
            return methodRange;
        }




        return this.RangeNull;
    }









    private Range StructRange(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return this.RangeNull;
        }




        Token structToken;


        structToken = this.Token(this.ClaseKeyword.Struct, this.IndexRange(range.Start));




        if (this.NullToken(structToken))
        {
            return this.RangeNull;
        }





        Range nameRange;


        nameRange = this.TypeNameRange(this.Range(structToken.Range.End, range.End));




        if (this.NullRange(nameRange))
        {
            return this.RangeNull;
        }





        if (this.Zero(this.Count(this.Range(nameRange.End, range.End))))
        {
            return this.RangeNull;
        }




        Token leftBracket;


        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(nameRange.End));



        if (this.NullToken(leftBracket))
        {
            return this.RangeNull;
        }




        Token rightBracket;


        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));



        if (this.NullToken(rightBracket))
        {
            return this.RangeNull;
        }





        Range t;


        t = this.Range(range.Start, rightBracket.Range.End);




        Range ret;

        ret = t;


        return ret;
    }






    private Range DelegateRange(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return this.RangeNull;
        }




        Token delegateToken;


        delegateToken = this.Token(this.ClaseKeyword.Delegate, this.IndexRange(range.Start));



        if (this.NullToken(delegateToken))
        {
            return this.RangeNull;
        }





        Range nameRange;


        nameRange = this.TypeNameRange(this.Range(delegateToken.Range.End, range.End));




        if (this.NullRange(nameRange))
        {
            return this.RangeNull;
        }






        Range typeRange;


        typeRange = this.TypeNameRange(this.Range(nameRange.End, range.End));




        if (this.NullRange(typeRange))
        {
            return this.RangeNull;
        }




        if (this.Zero(this.Count(this.Range(typeRange.End, range.End))))
        {
            return this.RangeNull;
        }





        Token leftBracket;


        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(typeRange.End));



        if (this.NullToken(leftBracket))
        {
            return this.RangeNull;
        }





        Token rightBracket;


        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));



        if (this.NullToken(rightBracket))
        {
            return this.RangeNull;
        }





        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return this.RangeNull;
        }





        Token semicolon;


        semicolon = this.Token(this.Delimiter.StateSign, this.IndexRange(rightBracket.Range.End));



        if (this.NullToken(semicolon))
        {
            return this.RangeNull;
        }





        Range t;


        t = this.Range(range.Start, semicolon.Range.End);




        Range ret;

        ret = t;


        return ret;
    }







    private Range GlobalRange(Range range)
    {
        Range variableRange;


        variableRange = this.ClaseVariableRange(range);




        if (this.NullRange(variableRange))
        {
            return this.RangeNull;
        }





        if (this.Zero(this.Count(this.Range(variableRange.End, range.End))))
        {
            return this.RangeNull;
        }







        Token semicolon;


        semicolon = this.Token(this.Delimiter.StateSign, this.IndexRange(variableRange.End));




        if (this.NullToken(semicolon))
        {
            return this.RangeNull;
        }






        Range t;


        t = this.Range(range.Start, semicolon.Range.End);





        Range ret;

        ret = t;


        return ret;
    }










    private Range ClaseMethodRange(Range range)
    {
        Range accessRange;



        accessRange = this.AccessRange(range);






        if (this.NullRange(accessRange))
        {
            return this.RangeNull;
        }







        Range typeRange;



        typeRange = this.TypeNameRange(this.Range(accessRange.End, range.End));






        if (this.NullRange(typeRange))
        {
            return this.RangeNull;
        }






        Range nameRange;



        nameRange = this.MethodNameRange(this.Range(typeRange.End, range.End));






        if (this.NullRange(nameRange))
        {
            return this.RangeNull;
        }




            


        if (this.Zero(this.Count(this.Range(nameRange.End, range.End))))
        {
            return this.RangeNull;
        }






        Token leftBracket;



        leftBracket = this.Token(this.Delimiter.LeftBracket, this.IndexRange(nameRange.End));




        if (this.NullToken(leftBracket))
        {
            return this.RangeNull;
        }





        Token rightBracket;



        rightBracket = this.TokenMatchLeftBracket(this.Range(leftBracket.Range.End, range.End));




        if (this.NullToken(rightBracket))
        {
            return this.RangeNull;
        }






        if (this.Zero(this.Count(this.Range(rightBracket.Range.End, range.End))))
        {
            return this.RangeNull;
        }






        Token leftBrace;



        leftBrace = this.Token(this.Delimiter.LeftBrace, this.IndexRange(rightBracket.Range.End));




        if (this.NullToken(leftBrace))
        {
            return this.RangeNull;
        }





        Token rightBrace;



        rightBrace = this.TokenMatchLeftBrace(this.Range(leftBrace.Range.End, range.End));




        if (this.NullToken(rightBrace))
        {
            return this.RangeNull;
        }







        Range t;

        t = this.Range(range.Start, rightBrace.Range.End);




        Range ret;

        ret = t;


        return ret;
    }



    









    protected override Range StateRange(Range range)
    {
        Range declareStateRange;


        declareStateRange = this.ClaseDeclareStateRange(range);




        if (!this.NullRange(declareStateRange))
        {
            return declareStateRange;
        }





        return base.StateRange(range);
    }








    private Range ClaseDeclareStateRange(Range range)
    {
        Range variableRange;


        variableRange = this.ClaseVariableRange(range);




        if (this.NullRange(variableRange))
        {
            return this.RangeNull;
        }





        if (this.Zero(this.Count(this.Range(variableRange.End, range.End))))
        {
            return this.RangeNull;
        }




        Token semicolon;


        semicolon = this.Token(this.Delimiter.StateSign, this.IndexRange(variableRange.End));



        if (this.NullToken(semicolon))
        {
            return this.RangeNull;
        }





        Range t;


        t = this.Range(range.Start, semicolon.Range.End);





        Range ret;


        ret = t;



        return ret;
    }




    protected override Range DeclareStateRange(Range range)
    {
        return this.RangeNull;
    }
}