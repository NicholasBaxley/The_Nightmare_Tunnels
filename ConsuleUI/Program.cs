using System;
using System.Collections.Generic;
using Objects;

namespace ConsuleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Intializing all of the list
            List<Room> rooms = new List<Room>();
            List<Weapon> weapons = new List<Weapon>();
            List<Potion> potions = new List<Potion>();
            List<Treasure> treasures = new List<Treasure>();
            List<Item> items = new List<Item>();
            List<Mob> mobs = new List<Mob>();

            //Creating all of the rooms
            rooms.Add(new Room("Entrance", "PLACEHOLDER"));
            rooms.Add(new Room("Hall", "PLACEHOLDER"));
            rooms.Add(new Room("Fountain", "PLACEHOLDER"));
            rooms.Add(new Room("Boss room", "PLACEHOLDER"));
            rooms.Add(new Room("Treasure room", "PLACEHOLDER"));

            //Creating all of the weapons
            weapons.Add(new Weapon("Iron sword", 10, 2, 0));
            weapons.Add(new Weapon("Bronze dagger", 6, 3, 0));
            weapons.Add(new Weapon("Steel Mace", 14, 1, 0));
            weapons.Add(new Weapon("Magic Tome", 8, 2, 1));

            //Creating all of the potions
            potions.Add(new Potion("Healing potion", 2));
            potions.Add(new Potion("Mana potion", 1));

            //Creating all of the treasures
            treasures.Add(new Treasure("Gold Necklace", "PLACEHOLDER", 1000));
            treasures.Add(new Treasure("Gold coin", "PLACEHOLDER", 1));
            treasures.Add(new Treasure("Silver ring", "PLACEHOLDER", 500));

            //Creating all of the items
            items.Add(new Item("Bucket", "PLACEHOLDER"));
            items.Add(new Item("Stool", "PLACEHOLDER"));
            items.Add(new Item("Table", "PLACEHOLDER"));
            items.Add(new Item("Plate", "PLACEHOLDER"));

            //Creating all of the mobs
            mobs.Add(new Mob("Goblin", "PLACEHOLDER", 5, 3, 20));
            mobs.Add(new Mob("Slime", "PLACEHOLDER", 2, 3, 15));
            mobs.Add(new Mob("Orc", "PLACEHOLDER", 7, 1, 30));
            mobs.Add(new Mob("Wolf", "PLACEHOLDER", 4, 4, 20));
            mobs.Add(new Mob("Demon", "PLACEHOLDER", 5, 2, 25));
        }
    }
}
