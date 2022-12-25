namespace Clase.Module;






class GlobalInitGenCall : InitGenCall
{
    public CheckClass GlobalClass { get; set; }






    protected override bool This()
    {
        this.Infra.AppendGlobalGlobalObjectVarName(this.GlobalClass);




        return true;
    }
}