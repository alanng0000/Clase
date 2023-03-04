namespace Clase.Node;





public class Compile : ClassCompile
{
    public override bool Init()
    {
        base.Init();




        this.ClaseKeywords = (Keywords)this.Keywords;




        this.ClaseErrorKinds = (ErrorKinds)this.ErrorKinds;





        return true;
    }





    protected override ClassKeywords CreateKeywords()
    {
        Keywords keywords;


        keywords = global::Clase.Infra.Keywords.Instance;
        




        ClassKeywords ret;

        ret = keywords;


        return ret;
    }






    protected override ClassErrorKinds CreateErrorKinds()
    {
        ErrorKinds errorKinds;


        errorKinds = new ErrorKinds();


        errorKinds.Init();



        ClassErrorKinds ret;

        ret = errorKinds;


        return ret;
    }





    private Keywords ClaseKeywords { get; set; }




    private ErrorKinds ClaseErrorKinds { get; set; }






    protected override bool InitNodeMethods()
    {
        base.InitNodeMethods();




        this.AddNodeMethod(nameof(this.DeleteState), this.DeleteState);






        return true;
    }






    protected override State State(Range range)
    {
        State ret;


        ret = null;



        if (this.Null(ret))
        {
            ret = this.DeleteState(range);
        }



        if (this.Null(ret))
        {
            ret = base.State(range);
        }



        return ret;
    }
    





    private DeleteState DeleteState(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return null;
        }




        Token deleteToken;
        

        deleteToken = this.Token(this.ClaseKeywords.Delete, this.IndexRange(range.Start));



        if (this.NullToken(deleteToken))
        {
            return null;
        }





        if (this.Zero(this.Count(this.Range(deleteToken.Range.End, range.End))))
        {
            return null;
        }




        int lastIndex;


        lastIndex = range.End - 1;




        Token semicolon;


        semicolon = this.Token(this.Delimiters.StateSign, this.IndexRange(lastIndex));



        if (this.NullToken(semicolon))
        {
            return null;
        }






        Express varObject;


        varObject = this.Express(this.Range(deleteToken.Range.End, semicolon.Range.Start));
        


        if (this.Null(varObject))
        {
            this.Error(this.ClaseErrorKinds.ObjectInvalid, range);
        }
        



        DeleteState ret;

        ret = new DeleteState();
        
        ret.Object = varObject;
        
        this.NodeInfo(ret, range);
        
        return ret;
    }








    protected override JoinExpress JoinExpress(Range range)
    {
        return null;
    }








    protected override Range StateRange(Range range)
    {
        Range deleteStateRange;


        deleteStateRange = this.DeleteStateRange(range);




        if (!this.Zero(this.Count(deleteStateRange)))
        {
            return deleteStateRange;
        }





        return base.StateRange(range);
    }






    private Range DeleteStateRange(Range range)
    {
        if (this.Zero(this.Count(range)))
        {
            return this.EmptyRange(range.Start);
        }





        Token deleteToken;
        

        deleteToken = this.Token(this.ClaseKeywords.Delete, this.IndexRange(range.Start));



        if (this.NullToken(deleteToken))
        {
            return this.EmptyRange(range.Start);
        }





        Token semicolon;



        semicolon = this.TokenForward(this.Delimiters.StateSign, this.Range(deleteToken.Range.End, range.End));



        if (this.NullToken(semicolon))
        {
            return this.EmptyRange(range.Start);
        }





        Range t;


        t = this.Range(range.Start, semicolon.Range.End);





        Range ret;


        ret = t;



        return ret;
    }
}