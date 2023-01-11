namespace Clase.Check;






public class Traverse : ClassBaseTraverse
{
    public override bool Init()
    {
        base.Init();





        this.ClaseErrorKind = this.Compile.ClaseErrorKind;




        return true;
    }





    public new Compile Compile { get; set; }




    public ErrorKindList ClaseErrorKind { get; set; }









    public virtual bool ExecuteClass(NodeClass nodeClass)
    {
        if (this.Null(nodeClass))
        {
            return true;
        }




        this.ExecuteNode(nodeClass);





        this.ExecuteClassName(nodeClass.Name);



        this.ExecuteMemberList(nodeClass.Member);




        return true;
    }









    public override bool ExecuteMember(Member member)
    {
        if (this.Null(member))
        {
            return true;
        }




        base.ExecuteMember(member);






        if (member is NodeStruct)
        {
            this.ExecuteStruct((NodeStruct)member);
        }





        if (member is NodeDelegate)
        {
            this.ExecuteDelegate((NodeDelegate)member);
        }





        if (member is NodeGlobal)
        {
            this.ExecuteGlobal((NodeGlobal)member);
        }
        




        if (member is NodeMethod)
        {
            this.ExecuteClaseMethod((NodeMethod)member);
        }






        return true;
    }











    public virtual bool ExecuteStruct(NodeStruct nodeStruct)
    {
        if (this.Null(nodeStruct))
        {
            return true;
        }




        this.ExecuteNode(nodeStruct);





        this.ExecuteTypeName(nodeStruct.Name);



        this.ExecuteStructFieldList(nodeStruct.Field);




        return true;
    }








    public virtual bool ExecuteStructFieldList(StructFieldList structFieldList)
    {
        if (this.Null(structFieldList))
        {
            return true;
        }




        this.ExecuteNode(structFieldList);




        ListIter iter;


        iter = structFieldList.Value.Iter();



        while (iter.Next())
        {
            NodeStructField structField;


            structField = (NodeStructField)iter.Value;



            this.ExecuteStructField(structField);
        }




        return true;
    }









    public virtual bool ExecuteStructField(NodeStructField structField)
    {
        if (this.Null(structField))
        {
            return true;
        }




        this.ExecuteNode(structField);

        


        this.ExecuteTypeName(structField.Type);



        this.ExecuteFieldName(structField.Name);
        



        return true;
    }










    public virtual bool ExecuteDelegate(NodeDelegate nodeDelegate)
    {
        if (this.Null(nodeDelegate))
        {
            return true;
        }





        this.ExecuteNode(nodeDelegate);

        



        this.ExecuteTypeName(nodeDelegate.Name);




        this.ExecuteTypeName(nodeDelegate.Type);




        this.ExecuteClaseParamList(nodeDelegate.Param);





        return true;
    }










    public virtual bool ExecuteGlobal(NodeGlobal global)
    {
        if (this.Null(global))
        {
            return true;
        }




        this.ExecuteNode(global);

        



        this.ExecuteClaseVar(global.Var);





        return true;
    }












    public virtual bool ExecuteClaseParamList(ParamList nodeParamList)
    {
        if (this.Null(nodeParamList))
        {
            return true;
        }




        this.ExecuteNode(nodeParamList);





        ListIter iter;


        iter = nodeParamList.Value.Iter();



        while (iter.Next())
        {
            Param param;


            param = (Param)iter.Value;



            this.ExecuteClaseParam(param);
        }




        return true;
    }











    public virtual bool ExecuteClaseParam(Param param)
    {
        if (this.Null(param))
        {
            return true;
        }



        this.ExecuteNode(param);




        this.ExecuteClaseVar(param.Var);





        return true;
    }












    public virtual bool ExecuteClaseMethod(NodeMethod method)
    {
        if (this.Null(method))
        {
            return true;
        }




        this.ExecuteNode(method);






        this.ExecuteAccess(method.Access);




        this.ExecuteTypeName(method.Type);




        this.ExecuteMethodName(method.Name);
        



        this.ExecuteClaseParamList(method.Param);




        this.ExecuteStateList(method.Call);






        return true;
    }
    












