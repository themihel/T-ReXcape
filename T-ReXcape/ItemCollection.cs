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
        /// <param name="item">Item to add</param>
        static public void addItem(Item item)
        {
            items.Add(item);
        }

        /// <summary>
        /// find item in list by his key
        /// </summary>
        /// <param name="key">Name / key of item</param>
        /// <returns>Item</returns>
        static public Item getItemByKey(String key)
        {
            // searched Item
            Item tmp = null;

            // search for item
            foreach (Item item in items)
            {
                // item key equals current item
                if (key.Equals(item.getKey()))
                {
                    // item found -> break
                    tmp = item;
                    break;
                }
            }

            // throw exception if item wasn't found
            if (tmp == null)
                throw new Exception("key not found: " + key);

            // return item
            return tmp;
        }

        /// <summary>
        /// check if item is in list by his key
        /// </summary>
        /// <param name="key">Name / key of item</param>
        /// <returns>Boolean if item is set</returns>
        static public bool isItemSet(String key)
        {
            // checkState
            bool result = false;

            // search item
            foreach (Item item in items)
            {
                // item key equals current item
                if (key.Equals(item.getKey()))
                {
                    // item found -> break
                    result = true;
                    break;
                }
            }

            // return checkState if item was found
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
