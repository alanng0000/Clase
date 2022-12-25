namespace Clase.Module;




class GenTraverse : Traverse
{
    private GenConstants Constants { get; set; }




    private SystemModule System { get; set; }





    private InterfaceInfra InterfaceInfra { get; set; }





    private GenInfra Infra { get; set; }





    private Map Indexs { get; set; }





    private CheckClass ObjectClass { get; set; }





    private Map Strings { get; set; }







    private TraverseGenGet GenGet { get; set; }





    private TraverseGenSet GenSet { get; set; }





    private TraverseGenCall GenCall { get; set; }







    private Field CurrentField { get; set; }






    private bool IsFieldSet { get; set; }








    public override bool Init()
    {
        base.Init();





        this.Constants = this.Compile.Constants;




        this.System = this.Compile.SystemModule;





        this.InterfaceInfra = this.Compile.InterfaceInfra;





        this.Infra = this.Compile.Infra;





        this.Indexs = this.Compile.Indexs;





        this.ObjectClass = this.Refer.Class.Get("Object");





        this.Strings = this.Compile.Strings;







        this.GenGet = new TraverseGenGet();



        this.GenGet.Compile = this.Compile;



        this.GenGet.Traverse = this;



        this.GenGet.Init();







        this.GenSet = new TraverseGenSet();



        this.GenSet.Compile = this.Compile;



        this.GenSet.Traverse = this;



        this.GenSet.Init();








        this.GenCall = new TraverseGenCall();



        this.GenCall.Compile = this.Compile;



        this.GenCall.Traverse = this;



        this.GenCall.Init();





        return true;
    }








    protected override bool ExecuteFieldGet(Field field)
    {
        CheckClass varClass;


        varClass = field.Parent;




        VariableMap fieldGet;


        fieldGet = field.Get;





        NodeField nodeField;


        nodeField = field.Node;



        

        States nodeGet;


        nodeGet = nodeField.Get;






        this.CurrentField = field;




        this.IsFieldSet = false;






        this.AppendIndent();



        
        this.Infra.AppendFieldGetFunctionInterface(field);
        



        this.AppendLine();





        this.AppendIndent();


        this.Append(this.Constants.LeftBrace);


        this.AppendLine();





        this.IncrementIndent();






        this.AppendLocalVariableDeclareStatements(fieldGet);



        this.AppendLine();




        base.ExecuteStates(nodeGet);





        this.AppendLine();





        this.Infra.AppendReturnNullState();





        this.DecrementIndent();





        this.AppendIndent();


        this.Append(this.Constants.RightBrace);


        this.AppendLine();





        this.AppendLine();


        this.AppendLine();


        this.AppendLine();






        this.IsFieldSet = false;




        this.CurrentField = null;





        return true;
    }

    






    protected override bool ExecuteFieldSet(Field field)
    {
        CheckClass varClass;


        varClass = field.Parent;




        VariableMap fieldSet;


        fieldSet = field.Set;





        NodeField nodeField;


        nodeField = field.Node;



        

        States nodeSet;


        nodeSet = nodeField.Set;






        this.CurrentField = field;




        this.IsFieldSet = true;






        this.AppendIndent();



        
        this.Infra.AppendFieldSetFunctionInterface(field);
        



        this.AppendLine();





        this.AppendIndent();


        this.Append(this.Constants.LeftBrace);


        this.AppendLine();





        this.IncrementIndent();






        this.AppendLocalVariableDeclareStatements(fieldSet);



        this.AppendLine();




        base.ExecuteStates(nodeSet);





        this.AppendLine();





        this.Infra.AppendReturnNullState();





        this.DecrementIndent();





        this.AppendIndent();


        this.Append(this.Constants.RightBrace);


        this.AppendLine();





        this.AppendLine();


        this.AppendLine();


        this.AppendLine();





        this.IsFieldSet = false;




        this.CurrentField = null;





        return true;
    }







    protected override bool ExecuteMethodCall(Method method)
    {
        CheckClass varClass;


        varClass = method.Parent;




        VariableMap varParams;


        varParams = method.Params;




        VariableMap call;


        call = method.Call;





        NodeMethod nodeMethod;


        nodeMethod = method.Node;




        States nodeCall;


        nodeCall = nodeMethod.Call;





        this.AppendIndent();



        
        this.Infra.AppendMethodFunctionInterface(method);
        



        this.AppendLine();





        this.AppendIndent();


        this.Append(this.Constants.LeftBrace);


        this.AppendLine();





        this.IncrementIndent();






        this.AppendLocalVariableDeclareStatements(call);



        this.AppendLine();
        



        base.ExecuteStates(nodeCall);




        this.AppendLine();





        this.Infra.AppendReturnNullState();





        this.DecrementIndent();





        this.AppendIndent();


        this.Append(this.Constants.RightBrace);


        this.AppendLine();





        this.AppendLine();


        this.AppendLine();


        this.AppendLine();



        return true;
    }







