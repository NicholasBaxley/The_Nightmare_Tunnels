using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Weapon : IInventoryItem
    {
        public string name { get; set; }
        public string desc { get; set; }
        public int dmg { get; set; }

        // 0 = Pierce/Thrust, 1 = Blunt, 2 = Slice, 3 = Magical
        public int dmgType { get; set; }
        public int price { get; set; }
        public int id { get; set; }

        public Weapon()
        {
            name = "Generic Sword";
            dmg = 1;
            dmgType = 0;
        }

        public Weapon(string weaponName, string weaponDesc, int weaponDmg, int weaponDmgType, int weaponPrice, int weaponId)
        {
            name = weaponName;
            desc = weaponDesc;
            dmg = weaponDmg;
            dmgType = weaponDmgType;
            price = weaponPrice;
            id = weaponId;
        }

        //Returns a random weapon from the list
        public static Weapon RandomWeapon(List<Weapon> weapons)
        {
            var rand = new Random();
            return weapons[rand.Next(0, weapons.Count - 1)];
        }

    }
}
