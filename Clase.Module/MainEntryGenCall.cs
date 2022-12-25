namespace Clase.Module;






class MainEntryGenCall : GenCall
{
    public string VariableName { get; set; }




    public Method EntryMethod { get; set; }






    protected override Method Method()
    {
        return this.EntryMethod;
    }





    protected override bool This()
    {
        this.Infra.Append(this.VariableName);




        return true;
    }





    private bool Loop { get; set; }





    protected override bool ArgueLoopBefore()
    {
        this.Loop = true;



        return true;
    }





    protected override bool ArgueLoopCond()
    {
        return this.Loop;
    }




    protected override bool ArgueLoopBody()
    {
        this.Infra.AppendClaseMainArgVariableName();
        



        this.Loop = false;
        


        return true;
    }
}