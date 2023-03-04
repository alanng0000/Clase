namespace Clase.Check;






public class Traverse : ClassTraverse
{
    public override bool Init()
    {
        base.Init();




        this.ClaseErrorKinds = ((Compile)this.Compile).ClaseErrorKinds;




        return true;
    }





    public ErrorKinds ClaseErrorKinds { get; set; }





    public override bool ExecuteState(State state)
    {
        if (this.Null(state))
        {
            return true;
        }




        base.ExecuteState(state);




        if (state is DeleteState)
        {
            this.ExecuteDeleteState((DeleteState)state);
        }



        return true;
    }






    public virtual bool ExecuteDeleteState(DeleteState deleteState)
    {
        if (this.Null(deleteState))
        {
            return true;
        }




        this.ExecuteNode(deleteState);

        


        this.ExecuteExpress(deleteState.Object);
        



        return true;
    }
}