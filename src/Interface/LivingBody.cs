namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;
    
    public class LivingBody : Body  // класс вкладки "Проживание" доделать 
    {


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
                    list.Clear();
                    list.Add(new Room1DetailsBody(x, y, height, width));
                    return list;
                }
            ));
            
            
           // room2 = "Двуместный стандарт";
            
            windows.Add(new Button<FunctionType>("Подробнее", x + 100, y + 20, 2, 15, (List<Body> list) =>
                {
                    list.Clear();
                    list.Add(new Room2DetailsBody(x, y, height, width));
                    return list;
                }
            ));
            
            
            //room3 = "Семейный";
            
            windows.Add(new Button<FunctionType>("Подробнее", x + 100, y + 30, 2, 15, (List<Body> list) =>
                {
                    list.Clear();
                    list.Add(new Room3DetailsBody(x, y, height, width));
                    return list;
                }
            ));

            
            windows.Add(new Names(x + 10, y + 11, client.DataBase.InitRoom(client.BusinessLogic.ServerMessage(1, "1")).name));
            windows.Add(new Names(x + 10, y + 21, client.DataBase.InitRoom(client.BusinessLogic.ServerMessage(1, "2")).name));
            windows.Add(new Names(x + 10, y + 31, client.DataBase.InitRoom(client.BusinessLogic.ServerMessage(1, "3")).name));

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