    public override bool ExecuteStates(States states)
    {
        if (this.Null(states))
        {
            return true;
        }



        this.IncrementIndent();




        base.ExecuteStates(states);




        this.DecrementIndent();



        return true;
    }







    public override bool ExecuteReturnState(ReturnState returnState)
    {
        if (this.Null(returnState))
        {
            return true;
        }





        bool b;


        b = false;



        if (!this.Null(this.CurrentField))
        {
            if (this.IsFieldSet)
            {
                b = true;
            }
        }





        this.AppendIndent();




        this.Append(this.Constants.ReturnWord);




        this.Append(this.Constants.Space);





        if (b)
        {
            this.Append(this.Constants.LeftBracket);






            this.Append(this.Constants.LeftBracket);





            this.Append(this.Constants.LeftBracket);



            this.Append(this.Constants.IntTypeName);



            this.Append(this.Constants.RightBracket);




            this.ExecuteExpress(returnState.Result);





            this.Append(this.Constants.RightBracket);
            




            this.Append(this.Constants.Space);



            this.Append(this.Constants.Ampersand);



            this.Append(this.Constants.Space);




            this.Append(this.Constants.NullWord);





            this.Append(this.Constants.RightBracket);
        }




        if (!b)
        {
            this.ExecuteExpress(returnState.Result);
        }





        this.Append(this.Constants.Semicolon);




        this.AppendLine();




        return true;
    }





    public override bool ExecuteIfState(IfState ifState)
    {
        if (this.Null(ifState))
        {
            return true;
        }





        this.AppendIndent();




        this.Append(this.Constants.IfWord);



        this.Append(this.Constants.Space);



        this.Append(this.Constants.LeftBracket);




        this.ExecuteExpress(ifState.Cond);




        this.Append(this.Constants.RightBracket);




        this.AppendLine();







        this.AppendIndent();




        this.Append(this.Constants.LeftBrace);




        this.AppendLine();





        this.ExecuteStates(ifState.Body);






        this.AppendIndent();




        this.Append(this.Constants.RightBrace);




        this.AppendLine();





        return true;
    }






    public override bool ExecuteWhileState(WhileState whileState)
    {
        if (this.Null(whileState))
        {
            return true;
        }





        this.AppendIndent();




        this.Append(this.Constants.WhileWord);



        this.Append(this.Constants.Space);



        this.Append(this.Constants.LeftBracket);




        this.ExecuteExpress(whileState.Cond);




        this.Append(this.Constants.RightBracket);




        this.AppendLine();







        this.AppendIndent();




        this.Append(this.Constants.LeftBrace);




        this.AppendLine();






        this.ExecuteStates(whileState.Body);






        this.AppendIndent();




        this.Append(this.Constants.RightBrace);




        this.AppendLine();





        return true;
    }









    public override bool ExecuteDeclareState(DeclareState declareState)
    {
        if (this.Null(declareState))
        {
            return true;
        }



        return true;
    }



    





    public override bool ExecuteAssignState(AssignState assignState)
    {
        if (this.Null(assignState))
        {
            return true;
        }





        Target target;



        target = assignState.Target;





        Express value;


        value = assignState.Value;






        bool b;


        b = (target is SetTarget);






        this.AppendIndent();






        if (!b)
        {
            this.ExecuteTarget(target);





            this.Append(this.Constants.Space);




            this.Append(this.Constants.EqualSign);




            this.Append(this.Constants.Space);





            this.ExecuteExpress(value);
        }




        if (b)
        {
            SetTarget setTarget;


            setTarget = (SetTarget)target;





            this.GenSet.SetTarget = setTarget;



            this.GenSet.ValueExpress = value;





            this.GenSet.Execute();
        }






        this.Append(this.Constants.Semicolon);




        this.AppendLine();

        




        return true;
    }





    public override bool ExecuteExpressState(ExpressState expressState)
    {
        if (this.Null(expressState))
        {
            return true;
        }




        this.AppendIndent();




        this.ExecuteExpress(expressState.Express);




        this.Append(this.Constants.Semicolon);




        this.AppendLine();





        return true;
    }







