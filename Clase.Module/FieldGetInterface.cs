namespace Clase.Module;




class FieldGetInterface : FieldInterface
{
    public override InterfaceType Type
    {
        get
        {
            return InterfaceTypes.This.FieldGet;
        }
    }
}