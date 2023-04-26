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
            

                Menu menu = new Menu();

                menu.Run();
            while (true)
            {
                int gg = Convert.ToInt32(Console.ReadLine());
                string gg1 = "Пиздец";
                gg1 = DataBase.BL.BusinessLogic.ServerMessage(gg, gg1);
                Console.WriteLine(gg1);
            }
            Console.ReadLine();
        }
    }   
}