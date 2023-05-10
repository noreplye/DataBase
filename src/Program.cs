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
            string client = DataBase.BL.BusinessLogic.Registration("Саша", "mralexgold01@gmail.com", "0", "22.05.2004", "22.05.2023");
            while (true)
            {
                Console.ReadLine();
                string gg;
               
                Console.WriteLine(client);
                gg = DataBase.BL.BusinessLogic.ServerMessage(3, client);
                Console.WriteLine("user id: ",gg);
                int a = Convert.ToInt32(Console.ReadLine());
                gg = DataBase.BL.BusinessLogic.ServerMessage(a, "nothing");
                Console.ReadLine();
                gg = DataBase.BL.BusinessLogic.ServerMessage(4, "4");
                Console.WriteLine(gg);
            }



            BodyList bodies = new BodyList(10, 5, 40, 125);
            bodies.Draw();

            while (true)
            {
                bodies.Draw();
                
                bodies.KeyDetect(Console.ReadKey());
                
                // int gg = Convert.ToInt32(Console.ReadLine());
                // string gg1 = "Пиздец";
                // gg1 = DataBase.BL.BusinessLogic.ServerMessage(gg, gg1);
                // Console.WriteLine(gg1);



            }

        }
    }   
}