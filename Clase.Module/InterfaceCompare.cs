namespace Clase.Module;





class InterfaceCompare : Compare
{
    public override bool Init()
    {
        base.Init();




        this.ClassCompare = new ClassCompare();

        this.ClassCompare.Init();



        this.StringCompare = new StringCompare();

        this.StringCompare.Init();



        this.AccessCompare = new AccessCompare();

        this.AccessCompare.Init();


        



        return true;
    }




    protected ClassCompare ClassCompare { get; set; }



    protected StringCompare StringCompare { get; set; }



    protected AccessCompare AccessCompare { get; set; }
}