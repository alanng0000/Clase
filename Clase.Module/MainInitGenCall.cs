namespace Clase.Module;






class MainInitGenCall : InitGenCall
{
    public string VariableName { get; set; }






    protected override bool This()
    {
        this.Infra.Append(this.VariableName);




        return true;
    }
}