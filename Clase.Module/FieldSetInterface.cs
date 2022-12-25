namespace Clase.Module;




class FieldSetInterface : FieldInterface
{
    public override InterfaceType Type
    {
        get
        {
            return InterfaceTypes.This.FieldSet;
        }
    }
}