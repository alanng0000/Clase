namespace Clase.Infra;






public class Keywords : ClassKeywords
{
    public new static Keywords Instance { get; } = CreateGlobal();




    private static Keywords CreateGlobal()
    {
        Keywords global;


        global = new Keywords();


        global.Init();


        return global;
    }






    public string Delete { get; private set; }






    public override bool Init()
    {
        base.Init();





        this.Delete = "delete";







        this.All.Add(this.Delete);



        
        



        return true;
    }
}