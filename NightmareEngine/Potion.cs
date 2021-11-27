using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Potion : IInventoryItem
    {
        public string name { get; set; }
        public string desc { get; set; }
        public int dmg { get; set; }
        public int id { get; set; }
        
        
        
        public Potion()
        {
            name = "Generic Potion";
        }

        public Potion(int potId,  string potName, string potDesc, int potDmg)
        {
            name = potName;
            desc = potDesc;
            id = potId;
            dmg = potDmg;
        }
        
        
    }
}
