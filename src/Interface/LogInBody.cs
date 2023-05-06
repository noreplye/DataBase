namespace DataBase.Interface
{
    using FunctionType = Func<List<Body>, List<Body>>;
    
    public class LogInBody : Body
    {
        public LogInBody(int x, int y, int height, int width) : base(x, y, height, width, "Регистрация")
        {
            windows.Add(new InputSpace(x + width /4 - 4, y + 12, 50, "ФИО:", 0));

            windows.Add(new InputSpace(x + width / 4 - 7, y + 15, 50, "E-mail:", 1));

            windows.Add(new InputSpace(x + width / 4 - 7, y + 18, 50, "Пароль:", 2));

            windows.Add(new InputSpace(x + width / 4 - 19, y + 21, 50, "Подтвердите пароль:", 2));

            windows.Add(new Button<FunctionType>("ОК", x + width /2 - 10, y + 24, 2, 20, (List<Body> list) =>
                {
                    bool check = true;

                    for (int i = 0; i < 4; i++)
                        ((InputSpace)windows[i]).field.consoleColor = ConsoleColor.White;

                    if (!((InputSpace)windows[0]).input.Validation())
                    {
                        check = false;
                        ((InputSpace)windows[0]).field.consoleColor = ConsoleColor.Red;
                    }
                    if (!((InputSpace)windows[1]).input.Validation())
                    {
                        check = false;
                        ((InputSpace)windows[1]).field.consoleColor = ConsoleColor.Red;
                    }
                    if (!((InputSpace)windows[2]).input.Validation())
                    {
                        check = false;
                        ((InputSpace)windows[2]).field.consoleColor = ConsoleColor.Red;
                    }
                    if (((InputSpace)windows[2]).input.text != ((InputSpace)windows[3]).input.text)
                    {
                        check = false;
                        ((InputSpace)windows[2]).field.consoleColor = ConsoleColor.Red;
                        ((InputSpace)windows[3]).field.consoleColor = ConsoleColor.Red;
                    }

                    if (check)
                    {
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
                        // }
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
                    if (ActiveButton == 4)
                    {
                        ((Button<FunctionType>)windows[ActiveButton]).text.consoleColor = ConsoleColor.White;
                    }

                    ActiveButton = (ActiveButton + 1) % windows.Count;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (ActiveButton == 4)
                    {
                        ((Button<FunctionType>)windows[ActiveButton]).func(bodies);
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (ActiveButton < 4)
                    {
                        ((InputSpace)windows[ActiveButton]).input.DelSymbol();
                    }
                }
                else
                {
                    if (ActiveButton < 4)
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

            if (ActiveButton == 4)
            {
                ((Button<FunctionType>)windows[ActiveButton]).
                    text.consoleColor = ActiveColor;
            }

            if (ActiveButton < 4)
            {
                var item = (InputSpace)windows[ActiveButton];

                Console.SetCursorPosition(item.x + item.field.text.Length + 5 + item.input.text.Length, item.y + 1);

                Console.CursorVisible = true;
            }
        }
    }
}
