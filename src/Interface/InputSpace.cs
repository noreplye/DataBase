namespace DataBase.Interface
{
    
    public class InputSpace : View
    {
        public Names field;
        public TextInput input;

        public InputSpace(int x, int y, int width, string field, int typeOfInput) : base(x, y, 2, width)
        {
            this.field = new Names(x + 5, y + 1, field);

            if (typeOfInput == 0)
            {
                input = new TextInput(x + 5 + field.Length, y, 2, width);
            }
            else if (typeOfInput == 1)
            {
                input = new Mail(x + 5 +  field.Length, y, 2, width);
            }
            else if (typeOfInput == 2)
            {
                input = new Password(x + 5 + field.Length, y, 2, width);

            }


        }
        public string Text()
        {
            return input.text;
        }
        
        public override void Draw()
        {
            //base.Draw();
            field.Draw();
            input.Draw();
        }
    }
}