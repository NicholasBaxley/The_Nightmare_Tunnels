using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using Objects;

namespace ConsuleUI
{
    public class SqliteDataAccess
    {

        //Loads all items into the world list
        public static List<Item> LoadItems() 
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Item>("select * from items", new DynamicParameters());
                return output.ToList();
            }
        }

        //Loads all rooms into the world list and populates them with mobs and items
        public static List<Room> LoadRooms()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Room>("select * from rooms", new DynamicParameters());
                List<Room> rooms = output.ToList();

                //Adding items and mobs to rooms
                for (int index = 0; index < rooms.Count(); index++)
                {
                    Room room = rooms[index];
                    if (room.difficulty > 0)
                    {
                        room.mob = Combat.RandomMob(room.difficulty);
                    }
                    room.items = Item.RandomItems(World.items, index);
                }
                return rooms;
                    
            }
        }

        //Loads all mobs into the world list
        public static List<Mob> LoadMobs()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Mob>("select * from mobs", new DynamicParameters());

                return output.ToList();
            }
        }

        //Loads all potion into the world list
        public static List<Potion> LoadPotions()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Potion>("select * from potions", new DynamicParameters());
                return output.ToList();
            }
        }

        //Loads all treasure into the world list
        public static List<Treasure> LoadTreasure()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Treasure>("select * from treasure", new DynamicParameters());
                return output.ToList();
            }
        }

        //Loads all weapons into the world list
        public static List<Weapon> LoadWeapons()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Weapon>("select * from weapons", new DynamicParameters());
                return output.ToList();
            }
        }
        
        //TODO - Crashes if name doesnt exist, add try statement
        // Loads the player into the game doing login.
        public static void LoadPlayer(string name, string password) // input validation
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QuerySingle<Player>($"select id, name, password, playerClass, race, hp, maxHp, ac, maxAc, dmg" +
                                                     $" from Players where Name=@name", new { name });
                int weaponId = cnn.QuerySingle<int>($"select equippedWeapon" +
                                                     $" from Players where Name=@name", new { name });
                output.equippedWeapon = World.weapons[weaponId];

                if (password == output.password)
                {
                    World.player = output;
                } 
                
                
                
            } 
        }

        public static bool CheckForPass(string name, string pass)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) // Fix after adding inventory
            {
                try
                {
                    string temp = cnn.QuerySingle<string>($"SELECT password " +
                                                          $"  FROM players " +
                                                          $" WHERE name=@name AND password = @pass", new { name,pass });
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        // Updates a players stats
        public static void SavePlayer(Player player)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) // Fix after adding inventory
            {               
                cnn.Execute($"UPDATE players " +
                            $"   SET equippedWeapon = @weaponId, hp = @hp, maxHp = @maxHp, ac = @ac, maxAc = @maxAc, dmg = @dmg " +
                            $" WHERE name = @name", player);
            }
        }

        // Saves a new player
        public static void SaveNewPlayer(Player player)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) // Fix after adding inventory
            {
                cnn.Execute($"insert into players (name, password, playerClass, race, hp, maxHp, ac, maxAc, dmg) " +
                            $"values (@name, @password, @playerClass, @race, @maxHp, @maxHp, @maxAc, @maxAc, @dmg)", player);
            }
        }

        // Checks to see if a playername is in the database
        public static bool CheckForPlayer(string name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) // Fix after adding inventory
            {
                try
                {
                    int temp = cnn.QuerySingle<int>($"SELECT id " +
                                                    $"  FROM players " +
                                                    $" WHERE name=@name ", new { name });
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
        private static string LoadConnectionString(string id= "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
