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






    public string Struct { get; private set; }





    public string Delegate { get; private set;}





    public string Call { get; private set;}






    public string Size { get; private set; }





    public string Var { get; private set; }




    public string Method { get; private set; }






    public override bool Init()
    {
        base.Init();





        this.Struct = "struct";






        this.Delegate = "delegate";






        this.Call = "call";





        this.Size = "size";




        this.Var = "var";




        this.Method = "method";






        this.All.Add(this.Struct);




        this.All.Add(this.Delegate);




        this.All.Add(this.Call);





        this.All.Add(this.Size);




        this.All.Add(this.Var);




        this.All.Add(this.Method);






        this.Access = new List();
        this.Access.Init();
        this.Access.Add(this.Public);
        this.Access.Add(this.Private);
        

        
        



        return true;
    }
}