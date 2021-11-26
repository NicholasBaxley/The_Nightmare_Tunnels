/**
* 9/10/2021 (UPDATED - 11/26/2021)
* CSC 253
* Group 4
* Group Members: Nicholas Baxley, Branden Alder
* Last sprint of The Nightmare Tunnels project
*/
using System;
using System.Collections.Generic;
using Objects;

namespace ConsuleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            World.message = new Alert(Console.WriteLine, Console.Write);

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
            Menu.Game();
        }
    }
}
