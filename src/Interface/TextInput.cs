namespace DataBase.Interface
{
    public class TextInput : View
    {
        public string text;

        public TextInput(int x, int y, int height, int width) : base(x, y, height, width)
        {
            text = " ";
        }
        
        public override void Draw()
        {
            DrawFrame();
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write(text);
        }
        public virtual bool Validation()
        {
            return text.Length != 0;
        }
    }
}