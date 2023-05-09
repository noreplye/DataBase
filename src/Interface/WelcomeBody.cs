﻿using System;
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
                    
                    list.Add(new LivingBody(x, y, height, width));
                    return list;
                }

            ));
            
            windows.Add(new Button<FunctionType>("Мои брони", x + 50, y + 15, 2, 20, (List<Body> list) =>
                {
                    
                    list.Add(new MyBronesBody(x, y, height, width));
                    return list;
                }

            ));
            
            

            
        }      
        

        public override void Draw()
        {
            base.Draw();
            
            ((Button<FunctionType>)windows[ActiveButton]).text.consoleColor = ActiveColor;
                
            

        }    
    }
}

