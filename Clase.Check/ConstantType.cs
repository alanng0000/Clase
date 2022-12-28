namespace Clase.Check;






public class ConstantType : Object
{
    public override bool Init()
    {
        base.Init();




        this.Bool = this.AddType("Bool");




        this.Int = this.AddType("Int");





        return true;
    }







    private Type AddType(string name)
    {
        Type type;


        type = new Type();


        type.Init();


        type.Name = name;




        Type ret;


        ret = type;


        return ret;
    }






    public Type Bool { get; private set; }



    public Type Int { get; private set; }
}