namespace Clase.Module;






class TraverseGenSet : GenSet
{
    public Traverse Traverse { get; set; }





    public SetTarget SetTarget { get; set; }


    


    public Express ValueExpress { get; set; }





    protected override Field Field()
    {
        return this.Traverse.LocalCheck(this.SetTarget).SetField;
    }






    protected override bool This()
    {
        this.Traverse.ExecuteExpress(this.SetTarget.This);



        return true;
    }




    protected override bool Value()
    {
        this.Traverse.ExecuteExpress(this.ValueExpress);



        return true;
    }
}