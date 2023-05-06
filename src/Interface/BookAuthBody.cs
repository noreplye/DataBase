using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using client;

namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;

    public class BookAuthBody : Body //класс страницы брони комнаты(после кнопки забронировать) с вводимой инфой от клиента
    {
        public BookAuthBody(int x, int y, int height, int width, int typeOfRoom):base(x, y, height, width, "Бронь")
        { 

            windows.Add(new InputSpace(x + 5, y + 6,33, "ФИО:", 0));

            windows.Add(new InputSpace(x + 5, y + 9, 33,"E-mail:", 1));

            windows.Add(new InputSpace(x + 5, y + 12, 33, "Телефон:", 2));

            windows.Add(new InputSpace(x + 5, y + 15, 33, "Дата заезда:", 3));

            windows.Add(new InputSpace(x + 5, y + 18, 33, "Дата выезда:", 4));

            windows.Add(new Button<FunctionType>("Назад", x + 5, y + 35, 2, 20, (List<Body> list) =>
                {
                    if (typeOfRoom == 1) //выбор по типу комнаты, в зависимости от того, на кнопку какой комнаты нажали
                    {
                        list.Remove(this);
                        list.Add(new Room1DetailsBody(x,y,height,width)); // страница румы первого типа
                    }
            
                    if (typeOfRoom == 2)
                    {
                        list.Remove(this);
                        list.Add(new Room2DetailsBody(x,y,height,width)); // страница румы второго типа
                    }
            
                    if (typeOfRoom == 3)
                    {
                        list.Remove(this);
                        list.Add(new Room3DetailsBody(x,y,height,width)); // страница румы третьего типа
                    }
                    return list;
                }
            ));
            
            
            windows.Add(new Button<FunctionType>("Забронировать", x + 50, y + 35, 2, 20, (List<Body> list) =>
                {
                    // if (DataBase.( функция проверки на существование пользователя и добавление к нему дат и номера брони )(((InputSpace)windows[0]).Text(),
                    //     ((InputSpace)windows[1]).Text(), ((InputSpace)windows[2]).Text(), ((InputSpace)windows[3]).Text(), ((InputSpace)windows[4]).Text()))
                    // {
                    //     list.Clear();
                    //     list.Add(new BookingAcceptBody(x, y, height, width));
                              // сюда надо впихнуть фунцию для добавления брони хз 
                    // }
                    // else
                    // {
                    //     ((InputSpace)windows[0]).field.consoleColor = ConsoleColor.Red;
                    // }
                    //
                    return list;
                }
            ));
        }
        
        public override List<Body> KeyDetect(ConsoleKeyInfo keyInfo, List<Body> bodies)
        {
            KeyPressed = false;
            bodies = base.KeyDetect(keyInfo, bodies);

            if (!KeyPressed)
            {
                if (keyInfo.Key == ConsoleKey.Tab)
                {
                    if (ActiveButton > 1)
                    {
                        ((Button<FunctionType>)windows[ActiveButton]).text.consoleColor = ConsoleColor.White;
                    }

                    ActiveButton = (ActiveButton + 1) % windows.Count;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (ActiveButton > 1)
                    {
                        ((Button<FunctionType>)windows[ActiveButton]).func(bodies);
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (ActiveButton < 2)
                    {
                        ((InputSpace)windows[ActiveButton]).input.DelSymbol();
                    }
                }
                else
                {
                    if (ActiveButton < 2)
                    {
                        ((InputSpace)windows[ActiveButton]).input.AddSymbol(keyInfo.KeyChar);
                    }
                }
            }

            return bodies;
        }


        public override void Draw()
        {
            base.Draw();

            if (ActiveButton > 1)
            {
                ((Button<FunctionType>)windows[ActiveButton]).
                    text.consoleColor = ActiveColor;
            }

            if (ActiveButton < 2)
            {
                var item = (InputSpace)windows[ActiveButton];

                Console.SetCursorPosition(item.x + item.field.text.Length + 5 + item.input.text.Length, item.y + 1);

                Console.CursorVisible = true;
            }
        
            // var item = (InputSpace)windows[ActiveButton];
            //
            // Console.SetCursorPosition((item.x + item.field.text.Length + 1 + item.input.text.Length),
            //     (item.y + 1));
            // try
            // {
            //     ((Button<FunctionType>)windows[ActiveButton]).text.consoleColor = ActiveColor;
            // }
            // catch (Exception)
            // {
            //     try
            //     {
            //         var item = (InputSpace)windows[ActiveButton];
            //
            //         Console.SetCursorPosition((item.x + item.field.text.Length + 1 + item.input.text.Length),
            //             (item.y + 1));
            //
            //         Console.CursorVisible = true;
            //     }
            //     catch (Exception e)
            //     {
            //
            //     }
            // } 
            // ((Button<FunctionType>)windows[ActiveButton]).
            //     text.consoleColor = ActiveColor;
            //недоделанное переключение курсора в полях ввода, не работает чета 
            // if (ActiveButton == windows.Count - 2||ActiveButton == windows.Count-1 )
            // {
            //     ((Button<FunctionType>)windows[ActiveButton]).
            //         text.consoleColor = ActiveColor;
            // }
            
            // else
            // {
            //     var item = (InputSpace)windows[ActiveButton];
            //
            //     Console.SetCursorPosition((item.x + item.field.text.Length + 1 + item.input.text.Length), (item.y + 1));
            //
            //     Console.CursorVisible = true;
            // }
            
        }
    }
}

