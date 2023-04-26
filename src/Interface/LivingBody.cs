﻿namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;
    
    public class LivingBody : Body  // класс вкладки "Проживание" доделать 
    {
        // private string room1;
        // private string room2;
        // private string room3;
        
        public LivingBody(int x, int y, int height, int width):base(x, y, height, width, "Проживание")
        {
            windows.Add(new Button<FunctionType>("Назад", x + 5, y + 35, 2, 20, (List<Body> list) =>
                {
                    list.Clear();
                    list.Add(new WelcomeBody(x,y,height,width));
                    return list;
                }
            ));
            //
            // room1 = "Одноместный стандарт";
            //
            windows.Add(new Button<FunctionType>("Подробнее", x + 100, y + 10, 2, 15, (List<Body> list) =>
                {
                    
                    list.Add(new Room1DetailsBody(x, y, height, width));
                    return list;
                }
            ));
            
            
           // room2 = "Двуместный стандарт";
            
            windows.Add(new Button<FunctionType>("Подробнее", x + 100, y + 20, 2, 15, (List<Body> list) =>
                {
                    list.Add(new Room2DetailsBody(x, y, height, width));
                    return list;
                }
            ));
            
            
            //room3 = "Семейный";
            
            windows.Add(new Button<FunctionType>("Подробнее", x + 100, y + 30, 2, 15, (List<Body> list) =>
                {
                    list.Add(new Room3DetailsBody(x, y, height, width));
                    return list;
                }
            ));
            


        }
        


        public override void  Draw()
        {
            base.Draw();
            // Console.SetCursorPosition(5,10);
            // Console.WriteLine(room1);
            // Console.WriteLine(room2);
            // Console.WriteLine(room3);
            
            ((Button<FunctionType>)windows[ActiveButton]).
                text.consoleColor = ActiveColor;
            
        }
    }
}

