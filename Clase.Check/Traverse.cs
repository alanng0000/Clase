namespace Clase.Check;






public class Traverse : ClassTraverse
{
    public override bool Init()
    {
        base.Init();





        this.ClaseErrorKinds = this.Compile.ClaseErrorKinds;




        return true;
    }





    public new Compile Compile { get; set; }




    public ErrorKinds ClaseErrorKinds { get; set; }









    public virtual bool ExecuteClass(NodeClass nodeClass)
    {
        if (this.Null(nodeClass))
        {
            return true;
        }




        this.ExecuteNode(nodeClass);





        this.ExecuteClassName(nodeClass.Name);



        this.ExecuteMembers(nodeClass.Members);




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



        this.ExecuteStructFields(nodeStruct.Fields);




        return true;
    }








    public virtual bool ExecuteStructFields(StructFields structFields)
    {
        if (this.Null(structFields))
        {
            return true;
        }




        this.ExecuteNode(structFields);




        NodeListIter iter;


        iter = structFields.Values.Iter();



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




        this.ExecuteClaseParams(nodeDelegate.Params);





        return true;
    }










    public virtual bool ExecuteGlobal(NodeGlobal global)
    {
        if (this.Null(global))
        {
            return true;
        }




        this.ExecuteNode(global);

        



        this.ExecuteClaseVariable(global.Variable);





        return true;
    }












    public virtual bool ExecuteClaseParams(Params nodeParams)
    {
        if (this.Null(nodeParams))
        {
            return true;
        }




        this.ExecuteNode(nodeParams);





        NodeListIter iter;


        iter = nodeParams.Values.Iter();



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




        this.ExecuteClaseVariable(param.Variable);





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
        



        this.ExecuteClaseParams(method.Params);




        this.ExecuteStates(method.Call);






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

        


        this.ExecuteClaseVariable(declareState.Variable);
        



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




        if (express is VariableAddressExpress)
        {
            this.ExecuteVariableAddressExpress((VariableAddressExpress)express);
        }




        if (express is MethodAddressExpress)
        {
            this.ExecuteMethodAddressExpress((MethodAddressExpress)express);
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


        this.ExecuteArgues(callExpress.Argues);



        return true;
    }






    public virtual bool ExecuteDelegateCallExpress(DelegateCallExpress delegateCallExpress)
    {
        if (this.Null(delegateCallExpress))
        {
            return true;
        }



        this.ExecuteNode(delegateCallExpress);




        this.ExecuteVariableName(delegateCallExpress.Variable);



        this.ExecuteArgues(delegateCallExpress.Argues);



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








    public virtual bool ExecuteVariableAddressExpress(VariableAddressExpress variableAddressExpress)
    {
        if (this.Null(variableAddressExpress))
        {
            return true;
        }




        this.ExecuteNode(variableAddressExpress);




        this.ExecuteVariableName(variableAddressExpress.Variable);




        return true;
    }









    public virtual bool ExecuteMethodAddressExpress(MethodAddressExpress methodAddressExpress)
    {
        if (this.Null(methodAddressExpress))
        {
            return true;
        }




        this.ExecuteNode(methodAddressExpress);




        this.ExecuteClassName(methodAddressExpress.Class);




        this.ExecuteMethodName(methodAddressExpress.Method);




        return true;
    }









    public virtual bool ExecuteClaseVariable(NodeVariable variable)
    {
        if (this.Null(variable))
        {
            return true;
        }




        this.ExecuteNode(variable);





        this.ExecuteTypeName(variable.Type);




        this.ExecuteVariableName(variable.Name);





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
}