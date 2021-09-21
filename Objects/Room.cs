﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Room
    {
        public string name { get; set; }
        public string desc { get; set; }
        public bool locked { get; set; }
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


        ///add e exit here
        ///finish adding room ids
        public Room(string roomName, string roomDesc, bool roomLocked = false, int roomId)
        {
            name = roomName;
            desc = roomDesc;
            locked = roomLocked;
            id = roomId;
        }
    }
}