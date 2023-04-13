using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.BD
{

    public class RoomsArray
    {
        public Room[] rooms { get; set; }
    }

    public class Room
    {
        public string Name { get; set; }
        public string Quality { get; set; }
        public string Description { get; set; }
        public int Seats { get; set; }
        public int RoomPrice { get; set; }
        public int Room_id { get; set; }
    }

}
