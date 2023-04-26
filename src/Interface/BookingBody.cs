namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;
    
    public class BookingBody : Body//класс Бронь (кнопка "забронировать" в теле "подробнее"
    {
        public BookingBody(int x, int y, int height, int width):base(x, y, height, width, "Забронировать")
        {
            
        }
    }
}

