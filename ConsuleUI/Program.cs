/**
* 9/10/2021 (UPDATED - 9/11/2021)
* CSC 253
* Group 4
* Group Members: Nicholas Baxley, Branden Alder
* First sprint of The Nightmare Tunnels project
*/
using System;
using System.Collections.Generic;
using Objects;

namespace ConsuleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Intializing all of the lists
            List<Room> rooms = new List<Room>();
            List<Weapon> weapons = new List<Weapon>();
            List<Potion> potions = new List<Potion>();
            List<Treasure> treasures = new List<Treasure>();
            List<Item> items = new List<Item>();
            List<Mob> mobs = new List<Mob>();

            //Creating all of the rooms
            rooms.Add(new Room("Entrance", "PLACEHOLDER"));
            rooms.Add(new Room("Hall", "PLACEHOLDER"));
            rooms.Add(new Room("Fountain", "PLACEHOLDER"));
            rooms.Add(new Room("Boss room", "PLACEHOLDER"));
            rooms.Add(new Room("Treasure room", "PLACEHOLDER"));

            //Creating all of the weapons
            weapons.Add(new Weapon("Iron sword", 10, 2, 0));
            weapons.Add(new Weapon("Bronze dagger", 6, 3, 0));
            weapons.Add(new Weapon("Steel Mace", 14, 1, 0));
            weapons.Add(new Weapon("Magic Tome", 8, 2, 1));

            //Creating all of the potions
            potions.Add(new Potion("Healing potion", 2));
            potions.Add(new Potion("Mana potion", 1));

            //Creating all of the treasures
            treasures.Add(new Treasure("Gold necklace", "PLACEHOLDER", 1000));
            treasures.Add(new Treasure("Gold coin", "PLACEHOLDER", 1));
            treasures.Add(new Treasure("Silver ring", "PLACEHOLDER", 500));

            //Creating all of the items
            items.Add(new Item("Bucket", "PLACEHOLDER"));
            items.Add(new Item("Tin can", "PLACEHOLDER"));
            items.Add(new Item("Candle", "PLACEHOLDER"));
            items.Add(new Item("Rope", "PLACEHOLDER"));

            //Creating all of the mobs
            mobs.Add(new Mob("Goblin", "PLACEHOLDER", 5, 3, 20, 10));
            mobs.Add(new Mob("Slime", "PLACEHOLDER", 2, 3, 15, 10));
            mobs.Add(new Mob("Orc", "PLACEHOLDER", 7, 1, 30, 10));
            mobs.Add(new Mob("Wolf", "PLACEHOLDER", 4, 4, 20, 10));
            mobs.Add(new Mob("Demon", "PLACEHOLDER", 5, 2, 25, 10));

            // Creating player
            Player player = new Player();

            int position = 0;
            bool quit = false;
            bool login = false;
            bool passFlag = false;
            string input;

            // Slop for testing
            Console.WriteLine("Welcome to The Nightmare Tunnels!");

            while (!login)
            {
                Console.WriteLine("Are you a new player?(y/n)");
                input = Console.ReadLine().ToLower();
                if (input == "y" || input == "yes")
                {
                    login = true;
                    Console.WriteLine("\nWhat is your name?");
                    player.name = Console.ReadLine();
                    while (!passFlag)
                    {
                        Console.WriteLine("\nEnter a password. (must contain upper case, lower case and a special character)");
                        string pass = Console.ReadLine();
                        if (Player.CheckPassword(pass))
                        {
                            player.password = pass;
                            passFlag = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid password!");
                        }
                    }

                    // TODO - input validation
                    Console.WriteLine("\nWhat class do you want to be? (Warrior or mage)");
                    player.playerClass = Console.ReadLine();
                    Console.WriteLine("\nWhat race do you want to be? (Human or dwarf)");
                    player.race = Console.ReadLine();

                    // Saves new player
                    Console.WriteLine(WriteRead.SaveNewPlayer(player));
                }
                else if (input == "n" || input == "no")
                {
                    Console.WriteLine("Enter your characters name");
                    string loginName = Console.ReadLine();
                    Console.WriteLine("Enter your password");
                    string pass = Console.ReadLine();

                    Console.WriteLine(WriteRead.LoadPlayer(loginName, pass, new Player()));

                    login = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid option!");
                }
            }

            // Switch and loop
            StandardMessages.DisplayHelpMessage();
            while (!quit)
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "north":
                    case "n":
                        Movement.MoveNorth(ref position);
                        Console.WriteLine(StandardMessages.DisplayCurrentRoom(position, rooms));
                        Console.WriteLine(StandardMessages.DisplayNextRoomNorth(position, rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomDescription(position, rooms));
                        break;
                    case "south":
                    case "s":
                        Movement.MoveSouth(ref position);
                        Console.WriteLine(StandardMessages.DisplayCurrentRoom(position, rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomDescription(position, rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomsReversed(position, rooms));
                        break;
                    case "q":
                    case "quit":
                        quit = true;
                        break;
                    case "h":
                    case "help":
                        StandardMessages.DisplayHelpMessage();
                        break;
                    case "f":
                    case "fight":
                        // For now you can only fight random monsters
                        Combat.StartFight(player, Combat.RandomMob());
                        StandardMessages.DisplayHelpMessage();
                        break;
                    case "i":
                    case "inventory":
                        // TO DO - Display whats in inventory
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;

                }
            }
        }
    }
}
