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
            //Creating the map
            List<Room> rooms = Read.CreateMap();
            List<Potion> potions = Read.CreatePotionList();
            List<Item> items = Read.CreateItemList();
            List<Mob> mobs = Read.CreateMobList();
            List<Treasure> treasures = Read.CreateTreasureList();
            List<Weapon> weapons = Read.CreateWeaponList();

            // Creating player
            Player player = new Player();

            // TODO - For now give player a random weapon, later save player weapon to file
            player.equippedWeapon = Weapon.RandomWeapon(weapons);

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

                    Console.WriteLine(Read.LoadPlayer(loginName, pass, new Player()));

                    login = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid option!");
                }
            }

            // Switch and loop
            StandardMessages.DisplayHelpMessage();
            Console.WriteLine(StandardMessages.DisplayCurrentRoom(position, rooms));
            Console.WriteLine(StandardMessages.DisplayRoomDescription(position, rooms));
            while (!quit)
            {

                switch (Console.ReadLine().ToLower())
                {
                    case "north":
                    case "n":
                        Movement.MoveNorth(ref position, rooms);
                        Console.WriteLine(StandardMessages.DisplayCurrentRoom(position, rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomDescription(position, rooms));
                        StandardMessages.DisplayNextRooms(position, rooms);
                        break;
                    case "south":
                    case "s":
                        Movement.MoveSouth(ref position, rooms);
                        Console.WriteLine(StandardMessages.DisplayCurrentRoom(position, rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomDescription(position, rooms));
                        StandardMessages.DisplayNextRooms(position, rooms);
                        break;
                    case "west":
                    case "w":
                        Movement.MoveWest(ref position, rooms);
                        Console.WriteLine(StandardMessages.DisplayCurrentRoom(position, rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomDescription(position, rooms));
                        StandardMessages.DisplayNextRooms(position, rooms);
                        break;
                    case "east":
                    case "e":
                        Movement.MoveEast(ref position, rooms);
                        Console.WriteLine(StandardMessages.DisplayCurrentRoom(position, rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomDescription(position, rooms));
                        StandardMessages.DisplayNextRooms(position, rooms);
                        break;
                    case "directions":
                    case "d":
                        StandardMessages.DisplayNextRooms(position, rooms);
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
                        if (rooms[position].difficulty == 0)
                        {
                            Console.WriteLine("There are no monsters in this room.");
                        }
                        else
                        {
                            Combat.StartFight(player, Combat.RandomMob(rooms[position].difficulty, mobs));
                            StandardMessages.DisplayHelpMessage();
                        }                        
                        break;
                    case "i":
                    case "inventory":
                        StandardMessages.DisplayInventory(player);                       
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;

                }
            }
        }
    }
}
