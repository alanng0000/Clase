namespace Clase.Node;







public class Method : Member
{
    public Access Access { get; set; }
    



    public TypeName Type { get; set; }




    public MethodName Name { get; set; }




    public ParamList Param { get; set; }




    public StateList Call { get; set; }
}