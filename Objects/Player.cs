﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Player
    {
        private int _hp;
        private List<IInventoryItem> _inventory;
        public Weapon _equippedWeapon;
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string playerClass { get; set; }
        public string race { get; set; }
        public int weaponId { get; set; }     
        public int ac { get; set; }
        public int maxHp { get; set; }
        public int maxAc { get; set; }
        public int dmg { get; set; }
        

        public Player()
        {
            name = "John Doe";
            inventory = new List<IInventoryItem>();
            password = "Password1!";
            playerClass = "Warrior";
            race = "Dork";
            hp = 25;
            maxHp = 25;
            ac = 90;
            maxAc = 90;
            dmg = 3;
        }

        public Player(string playerName, string playerPassword, string Class, string playerRace)
        {
            name = playerName;
            password = playerPassword;
            playerClass = Class;
            race = playerRace;
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


        public static string DisplayInventory(Player player)
        {
            // TO DO - Display Items
            return "";
        }
    }
}
