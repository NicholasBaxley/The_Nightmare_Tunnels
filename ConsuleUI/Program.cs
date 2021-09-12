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
            //Intializing all of the list
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
            treasures.Add(new Treasure("Gold Necklace", "PLACEHOLDER", 1000));
            treasures.Add(new Treasure("Gold coin", "PLACEHOLDER", 1));
            treasures.Add(new Treasure("Silver ring", "PLACEHOLDER", 500));

            //Creating all of the items
            items.Add(new Item("Bucket", "PLACEHOLDER"));
            items.Add(new Item("", "PLACEHOLDER"));
            items.Add(new Item("Candle", "PLACEHOLDER"));
            items.Add(new Item("Rope", "PLACEHOLDER"));

            //Creating all of the mobs
            mobs.Add(new Mob("Goblin", "PLACEHOLDER", 5, 3, 20));
            mobs.Add(new Mob("Slime", "PLACEHOLDER", 2, 3, 15));
            mobs.Add(new Mob("Orc", "PLACEHOLDER", 7, 1, 30));
            mobs.Add(new Mob("Wolf", "PLACEHOLDER", 4, 4, 20));
            mobs.Add(new Mob("Demon", "PLACEHOLDER", 5, 2, 25));

            // Creating player
            Player player = new Player();

            int position = 0;
            bool quit = false;
            bool passFlag = false;
            string input;

            // Slop for testing
            Console.WriteLine("Welcome to The Nightmare Tunnels!");
            
            Console.WriteLine("Are you a new player?(y/n)");
            input = Console.ReadLine().ToLower();
            if(input == "y" || input == "yes")
            {
                Console.WriteLine("What is your name?");
                player.Name = Console.ReadLine();
                while (!passFlag)
                {
                    Console.WriteLine("Enter a password. (must contain upper case, lower case and a special character)");
                    string pass = Console.ReadLine();
                    if (Player.CheckPassword(pass))
                    {
                        passFlag = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid password! Your password must contain an uppercase, lowercase and a special character! Try again.");
                    }
                }

                // TODO - input validation
                Console.WriteLine("What class do you want to be? (Warrior or mage)");
                player.Class = Console.ReadLine();
                Console.WriteLine("What race do you want to be? (Human or dwarf)");
                player.Race = Console.ReadLine();

            }
            else if(input == "n")
            {
                // TODO - Add user login, etc
            }

            // Switch and loop
            StandardMessages.DisplayHelpMessage();
            while (!quit)
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "n":
                        Movement.MoveNorth(ref position);
                        Console.WriteLine(StandardMessages.DisplayCurrentRoom(position, rooms));
                        Console.WriteLine(StandardMessages.DisplayNextRoomNorth(position, rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomDescription(position, rooms));
                        break;
                    case "s":
                        Movement.MoveSouth(ref position);
                        Console.WriteLine(StandardMessages.DisplayCurrentRoom(position, rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomDescription(position, rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomsReversed(position, rooms));
                        break;
                    case "quit":
                        quit = true;
                        break;
                    case "help":
                        StandardMessages.DisplayHelpMessage();
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;

                }
            }
        }
    }
}
