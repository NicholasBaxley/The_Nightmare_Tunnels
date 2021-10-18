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
                        Console.WriteLine("Invalid input.");
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
                Console.WriteLine("\nType the id of the item you want to delete or type Quit to leave.");
                input = Console.ReadLine().ToLower();

                if (input == "quit" || input == "q")
                {
                    quit = true;
                    input = "fail boolean check";
                }

                bool succuess = int.TryParse(input, out id);
                if (succuess)
                {
                    if (id < 0)
                    {
                        Console.WriteLine("Items cant have negative id's!");
                    }
                    else if (id > player.inventory.Count() - 1)
                    {
                        Console.WriteLine("That item doesnt exist!");
                    }
                    else
                    {
                        player.inventory.RemoveAt(id);
                        Console.WriteLine("Item deleted!");
                    }               
                }
            }                 
        }
    }
}
