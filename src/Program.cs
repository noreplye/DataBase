using DataBase.Interface;
using System.Net;
using System.Net.Sockets;
using System.Text;
using DataBase.BL;

namespace DataBase
{
    class Program
    {
        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ReadLine();
                string gg;
                string client = DataBase.BL.BusinessLogic.Registration("Саша", "mralexgold01@gmail.com", "0", "22.05.2004", "22.05.2023");
                Console.WriteLine(client);
                gg = DataBase.BL.BusinessLogic.ServerMessage(3, client);
                Console.WriteLine(gg);
                Console.ReadLine();
                gg = DataBase.BL.BusinessLogic.ServerMessage(4, "4");
                Console.WriteLine(gg);
            }

        }
    }   
}