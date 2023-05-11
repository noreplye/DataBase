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
        public string user_id;
        public BookAuthBody(int x, int y, int height, int width, int typeOfRoom,string user_id):base(x, y, height, width, "Бронь")
        {
            this.user_id = user_id;
            windows.Add(new Button<FunctionType>("Назад", x + 5, y + 25, 2, 20, (List<Body> list) =>
            {
                if (typeOfRoom == 1) //выбор по типу комнаты, в зависимости от того, на кнопку какой комнаты нажали
                {
                    list.Clear();
                    var newWindow = new Room1DetailsBody(x, y, height, width);// страница румы первого типа
                    newWindow.user_id = user_id;
                    list.Add(newWindow);
                    return list; 
                }

                if (typeOfRoom == 2)
                {
                    list.Clear();
                    var newWindow = new Room2DetailsBody(x, y, height, width);// страница румы второго типа
                    newWindow.user_id = user_id;
                    list.Add(newWindow);
                    return list; 
                }

                if (typeOfRoom == 3)
                {
                    list.Clear();
                    var newWindow = new Room2DetailsBody(x, y, height, width);// страница румы третьего типа
                    newWindow.user_id = user_id;
                    list.Add(newWindow);
                    return list; 
                }
                return list;
            }
            ));
            windows.Add(new InputSpace(x + 5, y + 10, 33, "Дата вьезда:", 0));

            windows.Add(new InputSpace(x + 5, y + 15, 33, "Дата выезда:", 0));

            
            
            
            windows.Add(new Button<FunctionType>("Забронировать", x + 50, y + 25, 2, 20, (List<Body> list) =>
                {
                    string result = BusinessLogic.Book(user_id, typeOfRoom.ToString(), ((InputSpace)windows[1]).input.text, ((InputSpace)windows[2]).input.text);
                    if (!(result.Contains("wrongCount") || result.Contains("wrongDate")|| result.Contains("ExceptionDate") || result == null|| result.Contains("totalDays")|| result.Contains("after")))
                    {
                        Console.SetCursorPosition(x + 30, y + 30);
                        Console.WriteLine("Вы успешно забронировали номер в отеле, для просмотра перейдите в пункт мои брони");
                        Console.SetCursorPosition(x + 30, y + 31);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enter - OK");
                        Console.ForegroundColor = ConsoleColor.White;
                        while (!(Console.ReadKey().Key == ConsoleKey.Enter)) ;
                        list.Clear();
                        if (typeOfRoom == 1)
                        {
                            var newWindow = new Room1DetailsBody(x, y, height, width);// страница румы первого типа
                            newWindow.user_id = user_id;
                            list.Add(newWindow);
                        }
                        if (typeOfRoom == 2)
                        {
                            var newWindow = new Room2DetailsBody(x, y, height, width);// страница румы первого типа
                            newWindow.user_id = user_id;
                            list.Add(newWindow);
                        }
                        if (typeOfRoom == 3)
                        {
                            var newWindow = new Room3DetailsBody(x, y, height, width);// страница румы первого типа
                            newWindow.user_id = user_id;
                            list.Add(newWindow);
                        }
                        return list;
                    }
                    if (result.Contains("wrongCount"))
                    {
                        Console.SetCursorPosition(x + 30, y + 30);
                        Console.WriteLine("Вы превысили максимальное количество возможных броней");
                        Console.SetCursorPosition(x + 30, y + 31);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enter - OK");
                        Console.ForegroundColor = ConsoleColor.White;
                        while (!(Console.ReadKey().Key == ConsoleKey.Enter)) ;
                    }
                    if (result.Contains("wrongDate"))
                    {
                        Console.SetCursorPosition(x + 30, y + 30);
                        Console.WriteLine("На эту дату не осталось свободных номеров");
                        Console.SetCursorPosition(x + 30, y + 31);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enter - OK");
                        Console.ForegroundColor = ConsoleColor.White;
                        while (!(Console.ReadKey().Key == ConsoleKey.Enter)) ;
                    }
                    if (result.Contains("ExceptionDate"))
                    {
                        Console.SetCursorPosition(x + 30, y + 30);
                        Console.WriteLine("Вы неправильно ввели дату. Формат ДД/ММ/ГГГГ");
                        Console.SetCursorPosition(x + 30, y + 31);
                        Console.WriteLine("Пример : 15/05/2023");
                        Console.SetCursorPosition(x + 30, y + 32);
                        Console.WriteLine("Забронировать можно только на ближайшие 30 дней");
                        Console.SetCursorPosition(x + 30, y + 33);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enter - OK");
                        Console.ForegroundColor = ConsoleColor.White;
                        while (!(Console.ReadKey().Key == ConsoleKey.Enter)) ;
                    }
                    if (result.Contains("totalDays"))
                    {
                        Console.SetCursorPosition(x + 30, y + 30);
                        Console.WriteLine("Вы превысили максимальное число дней для бронирования. Максимум 30 дней.");
                        Console.SetCursorPosition(x + 30, y + 31);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enter - OK");
                        Console.ForegroundColor = ConsoleColor.White;
                        while (!(Console.ReadKey().Key == ConsoleKey.Enter)) ;

                    }
                    if (result.Contains("after"))
                    {
                        Console.SetCursorPosition(x + 30, y + 30);
                        Console.WriteLine("Дата выезда должна быть после даты вьезда.");
                        Console.SetCursorPosition(x + 30, y + 31);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enter - OK");
                        Console.ForegroundColor = ConsoleColor.White;
                        while (!(Console.ReadKey().Key == ConsoleKey.Enter)) ;

                    }

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
                    if (ActiveButton ==0|| ActiveButton == 3)
                    {
                        ((Button<FunctionType>)windows[ActiveButton]).text.consoleColor = ConsoleColor.White;
                    }

                    ActiveButton = (ActiveButton + 1) % windows.Count;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (ActiveButton == 0 || ActiveButton == 3)
                    {
                        ((Button<FunctionType>)windows[ActiveButton]).func(bodies);
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (ActiveButton == 1 || ActiveButton == 2)
                    {
                        ((InputSpace)windows[ActiveButton]).input.DelSymbol();
                    }
                }
                else
                {
                    if (ActiveButton == 1 || ActiveButton == 2)
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

            if (ActiveButton == 0 || ActiveButton == 3)
            {
                ((Button<FunctionType>)windows[ActiveButton]).
                    text.consoleColor = ActiveColor;
            }

            if (ActiveButton == 1 || ActiveButton == 2)
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

