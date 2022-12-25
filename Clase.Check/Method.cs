namespace Clase.Check;



public class Method : Object
{
    public string Name { get; set; }



    public Access Access { get; set; }



    public Type Type { get; set; }



    public VariableMap Params { get; set; }



    public VariableMap Call { get; set; }




    public Class Parent { get; set; }




    public NodeMethod Node { get; set; }




    public int Index { get; set; }
}