    public override bool ExecuteDeleteState(DeleteState deleteState)
    {
        if (this.Null(deleteState))
        {
            return true;
        }






        Express varObject;


        varObject = deleteState.Object;






        CheckClass objectClass;



        objectClass = this.Check(varObject).ExpressClass;








        this.AppendIndent();







        this.Infra.AppendClaseDeleteFunctionName();



        this.Append(this.Constants.LeftBracket);




        this.Append(this.Constants.LeftBracket);



        this.Append(this.Constants.IntTypeName);



        this.Append(this.Constants.RightBracket);




        this.ExecuteExpress(deleteState.Object);




        this.Append(this.Constants.RightBracket);
        






        this.Append(this.Constants.Semicolon);




        this.AppendLine();





        return true;
    }








    public override bool ExecuteThisExpress(ThisExpress thisExpress)
    {
        if (this.Null(thisExpress))
        {
            return true;
        }




        this.Append(this.Constants.LeftBracket);



        this.Append(this.Constants.ThisVarName);



        this.Append(this.Constants.RightBracket);




        return true;
    }







    public override bool ExecuteNewExpress(NewExpress newExpress)
    {
        if (this.Null(newExpress))
        {
            return true;
        }





        CheckClass newClass;


        newClass = this.Check(newExpress).NewClass;





        this.Infra.AppendNewCall(newClass);




        return true;
    }







    public override bool ExecuteGlobalExpress(GlobalExpress globalExpress)
    {
        if (this.Null(globalExpress))
        {
            return true;
        }






        CheckClass globalClass;



        globalClass = this.Check(globalExpress).GlobalClass;






        this.Append(this.Constants.LeftBracket);





        this.Infra.AppendGlobalGlobalObjectVarName(globalClass);





        this.Append(this.Constants.RightBracket);






        return true;
    }








    public override bool ExecuteAndExpress(AndExpress andExpress)
    {
        if (this.Null(andExpress))
        {
            return true;
        }



        this.Append(this.Constants.LeftBracket);
        
        


        this.ExecuteExpress(andExpress.Left);




        this.Append(this.Constants.Space);



        this.Append(this.Constants.Ampersand);



        this.Append(this.Constants.Space);




        this.ExecuteExpress(andExpress.Right);




        this.Append(this.Constants.RightBracket);




        return true;
    }






    public override bool ExecuteOrnExpress(OrnExpress ornExpress)
    {
        if (this.Null(ornExpress))
        {
            return true;
        }



        this.Append(this.Constants.LeftBracket);
        
        


        this.ExecuteExpress(ornExpress.Left);




        this.Append(this.Constants.Space);



        this.Append(this.Constants.VerticalBar);



        this.Append(this.Constants.Space);




        this.ExecuteExpress(ornExpress.Right);




        this.Append(this.Constants.RightBracket);




        return true;
    }







    public override bool ExecuteNotExpress(NotExpress notExpress)
    {
        if (this.Null(notExpress))
        {
            return true;
        }




        this.Append(this.Constants.LeftBracket);

        

        this.Append(this.Constants.ExclamationMark);



        this.Append(this.Constants.Space);




        this.ExecuteExpress(notExpress.Bool);




        this.Append(this.Constants.RightBracket);




        return true;
    }






    public override bool ExecuteAddExpress(AddExpress addExpress)
    {
        if (this.Null(addExpress))
        {
            return true;
        }



        this.Append(this.Constants.LeftBracket);
        
        


        this.ExecuteExpress(addExpress.Left);




        this.Append(this.Constants.Space);



        this.Append(this.Constants.AddSign);



        this.Append(this.Constants.Space);




        this.ExecuteExpress(addExpress.Right);




        this.Append(this.Constants.RightBracket);




        return true;
    }






