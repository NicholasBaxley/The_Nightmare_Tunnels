using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace ConsuleUI
{
    public class Menu
    {
        public static void Game()
        {
            Player player = World.player;

            while (!World.quit)
            {
                World.message.Write("Input >> ");
                switch (Console.ReadLine().ToLower())
                {
                    case "north":
                    case "n":
                        Movement.MoveNorth(ref World.position, World.rooms);
                        Console.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
                        Console.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));
                        StandardMessages.DisplayNextRooms(World.position, World.rooms);
                        break;
                    case "south":
                    case "s":
                        Movement.MoveSouth(ref World.position, World.rooms);
                        World.message.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
                        World.message.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));
                        StandardMessages.DisplayNextRooms(World.position, World.rooms);
                        break;
                    case "west":
                    case "w":
                        Movement.MoveWest(ref World.position, World.rooms);
                        World.message.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
                        World.message.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));
                        StandardMessages.DisplayNextRooms(World.position, World.rooms);
                        break;
                    case "east":
                    case "e":
                        Movement.MoveEast(ref World.position, World.rooms);
                        World.message.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
                        World.message.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));
                        StandardMessages.DisplayNextRooms(World.position, World.rooms);
                        break;
                    case "directions":
                    case "d":
                        StandardMessages.DisplayNextRooms(World.position, World.rooms);
                        break;
                    case "q":
                    case "quit":
                        SqliteDataAccess.SavePlayer(player);
                        World.quit = true;
                        break;
                    case "h":
                    case "help":
                        StandardMessages.DisplayHelpMessage();
                        break;
                    case "f":
                    case "fight":
                        // For now you can only fight random monsters
                        if (World.rooms[World.position].mob == null)
                        {
                            StandardMessages.NoMobsInRoom();
                        }
                        else if (World.rooms[World.position].mob.hp == 0)
                        {
                            StandardMessages.NoMobsInRoom();
                        }
                        else
                        {
                            Combat.StartFight(player, World.rooms[World.position].mob);
                            StandardMessages.DisplayHelpMessage();
                        }
                        break;
                    case "i":
                    case "inventory":
                        InventoryMenu.DisplayInventory(player);
                        World.message.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
                        World.message.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));
                        break;
                    case "l":
                    case "look":
                        StandardMessages.DisplayLook(World.rooms[World.position]);
                        break;
                    case "t":
                    case "take":
                        InventoryMenu.TakeItem(player, World.rooms[World.position]);
                        World.message.WriteLine(StandardMessages.DisplayCurrentRoom(World.position, World.rooms));
                        World.message.WriteLine(StandardMessages.DisplayRoomDescription(World.position, World.rooms));
                        break;
                    case "save":
                        SqliteDataAccess.SavePlayer(player);
                        World.message.WriteLine("Saved.");
                        break;
                    case "me":
                    case "moveenemies":
                        Movement.MoveEnemies();
                        World.message.WriteLine("\nEnemies Moved");
                        break;
                    default:
                        World.message.WriteLine("Invalid input.");
                        break;
                }
            }
        }
    }
}
