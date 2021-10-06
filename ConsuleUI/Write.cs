using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;
using System.IO;

namespace ConsuleUI
{
    public static class Write
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
            catch (Exception)
            {
                return "Error saving player.";
            }
        }

    }
}
