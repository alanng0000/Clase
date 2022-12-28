namespace Clase.Check;




public class Class : Object
{
    public string Name { get; set; }



    public StructMap Struct { get; set; }



    public DelegateMap Delegate { get; set; }



    public VarMap Global { get; set; }



    public MethodMap Method { get; set; }





    public Module Module { get; set; }





    public NodeClass Node { get; set; }




    public Source Source { get; set; }




    public int Index { get; set; }




    public ulong Id { get; set; }
}