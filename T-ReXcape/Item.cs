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
        private String maxOnPanel;
        private String name;
        private String width;
        private String height;
        
        public Item(String _key,
                    String _width,
                    String _height)
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

        public void setMaxOnPanel(String _maxOnPanel)
        {
            maxOnPanel = _maxOnPanel;
        }

        public String getKey()
        {
            return key;
        }

        public String getMaxOnPanel()
        {
            return maxOnPanel;
        }

        public String getWidth()
        {
            return width;
        }

        public String getHeight()
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
