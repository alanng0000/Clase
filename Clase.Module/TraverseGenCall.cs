namespace Clase.Module;






class TraverseGenCall : GenCall
{
    public Traverse Traverse { get; set; }





    public CallExpress CallExpress { get; set; }


    





    protected override Method Method()
    {
        return this.Traverse.LocalCheck(this.CallExpress).CallMethod;
    }






    protected override bool This()
    {
        this.Traverse.ExecuteExpress(this.CallExpress.This);



        return true;
    }





    protected NodeListIter Iter;





    protected override bool ArgueLoopBefore()
    {
        this.Iter = this.CallExpress.Argues.Values.Iter();



        return true;
    }





    protected override bool ArgueLoopCond()
    {
        return this.Iter.Next();
    }





    protected override bool ArgueLoopBody()
    {
        Argue argue;


        argue = (Argue)this.Iter.Value;



        Express e;


        e = argue.Express;




        this.Traverse.ExecuteExpress(e);



        return true;
    }
}