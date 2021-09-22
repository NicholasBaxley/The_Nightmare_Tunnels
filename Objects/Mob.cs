using System;
using System.Collections.Generic;
using System.IO;
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

        private int _hp;
        public int ac { get; set; }
        public int maxHp { get; set; }
        public int maxAc { get; set; }
        public int difficulty { get; set; }

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
            difficulty = 1;
        }

        public Mob(string mobName, string mobDesc, int mobDmg, int mobHp, int mobAc, int mobDifficulty)
        {
            name = mobName;
            desc = mobDesc;
            dmg = mobDmg;
            hp = mobHp;
            maxHp = mobHp;
            ac = mobAc;
            maxAc = mobAc;
            difficulty = mobDifficulty;
        }

       
    }
}