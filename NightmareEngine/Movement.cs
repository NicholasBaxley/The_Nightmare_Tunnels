using System;
using System.Collections.Generic;
using System.Linq;
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
                MoveEnemies();

            }
        }

        public static void MoveSouth(ref int position, List<Room> rooms)
        {
            int newPosition = rooms[position].sExit;
            if (!(newPosition == -1))
            {
                position = newPosition;
                MoveEnemies();

            }
        }

        public static void MoveWest(ref int position, List<Room> rooms)
        {
            int newPosition = rooms[position].wExit;
            if (!(newPosition == -1))
            {
                position = newPosition;
                MoveEnemies();

            }
        }

        public static void MoveEast(ref int position, List<Room> rooms)
        {
            int newPosition = rooms[position].eExit;
            if (!(newPosition == -1))
            {
                position = newPosition;
                MoveEnemies();
            }
        }

        // Moves all enemies on the map to a new location
        public static void MoveEnemies()
        {
            // Ids of rooms mobs are not allowed into, i.e. Boss Room, Entrance, Exit
            int[] notAllowedRooms = new int[5] { -1, 3, 17, 6, 19};
            
            List<Room> rooms = World.rooms;

            // Checks all rooms if they have a mob in them and moves it
            for (int index = 0; index < rooms.Count; index++) 
            {
                Random rand = new Random();
                rand.Next();
                Room room = rooms[index];
                List<int> allowedRooms = new List<int>();

                

                // Checks to see if the mob is a moveable one (not a boss or a prevoiusly moved mob)
                if (room.mob != null && !room.mob.isBoss && !room.mob.moved)
                {

                    // If the room is a room they are allowed into and the room doesnt have a mob in it, adds the room as a option for moving into.
                    List<Room> moveable = new List<Room>();
                    if (!notAllowedRooms.Contains(room.nExit) && World.rooms[room.nExit].mob == null)
                    {
                        allowedRooms.Add(room.nExit);
                    }
                    if (!notAllowedRooms.Contains(room.eExit) && World.rooms[room.eExit].mob == null)
                    {
                        allowedRooms.Add(room.eExit);
                    }
                    if (!notAllowedRooms.Contains(room.sExit) && World.rooms[room.sExit].mob == null)
                    {
                        allowedRooms.Add(room.sExit);
                    }
                    if (!notAllowedRooms.Contains(room.wExit) && World.rooms[room.wExit].mob == null)
                    {
                        allowedRooms.Add(room.wExit);
                    }

                    //If there is a moveable room(s), decides which one to use here
                    if (allowedRooms.Count > 0)
                    {
                        int roomID;
                        int randomNumber = rand.Next(0, allowedRooms.Count);

                        roomID = allowedRooms[randomNumber];
                        World.rooms[roomID].mob = room.mob.CopyMob();
                        //Once a mob is moved, its not allowed to move again untill player is able to make another choice
                        World.rooms[roomID].mob.moved = true;
                        room.mob = null;
                    }                   
                }
            }

            // Reset all mobs to be moveable again
            foreach (Room room in World.rooms)
            {
                if (room.mob != null)
                {
                    room.mob.moved = false;
                }
            }
        }
    }
}
