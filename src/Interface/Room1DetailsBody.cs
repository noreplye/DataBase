using System.ComponentModel;
using client;

namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;

    public class Room1DetailsBody : Body // класс вкладки "Подробнее" 
    {
        public string user_id;
        public Room1DetailsBody(int x, int y, int height, int width) : base(x, y, height, width, "Подробнее: комната '"+ client.DataBase.InitRoom(client.BusinessLogic.ServerMessage(1, "1")).name+"'")
        {
            
            
            windows.Add(new Button<FunctionType>("Назад", x + 5, y + 35, 2, 20, (List<Body> list) =>
                {
                    list.Clear();
                    var newWindow = new LivingBody(x, y, height, width);
                    newWindow.user_id = user_id;
                    list.Add(newWindow);
                    return list;
                }
            ));

            windows.Add(new Button<FunctionType>("Забронировать", x + 100, y + 35, 2, 20, (List<Body> list) =>
                {
                    list.Clear();
                    list.Add(new BookAuthBody( x, y, height, width, 1,user_id));
                    return list;
                }
            ));
            windows.Add(new Names(x + 10, y + 8, "Описание: " + client.DataBase.InitRoom(client.BusinessLogic.ServerMessage(1, "1")).description));
            windows.Add(new Names(x + 10, y + 10, "Тип комнаты: "+client.DataBase.InitRoom(client.BusinessLogic.ServerMessage(1, "1")).quality));
            windows.Add(new Names(x + 10, y + 12, "Количество мест: " + client.DataBase.InitRoom(client.BusinessLogic.ServerMessage(1, "1")).seats));
            windows.Add(new Names(x + 10, y + 14, "Цена комнаты: " + client.DataBase.InitRoom(client.BusinessLogic.ServerMessage(1, "1")).price));
        }
        public override List<Body> KeyDetect(ConsoleKeyInfo keyInfo, List<Body> bodies)
        {
            KeyPressed = false;
            bodies = base.KeyDetect(keyInfo, bodies);

            if (!KeyPressed)
            {
                if (keyInfo.Key == ConsoleKey.Tab)
                {
                    if (ActiveButton < 2)
                    {
                        ((Button<FunctionType>)windows[ActiveButton]).text.consoleColor = ConsoleColor.White;
                    }

                    ActiveButton = (ActiveButton + 1) % windows.Count;
                    if (ActiveButton == 2)
                    {
                        ActiveButton = 0;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (ActiveButton < 2)
                    {
                        ((Button<FunctionType>)windows[ActiveButton]).func(bodies);
                    }
                }
            }
            return bodies;
        }
        public override void Draw()
        {
            base.Draw();
            ((Button<FunctionType>)windows[ActiveButton]).text.consoleColor = ActiveColor;

        }
    }
    
}

