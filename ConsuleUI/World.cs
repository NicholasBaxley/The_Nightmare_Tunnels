using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace ConsuleUI
{
    public static class World
    {
        // Create lists
        public static List<Potion> potions = SqliteDataAccess.LoadPotions();
        public static List<Item> items = SqliteDataAccess.LoadItems();
        public static List<Room> rooms = SqliteDataAccess.LoadRooms();
        public static List<Mob> mobs = SqliteDataAccess.LoadMobs();
        public static List<Treasure> treasures = SqliteDataAccess.LoadTreasure();
        public static List<Weapon> weapons = SqliteDataAccess.LoadWeapons();

        public static Player player;

        public static int position = 0;
        public static bool quit = false;
    }
}
