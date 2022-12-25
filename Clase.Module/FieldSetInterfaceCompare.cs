namespace Clase.Module;





class FieldSetInterfaceCompare : InterfaceCompare
{
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




        FieldSetInterface leftT;


        leftT = (FieldSetInterface)left;



        FieldSetInterface rightT;


        rightT = (FieldSetInterface)right;





        int n;





        n = this.ClassCompare.Execute(leftT.Class, rightT.Class);



        if (!(n == 0))
        {
            return n;
        }




        n = this.AccessCompare.Execute(leftT.Access, rightT.Access);



        if (!(n == 0))
        {
            return n;
        }




        n = this.StringCompare.Execute(leftT.Name, rightT.Name);



        if (!(n == 0))
        {
            return n;
        }





        return 0;
    }
}