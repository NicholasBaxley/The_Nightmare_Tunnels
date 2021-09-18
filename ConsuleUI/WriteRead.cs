using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;
using System.IO;

namespace ConsuleUI
{
    public static class WriteRead
    {
        //  Saves new players into csv file
        public static string SaveNewPlayer(Player player)
        {
            try
            {
                // Open player file.
                StreamWriter outputFile;
                outputFile = new StreamWriter("players.csv", true);

                outputFile.WriteLine($"{player.name},{player.password},{player.playerClass},{player.race},{player.hp}");

                outputFile.Close();

                return "New player saved!";
            }
            catch(Exception ex)
            {
                return "Error saving player.";
            }
        }

        //  Finds player from csv and loads it
        public static string LoadPlayer(string name, string pass, Player player)
        {   
            try
            {
                StreamReader inputFile;
                inputFile = File.OpenText("players.csv");

                while(!inputFile.EndOfStream)
                {
                    string line = inputFile.ReadLine();

                    if(line.Contains(name))
                    {
                        string[] playerVals = line.Split(',');

                        if(pass != playerVals[1])
                        {
                            while(pass != playerVals[1])
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
            catch(Exception ex)
            {
                return "Error loading player.";
            }
        }
    }
}
