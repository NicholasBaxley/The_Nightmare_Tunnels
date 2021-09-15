using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Player
    {
        public string name { get; set; }
        public string password { get; set; }
        // class is a reserved keyword by c# so i changed it to playerClass
        public string playerClass { get; set; }
        public string race { get; set; }

        private int _hp;
        public int ac { get; set; }
        public int maxHp { get; set; }
        public int maxAc { get; set; }
        public int dmg { get; set; }
        public List<Item> inventory { get; set; }

        public Player()
        {
            name = "John Doe";
            password = "Password1!";
            playerClass = "Warrior";
            race = "Dork";
            hp = 25;
            maxHp = 25;
            ac = 25;
            maxAc = 25;
            dmg = 6;
        }

        public Player(string playerName, string playerPassword)
        {
            name = playerName;
            password = playerPassword;
        }

        // Makes sure hp can not go below 0
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
