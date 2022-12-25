namespace Clase.Module;






class MemberInterfaceCompare : Compare
{
    public override bool Init()
    {
        base.Init();




        this.FieldGetCompare = new FieldGetInterfaceCompare();


        this.FieldGetCompare.Init();





        this.FieldSetCompare = new FieldSetInterfaceCompare();


        this.FieldSetCompare.Init();





        this.MethodCallCompare = new MethodCallInterfaceCompare();


        this.MethodCallCompare.Init();





        return true;
    }





    private FieldGetInterfaceCompare FieldGetCompare { get; set; }





    private FieldSetInterfaceCompare FieldSetCompare { get; set; }





    private MethodCallInterfaceCompare MethodCallCompare { get; set; }






    public override int Execute(object left, object right)
    {
        if (left == null)
        {
            return 0;
        }


        if (right == null)
        {
            return 0;
        }





        Interface leftInterface;

        leftInterface = (Interface)left;



        Interface rightInterface;

        rightInterface = (Interface)right;





        int n;




        n = leftInterface.Type.Id.CompareTo(rightInterface.Type.Id);



        if (!(n == 0))
        {
            return n;
        }








        if (leftInterface.Type == InterfaceTypes.This.FieldGet)
        {
            FieldGetInterface leftFieldGet;

            leftFieldGet = (FieldGetInterface)left;



            FieldGetInterface rightFieldGet;

            rightFieldGet = (FieldGetInterface)right;



            return this.FieldGetCompare.Execute(leftFieldGet, rightFieldGet);
        }






        if (leftInterface.Type == InterfaceTypes.This.FieldSet)
        {
            FieldSetInterface leftFieldSet;

            leftFieldSet = (FieldSetInterface)left;



            FieldSetInterface rightFieldSet;

            rightFieldSet = (FieldSetInterface)right;



            return this.FieldSetCompare.Execute(leftFieldSet, rightFieldSet);
        }







        if (leftInterface.Type == InterfaceTypes.This.MethodCall)
        {
            MethodCallInterface leftMethodCall;

            leftMethodCall = (MethodCallInterface)left;



            MethodCallInterface rightMethodCall;

            rightMethodCall = (MethodCallInterface)right;



            return this.MethodCallCompare.Execute(leftMethodCall, rightMethodCall);
        }








        return 0;
    }
}