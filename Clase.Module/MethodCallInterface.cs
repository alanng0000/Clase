namespace Clase.Module;




class MethodCallInterface : MethodInterface
{
    public override InterfaceType Type
    {
        get
        {
            return InterfaceTypes.This.MethodCall;
        }
    }
}