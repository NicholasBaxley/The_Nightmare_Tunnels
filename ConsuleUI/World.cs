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
        public static List<Potion> potions = Read.CreatePotionList();
        public static List<Item> items = Read.CreateItemList();
        public static List<Room> rooms = Read.CreateMap(items);
        public static List<Mob> mobs = Read.CreateMobList();
        public static List<Treasure> treasures = Read.CreateTreasureList();
        public static List<Weapon> weapons = Read.CreateWeaponList();

        public static Player player = new Player();

        public static int position = 0;
        public static bool quit = false;
    }
}
