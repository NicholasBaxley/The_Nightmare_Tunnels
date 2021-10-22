﻿using System;
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
        public double weakSlash { get; set; }
        public double weakPierce { get; set; }
        public double weakBlunt { get; set; }
        public double weakMagical { get; set; }

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

        public Living(string Name, int Hp, int MaxHP, int Ac, int MaxAc, int Dmg, double WeakSlash, double WeakPierce, double WeakBlunt, double WeakMagical)
        {
            name = Name;
            hp = Hp;
            maxHp = MaxHP;
            ac = Ac;
            maxAc = MaxAc;
            dmg = Dmg;
            weakSlash = WeakSlash;
            weakPierce = WeakPierce;
            weakBlunt = WeakBlunt;
            weakMagical = WeakMagical;
        }
    }
}