    public override bool ExecuteSubExpress(SubExpress subExpress)
    {
        if (this.Null(subExpress))
        {
            return true;
        }



        this.Append(this.Constants.LeftBracket);
        






        this.Append(this.Constants.LeftBracket);






        this.Append(this.Constants.LeftBracket);





        this.Append(this.Constants.LeftBracket);



        this.Infra.AppendGlobalOpExpressLeftVarName();



        this.Append(this.Constants.Space);



        this.Append(this.Constants.EqualSign);



        this.Append(this.Constants.Space);
        


        this.ExecuteExpress(subExpress.Left);



        this.Append(this.Constants.RightBracket);




        this.Append(this.Constants.Space);



        this.Append(this.Constants.Ampersand);



        this.Append(this.Constants.Space);




        this.Append(this.Constants.LeftBracket);



        this.Infra.AppendGlobalOpExpressRightVarName();



        this.Append(this.Constants.Space);



        this.Append(this.Constants.EqualSign);



        this.Append(this.Constants.Space);
        


        this.ExecuteExpress(subExpress.Right);



        this.Append(this.Constants.RightBracket);





        this.Append(this.Constants.RightBracket);





        this.Append(this.Constants.Space);



        this.Append(this.Constants.Ampersand);



        this.Append(this.Constants.Space);



        this.Append(this.Constants.FalseWord);






        this.Append(this.Constants.RightBracket);







        this.Append(this.Constants.Space);



        this.Append(this.Constants.VerticalBar);



        this.Append(this.Constants.Space);






        this.Append(this.Constants.LeftBracket);





        this.Append(this.Constants.LeftBracket);



        this.Infra.AppendGlobalOpExpressLeftVarName();



        this.Append(this.Constants.Space);



        this.Append(this.Constants.LessThan);



        this.Append(this.Constants.Space);



        this.Infra.AppendGlobalOpExpressRightVarName();



        this.Append(this.Constants.RightBracket);





        this.Append(this.Constants.Space);



        this.Append(this.Constants.QuestionMark);



        this.Append(this.Constants.Space);





        this.Append(this.Constants.Zero);





        this.Append(this.Constants.Space);



        this.Append(this.Constants.Colon);



        this.Append(this.Constants.Space);






        this.Append(this.Constants.LeftBracket);



        this.Infra.AppendGlobalOpExpressLeftVarName();



        this.Append(this.Constants.Space);



        this.Append(this.Constants.Hyphen);



        this.Append(this.Constants.Space);



        this.Infra.AppendGlobalOpExpressRightVarName();



        this.Append(this.Constants.RightBracket);







        this.Append(this.Constants.RightBracket);







        this.Append(this.Constants.RightBracket);




        return true;
    }







    public override bool ExecuteMulExpress(MulExpress mulExpress)
    {
        if (this.Null(mulExpress))
        {
            return true;
        }



        this.Append(this.Constants.LeftBracket);
        
        


        this.ExecuteExpress(mulExpress.Left);




        this.Append(this.Constants.Space);



        this.Append(this.Constants.Asterisk);



        this.Append(this.Constants.Space);




        this.ExecuteExpress(mulExpress.Right);




        this.Append(this.Constants.RightBracket);




        return true;
    }






    public override bool ExecuteDivExpress(DivExpress divExpress)
    {
        if (this.Null(divExpress))
        {
            return true;
        }





        this.Append(this.Constants.LeftBracket);
        






        this.Append(this.Constants.LeftBracket);






        this.Append(this.Constants.LeftBracket);





        this.Append(this.Constants.LeftBracket);



        this.Infra.AppendGlobalOpExpressLeftVarName();



        this.Append(this.Constants.Space);



        this.Append(this.Constants.EqualSign);



        this.Append(this.Constants.Space);
        


        this.ExecuteExpress(divExpress.Left);



        this.Append(this.Constants.RightBracket);





        this.Append(this.Constants.Space);



        this.Append(this.Constants.Ampersand);



        this.Append(this.Constants.Space);





        this.Append(this.Constants.LeftBracket);



        this.Infra.AppendGlobalOpExpressRightVarName();



        this.Append(this.Constants.Space);



        this.Append(this.Constants.EqualSign);



        this.Append(this.Constants.Space);
        


        this.ExecuteExpress(divExpress.Right);



        this.Append(this.Constants.RightBracket);





        this.Append(this.Constants.RightBracket);





        this.Append(this.Constants.Space);



        this.Append(this.Constants.Ampersand);



        this.Append(this.Constants.Space);



        this.Append(this.Constants.FalseWord);






        this.Append(this.Constants.RightBracket);







        this.Append(this.Constants.Space);



        this.Append(this.Constants.VerticalBar);



        this.Append(this.Constants.Space);






        this.Append(this.Constants.LeftBracket);





        this.Append(this.Constants.LeftBracket);



        this.Infra.AppendGlobalOpExpressRightVarName();



        this.Append(this.Constants.Space);



        this.Append(this.Constants.EqualSign);



        this.Append(this.Constants.EqualSign);



        this.Append(this.Constants.Space);



        this.Append(this.Constants.Zero);



        this.Append(this.Constants.RightBracket);





        this.Append(this.Constants.Space);



        this.Append(this.Constants.QuestionMark);



        this.Append(this.Constants.Space);





        this.Append(this.Constants.Zero);





        this.Append(this.Constants.Space);



        this.Append(this.Constants.Colon);



        this.Append(this.Constants.Space);






        this.Append(this.Constants.LeftBracket);



        this.Infra.AppendGlobalOpExpressLeftVarName();



        this.Append(this.Constants.Space);



        this.Append(this.Constants.Slash);



        this.Append(this.Constants.Space);



        this.Infra.AppendGlobalOpExpressRightVarName();



        this.Append(this.Constants.RightBracket);







        this.Append(this.Constants.RightBracket);







        this.Append(this.Constants.RightBracket);







        return true;
    }






