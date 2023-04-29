using System;
namespace DataBase.Interface
{
    public class PersonInput

    {
        public string fullName;
        public string comeDate;
        public string outDate;

        //public static PersonInput( string FullName,  string InDate, string OutDate)
        public PersonInput( string fullName,  string comeDate, string outDate)
        {
            this.fullName = fullName;
            this.comeDate = comeDate;
            this.outDate = outDate;
        }
    }
}