namespace Clase.Check;




public class Class : Object
{
    public string Name { get; set; }



    public StructMap Structs { get; set; }



    public DelegateMap Delegates { get; set; }



    public VariableMap Globals { get; set; }



    public MethodMap Methods { get; set; }



    public Module Module { get; set; }



    public NodeClass Node { get; set; }




    public Source Source { get; set; }




    public int Index { get; set; }




    public ulong Id { get; set; }
}