    public override bool ExecuteState(State state)
    {
        if (this.Null(state))
        {
            return true;
        }




        base.ExecuteState(state);




        if (state is DeclareState)
        {
            this.ExecuteClaseDeclareState((DeclareState)state);
        }



        return true;
    }






    public virtual bool ExecuteClaseDeclareState(DeclareState declareState)
    {
        if (this.Null(declareState))
        {
            return true;
        }




        this.ExecuteNode(declareState);

        


        this.ExecuteClaseVar(declareState.Var);
        



        return true;
    }







    public override bool ExecuteExpress(Express express)
    {
        if (this.Null(express))
        {
            return true;
        }




        base.ExecuteExpress(express);





        if (express is CastExpress)
        {
            this.ExecuteClaseCastExpress((CastExpress)express);
        }




        if (express is CallExpress)
        {
            this.ExecuteClaseCallExpress((CallExpress)express);
        }




        if (express is DelegateCallExpress)
        {
            this.ExecuteDelegateCallExpress((DelegateCallExpress)express);
        }




        if (express is SizeExpress)
        {
            this.ExecuteSizeExpress((SizeExpress)express);
        }




        if (express is MethodExpress)
        {
            this.ExecuteMethodExpress((MethodExpress)express);
        }





        return true;
    }







    public virtual bool ExecuteClaseCastExpress(CastExpress castExpress)
    {
        if (this.Null(castExpress))
        {
            return true;
        }




        this.ExecuteNode(castExpress);





        this.ExecuteTypeName(castExpress.Type);




        this.ExecuteExpress(castExpress.Object);




        return true;
    }







    public virtual bool ExecuteClaseCallExpress(CallExpress callExpress)
    {
        if (this.Null(callExpress))
        {
            return true;
        }



        this.ExecuteNode(callExpress);




        this.ExecuteClassName(callExpress.Class);


        this.ExecuteMethodName(callExpress.Method);


        this.ExecuteArgueList(callExpress.Argue);



        return true;
    }






    public virtual bool ExecuteDelegateCallExpress(DelegateCallExpress delegateCallExpress)
    {
        if (this.Null(delegateCallExpress))
        {
            return true;
        }



        this.ExecuteNode(delegateCallExpress);




        this.ExecuteVarName(delegateCallExpress.Var);



        this.ExecuteArgueList(delegateCallExpress.Argue);



        return true;
    }







    public virtual bool ExecuteSizeExpress(SizeExpress sizeExpress)
    {
        if (this.Null(sizeExpress))
        {
            return true;
        }




        this.ExecuteNode(sizeExpress);




        this.ExecuteTypeName(sizeExpress.Type);




        return true;
    }








    public virtual bool ExecuteMethodExpress(MethodExpress methodExpress)
    {
        if (this.Null(methodExpress))
        {
            return true;
        }




        this.ExecuteNode(methodExpress);




        this.ExecuteClassName(methodExpress.Class);




        this.ExecuteMethodName(methodExpress.Method);




        return true;
    }









    public virtual bool ExecuteClaseVar(NodeVar nodeVar)
    {
        if (this.Null(nodeVar))
        {
            return true;
        }




        this.ExecuteNode(nodeVar);





        this.ExecuteTypeName(nodeVar.Type);




        this.ExecuteVarName(nodeVar.Name);





        return true;
    }






    public virtual bool ExecuteTypeName(TypeName typeName)
    {
        if (this.Null(typeName))
        {
            return true;
        }




        this.ExecuteNode(typeName);




        return true;
    }






    protected new Class Class(string name)
    {
        Class ret;


        ret = this.Compile.Class(name);


        return ret;
    }





    protected Type Type(Class varClass, string name)
    {
        return this.Compile.Type(varClass, name);
    }






    protected new Check Check(NodeNode node)
    {
        return (Check)this.Compile.Check.Get(node);
    }
}