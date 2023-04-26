using System;
using System.Collections.Generic;

namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;
    
    public class BookAuthBody : Body //класс страницы брони комнаты(после кнопки забронировать) с вводимой инфой от клиента
    {
        public BookAuthBody(int x, int y, int height, int width, int typeOfRoom):base(x, y, height, width, "Бронь")
        {
            windows.Add(new Button<FunctionType>("Назад", x + 5, y + 35, 2, 20, (List<Body> list) =>
                {
                    if (typeOfRoom == 1)
                    {
                        list.Clear();
                        list.Add(new Room1DetailsBody(x,y,height,width));
                    }

                    if (typeOfRoom == 2)
                    {
                        list.Clear();
                        list.Add(new Room2DetailsBody(x,y,height,width));
                    }

                    if (typeOfRoom == 3)
                    {
                        list.Clear();
                        list.Add(new Room3DetailsBody(x,y,height,width));
                    }
                    return list;
                }
            ));
            
            windows.Add(new InputSpace(x + 5, y + 6,33, "ФИО:", 0));
            //((InputSpace)windows[0]).input.text = PersonInput.FullName;

            string email = "E-mail:";
            windows.Add(new InputSpace(x + 5, y + 9, 33, email, 1));
            
            string phone = "Телефон:";
            windows.Add(new InputSpace(x + 5, y + 12, 33, phone, 2));
            
            windows.Add(new InputSpace(x + 5, y + 15, 33, "Дата заезда:", 0));
            //((InputSpace)windows[0]).input.text = PersonInput.InDate;
            
            windows.Add(new InputSpace(x + 5, y + 18, 33, "Дата выезда:", 0));
            //((InputSpace)windows[0]).input.text = PersonInput.OutDate;
            
            windows.Add(new Button<FunctionType>("Забронировать", x + 50, y + 35, 2, 20, (List<Body> list) =>
                {
                    list.Clear();
                    list.Add(new BookingAcceptBody(x,y,height,width));
                    return list;
                }
            ));
        }
        
        public override void Draw()
        {
            base.Draw();

            if (ActiveButton > 2)
            {
                ((Button<FunctionType>)windows[ActiveButton]).
                    text.consoleColor = ActiveColor;
            }

            if (ActiveButton < 3)
            {
                var item = (InputSpace)windows[ActiveButton];

                Console.SetCursorPosition(item.x + item.field.text.Length + 1 + item.input.text.Length,
                    item.y + 1);

                Console.CursorVisible = true;
            }
        }
    }
}

