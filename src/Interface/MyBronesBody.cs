namespace DataBase.Interface
{
    using client;
    using FunctionType = Func<List<Body>, List<Body>>;
    public class MyBronesBody : Body
    {
        public string user_id;
        public MyBronesBody(int x, int y, int height, int width,string user_id) : base(x, y, height, width, "Мои брони")
        {   
            this.user_id = user_id;
            windows.Add(new Button<FunctionType>("Назад", x + 5, y + 35, 2, 20, (List<Body> list) =>
                {
                    list.Clear();
                    var newWindow = new WelcomeBody(x, y, height, width);
                    newWindow.user_id = user_id;
                    list.Add(newWindow);
                    return list;
                }
            ));
            Bookingobject myBookings = BusinessLogic.GetBookings(user_id);
            if (myBookings.bookings.Length==0)
            {
                windows.Add(new Names(x + 4*width / 11, y + 20, "Вы ещё не забронировали номер в отеле."));
            }
            for (int i = 0; i < myBookings.bookings.Length; i++)
            {   
                windows.Add(new Button<FunctionType>("Отменить", x + 100, y + 9+i*3, 2, 15, (List<Body> list) =>
                {
                    var newWindow = new MyBronesBody(x, y, height, width, user_id);
                    list.Clear();
                    list.Add(newWindow);
                    return list;
                }
            ));
            }
            windows.Add(new Names(x + 3, y + 7, "Дата заезда - дата выезда"));
            windows.Add(new Names(x + 33, y + 7, "Номер брони"));
            windows.Add(new Names(x + 50, y + 7, "Тип комнаты"));
            windows.Add(new Names(x + 70, y + 7, "Номер комнаты"));
            windows.Add(new Names(x + 90, y + 7, "Цена"));
            for (int i = 0; i < myBookings.bookings.Length; i++)
            {
                windows.Add(new Names(x + 3, y + 10 + i * 3, myBookings.bookings[i].comeDate+"-"+ myBookings.bookings[i].outDate));
                windows.Add(new Names(x + 36, y + 10 + i * 3, myBookings.bookings[i].id));
                windows.Add(new Names(x + 50, y + 10 + i * 3, BusinessLogic.GetRoomType(myBookings.bookings[i].room_number).quality));
                windows.Add(new Names(x + 74, y + 10 + i * 3, "№"+myBookings.bookings[i].room_number));
                windows.Add(new Names(x + 90, y + 10 + i * 3, BusinessLogic.GetRoomType(myBookings.bookings[i].room_number).price));
            }
            
        }
        public override List<Body> KeyDetect(ConsoleKeyInfo keyInfo, List<Body> bodies)
        {
            KeyPressed = false;
            bodies = base.KeyDetect(keyInfo, bodies);
            var myBookings = BusinessLogic.GetBookings(user_id);
            if (!KeyPressed)
            {
                if (keyInfo.Key == ConsoleKey.Tab)
                {
                    if (ActiveButton < myBookings.bookings.Length + 1)
                    {
                        ((Button<FunctionType>)windows[ActiveButton]).text.consoleColor = ConsoleColor.White;
                        
                    }

                    ActiveButton = (ActiveButton + 1) % windows.Count;
                    if (ActiveButton == myBookings.bookings.Length + 1)
                    {
                        ActiveButton = 0;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (((Button<FunctionType>)windows[ActiveButton]).text.text == "Отменить")
                    {   if (myBookings.bookings.Length > 0)
                        {
                                BusinessLogic.DeleteBooking(myBookings.bookings[ActiveButton-1].id);
                        }
                        
                    }
                    if (ActiveButton < myBookings.bookings.Length + 1)
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