using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Item : IInventoryItem
    {
        public string name { get; set; }
        public string desc { get; set; }
        public int price { get; set; }
        public bool questItem { get; set; }
        public int id { get; set; }

        public Item()
        {
            name = "Generic Item";
            desc = "Just some rubbish";
        }

        public Item(string itemName, string itemDesc, int itemPrice, bool forQuest, int itemID)
        {
            name = itemName;
            desc = itemDesc;
            price = itemPrice;
            questItem = forQuest;
            id = itemID;
        }

        public static List<Item> RandomItems(List<Item> items, int count)
        {
            var rand = new Random(count);
            List<Item> newItems = new List<Item>();
            int totalItems = rand.Next(1, 4);
            for (int index = 0; index < totalItems; index++)
            {
                Item copyItem = items[rand.Next(0, items.Count)];
                Item newItem = new Item(copyItem.name, copyItem.desc, copyItem.price, copyItem.questItem, copyItem.id);
                newItems.Add(newItem);
            }
            return newItems;
        }
    }
}
