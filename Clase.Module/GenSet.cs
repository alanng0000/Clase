namespace Clase.Module;







class GenSet : GenBase
{
    public override bool Execute()
    {
        Field field;


        field = this.Field();





        CheckClass parent;


        parent = field.Parent;







        FieldSetInterface fieldSetInterface;



        fieldSetInterface = this.InterfaceInfra.FieldSetInterface(field);





        ClassIndex classIndex;
        
        

        classIndex = (ClassIndex)this.Indexs.Get(parent);







        FieldSetIndex fieldSetIndex;



        fieldSetIndex = (FieldSetIndex)classIndex.Members.Get(fieldSetInterface);







        string s;


        s = fieldSetIndex.Index.ToString();








        this.Infra.Append(this.Constants.LeftBracket);









        this.Infra.Append(this.Constants.LeftBracket);






        this.Infra.Append(this.Constants.LeftBracket);




        
        this.Infra.AppendFieldFunctionPointerTypeName(field, true);





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







        this.Infra.Append(this.Constants.Comma);




        this.Infra.Append(this.Constants.Space);







        this.Value();








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
    




    protected virtual bool Value()
    {
        return true;
    }
}