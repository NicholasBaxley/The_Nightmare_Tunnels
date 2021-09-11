using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    class Potion
    {
        public string name { get; set; }
        public int usesLeft { get; set; } 
        
        public Potion()
        {
            name = "Generic Potion";
            usesLeft = 1;
        }

        public Potion(string potName, int potUses)
        {
            name = potName;
            usesLeft = potUses;
        }
        
    }
}
