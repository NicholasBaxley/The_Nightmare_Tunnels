using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Item
    {
        public string name { get; set; }
        public string desc { get; set; }
        public int price { get; set; }
        public bool questItem { get; set; }
        public int id { get; set; }

        public Item()
        {
            name = "Generic Item";
            desc = "Just some rubbish";
        }

        public Item(string itemName, string itemDesc, int itemPrice, bool forQuest, int itemID)
        {
            name = itemName;
            desc = itemDesc;
            price = itemPrice;
            questItem = forQuest;
            id = itemID;
        }
    }
}
