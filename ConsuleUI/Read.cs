using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;
using System.IO;

namespace ConsuleUI
{
    public static class Read
    {
        public static List<Item> CreateItemList()
        {
            List<Item> items = new List<Item>();
            StreamReader inputFile;

            try
            {
                inputFile = File.OpenText("Items.csv");
                inputFile.ReadLine();

                while (!inputFile.EndOfStream)
                {
                    string[] token = inputFile.ReadLine().Split(',');

                    items.Add(new Item(token[0], token[1], int.Parse(token[2]), bool.Parse(token[3]), int.Parse(token[4])));
                }

                inputFile.Close();
                return items;
            }
            catch (Exception)
            {
                Console.WriteLine("Error generating Items");
                return items;
            }
        }
        public static List<Mob> CreateMobList()
        {
            List<Mob> mobs = new List<Mob>();
            StreamReader inputFile;

            try
            {
                inputFile = File.OpenText("Mobs.csv");
                inputFile.ReadLine();

                while (!inputFile.EndOfStream)
                {
                    string[] token = inputFile.ReadLine().Split(',');

                    mobs.Add(new Mob(token[0], token[1], int.Parse(token[2]), int.Parse(token[3]), int.Parse(token[4]), int.Parse(token[5])));
                }

                inputFile.Close();

                return mobs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error generating mobs");

                return mobs;
            }
        }
        public static List<Potion> CreatePotionList()
        {
            List<Potion> potions = new List<Potion>();
            StreamReader inputFile;


            try
            {
                inputFile = File.OpenText("potions.csv");
                inputFile.ReadLine();

                while (!inputFile.EndOfStream)
                {
                    string[] token = inputFile.ReadLine().Split(',');

                    potions.Add(new Potion(token[0], token[1], int.Parse(token[2]), int.Parse(token[3]), int.Parse(token[4])));

                }

                inputFile.Close();

                return potions;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading potions");
                return potions;
            }
        }
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
                                               int.Parse(room[3]),
                                               int.Parse(room[4]),
                                               int.Parse(room[5]),
                                               int.Parse(room[6]),
                                               int.Parse(room[7]),
                                               int.Parse(room[8]));
                    if (roomObject.difficulty > 0)
                    {
                        roomObject.mob = Combat.RandomMob(roomObject.difficulty);
                    }
                    rooms.Add(roomObject);
                }
                return rooms;
            }
            catch (Exception)
            {
                return rooms;
            }
        }
        public static List<Treasure> CreateTreasureList()
        {
            List<Treasure> treasures = new List<Treasure>();
            StreamReader inputFile;



            try
            {
                inputFile = File.OpenText("Treasure.csv");
                inputFile.ReadLine();

                while (!inputFile.EndOfStream)
                {
                    string[] token = inputFile.ReadLine().Split(',');

                    treasures.Add(new Treasure(token[0], token[1], int.Parse(token[2]), bool.Parse(token[3]), int.Parse(token[4])));
                }
                inputFile.Close();

                return treasures;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating treasures");
                return treasures;
            }
        }
        public static List<Weapon> CreateWeaponList()
        {
            List<Weapon> weapons = new List<Weapon>();
            StreamReader inputFile;

            try
            {
                inputFile = File.OpenText("Weapons.csv");
                inputFile.ReadLine();

                while (!inputFile.EndOfStream)
                {
                    string[] token = inputFile.ReadLine().Split(',');

                    weapons.Add(new Weapon(token[0], token[1], int.Parse(token[2]), int.Parse(token[3]), int.Parse(token[4]), int.Parse(token[5])));
                }

                inputFile.Close();
                return weapons;
            }
            catch (Exception)
            {
                Console.WriteLine("Error generating Weapons");
                return weapons;
            }
        }
        // Reads player CSV to load player
        public static string LoadPlayer(string name, string pass, Player player)
        {
            try
            {
                StreamReader inputFile;
                inputFile = File.OpenText("players.csv");

                while (!inputFile.EndOfStream)
                {
                    string line = inputFile.ReadLine();

                    if (line.Contains(name))
                    {
                        string[] playerVals = line.Split(',');

                        if (pass != playerVals[1])
                        {
                            while (pass != playerVals[1])
                            {
                                Console.WriteLine("Player found. However, your password didn't match. Try to enter your password again.");
                                pass = Console.ReadLine();
                                // Endless if you dont know your pass
                            }
                        }
                        else
                        {
                            //Load players info into player obj
                            player.name = playerVals[0];
                            player.password = playerVals[1];
                            player.playerClass = playerVals[2];
                            player.race = playerVals[3];
                            player.hp = int.Parse(playerVals[4]);

                            // TO-DO.. LOAD PLAYERS INVENTORY, location, etc
                        }
                    }
                }

                inputFile.Close();

                return $"Player loaded! Welcome back, {player.name}!";
            }
            catch (Exception)
            {
                return "Error loading player.";
            }
        }
    }
}
