namespace Clase.Module;





public class Compile : ClassCompile
{
    public StringBuilder StringBuilder { get; set; }





    internal InterfaceInfra InterfaceInfra { get; set; }





    public Map Derives { get; set; }





    public Map Indexs { get; set; }
    




    public Map GlobalClass { get; set; }






    public Map Strings { get; set; }






    public Method EntryMethod { get; set; }





    public GenConstants Constants { get; set; }





    public GenInfra Infra { get; set; }





    private string GenString { get; set; }






    public override bool Init()
    {
        base.Init();




        this.InterfaceInfra = new InterfaceInfra();


        this.InterfaceInfra.Init();




        return true;
    }





    protected override bool ExecuteStages()
    {
        this.ExecuteDerive();



        this.ExecuteIndex();



        this.ExecuteGlobal();



        this.ExecuteStrings();



        this.ExecuteEntry();



        this.ExecuteGen();



        return true;
    }






    private bool ExecuteDerive()
    {
        ClassCompare compare;



        compare = new ClassCompare();



        compare.Init();






        this.Derives = new Map();



        this.Derives.Compare = compare;



        this.Derives.Init();





        DerivesGet derivesGet;


        derivesGet = new DerivesGet();


        derivesGet.Compile = this;


        derivesGet.Init();


        derivesGet.Execute();
        
        




        return true;
    }







    private bool ExecuteIndex()
    {
        ClassCompare compare;



        compare = new ClassCompare();



        compare.Init();






        this.Indexs = new Map();



        this.Indexs.Compare = compare;



        this.Indexs.Init();

        





        IndexsGet indexsGet;


        indexsGet = new IndexsGet();


        indexsGet.Compile = this;


        indexsGet.Init();


        indexsGet.Execute();
        




        return true;
    }








    private bool ExecuteGlobal()
    {
        ClassCompare compare;


        compare = new ClassCompare();


        compare.Init();






        this.GlobalClass = new Map();


        this.GlobalClass.Compare = compare;


        this.GlobalClass.Init();







        GlobalTraverse traverse;


        traverse = new GlobalTraverse();


        traverse.Compile = this;


        traverse.Init();




        this.Traverse(traverse);





        return true;
    }






    private bool ExecuteStrings()
    {
        NodeCompare compare;


        compare = new NodeCompare();


        compare.Init();





        this.Strings = new Map();


        this.Strings.Compare = compare;


        this.Strings.Init();







        StringTraverse traverse;


        traverse = new StringTraverse();


        traverse.Compile = this;


        traverse.Init();




        this.Traverse(traverse);





        return true;
    }









    private bool ExecuteEntry()
    {
        EntryGet entryGet;



        entryGet = new EntryGet();



        entryGet.Compile = this;



        entryGet.Init();



        entryGet.Execute();





        return true;
    }






    private bool ExecuteGen()
    {
        this.StringBuilder = new StringBuilder();





        this.Constants = new GenConstants();


        this.Constants.Init();





        this.Infra = new GenInfra();


        this.Infra.Compile = this;


        this.Infra.Init();






        GenDeclaration genDeclaration;


        genDeclaration = new GenDeclaration();


        genDeclaration.Compile = this;


        genDeclaration.Init();



        genDeclaration.Execute();
        







        // GenSystemFunction genSystemFunction;


        // genSystemFunction = new GenSystemFunction();


        // genSystemFunction.Compile = this;


        // genSystemFunction.Init();



        // genSystemFunction.Execute();








        GenTraverse traverse;


        traverse = new GenTraverse();


        traverse.Compile = this;


        traverse.Init();




        this.Traverse(traverse);






        GenClaseFunction claseFunction;


        claseFunction = new GenClaseFunction();


        claseFunction.Compile = this;


        claseFunction.Init();



        claseFunction.Execute();







        this.GenString = this.StringBuilder.ToString();






        File.WriteAllText("../../../../Gen/Gen.c", this.GenString);






        this.ExecuteMakePlatformModule();





        return true;
    }






    private bool ExecuteMakePlatformModule()
    {
        this.ExecuteMakeWindowsModule();



        return true;
    }






    private bool ExecuteMakeWindowsModule()
    {
        this.ExecuteWindowsMakeCommand();



        return true;
    }






    private bool ExecuteWindowsMakeCommand()
    {
        ProcessStartInfo u;


        u = new ProcessStartInfo();


        u.FileName = "cmd.exe";


        u.Arguments = "/C MakeWindowsModule.cmd" + " " + "\"" + this.Module.Name + "\"";


        u.UseShellExecute = false;


        u.WorkingDirectory = "../../../..";
        

        u.WindowStyle = ProcessWindowStyle.Hidden;


        u.CreateNoWindow = true;


        u.RedirectStandardOutput = false;


        u.RedirectStandardError = false;





        Process process;


        process = Process.Start(u);



        process.WaitForExit();



        process.Dispose();





        return true;
    }








    private bool Traverse(Traverse traverse)
    {
        MapIter iter;


        iter = this.Module.Class.Iter();




        
        while (iter.Next())
        {
            Pair pair;


            pair = (Pair)iter.Value;




            CheckClass varClass;


            varClass = (CheckClass)pair.Value;



            traverse.ExecuteClass(varClass);
        }




        return true;
    }






    public bool SystemClass(CheckClass varClass)
    {
        return varClass.Module == this.SystemModule.Module;
    }





    protected override byte[] DataResult()
    {
        return new byte[0];
    }
}