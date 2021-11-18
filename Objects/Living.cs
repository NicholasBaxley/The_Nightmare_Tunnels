using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Living
    {
        public string name { get; set; }
        private int _hp;
        public Weapon _equippedWeapon;
        public int maxHp { get; set; }
        public int ac { get; set; }
        public int maxAc { get; set; }
        public int dmg { get; set; }
        public double _weakSlash;
        public double _weakPierce;
        public double _weakBlunt;
        public double _weakMagical;

        // Makes sure hp can not drop below 0
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
        public int weaponId { get; set; }     

        //Automatically sets the weapons id
        public Weapon equippedWeapon
        {
            get { return _equippedWeapon; }
            set
            {
                _equippedWeapon = value;
                weaponId = equippedWeapon.id;

            }
        }

        public Living()
        {
            name = "";
            hp = 25;
            maxHp = 25;
            ac = 90;
            maxAc = 90;
            dmg = 1; 
        }

        //For making mobs
        public Living(string Name, int Hp, int MaxHP, int Ac, int MaxAc, int Dmg, double WeakSlash, double WeakPierce, double WeakBlunt, double WeakMagical)
        {
            name = Name;
            hp = Hp;
            maxHp = MaxHP;
            ac = Ac;
            maxAc = MaxAc;
            dmg = Dmg;
            _weakSlash = WeakSlash;
            _weakPierce = WeakPierce;
            _weakBlunt = WeakBlunt;
            _weakMagical = WeakMagical;
        }

        //For making players
        public Living(string Name, int Hp, int MaxHP, int Ac, int MaxAc, int Dmg)
        {
            name = Name;
            hp = Hp;
            maxHp = MaxHP;
            ac = Ac;
            maxAc = MaxAc;
            dmg = Dmg;
        }
    }
}
