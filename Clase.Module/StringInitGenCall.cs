namespace Clase.Module;






class StringInitGenCall : InitGenCall
{
    public ulong Index { get; set; }






    protected override bool This()
    {
        this.Infra.AppendGlobalStringVarName(this.Index);




        return true;
    }
}