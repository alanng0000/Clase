namespace Clase.Node;





public class ErrorKinds : ClassErrorKinds
{
   public new static ErrorKinds This { get; } = CreateGlobal();




    private static ErrorKinds CreateGlobal()
    {
        ErrorKinds global;


        global = new ErrorKinds();


        global.Init();


        return global;
    }





    public ErrorKind TypeInvalid { get; private set; }




    public ErrorKind FieldsInvalid { get; private set; }




    public ErrorKind DeclaresInvalid { get; private set; }





    public override bool Init()
    {
        base.Init();




        this.TypeInvalid = this.AddKind("TypeInvalid");





        this.FieldsInvalid = this.AddKind("FieldsInvalid");





        this.DeclaresInvalid = this.AddKind("DeclaresInvalid");






        return true;
    }
}