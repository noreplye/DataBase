namespace DataBase.Interface
{
    using client;
    using System.Xml.Serialization;
    using FunctionType = Func<List<Body>, List<Body>>;
    
    public class AuthBody : Body
    {
        public AuthBody(int x, int y, int height, int width) : base(x, y, height, width, "Degenerate Hotel: Авторизация")
        {
              string email = "Логин, E-mail или номер телефона:";

            windows.Add(new InputSpace(x + width/4 - 29, y + 12, 50, email, 1));

            string password = "Пароль:";

            windows.Add(new InputSpace(x + width/4 - 3, y + 15, 50, password, 2));

            string signIn = "Войти";
            
            windows.Add(new Button<FunctionType>(signIn, x + width / 3 - 1, y + 18, 2, 22, (List<Body> list) =>
                {
                    var first = ((InputSpace)windows[0]).input.text.TrimStart();
                    var second = ((InputSpace)windows[1]).input.text.TrimStart();
                    string checker = BusinessLogic.CheckValid("", ((InputSpace)windows[0]).input.text, ((InputSpace)windows[1]).input.text, ((InputSpace)windows[0]).input.text, ((InputSpace)windows[0]).input.text);
                    if (!(checker.Contains("e")&& checker.Contains("n") && checker.Contains("l"))&&(!checker.Contains("p")))
                    {
                        var tryLogin = BusinessLogic.Login(first, second);
                        if (tryLogin != "wrong")
                        {
                            list.Clear();
                            var newWindow = new WelcomeBody(x, y, height, width);
                            newWindow.user_id = tryLogin;
                            list.Add(newWindow);
                        }
                        else
                        {
                            ((InputSpace)windows[0]).field.consoleColor = ConsoleColor.Red;
                            ((InputSpace)windows[1]).field.consoleColor = ConsoleColor.Red;
                        }
                            
                    }
                    else
                    {
                        ((InputSpace)windows[0]).field.consoleColor = ConsoleColor.Red;
                        ((InputSpace)windows[1]).field.consoleColor = ConsoleColor.Red;
                    }
                    
                    


                    return list;
                }
            ));

            string signUp = "Зарегистрироваться";

            windows.Add(new Button<FunctionType>(signUp, x + width/3 - 1, y + 21, 2, 22, (List<Body> list) =>
                {  
                    list.Clear();
                    list.Add(new LogInBody(x, y, height, width));

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
        }
    }
}