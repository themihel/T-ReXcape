using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_ReXcape
{
    class Item
    {
        private String key;
        private String background;
        private Int32 maxOnPanel;
        private String name;
        private Int32 width;
        private Int32 height;
        
        public Item(String _key,
                    Int32 _width,
                    Int32 _height)
        {
            key = _key;
            width = _width;
            height = _height;
        }

        public void setName(String _name)
        {
            name = _name;
        }

        public void setBackground(String _background)
        {
            background = _background;
        }

        public void setMaxOnPanel(Int32 _maxOnPanel)
        {
            // check if number is equal or greater than 0 (Note: 0 == disabled)
            if (maxOnPanel >= 0)
            {
                maxOnPanel = _maxOnPanel;
            }
            
        }

        public String getKey()
        {
            return key;
        }

        public Int32 getMaxOnPanel()
        {
            return maxOnPanel;
        }

        public Int32 getWidth()
        {
            return width;
        }

        public Int32 getHeight()
        {
            return height;
        }

        public String getBackground()
        {
            return background;
        }

        public String getName()
        {
            return name;
        }
    }
}
