namespace Clase.Module;






class StringFieldGenSet : GenSet
{
    public ulong Index { get; set; }




    public Field SetField { get; set; }




    public string ValueString { get; set; }





    protected override Field Field()
    {
        return this.SetField;
    }





    protected override bool This()
    {
        this.Infra.AppendGlobalStringVarName(this.Index);




        return true;
    }





    protected override bool Value()
    {
        this.Infra.Append(this.ValueString);


        return true;
    }
}