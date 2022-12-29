namespace Clase.Check;






public class StateTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();




        this.InitNullClass();




        this.VarStack = new VarStack();



        this.VarStack.Init();





        this.Constant = this.Compile.ConstantType;





        return true;
    }






    private bool InitNullClass()
    {
        Type a;


        a = new Type();


        a.Init();


        a.Name = null;




        this.NullType = a;




        return true;
    }





    public Type NullType { get; set; }




    public Class CurrentClass { get; set; }




    public Type CurrentResultType { get; set; }





    private bool IsFieldSet { get; set; }





    public ConstantType Constant { get; set; }





    public VarMap Vars { get; set; }





    public VarMap StateVars { get; set; }




        
    public VarStack VarStack { get; set; }






    public override bool ExecuteClass(NodeClass varClass)
    {
        if (this.Null(varClass))
        {
            return true;
        }





        this.CurrentClass = this.Check(varClass).Class;




        if (this.Null(this.CurrentClass))
        {
            return true;
        }





        base.ExecuteClass(varClass);




        return true;
    }







        

    public override bool ExecuteClaseMethod(NodeMethod nodeMethod)
    {
        if (this.Null(nodeMethod))
        {
            return true;
        }





        ParamList paramList;


        paramList = nodeMethod.Param;





        StateList call;


        call = nodeMethod.Call;






        Method method;


        method = this.Check(nodeMethod).Method;




        if (this.Null(method))
        {
            return true;
        }





        this.CurrentResultType = method.Type;





        this.StateVars = method.Call;





        VarMap f;



        f = new VarMap();



        f.Init();




        this.Vars = f;
        





        VarMap o;



        o = new VarMap();



        o.Init();





        this.VarMapMapAdd(o, method.Param);




        
        this.VarMapMapAdd(this.Vars, o);







        this.VarStack.Push(o);





        this.ExecuteStateList(call);





        this.VarStack.Pop();





        this.Vars = null;





        this.StateVars = null;





        this.CurrentResultType = null;





        return true;
    }





    public override bool ExecuteClaseVar(NodeVar nodeVar)
    {
        if (this.Null(nodeVar))
        {
            return true;
        }





        VarName name;

        name = nodeVar.Name;




        TypeName nodeType;

        nodeType = nodeVar.Type;
            




        string varName;


        varName = name.Value;
            




        string typeName;


        typeName = nodeType.Value;






        if (!this.Null(this.Vars.Get(varName)))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeVar);


            return true;
        }





        Type varType;


        varType = this.Type(this.CurrentClass, typeName);

        


        if (this.Null(varType))
        {
            this.Error(this.ClaseErrorKind.TypeUndefined, nodeVar);


            return true;
        }





        Var varVar;


        varVar = new Var();


        varVar.Init();


        varVar.Name = varName;


        varVar.Type = varType;


        varVar.Node = nodeVar;





        this.VarMapAdd(this.Vars, varVar);





        this.VarMapAdd(this.VarStack.Top, varVar);





        this.VarMapAdd(this.StateVars, varVar);
        




        this.Check(nodeVar).Var = varVar;




        return true;
    }





    public override bool ExecuteStateList(StateList stateList)
    {
        if (this.Null(stateList))
        {
            return true;
        }





        VarMap vars;




        vars = new VarMap();




        vars.Init();





        this.VarStack.Push(vars);




        base.ExecuteStateList(stateList);




        this.VarStack.Pop();




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





        base.ExecuteAssignState(assignState);




        Type targetType;


        targetType = null;


        if (!this.Null(target))
        {
            targetType = this.Check(target).TargetType;
        }




        Type valueType;


        valueType = null;


        if (!this.Null(value))
        {
            valueType = this.Check(value).ExpressType;
        }




        if (this.Null(targetType))
        {
            this.Error(this.ErrorKind.TargetUndefined, assignState);
        }



        if (this.Null(valueType))
        {
            this.Error(this.ErrorKind.ValueUndefined, assignState);
        }





        if (!this.Null(targetType) & !this.Null(valueType))
        {
            if (!this.CheckType(valueType, targetType))
            {
                this.Error(this.ErrorKind.ValueUnassignable, assignState);
            }
        }






        return true;
    }










    public override bool ExecuteBracketExpress(BracketExpress bracketExpress)
    {
        if (this.Null(bracketExpress))
        {
            return true;
        }





        Express express;

        express = bracketExpress.Express;





        base.ExecuteBracketExpress(bracketExpress);





        Type expressType;

        expressType = null;



        if (!this.Null(express))
        {
            expressType = this.Check(express).ExpressType;
        }



            

        this.Check(bracketExpress).ExpressType = expressType;




        return true;
    }







    public override bool ExecuteAndExpress(AndExpress andExpress)
    {
        if (this.Null(andExpress))
        {
            return true;
        }





        Express left;
            
        left = andExpress.Left;



        Express right;
            
        right = andExpress.Right;





        base.ExecuteAndExpress(andExpress);






        Type leftType;

        leftType = null;




        if (!this.Null(left))
        {
            leftType = this.Check(left).ExpressType;
        }





        Type rightType;

        rightType = null;




        if (!this.Null(right))
        {
            rightType = this.Check(right).ExpressType;
        }






        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, andExpress, ref hasOperandUndefined);
        }




        if (!this.Null(leftType))
        {
            if (!this.CheckType(leftType, this.Constant.Bool))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, andExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, andExpress, ref hasOperandUndefined);
        }




        if (!this.Null(rightType))
        {
            if (!this.CheckType(rightType, this.Constant.Bool))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, andExpress, ref hasOperandUnassignable);
            }
        }




        this.Check(andExpress).ExpressType = this.Constant.Bool;




        return true;
    }
    




    public override bool ExecuteOrnExpress(OrnExpress ornExpress)
    {
        if (this.Null(ornExpress))
        {
            return true;
        }





        Express left;

        left = ornExpress.Left;



        Express right;

        right = ornExpress.Right;





        base.ExecuteOrnExpress(ornExpress);





        Type leftType;

        leftType = null;



        if (!this.Null(left))
        {
            leftType = this.Check(left).ExpressType;
        }



        Type rightType;

        rightType = null;



        if (!this.Null(right))
        {
            rightType = this.Check(right).ExpressType;
        }





        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, ornExpress, ref hasOperandUndefined);
        }




        if (!this.Null(leftType))
        {
            if (!this.CheckType(leftType, this.Constant.Bool))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, ornExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, ornExpress, ref hasOperandUndefined);
        }




        if (!this.Null(rightType))
        {
            if (!this.CheckType(rightType, this.Constant.Bool))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, ornExpress, ref hasOperandUnassignable);
            }
        }




        this.Check(ornExpress).ExpressType = this.Constant.Bool;




        return true;
    }





    public override bool ExecuteNotExpress(NotExpress notExpress)
    {
        if (this.Null(notExpress))
        {
            return true;
        }





        Express nodeBool;

        nodeBool = notExpress.Bool;





        base.ExecuteNotExpress(notExpress);





        Type boolType;

        boolType = null;



        if (!this.Null(nodeBool))
        {
            boolType = this.Check(nodeBool).ExpressType;
        }





        if (this.Null(boolType))
        {
            this.Error(this.ErrorKind.OperandUndefined, notExpress);
        }




        if (!this.Null(boolType))
        {
            if (!this.CheckType(boolType, this.Constant.Bool))
            {
                this.Error(this.ErrorKind.OperandUnassignable, notExpress);
            }
        }


            

        this.Check(notExpress).ExpressType = this.Constant.Bool;




        return true;
    }






    public override bool ExecuteAddExpress(AddExpress addExpress)
    {
        if (this.Null(addExpress))
        {
            return true;
        }





        Express left;

        left = addExpress.Left;



        Express right;

        right = addExpress.Right;





        base.ExecuteAddExpress(addExpress);





        Type leftType;

        leftType = null;



        if (!this.Null(left))
        {
            leftType = this.Check(left).ExpressType;
        }



        Type rightType;

        rightType = null;



        if (!this.Null(right))
        {
            rightType = this.Check(right).ExpressType;
        }





        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, addExpress, ref hasOperandUndefined);
        }




        if (!this.Null(leftType))
        {
            if (!this.CheckType(leftType, this.Constant.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, addExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, addExpress, ref hasOperandUndefined);
        }




        if (!this.Null(rightType))
        {
            if (!this.CheckType(rightType, this.Constant.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, addExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(addExpress).ExpressType = this.Constant.Int;




        return true;
    }






    public override bool ExecuteSubExpress(SubExpress subExpress)
    {
        if (this.Null(subExpress))
        {
            return true;
        }





        Express left;

        left = subExpress.Left;



        Express right;

        right = subExpress.Right;





        base.ExecuteSubExpress(subExpress);





        Type leftType;

        leftType = null;



        if (!this.Null(left))
        {
            leftType = this.Check(left).ExpressType;
        }



        Type rightType;

        rightType = null;



        if (!this.Null(right))
        {
            rightType = this.Check(right).ExpressType;
        }





        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, subExpress, ref hasOperandUndefined);
        }




        if (!this.Null(leftType))
        {
            if (!this.CheckType(leftType, this.Constant.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, subExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, subExpress, ref hasOperandUndefined);
        }




        if (!this.Null(rightType))
        {
            if (!this.CheckType(rightType, this.Constant.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, subExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(subExpress).ExpressType = this.Constant.Int;




        return true;
    }





    public override bool ExecuteMulExpress(MulExpress mulExpress)
    {
        if (this.Null(mulExpress))
        {
            return true;
        }





        Express left;

        left = mulExpress.Left;



        Express right;

        right = mulExpress.Right;





        base.ExecuteMulExpress(mulExpress);





        Type leftType;

        leftType = null;



        if (!this.Null(left))
        {
            leftType = this.Check(left).ExpressType;
        }



        Type rightType;

        rightType = null;



        if (!this.Null(right))
        {
            rightType = this.Check(right).ExpressType;
        }





        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, mulExpress, ref hasOperandUndefined);
        }




        if (!this.Null(leftType))
        {
            if (!this.CheckType(leftType, this.Constant.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, mulExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, mulExpress, ref hasOperandUndefined);
        }




        if (!this.Null(rightType))
        {
            if (!this.CheckType(rightType, this.Constant.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, mulExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(mulExpress).ExpressType = this.Constant.Int;




        return true;
    }





    public override bool ExecuteDivExpress(DivExpress divExpress)
    {
        if (this.Null(divExpress))
        {
            return true;
        }





        Express left;

        left = divExpress.Left;



        Express right;

        right = divExpress.Right;





        base.ExecuteDivExpress(divExpress);





        Type leftType;

        leftType = null;



        if (! this.Null(left))
        {
            leftType = this.Check(left).ExpressType;
        }



        Type rightType;

        rightType = null;



        if (! this.Null(right))
        {
            rightType = this.Check(right).ExpressType;
        }





        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, divExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftType))
        {
            if (! this.CheckType(leftType, this.Constant.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, divExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, divExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightType))
        {
            if (! this.CheckType(rightType, this.Constant.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, divExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(divExpress).ExpressType = this.Constant.Int;




        return true;
    }





    public override bool ExecuteEqualExpress(EqualExpress equalExpress)
    {
        if (this.Null(equalExpress))
        {
            return true;
        }





        Express left;

        left = equalExpress.Left;




        Express right;

        right = equalExpress.Right;




        base.ExecuteEqualExpress(equalExpress);





        Type leftType;

        leftType = null;



        if (! this.Null(left))
        {
            leftType = this.Check(left).ExpressType;
        }




        Type rightType;

        rightType = null;



        if (! this.Null(right))
        {
            rightType = this.Check(right).ExpressType;
        }







        bool hasOperandUndefined;



        hasOperandUndefined = false;





        if (this.Null(leftType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, equalExpress, ref hasOperandUndefined);
        }





        if (this.Null(rightType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, equalExpress, ref hasOperandUndefined);
        }



        


        this.Check(equalExpress).ExpressType = this.Constant.Bool;




        return true;
    }





    public override bool ExecuteLessExpress(LessExpress lessExpress)
    {
        if (this.Null(lessExpress))
        {
            return true;
        }





        Express left;

        left = lessExpress.Left;



        Express right;

        right = lessExpress.Right;





        base.ExecuteLessExpress(lessExpress);





        Type leftType;

        leftType = null;



        if (! this.Null(left))
        {
            leftType = this.Check(left).ExpressType;
        }



        Type rightType;

        rightType = null;



        if (! this.Null(right))
        {
            rightType = this.Check(right).ExpressType;
        }






        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (this.Null(leftType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, lessExpress, ref hasOperandUndefined);
        }




        if (! this.Null(leftType))
        {
            if (! this.CheckType(leftType, this.Constant.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, lessExpress, ref hasOperandUnassignable);
            }
        }





        if (this.Null(rightType))
        {
            this.UniqueError(this.ErrorKind.OperandUndefined, lessExpress, ref hasOperandUndefined);
        }




        if (! this.Null(rightType))
        {
            if (! this.CheckType(rightType, this.Constant.Int))
            {
                this.UniqueError(this.ErrorKind.OperandUnassignable, lessExpress, ref hasOperandUnassignable);
            }
        }





        this.Check(lessExpress).ExpressType = this.Constant.Bool;




        return true;
    }








    public override bool ExecuteGetExpress(GetExpress getExpress)
    {
        if (this.Null(getExpress))
        {
            return true;
        }





        Express varThis;

        varThis = getExpress.This;




        FieldName nodeField;

        nodeField = getExpress.Field;





        base.ExecuteGetExpress(getExpress);





        Class thisClass;


        thisClass = null;



        if (! this.Null(varThis))
        {
            thisClass = this.Check(varThis).ExpressType;
        }




        string fieldName;


        fieldName = null;



        if (! this.Null(nodeField))
        {
            fieldName = nodeField.Value;
        }




        if (this.Null(thisClass))
        {
            this.Error(this.ErrorKind.ThisUndefined, getExpress);
        }





        Field field;


        field = null;




        if (! this.Null(thisClass))
        {
            if (! this.Null(fieldName))
            {
                field = this.Field(thisClass, fieldName);
            }



            if (this.Null(field))
            {
                this.Error(this.ErrorKind.FieldUndefined, getExpress);
            }
        }





        Class expressClass;


        expressClass = null;




        if (! this.Null(field))
        {
            expressClass = field.Class;
        }




        this.Check(getExpress).GetField = field;



        this.Check(getExpress).ExpressType = expressClass;




        return true;
    }




    public override bool ExecuteCallExpress(CallExpress callExpress)
    {
        if (this.Null(callExpress))
        {
            return true;
        }





        Express varThis;

        varThis = callExpress.This;




        MethodName nodeMethod;

        nodeMethod = callExpress.Method;




        ArgueList argueList;

        argueList = callExpress.Argue;





        base.ExecuteCallExpress(callExpress);





        Class thisClass;


        thisClass = null;


            
        if (! this.Null(varThis))
        {
            thisClass = this.Check(varThis).ExpressType;
        }




        string methodName;


        methodName = null;



        if (! this.Null(nodeMethod))
        {
            methodName = nodeMethod.Value;
        }




        if (this.Null(thisClass))
        {
            this.Error(this.ErrorKind.ThisUndefined, callExpress);
        }





        Method method;


        method = null;




        if (! this.Null(thisClass))
        {
            if (! this.Null(methodName))
            {
                method = this.Method(thisClass, methodName);
            }



            if (this.Null(method))
            {
                this.Error(this.ErrorKind.MethodUndefined, callExpress);
            }
        }






        if (!this.Null(method))
        {
            if (!this.ArgueListMatch(method, argueList))
            {
                this.Error(this.ErrorKind.ArgueUnassignable, callExpress);
            }
        }





        Class expressClass;


        expressClass = null;




        if (! this.Null(method))
        {
            expressClass = method.Class;
        }




        this.Check(callExpress).CallMethod = method;



        this.Check(callExpress).ExpressType = expressClass;




        return true;
    }








    public override bool ExecuteClaseCastExpress(CastExpress castExpress)
    {
        if (this.Null(castExpress))
        {
            return true;
        }






        ClassName nodeClass;

        nodeClass = castExpress.Class;




        Express nodeObject;

        nodeObject = castExpress.Object;







        base.ExecuteCastExpress(castExpress);





        Class objectClass;


        objectClass = null;



        if (! this.Null(nodeObject))
        {
            objectClass = this.Check(nodeObject).ExpressType;
        }



        if (this.Null(objectClass))
        {
            this.Error(this.ErrorKind.ObjectUndefined, castExpress);
        }




        string className;

        className = null;



        if (! this.Null(nodeClass))
        {
            className = nodeClass.Value;
        }




        Class varClass;

        varClass = null;


        if (! this.Null(className))
        {
            varClass = this.Class(className);
        }



        if (this.Null(varClass))
        {
            this.Error(this.ErrorKind.ClassUndefined, castExpress);
        }





        this.Check(castExpress).CastClass = varClass;



        this.Check(castExpress).ExpressType = varClass;




        return true;
    }





    public override bool ExecuteIfState(IfState ifState)
    {
        if (this.Null(ifState))
        {
            return true;
        }




        Express cond;
            
        cond = ifState.Cond;



        StateList then;
        
        then = ifState.Then;





        base.ExecuteIfState(ifState);





        Class condClass;


        condClass = null;



        if (!this.Null(cond))
        {
            condClass = this.Check(cond).ExpressType;
        }





        if (this.Null(condClass))
        {
            this.Error(this.ErrorKind.CondUndefined, ifState);
        }





        if (!this.Null(condClass))
        {
            if (!this.CheckType(condClass, this.Constant.Bool))
            {
                this.Error(this.ErrorKind.CondUnassignable, ifState);
            }
        }






        return true;
    }





    public override bool ExecuteWhileState(WhileState whileState)
    {
        if (this.Null(whileState))
        {
            return true;
        }





        Express cond;

        cond = whileState.Cond;



        StateList loop;

        loop = whileState.Loop;





        base.ExecuteWhileState(whileState);





        Class condClass;


        condClass = null;



        if (!this.Null(cond))
        {
            condClass = this.Check(cond).ExpressType;
        }





        if (this.Null(condClass))
        {
            this.Error(this.ErrorKind.CondUndefined, whileState);
        }





        if (!this.Null(condClass))
        {
            if (!this.CheckType(condClass, this.Constant.Bool))
            {
                this.Error(this.ErrorKind.CondUnassignable, whileState);
            }
        }






        return true;
    }






    public override bool ExecuteReturnState(ReturnState returnState)
    {
        if (this.Null(returnState))
        {
            return true;
        }





        Express result;
            
        result = returnState.Result;





        base.ExecuteReturnState(returnState);




            
        Class resultClass;


        resultClass = null;




        if (! this.Null(result))
        {
            resultClass = this.Check(result).ExpressType;
        }




        
        
        if (this.Null(resultClass))
        {
            this.Error(this.ErrorKind.ResultUndefined, returnState);
        }
        



        if (! this.Null(resultClass))
        {
            if (!this.IsFieldSet)
            {
                if (! this.CheckType(resultClass, this.CurrentResultClass))
                {
                    this.Error(this.ErrorKind.ResultUnassignable, returnState);
                }
            }
        }





        return true;
    }





    public override bool ExecuteNullExpress(NullExpress nullExpress)
    {
        if (this.Null(nullExpress))
        {
            return true;
        }

        


        this.Check(nullExpress).ExpressType = this.NullClass;




        return true;
    }






    public override bool ExecuteVarExpress(VarExpress varExpress)
    {
        if (this.Null(varExpress))
        {
            return true;
        }




        VarName name;


        name = varExpress.Var;




        string varName;


        varName = name.Value;




        Var varVar;


        varVar = (Var)this.Vars.Get(varName);




        if (this.Null(varVar))
        {
            this.Error(this.ErrorKind.VarUndefined, varExpress);
        }




        Class varClass;

        varClass = null;
            

        if (! this.Null(varVar))
        {
            varClass = varVar.Class;
        }




        this.Check(varExpress).Var = varVar;



        this.Check(varExpress).ExpressType = varClass;



        return true;
    }





    public override bool ExecuteConstantExpress(ConstantExpress constantExpress)
    {
        if (this.Null(constantExpress))
        {
            return true;
        }





        Constant constant;
        

        constant = constantExpress.Constant;





        base.ExecuteConstantExpress(constantExpress);





        Type constantType;


        constantType = null;




        if (!this.Null(constant))
        {
            if (constant is BoolConstant)
            {
                constantType = this.Constant.Bool;
            }

            if (constant is IntConstant)
            {
                constantType = this.Constant.Int;
            }
        }




        this.Check(constantExpress).ExpressType = constantType;




        return true;
    }





    public override bool ExecuteVarTarget(VarTarget varTarget)
    {
        if (this.Null(varTarget))
        {
            return true;
        }




        VarName name;


        name = varTarget.Var;




        string varName;


        varName = name.Value;




        Var varVar;


        varVar = (Var)this.Vars.Get(varName);




        if (this.Null(varVar))
        {
            this.Error(this.ErrorKind.VarUndefined, varTarget);
        }




        Class varClass;

        varClass = null;


        if (! this.Null(varVar))
        {
            varClass = varVar.Class;
        }




        this.Check(varTarget).Var = varVar;



        this.Check(varTarget).TargetClass = varClass;




        return true;
    }





    public override bool ExecuteSetTarget(SetTarget setTarget)
    {
        if (this.Null(setTarget))
        {
            return true;
        }





        Express varThis;

        varThis = setTarget.This;




        FieldName nodeField;

        nodeField = setTarget.Field;





        base.ExecuteSetTarget(setTarget);





        Class thisClass;


        thisClass = null;



        if (! this.Null(varThis))
        {
            thisClass = this.Check(varThis).ExpressType;
        }




        string fieldName;


        fieldName = null;



        if (! this.Null(nodeField))
        {
            fieldName = nodeField.Value;
        }




        if (this.Null(thisClass))
        {
            this.Error(this.ErrorKind.ThisUndefined, setTarget);
        }





        Field field;


        field = null;




        if (! this.Null(thisClass))
        {
            if (! this.Null(fieldName))
            {
                field = this.Field(thisClass, fieldName);
            }



            if (this.Null(field))
            {
                this.Error(this.ErrorKind.FieldUndefined, setTarget);
            }
        }





        Class targetClass;


        targetClass = null;




        if (! this.Null(field))
        {
            targetClass = field.Class;
        }




        this.Check(setTarget).SetField = field;



        this.Check(setTarget).TargetClass = targetClass;



        return true;
    }







    protected bool CheckType(Type varType, Type requiredType)
    {
        bool b;


        b = false;

    


        if (varType == this.NullType)
        {
            b = true;
        }



        if (varType == requiredType)
        {
            b = true;
        }




        bool ret;


        ret = b;


        return ret;
    }





    private bool CheckAccess(Class varClass, Access access)
    {
        if (this.CurrentClass == varClass)
        {
            return true;
        }




        if (access == this.Access.Public)
        {
            return true;
        }




        if (access == this.Access.Local)
        {
            if (this.Compile.Module == varClass.Module)
            {
                return true;
            }


            return false;
        }





        if (access == this.Access.Private)
        {
            return false;
        }



        return true;
    }








    protected Method Method(Class varClass, string name)
    {
        Method h;



        h = (Method)varClass.Method.Get(name);





        if (!this.Null(h))
        {
            if (!this.CheckAccess(varClass, h.Access))
            {
                h = null;
            }
        }




        Method ret;


        ret = h;


        return ret;
    }





    protected bool ArgueListMatch(Method method, ArgueList argueList)
    {
        int count;



        count = method.Param.Count;





        bool countEqual;



        countEqual = (count == argueList.Value.Count);




        if (!countEqual)
        {
            return false;
        }




        MapIter varIter;


        varIter = method.Param.Iter();




        ListIter argueIter;


        argueIter = argueList.Value.Iter();



        int i;


        i = 0;


        while (i < count)
        {
            varIter.Next();



            argueIter.Next();




            Pair varPair;


            varPair = (Pair)varIter.Value;




            Argue argue;


            argue = (Argue)argueIter.Value;




            if (this.Null(argue))
            {
                return false;
            }





            Var varVar;


            varVar = (Var)varPair.Value;




            Class varClass;


            varClass = varVar.Class;




            Class expressClass;


            expressClass = this.Check(argue.Express).ExpressType;



            if (this.Null(expressClass))
            {
                return false;
            }



            if (!this.CheckType(expressClass, varClass))
            {
                return false;
            }




            i = i + 1;
        }



        return true;
    }





    private bool VarMapAdd(VarMap map, Var varVar)
    {
        Pair pair;


        pair = new Pair();


        pair.Init();


        pair.Key = varVar.Name;


        pair.Value = varVar;




        map.Add(pair);



        return true;
    }





    private bool VarMapMapAdd(VarMap map, VarMap other)
    {
        MapIter iter;


        iter = other.Iter();



        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            Var varVar;


            varVar = (Var)pair.Value;




            this.VarMapAdd(map, varVar);
        }



        return true;
    }







    private Var VarStackVar(string name)
    {
        ListIter iter;


        iter = this.VarStack.Iter();



        while (iter.Next())
        {
            VarMap varVars;


            varVars = (VarMap)iter.Value;




            Var varVar;



            varVar = (Var)varVars.Get(name);



            if (!this.Null(varVar))
            {
                return varVar;
            }
        }




        return null;
    }
}