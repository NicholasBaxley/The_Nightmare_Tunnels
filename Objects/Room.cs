using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Room
    {
        public string name { get; set; }
        public string desc { get; set; }
        public bool locked { get; set; }

        public Room()
        {
            name = "Generic Room";
            desc = "Nothing in here!";
            locked = false;
        }

        public Room(string roomName, string roomDesc, bool roomLocked = false)
        {
            name = roomName;
            desc = roomDesc;
            locked = roomLocked;
        }
    }
}
