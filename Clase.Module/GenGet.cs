namespace Clase.Module;







class GenGet : GenBase
{
    public override bool Execute()
    {
        Field field;


        field = this.Field();





        CheckClass parent;


        parent = field.Parent;







        FieldGetInterface fieldGetInterface;



        fieldGetInterface = this.InterfaceInfra.FieldGetInterface(field);





        ClassIndex classIndex;
        
        

        classIndex = (ClassIndex)this.Indexs.Get(parent);







        FieldGetIndex fieldGetIndex;



        fieldGetIndex = (FieldGetIndex)classIndex.Members.Get(fieldGetInterface);







        string s;


        s = fieldGetIndex.Index.ToString();








        this.Infra.Append(this.Constants.LeftBracket);









        this.Infra.Append(this.Constants.LeftBracket);






        this.Infra.Append(this.Constants.LeftBracket);




        
        this.Infra.AppendFieldFunctionPointerTypeName(field, false);





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








        this.Infra.Append(this.Constants.RightBracket);







        this.Infra.Append(this.Constants.RightBracket);




        return true;
    }












    protected virtual Field Field()
    {
        return null;
    }





    protected virtual bool This()
    {
        return true;
    }
}