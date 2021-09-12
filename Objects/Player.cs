using System;
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
        public int hp { get; set; }
        public int ac { get; set; }
        public List<Item> Inventory { get; set; }

        public Player()
        {
            Name = "";
            Password = "";
            Class = "";
            Race = "";
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
