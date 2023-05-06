using System;
using System.Collections.Generic;

namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;
    public class Body : View  // класс страницы
    {
        Header header;
        public List<View> windows;
        public int ActiveButton;
        public bool KeyPressed;
        public ConsoleColor ActiveColor;
        
        public Body(int x, int y, int height, int width, string title):base(x, y, height, width)
        {
            this.header = new Header(x , y, width, title);
            windows = new List<View>();

            ActiveButton = 0;
            KeyPressed = false;
            ActiveColor = ConsoleColor.Magenta;
        }

        virtual public List<Body> KeyDetect(ConsoleKeyInfo keyInfo, List<Body> bodies) 
        {
            
            if (keyInfo.Key == ConsoleKey.Escape) 
            {
                bodies.Remove(this);
                if (bodies.Count == 0)
                {
                    System.Environment.Exit(0);
                }

                KeyPressed = true;
            }
            return bodies;
        }

        public override void Draw()
        {
            DrawFrame();
            header.Draw();

            foreach (var w in windows)
            {
                w.Draw();
            }

            Console.CursorVisible = false;
        }
    }
}

