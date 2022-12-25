namespace Clase.Module;






class StringDataFieldGenSet : StringFieldGenSet
{
    protected override bool Value()
    {
        this.Infra.Append(this.Constants.LeftBracket);





        this.Infra.Append(this.Constants.LeftBracket);



        this.Infra.AppendTypeName();



        this.Infra.Append(this.Constants.RightBracket);





        this.Infra.Append(this.ValueString);





        this.Infra.Append(this.Constants.RightBracket);




        return true;
    }
}