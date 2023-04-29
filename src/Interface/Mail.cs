using System;
using System.Net.Mail;
namespace DataBase.Interface
{
    public class Mail: TextInput
    {
        public Mail(int x, int y, int height, int width) : base(x, y, height, width)
        {
            
        }
        
        public override bool Validation()
        {
            try
            {
                MailAddress m  = new MailAddress(text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

