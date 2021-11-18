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

        public List<double> raceBonus 
        {
            get
            {
                List<double> bonus = new List<double>();
                switch (playerClass.ToLower())
                {
                    // [slash, pierce, blunt, magical] adds resistance to these stats in this order.
                    // If Resistent give them a negative number, if they take more damage give positive number
                    case "human":
                        bonus.Add(-0.3);
                        bonus.Add(0.2);
                        bonus.Add(0.0);
                        bonus.Add(0.0);
                        break;
                    default:
                        bonus.Add(-0.1);
                        bonus.Add(0.1);
                        bonus.Add(-0.3);
                        bonus.Add(0.2);
                        break;
                }
                return bonus;
            }
        }

        public List<double> classBonus
        {
            get
            {
                List<double> bonus = new List<double>();
                switch (playerClass.ToLower())
                {
                    // [slash, pierce, blunt, magical] adds resistance to these stats in this order.
                    // If Resistent give them a negative number, if they take more damage give positive number
                    case "warrior":
                        bonus.Add(-0.3);
                        bonus.Add(0.2);
                        bonus.Add(0.0);
                        bonus.Add(0.0);
                        break;
                    default:
                        bonus.Add(0.2);
                        bonus.Add(0.1);
                        bonus.Add(0.0);
                        bonus.Add(-0.3);
                        break;
                }
                return bonus;
            }
        }

        public double weakSlash
        {
            get
            {
                return 1 + raceBonus[0] + classBonus[0];
            }
        }
        public double weakPierce
        {
            get
            {
                return 1 + raceBonus[1] + classBonus[1];
            }
        }

        public double weakBlunt
        {
            get
            {
                return 1 + raceBonus[2] + classBonus[2];
            }
        }

        public double weakMagical
        {
            get
            {
                return 1 + raceBonus[3] + classBonus[3];
            }
        }


        public Player() : base()
        {
            name = "John Doe";
            inventory = new List<IInventoryItem>();
            password = "Password1!";
            playerClass = "Warrior";
            race = "Human";
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
            : base(playerName, playerHP, playerMaxHP, playerAc, playerMaxAc, playerDmg)
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
