namespace Clase.Exe;




class Exe
{
    static void Main(string[] args)
    {
        Clase clase;


        clase = new Clase();



        clase.Init();





        Task task;



        task = clase.CreateTask(args);




        clase.Task = task;



        clase.Execute();
    }
}