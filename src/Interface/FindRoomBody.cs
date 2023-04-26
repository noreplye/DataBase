namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;
    
    public class FindRoomBody : Body  //класс вкладки "Найти номер"
    {
        public FindRoomBody(int x, int y, int height, int width) : base(x, y, height, width, "Найти номер")
        {
            windows.Add(new Button<FunctionType>("Назад", x + 5, y + 35, 2, 20, (List<Body> list) =>
                {
                    list.Clear();
                    list.Add(new WelcomeBody(x,y,height,width));
                    return list;
                }
            ));
        }

        public override void Draw()
        {
            base.Draw();
            
            ((Button<FunctionType>)windows[ActiveButton]).
                text.consoleColor = ActiveColor;
            
        }
    }
}

