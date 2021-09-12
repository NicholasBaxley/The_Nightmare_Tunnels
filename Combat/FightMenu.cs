using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace Combat
{
    public class FightMenu
    {
        //The main method that controls most of the fight.
        public static void StartFight(Player player, Mob mob)
        {
            bool fighting = true;
            bool playersTurn = true;
            bool playerDefending = false;
            string choice;

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

                                playersTurn = false;
                                break;
                            case "d":
                            case "defend":
                                playerDefending = true;
                                playersTurn = false;
                                break;
                        }
                    }
                    

                    DisplayFightersHP(player, mob);
                }
                else
                {
                    DisplayFightersHP(player, mob);

                    DisplayFightersHP(player, mob);
                }
            }
        }

        // Generates a random mob when given a list or array of mobs to choose from.
        public static Mob RandomMob(Mob[] mobs)
        {
            var rand = new Random();
            return mobs[rand.Next(mobs.Length - 1)];
        }

        public static Mob RandomMob(List<Mob> mobs)
        {
            var rand = new Random();
            return mobs[rand.Next(mobs.Count - 1)];
        }


        // The defeat/won messages
        // TODO - Change messages later when healing is implemented
        public static void DisplayLostMessage()
        {
            Console.WriteLine("You died! Here is a free revive for now...");
        }

        public static void DisplayWonMessage()
        {
            Console.WriteLine("You Won! Here is a free Heal for now...");
        }

        // Shows the hp for player and monster on screen
        //TODO - Make better formatting
        public static void DisplayFightersHP(Player player, Mob mob)
        {
            Console.WriteLine(player.name + ": " + player.hp + "/" + player.maxHp);
            Console.WriteLine("--------------------");
            Console.WriteLine(mob.name + ": " + mob.hp + "/" + mob.maxHp);
        }

        public static 
    }

}
