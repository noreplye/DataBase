using DataBase.Interface;
using System.Net;
using System.Net.Sockets;
using System.Text;
using DataBase.BusinessLogic;
using DataBase.Interface;

namespace DataBase
{
    class Program
    {
        
        static void Main(string[] args)
        {

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