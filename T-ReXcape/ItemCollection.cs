using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_ReXcape
{
    static class ItemCollection
    {
        static private List<Item> items = new List<Item>();

        static public void addItem(Item item)
        {
            items.Add(item);
        }

        static public Item getItemByKey(String key)
        {
            Item tmp = null;
            foreach (Item item in items)
            {
                if (key.Equals(item.getKey()))
                {
                    tmp = item;
                    break;
                }
            }
            if (tmp == null)
                throw new Exception("key not found: " + key);

            return tmp;
        }

        static public bool isItemSet(String key)
        {
            bool result = false;
            foreach (Item item in items)
            {
                if (key.Equals(item.getKey()))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        static public List<Item> getAllItems()
        {
            return items;
        }
    }
}
