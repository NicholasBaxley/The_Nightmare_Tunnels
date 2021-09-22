using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Potion
    {
        public string name { get; set; }
        public string desc { get; set; }
        public int healthRestore { get; set; }
        public int dmg { get; set; }
        public int id { get; set; }
        
        
        
        public Potion()
        {
            name = "Generic Potion";
        }

        public Potion(string potName, string potDesc, int potHealthRestore, int potDmg, int potId)
        {
            name = potName;
            desc = potDesc;
            id = potId;
            healthRestore = potHealthRestore;
            dmg = potDmg;
        }
        
        
    }
}
