namespace Clase.Module;






class InitGenCall : GenCall
{
    protected override Method Method()
    {
        return this.ObjectClass.Methods.Get(this.Constants.InitMethodName);
    }




    protected override bool ArgueLoopCond()
    {
        return false;
    }
}