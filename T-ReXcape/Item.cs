using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_ReXcape
{
    class Item
    {
        // variables
        private String key;
        private String background;
        private Int32 maxOnPanel;
        private String name;
        private Int32 width;
        private Int32 height;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_key">Key of item</param>
        /// <param name="_width">Width of item</param>
        /// <param name="_height">Height of item</param>
        public Item(String _key,
                    Int32 _width,
                    Int32 _height)
        {
            key = _key;
            width = _width;
            height = _height;
        }

        /// <summary>
        /// Sets name of item
        /// </summary>
        /// <param name="_name">Name of item</param>
        public void setName(String _name)
        {
            name = _name;
        }

        /// <summary>
        /// Sets background of item
        /// </summary>
        /// <param name="_background">Background filename related to ressources</param>
        public void setBackground(String _background)
        {
            background = _background;
        }

        /// <summary>
        /// Sets maximum amount of objects on panel // 0 = disabled
        /// </summary>
        /// <param name="_maxOnPanel">Maximum number of items</param>
        public void setMaxOnPanel(Int32 _maxOnPanel)
        {
            // check if number is equal or greater than 0 (Note: 0 == disabled)
            if (maxOnPanel >= 0)
            {
                maxOnPanel = _maxOnPanel;
            }
            
        }

        /// <summary>
        /// Returns item-key
        /// </summary>
        public String getKey()
        {
            return key;
        }

        /// <summary>
        /// Returns maximum amount of items on panel
        /// </summary>
        public Int32 getMaxOnPanel()
        {
            return maxOnPanel;
        }

        /// <summary>
        /// Returns width of item
        /// </summary>
        public Int32 getWidth()
        {
            return width;
        }

        /// <summary>
        /// Returns height of item
        /// </summary>
        public Int32 getHeight()
        {
            return height;
        }

        /// <summary>
        /// Returns background filname related to ressources
        /// </summary>
        public String getBackground()
        {
            return background;
        }

        /// <summary>
        /// Returns item-name
        /// </summary>
        public String getName()
        {
            return name;
        }
    }
}
