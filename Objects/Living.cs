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
        public int maxHp { get; set; }
        public int ac { get; set; }
        public int maxAc { get; set; }
        public int dmg { get; set; }
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

        public Living()
        {
            name = "";
            hp = 25;
            maxHp = 25;
            ac = 90;
            maxAc = 90;
            dmg = 3;
        }

        public Living(string name, int hp, int maxHP, int ac, int maxAc, int dmg)
        {
            this.name = name;
            this.hp = hp;
            this.maxHp = maxHP;
            this.ac = ac;
            this.maxAc = maxAc;
            this.dmg = dmg;
        }
    }
}
