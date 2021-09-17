using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Potion
    {
        public string name { get; set; }
        public int id { get; set; }
        public int healthRestore { get; set; }
        public int dmg { get; set; }
        
        public Potion()
        {
            name = "Generic Potion";
        }

        public Potion(string potName, int potId, int potHealthRestore, int potDmg)
        {
            name = potName;
            id = potId;
            healthRestore = potHealthRestore;
            dmg = potDmg;
        }
        
    }
}
