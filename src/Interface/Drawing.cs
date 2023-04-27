using System;
namespace DataBase.Interface
{
    public class Drawing
    {

        public static void HorDraw(int x, int y, int width)
        {
            for (int i = 1 ; i <= width; i++)
            {
                Console.SetCursorPosition(i + x, y);
                Console.Write("_");
            }
        }

        public static void VertDraw(int x, int y, int height)
        {
            for (int j = 1 ; j <= height; j++)
            {
                Console.SetCursorPosition(x, j + y);
                Console.Write("|");
            }
        }

        public static void BodyEmptyFill(int x, int y, int height, int width)
        {
            for (int i = 1; i < height; i++)
            {
                Console.SetCursorPosition(x + 1, y + i);
                for (int j = 1; j < width; j++)
                {
                    Console.Write(" ");
                }
            }
        }

    }
}