    public override bool ExecuteLessExpress(LessExpress lessExpress)
    {
        if (this.Null(lessExpress))
        {
            return true;
        }





        this.Append(this.Constants.LeftBracket);
        
        


        this.ExecuteExpress(lessExpress.Left);




        this.Append(this.Constants.Space);



        this.Append(this.Constants.LessThan);



        this.Append(this.Constants.Space);




        this.ExecuteExpress(lessExpress.Right);




        this.Append(this.Constants.RightBracket);





        return true;
    }







    public override bool ExecuteEqualExpress(EqualExpress equalExpress)
    {
        if (this.Null(equalExpress))
        {
            return true;
        }





        this.Append(this.Constants.LeftBracket);
        





        this.Append(this.Constants.LeftBracket);




        this.Append(this.Constants.LeftBracket);



        this.Append(this.Constants.IntTypeName);



        this.Append(this.Constants.RightBracket);




        this.ExecuteExpress(equalExpress.Left);



        this.Append(this.Constants.RightBracket);





        this.Append(this.Constants.Space);



        this.Append(this.Constants.EqualSign);



        this.Append(this.Constants.EqualSign);



        this.Append(this.Constants.Space);







        this.Append(this.Constants.LeftBracket);




        this.Append(this.Constants.LeftBracket);



        this.Append(this.Constants.IntTypeName);



        this.Append(this.Constants.RightBracket);




        this.ExecuteExpress(equalExpress.Right);




        this.Append(this.Constants.RightBracket);
        




        this.Append(this.Constants.RightBracket);





        return true;
    }







    public override bool ExecuteBracketExpress(BracketExpress bracketExpress)
    {
        if (this.Null(bracketExpress))
        {
            return true;
        }


        


        this.Append(this.Constants.LeftBracket);




        this.ExecuteExpress(bracketExpress.Express);




        this.Append(this.Constants.RightBracket);






        return true;
    }







    public override bool ExecuteCastExpress(CastExpress castExpress)
    {
        if (this.Null(castExpress))
        {
            return true;
        }






        CheckClass castClass;


        castClass = this.Check(castExpress).CastClass;





        if (castClass == this.System.Bool)
        {
            this.Append(this.Constants.LeftBracket);




            this.Append(this.Constants.LeftBracket);



            this.ExecuteExpress(castExpress.Subject);



            this.Append(this.Constants.Space);



            this.Append(this.Constants.EqualSign);



            this.Append(this.Constants.EqualSign);



            this.Append(this.Constants.Space);



            this.Append(this.Constants.NullWord);



            this.Append(this.Constants.RightBracket);



            this.Append(this.Constants.Space);



            this.Append(this.Constants.QuestionMark);



            this.Append(this.Constants.Space);



            this.Append(this.Constants.FalseWord);



            this.Append(this.Constants.Space);



            this.Append(this.Constants.Colon);



            this.Append(this.Constants.Space);



            this.Append(this.Constants.TrueWord);




            this.Append(this.Constants.RightBracket);




            return true;
        }






        this.Append(this.Constants.LeftBracket);






        this.ExecuteExpress(castExpress.Subject);






        this.Append(this.Constants.RightBracket);

        





        return true;
    }








    public override bool ExecuteGetExpress(GetExpress getExpress)
    {
        if (this.Null(getExpress))
        {
            return true;
        }






        this.GenGet.GetExpress = getExpress;




        this.GenGet.Execute();







        return true;
    }








    public override bool ExecuteCallExpress(CallExpress callExpress)
    {
        if (this.Null(callExpress))
        {
            return true;
        }






        this.GenCall.CallExpress = callExpress;




        this.GenCall.Execute();







        return true;
    }










