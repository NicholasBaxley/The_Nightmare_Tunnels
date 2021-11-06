using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Player : Living
    {
        private List<IInventoryItem> _inventory;

        public string password { get; set; }
        public string playerClass { get; set; }
        public string race { get; set; }

        public Player() : base()
        {
            name = "John Doe";
            inventory = new List<IInventoryItem>();
            password = "Password1!";
            playerClass = "Warrior";
            race = "Dork";
        }

        public Player(string playerName, string playerPassword, string playerClass, string playerRace) : base()
        {
            name = playerName;
            inventory = new List<IInventoryItem>();
            password = playerPassword;
            this.playerClass = playerClass;
            race = playerRace;
            ac = 15;
            maxAc = 15;
        }

        public Player(string playerName, string playerPassword, string playerClass, string playerRace, int playerHP, int playerMaxHP, int playerAc, int playerMaxAc, int playerDmg) 
            : base(playerName, playerHP, playerMaxHP, playerAc, playerMaxAc, playerDmg, 1.0, 1.0, 1.0, 1.0)
        {
            password = playerPassword;
            inventory = new List<IInventoryItem>();
            this.playerClass = playerClass;
            race = playerRace;
        }

        public List<IInventoryItem> inventory 
        {   
            get 
            {
                return _inventory; 
            } 
            
            set 
            { 
                _inventory = value; 
            } 
        }

        // Method to check whether password meets requirements
        public static bool CheckPassword(string pass)
        {   
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
