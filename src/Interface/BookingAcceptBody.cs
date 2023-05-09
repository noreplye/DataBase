namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;
    
    public class BookingAcceptBody : Body//класс заявки о брони (самый конец короче все прошло саксессфулл)
    {
        public BookingAcceptBody(int x, int y, int height, int width):base(x, y, height, width, "Degerate Hotel: номер забронирован успешно!")
        {
            windows.Add(new Button<FunctionType>("Главное меню", x + 5, y + 35, 2, 20, (List<Body> list) =>
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

