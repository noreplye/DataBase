using System;
using System.Text.RegularExpressions;

namespace DataBase.Interface
{
    public class PhoneNumber: TextInput
    {
        public PhoneNumber(int x, int y, int height, int width) : base(x, y, height, width)
        {
            
        }
        
        public override bool Validation()
        {
            return Regex.Match(text, @"^(\+[0-9]{9})$").Success;
        }
    }
}