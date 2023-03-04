namespace Clase.Check;





public class ErrorKinds : ClassErrorKinds
{
    public ErrorKind ObjectUndefined { get; private set; }






    public override bool Init()
    {
        base.Init();




        this.ObjectUndefined = this.AddKind("ObjectUndefined");





        return true;
    }
}