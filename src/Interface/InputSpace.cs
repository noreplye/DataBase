namespace DataBase.Interface
{
    
    public class InputSpace : View
    {
        public Names field;
        public TextInput input;

        public InputSpace(int x, int y, int width, string field, int typeOfInput) : base(x, y, 2, width)
        {
            this.field = new Names(x, y + 1, field);

            if (typeOfInput == 0)
            {
                input = new TextInput(x + field.Length, y, 2, width - 12);
            }
            else if (typeOfInput == 1)
            {
                input = new Mail(x + field.Length, y , height, width);
            }
            else if (typeOfInput == 2)
            {
                input = new PhoneNumber(x + field.Length, y, height, width);

            }

            
        }

        public override void Draw()
        {
            field.Draw();
            input.Draw();
        }
    }
}