namespace DataBase.Interface
{
    public class Header : View //класс верхнего меню
    {
        private Names title;
        public Header(int x, int y, int width, string title) : base(x, y , 4, width)
        {
            this.title = new Names(x + 2, y + 2, title); // расположение
        }

        public override void Draw()
        {
            DrawFrame();
            title.Draw();
        }
    }
}

