using System;
using Objects;
using NightmareEngine;
using System.Windows.Forms;

namespace The_Nightmare_Tunnels
{
    class Program
    {
        static void Main(string[] args)
        {
            World.message = new Alert(Console.WriteLine, Console.Write, Console.ReadLine);

            
            // Log player in
            Login.PlayerLogin();
            Player player = World.player;

            // TODO - For now gives new players a random weapon.
            if (player.equippedWeapon == null)
            {
                player.equippedWeapon = Weapon.RandomWeapon(World.weapons);
            }

            // Shows help message and starting location
            StandardMessages.DisplayHelpMessage();
            World.message.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
            World.message.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));

            // Main Menu that controls most of the game
            NightmareEngine.Menu.Game();
        }
    }
}
