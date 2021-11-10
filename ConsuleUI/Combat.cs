using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace ConsuleUI
{
    public class Combat
    {
        static Random rand = new Random();
        //The main method that controls most of the fight.
        public static void StartFight(Player player, Mob mob)
        {
            bool fighting = true;
            bool playersTurn = true;
            bool playerDefending = false;
            string choice;
            int damageDealt;
            int playerWeaponType = player.equippedWeapon.dmgType;

            // Give mob a random weapon
            mob.equippedWeapon = Weapon.RandomWeapon(World.weapons);

            while (fighting)
            {
                // If either the player or mob dies, a message is displayed and the fight ends
                if (mob.hp == 0)
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    fighting = false;
                    World.rooms[World.position].mob = null;
                    DisplayWonMessage();
                }
                else if (player.hp == 0)
                {
                    fighting = false;
                    DisplayLostMessage();
                }
                // Decides whose turn it is to attack, player starts first
                else if (playersTurn)
                {
                    playerDefending = false;
                    DisplayFightersHP(player, mob);
                    while (playersTurn)
                    {
                        // The options the player has doing a fight
                        Console.WriteLine("Attack/Defend");
                       
                        bool attacking = true;
                        while (attacking)
                        {
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "a":
                                case "attack":
                                    Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    if (TestAccuracy(player, mob))
                                    {
                                        damageDealt = (int)(Attack(player) * Weakness(player.equippedWeapon, mob));
                                        mob.hp -= damageDealt;
                                        Console.WriteLine("You did " + damageDealt + " damage to the monster!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("You missed!");
                                    }
                                    attacking = false;
                                    break;
                                case "d":
                                case "defend":
                                    Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    Console.WriteLine("You choose to defend!");
                                    playerDefending = true;
                                    attacking = false;
                                    break;
                                default:
                                    Console.WriteLine("Not an option!");
                                    break;
                            }
                        }
                        playersTurn = false;
                    }
                }
                // The monster attacks here
                else
                {
                    if (TestAccuracy(mob, player))
                    {
                        damageDealt = (int)(Attack(mob) * Weakness(mob.equippedWeapon, player));
                        if (playerDefending)
                        {
                            damageDealt = damageDealt / 3 ;
                        }
                        player.hp -= damageDealt;
                        Console.WriteLine("The monster did " + damageDealt + " damage to you!");
                    }
                    else
                    {
                        Console.WriteLine("The monster missed!");
                    }
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    playersTurn = true;
                }

            }
            //Reset player hp for testing purposes
            // TODO - DELETE THIS FOR THE REAL FIGHTS
            player.hp = player.maxHp;
        }

        // Generates a random mob based on the difficulty of the room
        public static Mob RandomMob(int difficulty)
        {
            List<Mob> mobs = SqliteDataAccess.LoadMobs();
            List<Mob> selectedMobs = new List<Mob>();
            foreach(Mob mob in mobs)
            {
                if (mob.difficulty == difficulty)
                {
                    selectedMobs.Add(mob);
                }
            }
            
            Mob temp = selectedMobs[rand.Next(0, selectedMobs.Count)];
            return temp.CopyMob();
        }

        // The defeat/won messages
        // TODO - Change messages later when healing is implemented
        public static void DisplayLostMessage()
        {
            Console.WriteLine("\nYou died! Here is a free revive for now...");
        }

        public static void DisplayWonMessage()
        {
            Console.WriteLine("\nYou Won! Here is a free Heal for now...");
        }

        // Shows the hp for player and monster on screen
        public static void DisplayFightersHP(Player player, Mob mob)
        {
            Console.WriteLine("\n\n" + player.name + ": " + player.hp + "/" + player.maxHp);
            Console.WriteLine("--------------------");
            Console.WriteLine(mob.name + ": " + mob.hp + "/" + mob.maxHp + "\n");
        }

        //Returns the amount of damage a player or mob will do.
        public static int Attack(Player character)
        {            
            int dmg = character.dmg + character.equippedWeapon.dmg + rand.Next(-2, 3);
            if (dmg < 0)
            {
                dmg = 1;
            }
            return dmg;
        }

        public static int Attack(Mob character)
        {
            int dmg = character.dmg + character.equippedWeapon.dmg;
            if (dmg < 0)
            {
                dmg = 1;
            }
            return dmg;
        }

        // Test the player/mobs accuracy and returns true or false
        public static bool TestAccuracy(Player player, Mob mob)
        {
            int accuracy = rand.Next(0, 31);
            if (accuracy >= mob.ac)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool TestAccuracy(Mob mob, Player player)
        {
            int accuracy = rand.Next(0, 31);
            if (accuracy >= player.ac)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Gets the player or mobs weakness depending on weapon being used.
        // 0 = slash, 1 = pierce, 2 = blunt, default = magical
        public static double Weakness(Weapon weapon, Living thing)
        {
            int weaponType = weapon.dmgType;
            switch (weaponType)
            {
                case 0:
                    return thing.weakSlash;
                case 1:
                    return thing.weakPierce;
                case 2:
                    return thing.weakBlunt;
                default:
                    return thing.weakMagical;
            }
        }
    }
}

