using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Objects
{
    public class Room
    {
        public string name { get; set; }
        public string desc { get; set; }
        public bool locked { get; set; }
        public int difficulty { get; set; }
        public int id { get; set; }
        // The exits should be the ids of the room they connect to
        public int nExit { get; set; }
        public int sExit { get; set; }
        public int wExit { get; set; }
        public int eExit { get; set; }

        public Room()
        {
            name = "Generic Room";
            desc = "Nothing in here!";
            locked = false;
            id = 0;
        }

        // Creates a list of all the rooms in the game.
        public static List<Room> CreateMap()
        {
            List<Room> rooms = new List<Room>();
            try
            {
                StreamReader inputFile = File.OpenText("rooms.csv");
                // This skips the first line of the file
                inputFile.ReadLine();
                while (!inputFile.EndOfStream)
                {
                    string roomline = inputFile.ReadLine();
                    string[] room = roomline.Split(',');
                    Room roomObject = new Room(room[0],
                                               room[1],
                                               bool.Parse(room[2]),
                                               Int32.Parse(room[3]),
                                               Int32.Parse(room[4]),
                                               Int32.Parse(room[5]),
                                               Int32.Parse(room[6]),
                                               Int32.Parse(room[7]),
                                               Int32.Parse(room[8]));
                    rooms.Add(roomObject);
                }
                return rooms;
            }
            catch (Exception)
            {
                return rooms;
            } 
        }


        ///add e exit here
        ///finish adding room ids
        public Room(string roomName, string roomDesc, bool roomLocked, int roomdifficulty, int roomId, int roomNExit, int roomSExit, int roomWExit, int roomEExit)
        {
            name = roomName;
            desc = roomDesc;
            locked = roomLocked;
            difficulty = roomdifficulty;
            id = roomId;
            nExit = roomNExit;
            sExit = roomSExit;
            wExit = roomWExit;
            eExit = roomEExit;
        }
    }
}