namespace Clase.Node;





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