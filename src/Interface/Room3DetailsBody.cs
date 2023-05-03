namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;
    
    public class Room3DetailsBody : Body // класс вкладки "Подробнее" 
    {

        public Room3DetailsBody(int x, int y, int height, int width) : base(x, y, height, width, "Подробнее: комната '" + client.DataBase.InitRoom(client.BusinessLogic.ServerMessage(1, "3")).name + "'")
        {
            windows.Add(new Button<FunctionType>("Назад", x + 5, y + 35, 2, 20, (List<Body> list) =>
            {
                list.Clear();
                list.Add(new LivingBody(x, y, height, width));
                return list;
            }
            ));
            windows.Add(new Button<FunctionType>("Забронировать", x + 100, y + 35, 2, 20, (List<Body> list) =>
            {
                list.Add(new BookAuthBody(x, y, height, width, 2));
                return list;
            }
            ));
            windows.Add(new Names(x + 10, y + 8, "Описание: " + client.DataBase.InitRoom(client.BusinessLogic.ServerMessage(1, "3")).description));
            windows.Add(new Names(x + 10, y + 10, "Тип комнаты: " + client.DataBase.InitRoom(client.BusinessLogic.ServerMessage(1, "3")).quality));
            windows.Add(new Names(x + 10, y + 12, "Количество мест: " + client.DataBase.InitRoom(client.BusinessLogic.ServerMessage(1, "3")).seats));
            windows.Add(new Names(x + 10, y + 14, "Цена комнаты: " + client.DataBase.InitRoom(client.BusinessLogic.ServerMessage(1, "3")).price));
        }

        public override void  Draw()
        {
            base.Draw();

            ((Button<FunctionType>)windows[ActiveButton]).
                text.consoleColor = ActiveColor;
            
        }
    }
}