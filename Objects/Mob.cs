using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    class Mob
    {
        public string name { get; set; }
        public string desc { get; set; }
        public int dmg { get; set; }
        public int atkspd { get; set; }
        public int hp { get; set; }

        public Mob()
        {
            name = "Generic Mob";
            desc = "Just some monster";
            dmg = 1;
            atkspd = 1;
            hp = 1;
        }

        public Mob(string mobName, string mobDesc, int mobDmg, int mobAtkspd, int mobHp )
        {
            name = mobName;
            desc = mobDesc;
            dmg = mobDmg;
            atkspd = mobAtkspd;
            hp = mobHp;
        }
    }
}
