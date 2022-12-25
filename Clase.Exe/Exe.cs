namespace Clase.Exe;




class Exe
{
    static void Main(string[] args)
    {
        Array array;


        array = new Array();


        array.Init();





        int count;


        count = args.Length;




        int i;


        i = 0;


        while (i < count)
        {
            string s;

            s = args[i];



            array.Add(s);



            i = i + 1;
        }







        Clase clase;


        clase = new Clase();



        clase.Init();



        clase.Main(array);
    }
}