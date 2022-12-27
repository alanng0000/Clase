namespace Clase;




class TaskCreate : Object
{
    public Task Task(string[] args)
    {
        if (!(args.Length == 2))
        {
            return null;
        }




        string a;

        a = args[0];

        

        string b;

        b = args[1];



        if (!(a == "Module"))
        {
            return null;
        }




        Task task;

        task = new Task();

        task.Init();

        task.Kind = TaskKindList.This.Module;

        task.Source = b;

        task.Out = Console.Out;



        Task ret;

        ret = task;


        return ret;
    }
}