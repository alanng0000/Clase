namespace Clase.Module;






class GenBase : Object
{
    public Compile Compile { get; set; }




    protected InterfaceInfra InterfaceInfra { get; set; }




    protected GenInfra Infra { get; set; }




    protected GenConstants Constants { get; set; }




    protected Map Indexs { get; set; }





    protected Refer Refer { get; set; }





    protected CheckClass ObjectClass { get; set; }






    public override bool Init()
    {
        base.Init();




        this.Refer = this.Compile.CheckResult.Refer;




        this.InterfaceInfra = this.Compile.InterfaceInfra;




        this.Infra = this.Compile.Infra;




        this.Constants = this.Compile.Constants;




        this.Indexs = this.Compile.Indexs;




        this.ObjectClass = this.Refer.Class.Get("Object");




        return true;
    }






    public virtual bool Execute()
    {
        return true;
    }
}