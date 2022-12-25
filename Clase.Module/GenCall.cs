namespace Clase.Module;







class GenCall : GenBase
{
    public override bool Execute()
    {
        Method method;


        method = this.Method();





        CheckClass parent;


        parent = method.Parent;







        MethodCallInterface methodCallInterface;



        methodCallInterface = this.InterfaceInfra.MethodCallInterface(method);





        ClassIndex classIndex;
        
        

        classIndex = (ClassIndex)this.Indexs.Get(parent);







        MethodCallIndex methodCallIndex;



        methodCallIndex = (MethodCallIndex)classIndex.Members.Get(methodCallInterface);







        string s;


        s = methodCallIndex.Index.ToString();








        this.Infra.Append(this.Constants.LeftBracket);









        this.Infra.Append(this.Constants.LeftBracket);






        this.Infra.Append(this.Constants.LeftBracket);




        
        this.Infra.AppendMethodFunctionPointerTypeName(method);





        this.Infra.Append(this.Constants.RightBracket);





        this.Infra.Append(this.Constants.LeftBracket);







        this.Infra.Append(this.Constants.LeftBracket);







        this.Infra.Append(this.Constants.LeftBracket);






        this.Infra.Append(this.Constants.LeftBracket);




        this.Infra.AppendStructPointerTypeName(this.ObjectClass);




        this.Infra.Append(this.Constants.RightBracket);





        this.Infra.Append(this.Constants.LeftBracket);





        this.Infra.AppendGlobalGetSetCallThisVarName();





        this.Infra.Append(this.Constants.Space);





        this.Infra.Append(this.Constants.EqualSign);





        this.Infra.Append(this.Constants.Space);







        this.This();







        this.Infra.Append(this.Constants.RightBracket);







        this.Infra.Append(this.Constants.RightBracket);








        this.Infra.Append(this.Constants.Hyphen);




        this.Infra.Append(this.Constants.GreaterThan);




        this.Infra.AppendObjectClassStructClassFieldName();






        this.Infra.Append(this.Constants.RightBracket);







        this.Infra.Append(this.Constants.LeftSquare);





        this.Infra.Append(s);





        this.Infra.Append(this.Constants.RightSquare);







        this.Infra.Append(this.Constants.RightBracket);








        this.Infra.Append(this.Constants.RightBracket);






        this.Infra.Append(this.Constants.LeftBracket);







        this.Infra.AppendGlobalGetSetCallThisVarName();

        



        

        this.ArgueLoopBefore();




        while (this.ArgueLoopCond())
        {
            this.Infra.Append(this.Constants.Comma);




            this.Infra.Append(this.Constants.Space);






            this.ArgueLoopBody();
        }







        this.Infra.Append(this.Constants.RightBracket);







        this.Infra.Append(this.Constants.RightBracket);




        return true;
    }












    protected virtual Method Method()
    {
        return null;
    }





    protected virtual bool This()
    {
        return true;
    }




    protected virtual bool ArgueLoopBefore()
    {
        return true;
    }



    protected virtual bool ArgueLoopCond()
    {
        return true;
    }



    protected virtual bool ArgueLoopBody()
    {
        return true;
    }
}