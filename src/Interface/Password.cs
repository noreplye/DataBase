namespace DataBase.Interface
{
    public class Password : TextInput
    {
        public Password(int x, int y, int height, int width): base(x, y, height, width) {}

        public override void Draw()
        {
            DrawFrame();
            Console.SetCursorPosition(x + 1, y + 1);
            for (var i = 1; i < text.Length; i++)
                Console.Write('*');
        }

        public override bool Validation()
        {
            if (text.Length < 6)
                return false;

            return true;
        }
    }
}