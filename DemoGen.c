


class Hh : Object
{
    public Int J
    {
        get
        {
        }
        set
        {
        }
    }
}


class Door : Hh
{
    public Int O
    {
        get
        {
        }
        set
        {
        }
    }



    public Int J
    {
        get
        {
        }
        set
        {
        }
    }



    private Bool K()
    {
        this.J;
    }
}





struct Clase_Object_;


typedef struct Clase_Object_ Clase_Object;



struct Clase_Object_
{
    Int** C;
};




typedef struct Clase_Hh_ Clase_Hh;


struct Clase_Hh_
{
    Clase_Object Base_
    Int J;
};




typedef struct Clase_Door_ Clase_Door;



struct Clase_Door_
{
    Clase_Hh Base_;
    Int O;
};




Int Clase__Members_Door[5];





Int* Clase__Class_Door[2];






Clase__Class_Door[1] = Clase__Members_Door;







new Door;



New(sizeof(Door));





Int Clase__This_Mask;



Clase__This_Mask = 0xffffffffffff;






Int Clase__This_Shift = 48;






Object Clase_Door_O_G(Object this)
{
    Object m;
    
    m = (((Clase_Door*)(this ^ Clase__This_Mask))->O);
}



Object Door_O_S(Object this, Object value)
{

}



typedef Object (*Clase_Door_J_G_P)(Object this);







Object Door_K(Object this)
{   
    Object m = null;




    ((Clase_Door_J_G_P)((((Clase_Object*)(Clase__This = m))->C)[Clase__This >> Clase__This_Shift][3]))(Clase__This);
}






Object Clase__New(Int size, Int** classArray)
{
    Object o = null;



    o = New(size);



    ((Clase_Object*)o)->C = classArray;



    return o;
}






struct Clase_Time_;
typedef struct Clase_Time_ Clase_Time;




struct Clase_Time_
{
    Clase_Object Base_;
    Object Infra_;
};








struct Clase_Ke_;
typedef struct Clase_Ke_ Clase_Ke;




struct Clase_Ke_
{
    Clase_Time Base_;
    Object MyTime;
};






Bool Clase_Time_Date_C(Object this, Object date)
{
    return Time_Date((((Clase_Time*)(this ^ Clase__This_Mask))->Infra_), (((Clase_Date*)(date ^ Clase__This_Mask))->Infra_));
}





Bool Time_Date(Object this, Object date);






class Ke : Time
{
    public Bool MyTime
    {
        get
        {
            Date date;


            date ← new Date;



            date.Init();




            this.Date(date);







            date.Final();



            delete date;



            return true;
        }
        set
        {
        }
    }



    public Int Tick
    {
        get
        {
            return base.Tick;
        }
    }
}








Bool Clase_Ke_MyTime_G(Object this)
{
    
}
