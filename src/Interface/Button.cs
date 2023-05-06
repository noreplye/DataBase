namespace DataBase.Interface
{
    public class Button<Function> : View   // класс кнопки 
    {
        public Names text;
        public Function func;
        
        public Button(string text, int x, int y, int height, int width, Function func):base(x, y, height, width)
        {
            this.text = new Names(x + 2, y + 1, text);
            this.func = func;
            
        }

        public override void Draw()
        {
            DrawFrame();
            text.Draw();
        }
    }
}

