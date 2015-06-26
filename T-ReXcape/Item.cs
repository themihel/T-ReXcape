using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T_ReXcape
{
    class Item : PictureBox
    {
        // images
        private Image imageLeft;
        private Image imageRight;
        private Image imageTop;
        private Image imageBottom;

        // maximum number of items on panel
        private Int32 maxOnPanel;

        // postion
        private Int32 positionX;
        private Int32 positionY;
        
        // desription
        private String description = "";

        // constants for hook position
        public const Int32 positionLeft = 1;
        public const Int32 positionRight = 2;
        public const Int32 positionCenter = 3;
        public const Int32 positionTop = 4;
        public const Int32 positionBottom = 5;

        // direction
        private int direction;

        // constans for directions
        public const int directionLeft = 1;
        public const int directionRight = 2;
        public const int directionTop = 3;
        public const int directionBottom = 4;

        // mouse postion
        static Point mousePosition;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_key">Key of item</param>
        /// <param name="_width">Width of item</param>
        /// <param name="_height">Height of item</param>
        public Item(String _key, Int32 _width, Int32 _height)
        {
            Name = _key;
            Width = _width;
            Height = _height;
            // set default hook position
            positionX = positionLeft;
            positionY = positionTop;
            // defalut direction to left
            direction = directionLeft;

            BackColor = Color.Transparent;
            SizeMode = PictureBoxSizeMode.Zoom;
        }

        /// <summary>
        /// clone item
        /// </summary>
        /// <returns>Returns copy of current item</returns>
        public Item clone()
        {
            Debug.WriteLine("clone key: " + this.Name);
            Item cloneItem = new Item(this.Name, this.Width, this.Height);
            cloneItem.setImageLeft(imageLeft);
            cloneItem.setImageRight(imageRight);
            cloneItem.setImageTop(imageTop);
            cloneItem.setImageBottom(imageBottom);
            cloneItem.setMaxOnPanel(maxOnPanel);
            cloneItem.setDescription(description);
            cloneItem.setHookPosition(positionX, positionY);
            cloneItem.setDirection(direction);
            return cloneItem;
        }

        /// <summary>
        /// Sets name of item
        /// </summary>
        /// <param name="_name">Name of item</param>
        public void setDescription(String _description)
        {
            description = _description;
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
        /// set hook position. use constants!
        /// </summary>
        public void setHookPosition(Int32 _positionX, Int32 _positionY)
        {
            positionX = _positionX;
            positionY = _positionY;
        }

        /// <summary>
        /// Returns item-key
        /// </summary>
        public String getKey()
        {
            return Name;
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
            return Width;
        }

        /// <summary>
        /// Returns height of item
        /// </summary>
        public Int32 getHeight()
        {
            return Height;
        }

        /// <summary>
        /// Returns background filname related to ressources
        /// </summary>
        public Image getImage()
        {
            if (direction == directionLeft)
            {
                return imageLeft;
            }
            else if (direction == directionRight)
            {
                return imageRight;
            }
            else if (direction == directionTop)
            {
                return imageTop;
            }
            else if (direction == directionBottom)
            {
                return imageBottom;
            }
            else
            {
                throw new Exception("wrong direction id");
            }
        }

        /// <summary>
        /// Returns item-name
        /// </summary>
        public String getDescription()
        {
            return description;
        }

        /// <summary>
        /// Returns position X offset
        /// </summary>
        public int getPositionOffsetX()
        {
            int offset = 0;
            if (positionX == positionRight)
            {
                offset = Width;
            }
            else if (positionX == positionCenter)
            {
                offset = Width / 2;
            }
            return offset * -1;
        }

        /// <summary>
        /// Returns position y offset
        /// </summary>
        public int getPositionOffsetY()
        {
            int offset = 0;
            if (positionY == positionBottom)
            {
                offset = Height;
            }
            else if (positionY == positionCenter)
            {
                offset = Height / 2;
            }
            return offset * -1;
        }

        /// <summary>
        /// Returns block X offset
        /// </summary>
        public int getBlockOffsetX(int blockSize)
        {
            int offset = 0;
            if (positionX == positionRight)
            {
                offset = blockSize;
            }
            else if (positionX == positionCenter)
            {
                offset = blockSize / 2;
            }
            return offset;
        }

        /// <summary>
        /// Returns position y offset
        /// </summary>
        public int getBlockOffsetY(int blockSize)
        {
            int offset = 0;
            if (positionY == positionBottom)
            {
                offset = blockSize;
            }
            else if (positionY == positionCenter)
            {
                offset = blockSize / 2;
            }
            return offset;
        }

        /// <summary>
        /// Sets direction of item
        /// </summary>
        /// <param name="dir">direction</param>
        public void setDirection(int dir)
        {
            // check given direction id
            if(dir == directionLeft || 
                dir == directionRight || 
                dir == directionTop ||
                dir == directionBottom)
            {
                if (
                    ((direction == directionLeft || direction == directionRight) &&
                    (dir == directionTop || dir == directionBottom))
                    ||
                    ((direction == directionTop || direction == directionBottom) &&
                    (dir == directionLeft || dir == directionRight))
                    )
                {
                    flipSize();
                }
                direction = dir;
                updateImage();
            }
        }

        /// <summary>
        /// Returns directions of item 
        /// </summary>
        /// <returns>Direction of item</returns>
        public int getDirection()
        {
            return direction;
        }

        /// <summary>
        /// set left-Image of item
        /// </summary>
        /// <param name="img">Image (left)</param>
        public void setImageLeft(Image img)
        {
            imageLeft = img;
            updateImage();
        }

        /// <summary>
        /// set right-Image of item
        /// </summary>
        /// <param name="img">Image (right)</param>
        public void setImageRight(Image img)
        {
            imageRight = img;
            updateImage();
        }

        /// <summary>
        /// set top-Image of item
        /// </summary>
        /// <param name="img">Image (top)</param>
        public void setImageTop(Image img)
        {
            imageTop = img;
            updateImage();
        }

        /// <summary>
        /// set bottom-Image of item
        /// </summary>
        /// <param name="img">Image (bottom)</param>
        public void setImageBottom(Image img)
        {
            imageBottom = img;
            updateImage();
        }

        /// <summary>
        /// sets Image for all directions
        /// </summary>
        /// <param name="img">Image (all)</param>
        public void setImageAllDirections(Image img)
        {
            imageLeft = img;
            imageRight = img;
            imageTop = img;
            imageBottom = img;
            updateImage();
        }

        /// <summary>
        /// Updates current image of item
        /// </summary>
        private void updateImage()
        {
            Image = getImage();
        }

        /// <summary>
        /// Flips dimensions of image
        /// </summary>
        private void flipSize()
        {
            int tmp = Height;
            Height = Width;
            Width = tmp;
        }

        /// <summary>
        /// gets center mouse postion of item
        /// </summary>
        public static void mouseDown(object sender, MouseEventArgs e)
        {
            Item item = sender as Item;
            mousePosition = new Point(item.Width / 2, item.Height / 2);
        }

        /// <summary>
        /// default value
        /// </summary>
        public static void mouseUp(object sender, MouseEventArgs e)
        {
            mousePosition = default(Point);
        }

        /// <summary>
        /// mouse move handler / updates direction
        /// </summary>
        public static void mouseMove(object sender, MouseEventArgs e)
        {
            if (!mousePosition.Equals(default(Point)))
            {
                int newX = e.X - mousePosition.X;
                int newY = mousePosition.Y - e.Y;
                if (newX < newY && (newX * -1) < newY && newY > 50)
                {
                    // top
                    ((Item)sender).setDirection(Item.directionTop);
                }
                else if (newX > newY && (newX * -1) > newY && newY < -50)
                {
                    // bottom
                    ((Item)sender).setDirection(Item.directionBottom);
                }
                else if (newY < newX && (newY * -1) < newX && newX > 50)
                {
                    // right
                    ((Item)sender).setDirection(Item.directionRight);
                }
                else if (newY > newX && (newY * -1) > newX && newX < -50)
                {
                    // left
                    ((Item)sender).setDirection(Item.directionLeft);
                }
            }
        }
    }
}
