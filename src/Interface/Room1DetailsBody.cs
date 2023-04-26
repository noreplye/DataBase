namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;
    
    public class Room1DetailsBody : Body // класс вкладки "Подробнее" 
    {
        public Room1DetailsBody(int x, int y, int height, int width) : base(x, y, height, width, "Подробнее")
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
                    list.Add(new BookAuthBody(x, y, height,width, 1));
                    return list;
                }
            ));
    }

        public override void  Draw()
        {
            base.Draw();
            
            ((Button<FunctionType>)windows[ActiveButton]).
                text.consoleColor = ActiveColor;
            
        }
    }
}

