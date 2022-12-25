namespace Clase.Module;






class TraverseGenGet : GenGet
{
    public Traverse Traverse { get; set; }





    public GetExpress GetExpress { get; set; }


    





    protected override Field Field()
    {
        return this.Traverse.LocalCheck(this.GetExpress).GetField;
    }






    protected override bool This()
    {
        this.Traverse.ExecuteExpress(this.GetExpress.This);



        return true;
    }
}