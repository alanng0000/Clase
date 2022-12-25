namespace Clase.Module;






class InterfaceTypes : Object
{
    public static InterfaceTypes This { get; } = CreateGlobal();




    private static InterfaceTypes CreateGlobal()
    {
        InterfaceTypes global;


        global = new InterfaceTypes();


        global.Init();


        return global;
    }






    public override bool Init()
    {
        base.Init();




        this.FieldGet = this.AddType();



        this.FieldSet = this.AddType();



        this.MethodCall = this.AddType();





        return true;
    }





    private int Count { get; set; }





    private InterfaceType AddType()
    {
        InterfaceType type;


        type = new InterfaceType();


        type.Init();


        type.Id = this.Count;




        this.Count = this.Count + 1;




        InterfaceType ret;


        ret = type;


        return ret;
    }





    public InterfaceType FieldGet { get; private set; }



    public InterfaceType FieldSet { get; private set; }



    public InterfaceType MethodCall { get; private set; }
}