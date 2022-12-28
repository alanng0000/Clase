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
}