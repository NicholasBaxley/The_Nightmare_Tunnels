using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Mob : Living
    {
        public string desc { get; set; }
        public int difficulty { get; set; }

        public Mob()
        {
            desc = "Just some monster";
            difficulty = 1;
        }

        public Mob(string mobName, string mobDesc, int mobDmg, int mobHp, int mobAc, int mobDifficulty) : base(mobName, mobHp, mobHp, mobAc, mobAc, mobDmg)
        {
            desc = mobDesc;
            difficulty = mobDifficulty;
        }

        public string Info()
        {
            return $"[{name}]: {desc}\n Damage:{dmg}\n Hp:{maxHp}\n Acc:{maxAc}\n Diff:{difficulty}";
        }

       
    }
}