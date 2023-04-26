namespace DataBase.Interface
{
    public class PersonInput

    {
    public string FullName;
    public string InDate;
    public string OutDate;

    public PersonInput(string FullName, string InDate, string OutDate)
        {
            this.FullName = FullName;
            this.InDate = InDate;
            this.OutDate = OutDate;
        }
    }
}