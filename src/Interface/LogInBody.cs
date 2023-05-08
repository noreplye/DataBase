namespace DataBase.Interface
{
    using client;
    using FunctionType = Func<List<Body>, List<Body>>;
    
    public class LogInBody : Body
    {
        public LogInBody(int x, int y, int height, int width) : base(x, y, height, width, "Регистрация")
        {
            windows.Add(new Button<FunctionType>("Назад", x + width / 2 - 25, y + 27, 2, 20, (List<Body> list) =>
            {
                list.Clear();
                list.Add(new AuthBody(x, y, height, width));
                return list;
            }
            ));

            windows.Add(new InputSpace(x + width /4 - 4, y + 9, 50, "ФИО:", 0));

            windows.Add(new InputSpace(x + width / 4 - 5, y + 12, 50, "Логин", 0));

            windows.Add(new InputSpace(x + width / 4 - 14, y + 15, 50, "Номер телефона", 0));

            windows.Add(new InputSpace(x + width / 4 - 7, y + 18, 50, "E-mail:", 1));

            windows.Add(new InputSpace(x + width / 4 - 7, y + 21, 50, "Пароль:", 2));

            windows.Add(new InputSpace(x + width / 4 - 19, y + 24, 50, "Подтвердите пароль:", 2));

            windows.Add(new Button<FunctionType>("ОК", x + width / 2+4 , y + 27, 2, 20, (List<Body> list) =>
                {
                    bool check = true;

                    for (int i = 1; i < 7; i++)
                        ((InputSpace)windows[i]).field.consoleColor = ConsoleColor.White;
                    var name = ((InputSpace)windows[1]).input.text.TrimStart();
                    var login = ((InputSpace)windows[2]).input.text.TrimStart();
                    var number = ((InputSpace)windows[3]).input.text.TrimStart();
                    var email = ((InputSpace)windows[4]).input.text.TrimStart();
                    var password = ((InputSpace)windows[5]).input.text.TrimStart();

                    var checker = BusinessLogic.CheckValid(name,login,password,number,email);
                    if (!((InputSpace)windows[1]).input.Validation())
                    {
                        check = false;
                        ((InputSpace)windows[1]).field.consoleColor = ConsoleColor.Red;
                    }
                    if (checker.Contains("l"))
                    {
                        check = false;
                        ((InputSpace)windows[2]).field.consoleColor = ConsoleColor.Red;
                    }
                    if (checker.Contains("n"))
                    {
                        check = false;
                        ((InputSpace)windows[3]).field.consoleColor = ConsoleColor.Red;
                    }
                    if (checker.Contains("e"))
                    {
                        check = false;
                        ((InputSpace)windows[4]).field.consoleColor = ConsoleColor.Red;
                    }
                    if (checker.Contains("p"))
                    {
                        check = false;
                        ((InputSpace)windows[5]).field.consoleColor = ConsoleColor.Red;
                    }
                    if (checker.Contains("p"))
                    {
                        check = false;
                        ((InputSpace)windows[6]).field.consoleColor = ConsoleColor.Red;
                    }
                    if (((InputSpace)windows[5]).input.text.TrimStart() != ((InputSpace)windows[6]).input.text.TrimStart())
                    {
                        check = false;
                        ((InputSpace)windows[5]).field.consoleColor = ConsoleColor.Red;
                        ((InputSpace)windows[6]).field.consoleColor = ConsoleColor.Red;
                    }
                    if (check)
                    {
                        var tryRegistr = BusinessLogic.Registration(name,login,password,number,email);
                        if (tryRegistr.Contains('e'))
                        {   
                            Console.SetCursorPosition(x + width / 2 - 10, y + 30);
                            Console.WriteLine("Аккаунт с такой почтой уже существует");
                            check = false;
                        }
                        if (tryRegistr.Contains('n'))
                        {
                            Console.SetCursorPosition(x + width / 2 - 10, y + 31);
                            Console.WriteLine("Аккаунт с таким номером уже существует");
                            check =false;
                        }
                        if (tryRegistr.Contains('l'))
                        {
                            Console.SetCursorPosition(x + width / 2 - 10, y + 32);
                            Console.WriteLine("Аккаунт с таким логином уже существует");
                            check = false;
                        }
                        Console.SetCursorPosition(x + width / 2 - 10, y + 33);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Enter - OK");
                        Console.ForegroundColor = ConsoleColor.White;
                        while(!(Console.ReadKey().Key==ConsoleKey.Enter));
                    }
                    if (check)
                    {
                      
                            list.Clear();
                            list.Add(new AuthBody(x, y, height, width));
                            return list;
                        // if (!DataBase.AddUser(((InputSpace)windows[0]).input.text,
                        //     ((InputSpace)windows[1]).input.text,
                        //     ((InputSpace)windows[2]).input.text))
                        // {
                        //     ((InputSpace)windows[1]).field.consoleColor = ConsoleColor.Red;
                        // }
                        // else
                        // {
                        //     list.Clear();
                        //     list.Add(new WelcomeBody(x, y, height, width));
                        //

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
                    if (ActiveButton == 7|| ActiveButton==0)
                    {
                        ((Button<FunctionType>)windows[ActiveButton]).text.consoleColor = ConsoleColor.White;
                    }

                    ActiveButton = (ActiveButton + 1) % windows.Count;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (ActiveButton == 7|| ActiveButton == 0)
                    {
                        ((Button<FunctionType>)windows[ActiveButton]).func(bodies);
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (ActiveButton < 7&& ActiveButton >0)
                    {
                        ((InputSpace)windows[ActiveButton]).input.DelSymbol();
                    }
                }
                else
                {
                    if (ActiveButton < 7&& ActiveButton >0)
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

            if (ActiveButton == 7|| ActiveButton == 0)
            {
                ((Button<FunctionType>)windows[ActiveButton]).
                    text.consoleColor = ActiveColor;
            }

            if (ActiveButton < 7 && ActiveButton > 0)
            {
                var item = (InputSpace)windows[ActiveButton];

                Console.SetCursorPosition(item.x + item.field.text.Length + 5 + item.input.text.Length, item.y + 1);

                Console.CursorVisible = true;
            }
        }
    }
}
