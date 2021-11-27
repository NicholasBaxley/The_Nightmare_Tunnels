using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class StatusEffect
    {
        // -1 = permanent, // 1 = one time use
        public int duration { get; set; }
        // 0 = buff, 1 = debuff
        public bool statusType { get; set; }
        public int effectId { get; set; }
        public int effectDamage { get; set; }

        public void Effect(Living thing)
        {
            switch(effectId)
            {
                case 0:
                    Heal(thing);
                    break;
                default:
                    Poison(thing);
                    break;
            }
        }

        public int Poison(Living thing)
        {
            return thing.hp - effectDamage;
        }

        public int Heal(Living thing)
        {
            return thing.hp + effectDamage;
        }
    }
}
