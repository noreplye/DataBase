namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;
    public class MyBronesBody : Body
    {
        public MyBronesBody(int x, int y, int height, int width) : base(x, y, height, width, "Мои брони")
        {
            windows.Add(new Button<FunctionType>("Назад", x + 5, y + 35, 2, 20, (List<Body> list) =>
                {
                    list.Clear();
                    list.Add(new WelcomeBody(x,y,height,width));
                    return list;
                }
            ));
            
            windows.Add(new Button<FunctionType>("Удалить", x + 100, y + 10, 2, 15, (List<Body> list) =>
                {
                    
                    list.Add(new Room1DetailsBody(x, y, height, width));
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