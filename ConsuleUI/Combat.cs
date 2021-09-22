using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace ConsuleUI
{
    class Combat
    {
        //The main method that controls most of the fight.
        public static void StartFight(Player player, Mob mob)
        {
            bool fighting = true;
            bool playersTurn = true;
            bool playerDefending = false;
            string choice;
            int damageDealt;

            while (fighting)
            {
                // If either the player or mob dies, a message is displayed and the fight ends
                if (mob.hp == 0)
                {
                    fighting = false;
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
                    DisplayFightersHP(player, mob);
                    while (playersTurn)
                    {
                        // The options the player has doing a fight
                        Console.WriteLine("Attack/Defend");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "a":
                            case "attack":
                                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                if (TestAccuracy(player))
                                {
                                    damageDealt = Attack(player);
                                    mob.hp -= damageDealt;
                                    Console.WriteLine("You did " + damageDealt + " damage to the monster!" );
                                }
                                else
                                {
                                    Console.WriteLine("You missed!");
                                }
                                break;
                            case "d":
                            case "defend":
                                playerDefending = true;
                                break;
                            default:
                                Console.WriteLine("Invalid option!");
                                break;
                        }
                        playersTurn = false;
                    }
                }
                // The monster attacks here
                else
                {
                    if (TestAccuracy(mob))
                    {
                        damageDealt = Attack(mob);
                        if (playerDefending)
                        {
                            damageDealt /= 3;
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
        public static Mob RandomMob(int difficulty, List<Mob> mobs)
        {
            var rand = new Random();
            List<Mob> selectedMobs = new List<Mob>();
            foreach(Mob mob in mobs)
            {
                if (mob.difficulty == difficulty)
                {
                    selectedMobs.Add(mob);
                }
            }
            return selectedMobs[rand.Next(0, selectedMobs.Count - 1)];
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
        //TODO - Make better formatting
        public static void DisplayFightersHP(Player player, Mob mob)
        {
            Console.WriteLine("\n\n" + player.name + ": " + player.hp + "/" + player.maxHp);
            Console.WriteLine("--------------------");
            Console.WriteLine(mob.name + ": " + mob.hp + "/" + mob.maxHp + "\n");
        }

        //Returns the amount of damage a player or mob will do.
        public static int Attack(Player character)
        {
            var rand = new Random();
            int dmg = character.dmg + character.equippedWeapon.dmg + rand.Next(-2, 3);
            if (dmg < 0)
            {
                dmg = 1;
            }
            return dmg;
        }

        public static int Attack(Mob character)
        {
            var rand = new Random();
            int dmg = character.dmg + rand.Next(-4, 5);
            if (dmg < 0)
            {
                dmg = 1;
            }
            return dmg;
        }

        // Test the player/mobs accuracy and returns true or false
        public static bool TestAccuracy(Player player)
        {
            var rand = new Random();
            int accuracy = rand.Next(0, 101);
            if (accuracy <= player.ac)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool TestAccuracy(Mob mob)
        {
            var rand = new Random();
            int accuracy = rand.Next(0, 101);
            if (accuracy <= mob.ac)
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

