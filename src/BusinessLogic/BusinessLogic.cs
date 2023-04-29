using System.Net.Sockets;
using System.Net;
using System.Text;
using DataBase.BD;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace DataBase.BusinessLogic
{
    public class BusinessLogic
{
    public static string ServerMessage(int choice, string message)
    {
        const string ip = "127.0.0.1"; //Ip локальный
        const int port = 8080; //Port любой
        while (true)
        {

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port); // класс конечной точки (точка подключения), принимает Ip and Port

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // сокет объявляем, через него все проходит + прописываем дефолтные характеристики для TCP

            byte[] bytesA = BitConverter.GetBytes(choice);



            byte[] data = Encoding.UTF8.GetBytes(message);

            byte[] BytesToSend = bytesA.Concat(data).ToArray();

            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(BytesToSend);

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

    public static string Registration(string name, string email, string number, string comeDate, string outDate)
    {
        User user = new User();
        user.name = name;
        user.email = email;
        user.number = number;
        user.comeDate = comeDate;
        user.outDate = outDate;

        string client = DataBase.BD.DataBase.GetCurrentUserString(user);
        return null;
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
}
}

