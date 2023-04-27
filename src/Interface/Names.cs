namespace DataBase.Interface
{
    public class Names: View //класс названий 
    {
        public string text;
        public ConsoleColor consoleColor;

        public Names(int x, int y, string text):base(x, y, 1, text.Length)
        {
            this.text = text;
            consoleColor = ConsoleColor.White;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = consoleColor;
            Console.Write(text);
            Console.ResetColor();
        }

    }
}

