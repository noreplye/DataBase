using System;
using System.Collections.Generic;

namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;
    
    public class WelcomeBody : Body  // класс главной встречающей страницы
    {
        public WelcomeBody(int x, int y, int height, int width) : base(x, y, height, width, "Degenerate Hotel")
        {
            windows.Add(new Button<FunctionType>("Об отеле", x + 30, y + 10, 2, 20, (List<Body> list) =>
                {
                    list.Clear();
                    list.Add(new AboutHotelBody(x, y, height, width));
                    return list;
                }
            ));

            windows.Add(new Button<FunctionType>("Проживание", x + 70, y + 10, 2, 20, (List<Body> list) =>
                {
                    list.Clear();
                    list.Add(new LivingBody(x, y, height, width));
                    return list;
                }

            ));
            
            
            //забейте на нее короче
            
            //переделать эту штуку нормально(не надо) 
            // windows.Add(new FindRoom<FunctionType>( "Найти номер", x + 8, y+20, 4, 109, (List<Body> list) =>
            //     {
            //         list.Add(new FindRoomBody(x, y, height, width));
            //         return list;
            //     }
            //
            // ));
            // windows.Add(new Button<FunctionType>( "Найти номер", x + 8, y+20, 4, 109, (List<Body> list) =>
            //     {
            //         list.Add(new FindRoomBody(x, y, height, width));
            //         return list;
            //     }
            //
            // ));
            
        }     //ВМЕсто нее можно рисунок смешной сделать 
        

        public override void Draw()
        {
            base.Draw();
            
            ((Button<FunctionType>)windows[ActiveButton]).text.consoleColor = ActiveColor;
                
            

        }    
    }
}

