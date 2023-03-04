namespace Clase.Node;





public class ErrorKinds : ClassErrorKinds
{
    public ErrorKind ObjectInvalid { get; private set; }





    public override bool Init()
    {
        base.Init();




        this.ObjectInvalid = this.AddKind("ObjectInvalid");






        return true;
    }
}