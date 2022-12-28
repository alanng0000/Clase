namespace Clase.Check;





public class ErrorKindList : ClassErrorKindList
{
    public new static ErrorKindList This { get; } = CreateGlobal();




    private static ErrorKindList CreateGlobal()
    {
        ErrorKindList global;


        global = new ErrorKindList();


        global.Init();


        return global;
    }





    public ErrorKind TypeUndefined { get; private set; }





    public override bool Init()
    {
        base.Init();




        this.TypeUndefined = this.AddKind("TypeUndefined");






        return true;
    }
}