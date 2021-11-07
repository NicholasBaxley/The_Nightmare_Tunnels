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
        public bool isBoss { get; set; }
        public bool moved { get; set; }

        public Mob()
        {
            desc = "Just some monster";
            difficulty = 1;
            isBoss = false;
        }

        public Mob(string mobName, string mobDesc, int mobDmg, int mobHp, int mobAc, int mobDifficulty, double WeakSlash, double WeakPierce, double WeakBlunt, double WeakMagical) 
            : base(mobName, mobHp, mobHp, mobAc, mobAc, mobDmg, WeakSlash, WeakPierce, WeakBlunt, WeakMagical)
        {
            desc = mobDesc;
            difficulty = mobDifficulty;
            isBoss = false;
            moved = false;
        }

        public string Info()
        {
            return $"[{name}]: {desc}\n Damage:{dmg}\n Hp:{maxHp}\n Acc:{maxAc}\n Diff:{difficulty}\n Boss?: {isBoss}";
        }

        //Makes a new copy of the mob (needed to make sure multiple rooms dont use the same copy of a monster)
        public Mob CopyMob()
        {         
            return new Mob(name, desc, dmg, hp, maxAc, difficulty, weakSlash, weakPierce, weakBlunt, weakMagical);
        }
       
    }
}