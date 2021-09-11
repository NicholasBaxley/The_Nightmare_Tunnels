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
        public int atkspd { get; set; }
        // 0 = Physical, 1 = Magical (Will Probably change later)
        public int dmgType { get; set; }

        public Weapon()
        {
            name = "Generic Sword";
            dmg = 1;
            atkspd = 1;
        }

        public Weapon(string weaponName, int weaponDmg, int weaponAtkspd, int weaponDmgType)
        {
            name = weaponName;
            dmg = weaponDmg;
            atkspd = weaponAtkspd;
            dmgType = weaponDmgType;

        }

    }
}
