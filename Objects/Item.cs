using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Item
    {
        public string name { get; set; }
        public string desc { get; set; }

        public Item()
        {
            name = "Generic Item";
            desc = "Just some rubbish";
        }

        public Item(string itemName, string itemDesc)
        {
            name = itemName;
            desc = itemDesc;
        }
    }
}
