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
            return $"Current room: {rooms[position].name}"; 
        }

            // Displays next room
        public static string DisplayNextRoomNorth(int position, List<Room> rooms)
        {
            if(position < rooms.Count - 1)
            {
                return $"Next Room: {rooms[position + 1].name}";
            }
            else
            {
                return "There is no room further north";
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
            Console.WriteLine("North: moves the player to the northern room.\n"
                            + "South: moves the player to the southern room.\n"
                            + "Quit: Closes the program\n"
                            + "Help: Provides a list of commands\n");
        }
    }
}
