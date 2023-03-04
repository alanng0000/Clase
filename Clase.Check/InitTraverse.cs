namespace Clase.Check;






class InitTraverse : ClassInitTraverse
{
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