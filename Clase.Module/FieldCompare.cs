namespace Clase.Module;




class FieldCompare : Compare
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






        Field leftField;



        leftField = (Field)left;




        Field rightField;


        rightField = (Field)right;





        CheckClass leftClass;



        leftClass = leftField.Parent;




        CheckClass rightClass;



        rightClass = rightField.Parent;





        int t;
        

        t = leftClass.Id.CompareTo(rightClass.Id);



        if (t == 0)
        {
            int k;


            k = leftField.Index.CompareTo(rightField.Index);


            return k;
        }


        return t;
    }
}