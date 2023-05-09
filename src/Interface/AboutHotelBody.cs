using System;
using System.Collections.Generic;

namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;
    
    public class AboutHotelBody : Body // класс раздела "об отеле" из верхнего меню
    {
        public string[] Info;
        public AboutHotelBody(int x, int y, int height, int width) : base(x, y, height, width, "Degenerate Hotel")
        { 
            windows.Add(new Button<FunctionType>("Назад", x + 5, y + 35, 2, 20, (List<Body> list) =>
                {
                    list.Clear();
                    list.Add(new WelcomeBody(x,y,height,width));
                    return list;
                }
            ));

            Info = new string[ ]{"Новый современный Degenerate Hotel, как и все отели сети, исключительно удобно расположен.",
                "Всего 40 минут езды от Международного аэропорта Владивостока или 5 минут от ж/д вокзала, и вы в центральной части города.",
                "Отель идеально подходит как для рабочих, так и личных поездок с семьей.",
                "Высокоскоростной интернет позволит вам с комфортом работать и участвовать в онлайн-встречах.",
                " ","Остановившись в Degenerate Hotel, вы сможете посещать фитнес-центр, а ужин в ресторане средиземноморской кухни станет",
                "лучшим завершением дня.","Если же потребуется провести деловую встречу за чашкой кофе - лобби бар отеля к вашим услугам.",
                "Degenerate Hotel совмещает все: комфорт и сервис, дизайн и европейский уровень.","И даже если ваш визит во Владивосток будет носить только деловой характер, будьте уверены, проживание в нашем отеле оставит",
                "воспоминания как о приятном отпуске."
            };
        }
        public override List<Body> KeyDetect(ConsoleKeyInfo keyInfo, List<Body> bodies)
        {
            KeyPressed = false;
            bodies = base.KeyDetect(keyInfo, bodies);
        
            if (!KeyPressed)
            {
                if (keyInfo.Key == ConsoleKey.Tab)
                {
                    if (ActiveButton < 4)
                    {
                        ((Button<FunctionType>)windows[ActiveButton]).text.consoleColor = ConsoleColor.White;
                    }
        
                    ActiveButton = (ActiveButton + 1) % windows.Count;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (ActiveButton < 4)
                    {
                        ((Button<FunctionType>)windows[ActiveButton]).func(bodies);
                    }
                }
            }
            return bodies;
        }
        public override void Draw()
        {
            base.Draw(); // базовая отрисовка всех элементов страницы 
            
            for (int i = 0; i < Info.Length; i++) // вывод инфы об отеле 
            {
                Console.SetCursorPosition(12,10 + i);
                Console.WriteLine(Info[i]);
            }

            ((Button<FunctionType>)windows[ActiveButton]). //передача цвета активной кнопке 
                text.consoleColor = ActiveColor;

        }
    }
}
