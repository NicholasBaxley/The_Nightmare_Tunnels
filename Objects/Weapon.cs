using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    class Weapon
    {
        public string name { get; set; }
        public int dmg { get; set; }
        public int atkspd { get; set; }

        public Weapon()
        {
            name = "Generic Sword";
            dmg = 1;
            atkspd = 1;
        }

        public Weapon(string weaponName, int weaponDmg, int weaponAtkspd)
        {
            name = weaponName;
            dmg = weaponDmg;
            atkspd = weaponAtkspd;

        }

    }
}
