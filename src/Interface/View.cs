using System;
namespace DataBase.Interface
{
    public class View
    {
        public int x;
        public int y;
        public int height;
        public int width;

        public View(int x, int y, int height, int width)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }
        
        public void DrawFrame()
        {
            Console.SetCursorPosition(x,y);
            Drawing.HorDraw(x, y, width);
            Drawing.HorDraw(x, y + height, width);
            Drawing.BodyEmptyFill(x, y, height, width);
            Drawing.VertDraw(x, y , height);
            Drawing.VertDraw(x + width, y , height);
        }
        virtual public void Draw() {}

    }
}