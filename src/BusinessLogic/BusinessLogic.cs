using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace client
{
    public class BusinessLogic
    {   

        public static bool IsServerOnline(IPEndPoint tcpEndPoint, Socket tcpSocket)
        {
                try
                {
                    tcpSocket.Connect(tcpEndPoint);
                    //Console.WriteLine("Connected!");
                }
                catch (Exception)
                {   
                    //комменты для того чтобы узнать ошибку... алгоритм взял с сайта майкрософака...
                    //Console.WriteLine("Source : " + e.Source);
                    //Console.WriteLine("Message : " + e.Message);
                    return false;
                }
            return true;
        }

        public static bool CheckConnection()
        {
            var check = SocketCreate();
            while (check == null)
            {
                
                Random random = new Random((int)DateTime.Now.Ticks);
                int curpos=random.Next(30);
                int xcurpos=random.Next(30,50);
                Console.Clear();
                Console.SetCursorPosition(xcurpos, curpos);
                Console.WriteLine("Ошибка. Невозможно подключиться к серверу.");
                Console.SetCursorPosition(xcurpos, curpos+1);
                Console.WriteLine("Проверьте подключение к сети интернет.");
                Console.SetCursorPosition(xcurpos, curpos+2);
                Console.WriteLine("Возможно ведутся технические работы.");
                Console.SetCursorPosition(xcurpos, curpos+3);
                Console.WriteLine("Нажмите любую клавишу чтобы попытаться подключиться");
                Console.SetCursorPosition(xcurpos, curpos+4);
                Console.WriteLine("Нажатие клавиши Esc приведёт к завершению работы");

                if (Console.ReadKey().Key == ConsoleKey.Escape) Environment.Exit(1);
                check = SocketCreate();
            }
            check.Close();
            return true;
        }

        public static Socket SocketCreate()
        {
            const string ip = "127.0.0.1"; //Ip локальный
            const int port = 8080; //Port любой
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port); // класс конечной точки (точка подключения), принимает Ip and Port
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // сокет объявляем, через него все проходит + прописываем дефолтные характеристики для TCP
            if (IsServerOnline(tcpEndPoint, tcpSocket)) return tcpSocket;
            else return null;

        }
        public static string ServerMessage(int choice, string message)
        {   while (true)
            {   if (CheckConnection())
                {
                    byte[] bytesA = BitConverter.GetBytes(choice);
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    byte[] BytesToSend = bytesA.Concat(data).ToArray();
                    var tcpSocket = SocketCreate();
                    if (tcpSocket == null) return null;
                    while (true)
                    {
                        tcpSocket.Send(BytesToSend);
                        var buffer = new byte[256];
                        var size = 0;
                        var answer = new StringBuilder();
                        try
                        {
                            do
                            {
                                size = tcpSocket.Receive(buffer);
                                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                            }
                            while (tcpSocket.Available > 0);

                        }
                        catch (Exception)
                        {
                            return null;
                        }
                        finally
                        {
                            tcpSocket.Close();
                        }
                        return answer.ToString();
                    }
                }    
            }
        }

        public static string Registration(string name, string email, string number, string comeDate, string outDate)
        {
            User user = new User();
            user.name = name;
            user.email = email;
            user.number = number;
            user.comeDate = comeDate;
            user.outDate = outDate;
            string client = DataBase.GetUserString(user);
            //Console.WriteLine(user);
            return client;
        }
    }
}
//console.writeline("пришли мне: \n1 - комнаты\n2 - клиентов");
//choose = console.readline();
//do {
//    if (choose == "1")
//    {
//        roomx = servermessage("1");
//    }
//    if (choose == "2")
//    {
//        clients = servermessage("2");
//    }
//} while ((choose != "1") || (choose != "2")); 
