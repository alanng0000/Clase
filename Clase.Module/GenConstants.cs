namespace Clase.Module;




public class GenConstants : Object
{
    public string Underscore { get; set; }



    public string LeftBracket { get; set; }



    public string RightBracket { get; set; }



    public string LeftBrace { get; set; }



    public string RightBrace { get; set; }



    public string LeftSquare { get; set; }



    public string RightSquare { get; set; }



    public string Semicolon { get; set; }



    public string Comma { get; set; }



    public string Asterisk { get; set; }



    public string EqualSign { get; set; }



    public string Ampersand { get; set; }



    public string VerticalBar { get; set; }



    public string ExclamationMark { get; set; }



    public string AddSign { get; set; }


    
    public string Slash { get; set; }



    public string Hyphen { get; set; }



    public string LessThan { get; set; }



    public string GreaterThan { get; set; }


    
    public string QuestionMark { get; set; }



    public string Colon { get; set; }



    public string Space { get; set; }



    public string NullWord { get; set; }



    public string TrueWord { get; set; }



    public string FalseWord { get; set; }



    public string ReturnWord { get; set; }



    public string IfWord { get; set; }



    public string WhileWord { get; set; }


    
    public string SizeOfWord { get; set; }



    public string TypeDefWord { get; set; }



    public string StructWord { get; set; }



    public string ObjectTypeName { get; set; }



    public string BoolTypeName { get; set; }



    public string IntTypeName { get; set; }



    public string InitMethodName { get; set; }



    public string FinalMethodName { get; set; }



    public string ThisVarName { get; set; }



    public string ValueVarName { get; set; }




    public string NewLine { get; set; }



    public string Quote { get; set; }





    public string Prefix { get; set; }




    public string FieldGetSuffix { get; set; }



    public string FieldSetSuffix { get; set; }




    public string MethodCallSuffix { get; set; }




    public string Zero { get; set; }




    public string IndentUnit { get; set; }





    public override bool Init()
    {
        base.Init();





        this.Underscore = "_";


        this.LeftBracket = "(";


        this.RightBracket = ")";


        this.LeftBrace = "{";


        this.RightBrace = "}";


        this.LeftSquare = "[";


        this.RightSquare = "]";


        this.Semicolon = ";";


        this.Comma = ",";


        this.Asterisk = "*";


        this.EqualSign = "=";


        this.Ampersand = "&";


        this.VerticalBar = "|";


        this.ExclamationMark = "!";


        this.AddSign = "+";


        this.Slash = "/";


        this.Hyphen = "-";


        this.LessThan = "<";


        this.GreaterThan = ">";


        this.QuestionMark = "?";


        this.Colon = ":";


        this.Space = " ";



        this.NullWord = "null";



        this.TrueWord = "true";



        this.FalseWord = "false";



        this.ReturnWord = "return";



        this.IfWord = "if";



        this.WhileWord = "while";



        this.SizeOfWord = "sizeof";



        this.TypeDefWord = "typedef";



        this.StructWord = "struct";



        this.ObjectTypeName = "Object";



        this.BoolTypeName = "Bool";



        this.IntTypeName = "Int";



        this.InitMethodName = "Init";



        this.FinalMethodName = "Final";



        this.ThisVarName = "this";



        this.ValueVarName = "value";




        this.NewLine = "\n";




        this.Quote = "\"";




        this.Prefix = "Clase";



        this.FieldGetSuffix = "G";



        this.FieldSetSuffix = "S";



        this.MethodCallSuffix = "C";




        this.Zero = "0";




        this.IndentUnit = "    ";




        return true;
    }
}