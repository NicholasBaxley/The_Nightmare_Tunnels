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
            // Displays rooms reversed
        public static string DisplayRoomsReversed(int position, List<Room> rooms)
        {
            string roomss = "";
            rooms.Reverse();

            foreach (var name in rooms)
            {
                roomss += "[" + name.name + "] ";
            }

            rooms.Reverse();

            return "Rooms: " + roomss;
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

        public static void DisplayInventory(Player player)
        {
            // TO DO - Display whats the rest of whats in the inventory
            Console.WriteLine("\nWeapon: " + player.equippedWeapon.name);
        }

        public static void DisplayLook(Room room)
        {
            Console.WriteLine("");
            if (room.difficulty > 0)
            {
                Console.WriteLine("[MOBS]--------------");
                if (room.mob.hp == 0)
                {
                    Console.WriteLine("A dead " + room.mob.name + " lays in the corner.");
                }
                else
                {
                    Console.WriteLine("A " + room.mob.name + " watches you from the corner of the room.");
                }
            }

            Console.WriteLine("[ITEMS]--------------");
            foreach (Item item in room.items)
            {
                Console.WriteLine("You see a " + item.name + " in this room.");
            }
        }
    }
}
