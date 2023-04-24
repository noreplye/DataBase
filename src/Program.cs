using DataBase.Interface;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DataBase
{
    class Program
    {
        public static string ServerMessage(string message)
        {
            const string ip = "127.0.0.1"; //Ip локальный
            const int port = 8080; //Port любой
            while (true)
            {

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port); // класс конечной точки (точка подключения), принимает Ip and Port

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // сокет объявляем, через него все проходит + прописываем дефолтные характеристики для TCP

                var data = Encoding.UTF8.GetBytes(message);
                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);

                var buffer = new byte[256];
                var size = 0;
                var answer = new StringBuilder();


                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (tcpSocket.Available > 0);


                return answer.ToString();
                break;
            }
        }
        static void Main(string[] args)
        {
            

                Menu menu = new Menu();

                menu.Run();
            string gg = Console.ReadLine();
            gg = ServerMessage (gg);
            Console.WriteLine(gg);
            gg = Console.ReadLine();
            ServerMessage(gg);
            Console.ReadLine();
        }
    }   
}