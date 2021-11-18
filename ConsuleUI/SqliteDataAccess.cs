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

        // Loads all items into the world list
        public static List<Item> LoadItems() 
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Item>("select * from items", new DynamicParameters());
                return output.ToList();
            }
        }

        // Loads all rooms into the world list and populates them with mobs and items
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
                    else
                    {
                        room.mob = null;
                    }
                    switch (room.id)
                    {
                        case 3:
                        case 17:
                            room.mob.isBoss = true;
                            break;
                        default:
                            break;
                    }
                    room.items = Item.RandomItems(World.items);
                }
                return rooms;                  
            }
        }

        // Loads all mobs into the world list
        public static List<Mob> LoadMobs()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Mob>("select * from mobs", new DynamicParameters());

                return output.ToList();
            }
        }

        // Loads all potion into the world list
        public static List<Potion> LoadPotions()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Potion>("select * from potions", new DynamicParameters());
                return output.ToList();
            }
        }

        // Loads all treasure into the world list
        public static List<Treasure> LoadTreasure()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Treasure>("select * from treasure", new DynamicParameters());
                return output.ToList();
            }
        }

        // Loads all weapons into the world list
        public static List<Weapon> LoadWeapons()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Weapon>("select * from weapons", new DynamicParameters());
                return output.ToList();
            }
        }
        
        // Loads the player into the game doing login.
        public static void LoadPlayer(string name, string password)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QuerySingle<Player>($"SELECT id, name, password, playerClass, race, hp, maxHp, ac, maxAc, dmg " +
                                                     $" FROM players " +
                                                     $"WHERE Name=@name ", new { name });
                int weaponId = cnn.QuerySingle<int>($"SELECT equippedWeapon" +
                                                     $" FROM Players " +
                                                     $"WHERE Name=@name", new { name });
                string invString = cnn.QuerySingle<string>($"SELECT inventory " +
                                                           $"  FROM players " +
                                                           $" WHERE Name=@name ", new { name });
                List<IInventoryItem> items = new List<IInventoryItem>();

                if (password == output.password)
                {
                    

                    // Remakes the weapon from its id
                    output.equippedWeapon = World.weapons[weaponId];

                    // Rebuilds all the items from their string ids if their inventory is not empty
                    if (!(invString == ""))
                    {
                        invString = invString.TrimEnd(',');
                        string[] tokens = invString.Split(',');

                        foreach (string token in tokens)
                        {
                            char itemType = token[0];
                            int id;
                            switch (itemType)
                            {
                                case 't':
                                    id = int.Parse(token.TrimStart('t'));
                                    Treasure t = World.treasures[id];
                                    output.inventory.Add(new Treasure(t.name, t.desc, t.value, t.questItem, t.id));
                                    break;
                                case 'i':
                                    id = int.Parse(token.TrimStart('i'));
                                    Item i = World.items[id];
                                    output.inventory.Add(new Item(i.name, i.desc, i.price, i.questItem, i.id));
                                    break;
                                default:
                                    id = int.Parse(token.TrimStart('p'));
                                    Potion p = World.potions[id];
                                    output.inventory.Add(new Potion(p.id, p.name, p.desc, p.healthRestore, p.dmg));
                                    break;
                            }
                        }
                    }
                    
                    // Sets the player stats
                    World.player = output;
                }                             
            } 
        }

        // Makes sure the password is correct when you try to log in.
        public static bool CheckForPass(string name, string pass)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    string temp = cnn.QuerySingle<string>($"SELECT password " +
                                                          $"  FROM players " +
                                                          $" WHERE name=@name AND password = @pass ", new { name,pass });
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
        }

        // Compresses the inventory down into a single string.
        public static string MakeInvString(Player player)
        {
            string invString = "";
            string part1;
            string part2;

            foreach (IInventoryItem thing in player.inventory)
            {
                if (thing.GetType() == typeof(Item))
                {
                    part1 = "i";
                    part2 = thing.id.ToString();
                }
                else if (thing.GetType() == typeof(Treasure))
                {
                    part1 = "t";
                    part2 = thing.id.ToString();
                }
                else
                {
                    part1 = "p";
                    part2 = thing.id.ToString();
                }
                invString += (part1 + part2 + ",");
            }

            return invString;
        }

        // Updates a players stats
        public static void SavePlayer(Player player)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string invString = MakeInvString(player);
                string playerName = player.name;

                cnn.Execute($"UPDATE players " +
                            $"   SET equippedWeapon = @weaponId, hp = @hp, maxHp = @maxHp, ac = @ac, maxAc = @maxAc, dmg = @dmg" +
                            $" WHERE name = @name",  player);

                cnn.Execute($"UPDATE players " +
                            $"   SET inventory = @invString" +
                            $" WHERE name = @playerName", new { invString,playerName } );
            }
        }

        // Saves a new player
        public static void SaveNewPlayer(Player player)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"INSERT into players (name, password, playerClass, race, hp, maxHp, ac, maxAc, dmg) " +
                            $"VALUES (@name, @password, @playerClass, @race, @maxHp, @maxHp, @maxAc, @maxAc, @dmg)", player);
            }
        }

        // Checks to see if a playername is in the database
        public static bool CheckForPlayer(string name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    int temp = cnn.QuerySingle<int>($"SELECT id " +
                                                    $"  FROM players " +
                                                    $" WHERE name=@name ", new { name });
                    return true;
                }
                catch(Exception)
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
