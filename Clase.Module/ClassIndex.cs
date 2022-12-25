namespace Clase.Module;





class ClassIndex : Object
{
    public override bool Init()
    {
        base.Init();





        MemberInterfaceCompare compare;


        compare = new MemberInterfaceCompare();


        compare.Init();







        this.Members = new Map();


        this.Members.Compare = compare;


        this.Members.Init();






        return true;
    }





    public CheckClass Class { get; set; }

    



    public Map Members { get; private set; }
}