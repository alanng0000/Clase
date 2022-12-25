namespace Clase.Check;






class StateTraverse : ClassStateTraverse
{
    public override bool Init()
    {
        base.Init();



        this.ClaseErrorKinds = (ErrorKinds)this.ErrorKinds;




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





        Express nodeObject;
            
        nodeObject = deleteState.Object;





        this.ExecuteExpress(nodeObject);




            
        ClassClass objectClass;


        objectClass = null;




        if (! this.Null(nodeObject))
        {
            objectClass = this.Check(nodeObject).ExpressClass;
        }




        
        
        if (this.Null(objectClass))
        {
            this.Error(this.ClaseErrorKinds.ObjectUndefined, deleteState);
        }





        return true;
    }
}