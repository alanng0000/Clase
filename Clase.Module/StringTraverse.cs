namespace Clase.Module;





class StringTraverse : Traverse
{
    private Map Strings { get; set; }






    public override bool Init()
    {
        base.Init();



        this.Strings = this.Compile.Strings;




        return true;
    }





    public override bool ExecuteStringConstant(StringConstant stringConstant)
    {
        if (this.Null(stringConstant))
        {
            return true;
        }






        bool b;
        
        
        b = (this.Strings.Contain(stringConstant));
        



        if (!b)
        {
            int u;


            u = this.Strings.Count;




            ulong index;


            index = (ulong)u;





            StringValue o;


            o = new StringValue();


            o.Index = index;


            o.Value = stringConstant.Value;





            Pair pair;


            pair = new Pair();


            pair.Init();


            pair.Key = stringConstant;


            pair.Value = o;



            this.Strings.Add(pair);
        }



        return true;
    }
}