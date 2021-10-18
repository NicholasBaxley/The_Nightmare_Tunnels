/**
* 9/10/2021 (UPDATED - 10/06/2021)
* CSC 253
* Group 4
* Group Members: Nicholas Baxley, Branden Alder
* Third sprint of The Nightmare Tunnels project
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
            Console.WriteLine("Welcome to The Nightmare Tunnels!");

            // Log player in
            Login.PlayerLogin();
            Player player =  World.player;

            // TODO - For now gives new players a random weapon.
            if (player.equippedWeapon == null)
            {
                player.equippedWeapon = Weapon.RandomWeapon(World.weapons);
            }
            

            // Switch and loop
            StandardMessages.DisplayHelpMessage();
            Console.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
            Console.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));

            while (!World.quit)
            {

                switch (Console.ReadLine().ToLower())
                {
                    case "north":
                    case "n":
                        Movement.MoveNorth(ref World.position, World.rooms);
                        Console.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));
                        StandardMessages.DisplayNextRooms(World.position, World.rooms);
                        break;
                    case "south":
                    case "s":
                        Movement.MoveSouth(ref World.position, World.rooms);
                        Console.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));
                        StandardMessages.DisplayNextRooms(World.position, World.rooms);
                        break;
                    case "west":
                    case "w":
                        Movement.MoveWest(ref World.position, World.rooms);
                        Console.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));
                        StandardMessages.DisplayNextRooms(World.position, World.rooms);
                        break;
                    case "east":
                    case "e":
                        Movement.MoveEast(ref World.position, World.rooms);
                        Console.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));
                        StandardMessages.DisplayNextRooms(World.position, World.rooms);
                        break;
                    case "directions":
                    case "d":
                        StandardMessages.DisplayNextRooms(World.position, World.rooms);
                        break;
                    case "q":
                    case "quit":
                        World.quit = true;
                        break;
                    case "h":
                    case "help":
                        StandardMessages.DisplayHelpMessage();
                        break;
                    case "f":
                    case "fight":
                        // For now you can only fight random monsters
                        if (World.rooms[World.position].difficulty == 0)
                        {
                            Console.WriteLine("There are no monsters in this room.");
                        }
                        else if (World.rooms[World.position].mob.hp == 0)
                        {
                            Console.WriteLine("There are no more monsters in this room.");
                        }
                        else
                        {
                            Combat.StartFight(player, World.rooms[World.position].mob);
                            StandardMessages.DisplayHelpMessage();
                        }                        
                        break;
                    case "i":
                    case "inventory":
                        InventoryMenu.DisplayInventory(player);
                        StandardMessages.DisplayHelpMessage();
                        break;
                    case "l":
                    case "look":
                        StandardMessages.DisplayLook(World.rooms[World.position]);
                        break;
                    case "save":
                        SqliteDataAccess.SavePlayer(player);
                        Console.WriteLine("Hopefully Saved.");
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;

                }
            }
        }
    }
}
