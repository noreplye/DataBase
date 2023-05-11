using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Linq;

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
                        tcpSocket.Close();
                        return answer.ToString();
                    }
                }    
            }
        }

        public static string Registration(string name, string login,string password, string number, string email)
        {
            User user = new User();
            user.name = name;
            user.login = login;
            user.password = password;
            user.number = number;
            user.email = email;
            user.bookingCount = 0;

            string client = DataBase.GetUserString(user);
            //Console.WriteLine(client);
            return ServerMessage(5, client);

        }

        public static string Login(string nameLoginNumber, string password)
        {
            return ServerMessage(6, nameLoginNumber+"'"+password);
        }

        public static string CheckValid(string name,string login, string password, string number, string email)
        {
            var result="";
            if (login.Length < 4)
            {
                result += "l";
            }
            if (password.Length < 8)
            {
                result += "p";
            }
            if (number.Length == 12)
            {
                if (number[0] != '+' || number[1]!='7')
                {
                
                    result += "n";
                }
            }
            if (number.Length == 11)
            {
                if (number[0] != '8')
                {
                    result += "n";
                }
            }
            if (number.Length < 11 || number.Length > 12)
            {
                result += "n";
            }
            if (!(email.Contains('@')&&(email.Contains(".com")|| email.Contains(".ru")) && email[0] != '@' && email.Length >= 5))
            {
                result+= "e";
            }

            return result;
        }
        public static Bookingobject GetBookings(string user_id)
        {
            var fromServer = ServerMessage(7, user_id);
            Bookingobject result = DataBase.InitBookings(fromServer);
            return result;
        }
        public static Room GetRoomType(string room_number)
        {
            return DataBase.InitRoom(ServerMessage(1, room_number));
        }
        public static string Book(string user_id,string roomType,string comeDate, string outDate)
        {
            if (comeDate.Length == 0 && comeDate.Length == 0)
            {
                return "ExceptionDate";
            }
            if (comeDate.Trim() == null && comeDate.Trim() == null)
            {
                return "ExceptionDate";
            }
            comeDate = comeDate.Trim(); outDate= outDate.Trim();
            if (comeDate.Length < 10)
            {
                return "ExceptionDate";
            }
            var toCheck1 = (comeDate[2] == '/' && comeDate[5] == '/');
            try
            {
                DateTime ki = DateTime.Parse(comeDate);
            }
            catch (Exception)
            {
                return "ExceptionDate";
            }
            try
            {
                DateTime ki = DateTime.Parse(outDate);
            }
            catch (Exception)
            {
                return "ExceptionDate";
            }
            if (toCheck1)
            {
                DateTime checkData1 = DateTime.Parse(comeDate);
                DateTime checkData2 = DateTime.Parse(outDate);
                if ((DateTime.Now - checkData2).TotalDays > 30)
                {
                    return "ExceptionDate";
                }

                if ((checkData2 - checkData1).Days <= 30)
                {   
                    if(checkData2 > checkData1)
                    {
                        
                            var result = ServerMessage(4, user_id + "'" + roomType + "'" + comeDate + "'" + outDate);
                            return result;


                    }
                    return "after";
                }
                return "totalDays"; 

            }
            return "ExceptionDate";


        }
        public static string DeleteBooking(string booking_id)
        {
            return ServerMessage(8, booking_id);
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
