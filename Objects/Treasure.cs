using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Treasure
    {
        public string name { get; set; }
        public string desc { get; set; }
        public int value { get; set; }
        public bool questItem { get; set; }
        public int id { get; set; }

        public Treasure()
        {
            name = "Generic Necklace";
            desc = "Not very pretty...";
            value = 1;
            questItem = false;
        }

        public Treasure(string treasureName, string treasureDesc, int treasureValue, bool treasureQuestItem, int treasureId)
        {
            name = treasureName;
            desc = treasureDesc;
            value = treasureValue;
            questItem = treasureQuestItem;
            id = treasureId;
        }

    }
}
