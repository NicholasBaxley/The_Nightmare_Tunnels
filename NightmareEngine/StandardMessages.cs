using Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightmareEngine
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
                World.message.WriteLine("N: " + rooms[nPosition].name);
            }
            else
            {
                World.message.WriteLine("N: [nothing]");
            }

            int sPosition = rooms[position].sExit;
            if (!(sPosition == -1))
            {
                World.message.WriteLine("S: " + rooms[sPosition].name);
            }
            else
            {
                World.message.WriteLine("S: [nothing]");
            }

            int wPosition = rooms[position].wExit;
            if (!(wPosition == -1))
            {
                World.message.WriteLine("W: " + rooms[wPosition].name);
            }
            else
            {
                World.message.WriteLine("W: [nothing]");
            }

            int ePosition = rooms[position].eExit;
            if (!(ePosition == -1))
            {
                World.message.WriteLine("E: " + rooms[ePosition].name);
            }
            else
            {
                World.message.WriteLine("E: [nothing]");
            }
        }

        // Displays room description
        public static string DisplayRoomDescription(int position, List<Room> rooms)
        {   
            return $"Room description: {rooms[position].desc}";
        }

        // Lists every command the user can use
        public static void DisplayHelpMessage()
        {
            World.message.WriteLine("\nNorth: Moves the player to the northern room.\n"
                            + "South: Moves the player to the southern room.\n"
                            + "West: Moves the player to the western room.\n"
                            + "East: Moves the player to the eastern room.\n"
                            + "Directions: Shows you the rooms that are connected to this one.\n"
                            + "Quit: Closes the program.\n"
                            + "Help: Provides a list of commands.\n"
                            + "Fight: Fight the monsters in the current room.\n"
                            + "Inventory: Shows your inventory and items.\n"
                            + "Look: Examine what is in the room.\n"
                            + "Save: Saves your player.\n"
                            + "MoveEnemies: A Test Command that forces all enemies to move.\n");
        }

        //Gives you the commands for the inventory menu
        public static void DisplayInventoryMenu()
        {
            World.message.WriteLine("\nWhat would you like to do?" +
                              "\nAll" +
                              "\nWeapon" +
                              "\nItems" +
                              "\nDiscard" +
                              "\nClose");
        }

        //Display the currently equipped weapon
        public static void DisplayInventoryWeapon(Player player)
        {
            World.message.WriteLine("\n[WEAPON]-----------------------");
            World.message.WriteLine(player.equippedWeapon.name);
        }

        //Displays all your items
        public static void DisplayInventoryItems(Player player)
        {
            int count = 0;
            World.message.WriteLine("\n[ITEMS]-----------------------");
            foreach (IInventoryItem item in player.inventory)
            {
                World.message.WriteLine($"[{count}] " + item.name);
                count++;
            }
        }

        // Displays all potions
        public static void DisplayPotions(Player player)
        {
            int count = 0;
            World.message.WriteLine("\n[POTIONS]-----------------------");
            foreach (IInventoryItem item in player.inventory)
            {
                if(item is Potion)
                {
                    World.message.WriteLine($"[{count}] " + item.name);
                }
                count++;
            }
        }

        // Displays all potions and returns a list of their ids
        public static List<int> DisplayPotionsAndIds(Player player)
        {
            List<int> validPots = new List<int>();
            int count = 0;
            World.message.WriteLine("\n[POTIONS]-----------------------");
            foreach (IInventoryItem item in player.inventory)
            {
                if (item is Potion)
                {
                    validPots.Add(count);
                    World.message.WriteLine($"[{count}] " + item.name);
                }
                count++;
            }
            return validPots;
        }

        //Displays both your weapon and items
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

        public static void NoMobsInRoom()
        {
            World.message.WriteLine("There are no mobs in this room");
        }

        //Displays the current rooms mobs
        public static void DisplayRoomMobs(Room room)
        {   
                World.message.WriteLine("\n[MOBS]--------------");
                if (room.mob == null)
                {
                World.message.WriteLine("");
                }
                else
                {
                    World.message.WriteLine("A " + room.mob.name + " watches you from the corner of the room.");
                }
        }

        //Displays the current rooms items
        public static void DisplayRoomItems(Room room)
        {
            int count = 0;

            World.message.WriteLine("\n" + "[ITEMS]--------------");
            foreach (Item item in room.items)
            {
                World.message.WriteLine($"[{count}]You see a " + item.name + " in this room.");
                count++;
            }
        }

    }
}
