using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    class Treasure
    {
        public string name { get; set; }
        public string desc { get; set; }
        public int value { get; set; }

        public Treasure()
        {
            name = "Generic Necklace";
            desc = "Not very pretty...";
            value = 1;
        }

        public Treasure(string treasureName, string treasureDesc, int treasureValue)
        {
            name = treasureName;
            desc = treasureDesc;
            value = treasureValue;
        }

    }
}
