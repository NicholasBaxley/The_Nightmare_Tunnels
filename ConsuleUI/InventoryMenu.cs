using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Objects;
using System.Threading.Tasks;

namespace ConsuleUI
{
    public class InventoryMenu
    {
        public static void DisplayInventory(Player player)
        {
            bool quit = false;
            string input;
            while (!quit)
            {
                StandardMessages.DisplayInventoryMenu();
                input = Console.ReadLine().ToLower(); ;
                switch (input)
                {
                    case "a":
                    case "all":
                        StandardMessages.DisplayInventoryAll(player);
                        break;
                    case "w":
                    case "weapon":
                        StandardMessages.DisplayInventoryWeapon(player);
                        break;
                    case "i":
                    case "items":
                        StandardMessages.DisplayInventoryItems(player);
                        break;
                    case "d":
                    case "discard":
                        DiscardItemMenu(player);
                        break;
                    case "c":
                    case "close":
                        quit = true;
                        break;
                    default:
                        World.message.WriteLine("Invalid input.");
                        break;
                }
            }
        }

        private static void DiscardItemMenu(Player player)
        {
            string input;
            int id;
            bool quit = false;
            while (!quit)
            {
                StandardMessages.DisplayInventoryItems(player);
                World.message.WriteLine("\nType the id of the item you want to delete or type Quit to leave.");
                input = Console.ReadLine().ToLower();

                if (input == "quit" || input == "q")
                {
                    quit = true;
                    input = "";
                }

                bool succuess = int.TryParse(input, out id);
                if (succuess)
                {
                    if (id < 0)
                    {
                        World.message.WriteLine("Items cant have negative id's!");
                    }
                    else if (id > player.inventory.Count() - 1)
                    {
                        World.message.WriteLine("That item doesnt exist!");
                    }
                    else
                    {
                        player.inventory.RemoveAt(id);
                        World.message.WriteLine("Item deleted!");
                    }               
                }
            }                 
        }

        public static void TakeItem(Player player, Room room)
        {
            string input;
            int id;
            bool quit = false;
            while (!quit)
            {
                StandardMessages.DisplayRoomItems(room);
                World.message.WriteLine("\nType the id of the item you want to take or type All to take all items or Quit to go back to the game menu.");
                input = Console.ReadLine().ToLower();

                if (input == "quit" || input == "q")
                {
                    quit = true;
                    input = "fail boolean check";
                }
                else if (input == "all" || input == "a")
                {
                    quit = true;
                    input = "fail boolean check";
                    for (int index = 0; index != room.items.Count();)
                    {
                        player.inventory.Add(room.items[index]);
                        room.items.Remove(room.items[index]);
                    }
                    World.message.WriteLine("You took all the items!");

                }

                bool succuess = int.TryParse(input, out id);
                if (succuess)
                {
                    if (id < 0)
                    {
                        World.message.WriteLine("Items cant have negative id's!");
                    }
                    else if (id > player.inventory.Count() - 1)
                    {
                        World.message.WriteLine("That item doesnt exist!");
                    }
                    else
                    {                     
                        player.inventory.Add(room.items[id]);
                        room.items.RemoveAt(id);
                        World.message.WriteLine("Item Obtained!");
                    }
                }
            }
        }

        public static Potion GrabPotionFromInv()
        {
            bool loop = true;
            List<int> validPots = StandardMessages.DisplayPotionsAndIds(World.player);
            Console.WriteLine("What potion do you want to use?");
            Potion pot = new Potion();
            string input;
            while (loop)
            {
                input = Console.ReadLine();
                bool succuess = int.TryParse(input, out int id);
                if (succuess)
                {
                    if (id < 0)
                    {
                        World.message.WriteLine("Items cant have negative id's!");
                    }
                    else if (!validPots.Contains(id))
                    {
                        World.message.WriteLine("That item doesnt exist!");
                    }
                    else
                    {
                        loop = false;
                        Potion temp = (Potion)World.player.inventory[id];
                        pot = new Potion(temp.id, temp.name, temp.desc, temp.dmg);
                        World.player.inventory.RemoveAt(id);
                    }
                }
                else
                {
                    World.message.WriteLine("Enter a Valid ID!");
                }                
            }
            return pot;
        }
    }
}
