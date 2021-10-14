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

        public static List<Item> LoadItems() 
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Item>("select * from items", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Room> LoadRooms()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Room>("select * from rooms", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Mob> LoadMobs()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Mob>("select * from mobs", new DynamicParameters());

                return output.ToList();
            }
        }

        public static List<Potion> LoadPotions()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Potion>("select * from potions", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Treasure> LoadTreasure()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Treasure>("select * from treasure", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Weapon> LoadWeapons()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Weapon>("select * from weapons", new DynamicParameters());
                return output.ToList();
            }
        }
        
        public static Player LoadPlayer(string name, string password) // input validation
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QuerySingle<Player>($"select * from players where Name=@name", new { name });
                if(password == output.password)
                {
                    return output;
                } 
                
                
                
            } 
            return null;
        }

        public static void SavePlayer(Player player)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) // Fix after adding inventory
            {
                cnn.Execute("");
            }
        }

        public static void SaveNewPlayer(Player player)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) // Fix after adding inventory
            {
                cnn.Execute($"insert into players (Name, Password, Class, Race, currentHP) values (@name, @password, @playerClass, @race, @hp)", player);
            }
        }

        private static string LoadConnectionString(string id= "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
