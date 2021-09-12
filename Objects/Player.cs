﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Player
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public int Hp { get; set; }
        public int Ac { get; set; }
        public int MaxHp { get; set; }
        public int MaxAc { get; set; }
        public List<Item> Inventory { get; set; }

        public Player()
        {
            Name = "";
            Password = "";
            Class = "";
            Race = "";
            Hp = 1;
            MaxHp = 1;
            Ac = 1;
            MaxAc = 1;
        }
        public Player(string name, string password)
        {
            Name = name;
            Password = password;
        }

        // Method to check whether password meets requirements
        public static bool CheckPassword(string pass)
        {   
            char[] split = pass.ToCharArray(); 
            bool hasUpper = false, hasLower = false, hasSpecial = false;

            foreach (char character in pass)
            {
                if (char.IsUpper(character))
                {
                    hasUpper = true;
                }
                if (char.IsLower(character))
                {
                    hasLower = true;
                }
                if (!char.IsLetterOrDigit(character))
                {
                    hasSpecial = true;
                }
            }

            if(hasUpper & hasLower & hasSpecial)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