    public override bool ExecuteNullExpress(NullExpress nullExpress)
    {
        if (this.Null(nullExpress))
        {
            return true;
        }



        this.Append(this.Constants.LeftBracket);



        this.Append(this.Constants.NullWord);



        this.Append(this.Constants.RightBracket);




        return true;
    }







    public override bool ExecuteVariableExpress(VariableExpress variableExpress)
    {
        if (this.Null(variableExpress))
        {
            return true;
        }





        Variable variable;


        variable = this.Check(variableExpress).Variable;





        bool b;


        b = this.ObjectFieldData(variable);

        



        this.Append(this.Constants.LeftBracket);




        if (!b)
        {
            this.Append(variable.Name);
        }


        if (b)
        {
            this.AppendObjectFieldData(this.CurrentField);
        }




        this.Append(this.Constants.RightBracket);






        return true;
    }






    public override bool ExecuteConstantExpress(ConstantExpress constantExpress)
    {
        if (this.Null(constantExpress))
        {
            return true;
        }



        this.Append(this.Constants.LeftBracket);



        this.ExecuteConstant(constantExpress.Constant);



        this.Append(this.Constants.RightBracket);




        return true;
    }








    public override bool ExecuteVariableTarget(VariableTarget variableTarget)
    {
        if (this.Null(variableTarget))
        {
            return true;
        }





        Variable variable;


        variable = this.Check(variableTarget).Variable;





        bool b;


        b = this.ObjectFieldData(variable);



        

        this.Append(this.Constants.LeftBracket);




        if (!b)
        {
            this.Append(variable.Name);
        }


        if (b)
        {
            this.AppendObjectFieldData(this.CurrentField);
        }




        this.Append(this.Constants.RightBracket);






        return true;
    }






    public override bool ExecuteSetTarget(SetTarget setTarget)
    {
        return true;
    }








    public override bool ExecuteBoolConstant(BoolConstant boolConstant)
    {
        if (this.Null(boolConstant))
        {
            return true;
        }



        bool b;

        b = boolConstant.Value;



        if (b)
        {
            this.Append(this.Constants.TrueWord);
        }



        if (!b)
        {
            this.Append(this.Constants.FalseWord);
        }




        return true;
    }





    public override bool ExecuteIntConstant(IntConstant intConstant)
    {
        if (this.Null(intConstant))
        {
            return true;
        }




        ulong o;

        o = intConstant.Value;



        string t;


        t = o.ToString();



        this.Append(t);




        return true;
    }







    public override bool ExecuteStringConstant(StringConstant stringConstant)
    {
        if (this.Null(stringConstant))
        {
            return true;
        }




        StringValue o;


        o = (StringValue)this.Strings.Get(stringConstant);




        ulong index;


        index = o.Index;





        this.Infra.AppendGlobalStringVarName(index);





        return true;
    }







    private bool ObjectFieldData(Variable variable)
    {
        bool b;

        b = false;



        bool ba;
        

        ba = this.Null(this.CurrentField);



        if (!ba)
        {
            if (variable.Name == "data")
            {
                b = true;
            }
        }


        return b;
    }






    private bool AppendObjectFieldData(Field field)
    {
        this.Append(this.Constants.LeftBracket);





        this.Append(this.Constants.LeftBracket);




        this.Infra.AppendStructPointerTypeName(field.Parent);




        this.Append(this.Constants.RightBracket);





        this.Append(this.Constants.ThisVarName);





        this.Append(this.Constants.RightBracket);





        this.Append(this.Constants.Hyphen);




        this.Append(this.Constants.GreaterThan);




        this.Append(field.Name);





        return true;
    }








    private bool AppendLocalVariableDeclareStatements(VariableMap variables)
    {
        MapIter iter;


        iter = variables.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;



            Variable variable;

            variable = (Variable)pair.Value;



            this.AppendIndent();


            this.AppendLocalVariableDeclare(variable);


            this.AppendLine();
        }



        return true;
    }





    private bool AppendLocalVariableDeclare(Variable variable)
    {
        this.Infra.AppendLocalVariableDeclare(variable.Name);



        return true;
    }














    private bool IncrementIndent()
    {
        this.Infra.IncrementIndent();


        return true;
    }




    private bool DecrementIndent()
    {
        this.Infra.DecrementIndent();


        return true;
    }




    private bool AppendIndent()
    {
        this.Infra.AppendIndent();
        


        return true;
    }





    private bool Append(string s)
    {
        this.Infra.Append(s);


        return true;
    }




    private bool AppendLine()
    {
        this.Infra.AppendLine();


        return true;
    }
}