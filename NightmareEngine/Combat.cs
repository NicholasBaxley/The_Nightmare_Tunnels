using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace NightmareEngine
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
                    World.message.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
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
                        World.message.WriteLine("Attack/Defend/Potion");
                       
                        bool attacking = true;
                        while (attacking)
                        {
                            choice = World.message.ReadLine();
                            switch (choice.ToLower())
                            {
                                case "a":
                                case "attack":
                                    World.message.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    if (TestAccuracy(player, mob))
                                    {
                                        damageDealt = (int)(Attack(player) * Weakness(player.equippedWeapon, mob));
                                        mob.hp -= damageDealt;
                                        World.message.WriteLine("You did " + damageDealt + " damage to the monster!");
                                    }
                                    else
                                    {
                                        World.message.WriteLine("You missed!");
                                    }
                                    attacking = false;
                                    break;
                                case "d":
                                case "defend":
                                    World.message.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    World.message.WriteLine("You choose to defend!");
                                    playerDefending = true;
                                    attacking = false;
                                    break;
                                case "p":
                                case "potion":
                                    Potion pot = InventoryMenu.GrabPotionFromInv();
                                    World.message.WriteLine("Who do you want to use the pot on?");
                                    bool loop = true;
                                    string option = "";
                                    while (loop)
                                    {
                                        option = World.message.ReadLine().ToLower();
                                        switch (option)
                                        {
                                            case "player":
                                                loop = false;
                                                break;
                                            case "mob":
                                                loop = false;
                                                break;
                                            default:
                                                World.message.WriteLine("Not a valid option!");
                                                break;
                                        }
                                    }
                                    
                                    //Write the use of a potion.



                                    if (option == "player")
                                    {

                                    }

                                    break;
                                default:
                                    World.message.WriteLine("Not an option!");
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
                            damageDealt = damageDealt / 3;
                        }
                        player.hp -= damageDealt;
                        World.message.WriteLine("The monster did " + damageDealt + " damage to you!");
                    }
                    else
                    {
                        World.message.WriteLine("The monster missed!");
                    }
                    World.message.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
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
            World.message.WriteLine("\nYou died! Here is a free revive for now...");
        }

        public static void DisplayWonMessage()
        {
            World.message.WriteLine("\nYou Won! Here is a free Heal for now...");
        }

        // Shows the hp for player and monster on screen
        public static void DisplayFightersHP(Player player, Mob mob)
        {
            World.message.WriteLine("\n\n" + player.name + ": " + player.hp + "/" + player.maxHp);
            World.message.WriteLine("--------------------");
            World.message.WriteLine(mob.name + ": " + mob.hp + "/" + mob.maxHp + "\n");
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
        public static double Weakness(Weapon weapon, Mob thing)
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

        public static double Weakness(Weapon weapon, Player thing)
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

