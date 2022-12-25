namespace Clase.Module;




class AccessCompare : Compare
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





        Access leftT;


        leftT = (Access)left;




        Access rightT;


        rightT = (Access)right;





        return leftT.Id.CompareTo(rightT.Id);
    }
}