using System;
using System.Collections.Generic;
using System.Text;
using Objects;

namespace ConsuleUI
{
    public class Movement
    {
        public static void MoveNorth(ref int position, List<Room> rooms)
        {
            int newPosition = rooms[position].nExit;
            if (!(newPosition == -1))
            {
                position = newPosition;
            }
        }

        public static void MoveSouth(ref int position, List<Room> rooms)
        {
            int newPosition = rooms[position].sExit;
            if (!(newPosition == -1))
            {
                position = newPosition;
            }
        }

        public static void MoveWest(ref int position, List<Room> rooms)
        {
            int newPosition = rooms[position].wExit;
            if (!(newPosition == -1))
            {
                position = newPosition;
            }
        }

        public static void MoveEast(ref int position, List<Room> rooms)
        {
            int newPosition = rooms[position].eExit;
            if (!(newPosition == -1))
            {
                position = newPosition;
            }
        }
    }
}
