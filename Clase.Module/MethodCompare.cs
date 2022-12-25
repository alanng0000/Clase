namespace Clase.Module;




class MethodCompare : Compare
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






        Method leftMethod;



        leftMethod = (Method)left;




        Method rightMethod;


        rightMethod = (Method)right;





        CheckClass leftClass;



        leftClass = leftMethod.Parent;




        CheckClass rightClass;



        rightClass = rightMethod.Parent;





        int t;
        

        t = leftClass.Id.CompareTo(rightClass.Id);



        if (t == 0)
        {
            int k;


            k = leftMethod.Index.CompareTo(rightMethod.Index);


            return k;
        }


        return t;
    }
}