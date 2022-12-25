namespace Clase.Module;





class MethodCallInterfaceCompare : InterfaceCompare
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




        MethodCallInterface leftT;


        leftT = (MethodCallInterface)left;



        MethodCallInterface rightT;


        rightT = (MethodCallInterface)right;





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






        int leftCount;


        leftCount = leftT.Params.Count;





        n = leftCount.CompareTo(rightT.Params.Count);



        if (!(n == 0))
        {
            return n;
        }






        int count;


        count = leftCount;



        int i;


        i = 0;



        while (i < count)
        {
            CheckClass leftParamClass;

            leftParamClass = leftT.Params[i];



            CheckClass rightParamClass;

            rightParamClass = rightT.Params[i];




            n = this.ClassCompare.Execute(leftParamClass, rightParamClass);



            if (!(n == 0))
            {
                return n;
            }



            i = i + 1;
        }




        return 0;
    }
}