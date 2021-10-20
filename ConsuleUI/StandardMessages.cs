using Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsuleUI
{
    public class StandardMessages
    {
            // Displays current room
        public static string DisplayCurrentRoom(int position, List<Room> rooms)
        {   
            return $"\nCurrent room: {rooms[position].name}"; 
        }

            // Displays next rooms
        public static void DisplayNextRooms(int position, List<Room> rooms)
        {
            int nPosition = rooms[position].nExit;
            if (!(nPosition == -1))
            {
                Console.WriteLine("N: " + rooms[nPosition].name);
            }
            else
            {
                Console.WriteLine("N: [nothing]");
            }

            int sPosition = rooms[position].sExit;
            if (!(sPosition == -1))
            {
                Console.WriteLine("S: " + rooms[sPosition].name);
            }
            else
            {
                Console.WriteLine("S: [nothing]");
            }

            int wPosition = rooms[position].wExit;
            if (!(wPosition == -1))
            {
                Console.WriteLine("W: " + rooms[wPosition].name);
            }
            else
            {
                Console.WriteLine("W: [nothing]");
            }

            int ePosition = rooms[position].eExit;
            if (!(ePosition == -1))
            {
                Console.WriteLine("E: " + rooms[ePosition].name);
            }
            else
            {
                Console.WriteLine("E: [nothing]");
            }
        }

            // Displays room description
        public static string DisplayRoomDescription(int position, List<Room> rooms)
        {   
            return $"Room description: {rooms[position].desc}";
        }

            // Lists every command the user can use
            // TODO - dont forget to add messages for any commands you add
        public static void DisplayHelpMessage()
        {
            Console.WriteLine("\nNorth: Moves the player to the northern room.\n"
                            + "South: Moves the player to the southern room.\n"
                            + "West: Moves the player to the western room.\n"
                            + "East: Moves the player to the eastern room.\n"
                            + "Directions: Shows you the rooms that are connected to this one.\n"
                            + "Quit: Closes the program.\n"
                            + "Help: Provides a list of commands.\n"
                            + "Fight: Fight the monsters in the current room.\n"
                            + "Inventory: Shows your inventory and items.\n"
                            + "Look: Examines whats in the room.\n"
                            + "Save: Saves your player.\n");
        }

        //Gives you the commands for the inventory menu
        public static void DisplayInventoryMenu()
        {
            Console.WriteLine("\nWhat would you like to do?" +
                              "\nAll" +
                              "\nWeapon" +
                              "\nItems" +
                              "\nDiscard" +
                              "\nClose");
        }

        //Display the currently equipped weapon
        public static void DisplayInventoryWeapon(Player player)
        {
            Console.WriteLine("\n[WEAPON]-----------------------");
            Console.WriteLine(player.equippedWeapon.name);
        }

        //Displays all your items
        public static void DisplayInventoryItems(Player player)
        {
            int count = 0;
            Console.WriteLine("\n[ITEMS]-----------------------");
            foreach (IInventoryItem item in player.inventory)
            {
                Console.WriteLine($"[{count}] " + item.name);
                count++;
            }
        }

        //Displays both yuor weapon and items
        public static void DisplayInventoryAll(Player player)
        {
            DisplayInventoryWeapon(player);
            DisplayInventoryItems(player);
        }

        // Displays all mobs and items in the current room
        public static void DisplayLook(Room room)
        {
            DisplayRoomMobs(room);
            DisplayRoomItems(room);
        }

        //Displays the current rooms mobs
        public static void DisplayRoomMobs(Room room)
        {
            if (room.difficulty > 0)
            {
                Console.WriteLine("\n[MOBS]--------------");
                if (room.mob.hp == 0)
                {
                    Console.WriteLine("A dead " + room.mob.name + " lays in the corner.");
                }
                else
                {
                    Console.WriteLine("A " + room.mob.name + " watches you from the corner of the room.");
                }
            }
        }

        //Displays the current rooms items
        public static void DisplayRoomItems(Room room)
        {
            int count = 0;
            Console.WriteLine("\n[ITEMS]--------------");
            foreach (Item item in room.items)
            {
                Console.WriteLine($"[{count}]You see a " + item.name + " in this room.");
                count++;
            }
        }
    }
}
