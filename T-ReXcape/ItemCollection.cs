using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_ReXcape
{
    static class ItemCollection
    {
        // create empty list of items
        static private List<Item> items = new List<Item>();

        /// <summary>
        /// add new item to list
        /// </summary>
        /// <param name="item"></param>
        static public void addItem(Item item)
        {
            items.Add(item);
        }

        /// <summary>
        /// find item in list by his key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Item</returns>
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

        /// <summary>
        /// check if item is in list by his key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Boolean</returns>
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

        /// <summary>
        /// get all items in list
        /// </summary>
        /// <returns>raw item list</returns>
        static public List<Item> getAllItems()
        {
            return items;
        }

        /// <summary>
        /// disposes all items in list
        /// </summary>
        static public void disposeAllItems()
        {
            items = new List<Item>();
        }
    }
}
