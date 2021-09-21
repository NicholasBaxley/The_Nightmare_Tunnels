using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Mob
    {
        public string name { get; set; }
        public string desc { get; set; }
        public int dmg { get; set; }

        public int _hp;
        public int ac { get; set; }
        public int maxHp { get; set; }
        public int maxAc { get; set; }
        
        // Makes sure hp can not go below 0
        public int hp
        {
            get { return _hp; }

            set
            {
                if (value < 0)
                {
                    _hp = 0;
                }
                else
                {
                    _hp = value;
                }

            }
        }

        public Mob()
        {
            name = "Generic Mob";
            desc = "Just some monster";
            dmg = 1;
            hp = 1;
            ac = 1;
            maxHp = 1;
            maxAc = 1;
        }

        public Mob(string mobName, string mobDesc, int mobDmg, int mobHp ,int mobAc)
        {
            name = mobName;
            desc = mobDesc;
            dmg = mobDmg;
            hp = mobHp;
            maxHp = mobHp;
            ac = mobAc;
            maxAc = mobAc;
        }
    }
}
