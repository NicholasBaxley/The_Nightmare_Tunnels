using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Weapon
    {
        public string name { get; set; }
        public int dmg { get; set; }
        // 0 = Pierce/Thrust, 1 = Blunt, 2 = Slice, 3 = Magical
        public int dmgType { get; set; }

        public Weapon()
        {
            name = "Generic Sword";
            dmg = 1;
            dmgType = 0;
        }

        public Weapon(string weaponName, int weaponDmg, int weaponDmgType)
        {
            name = weaponName;
            dmg = weaponDmg;
            dmgType = weaponDmgType;

        }

    }
}
