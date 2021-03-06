﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;

namespace T_ReXcape
{
    static class Util
    {
        /// <summary>
        /// Calculates exact position depending on point and blockSize
        /// </summary>
        /// <param name="p">MousePoint</param>
        /// <param name="blockSize">Size of a map block</param>
        /// <returns>Returns accurate position</returns>
        static public Point getAccuratePosition(Point p, Int32 blockSize)
        {
            int x = (p.X / blockSize) * blockSize;
            int y = (p.Y / blockSize) * blockSize;
            return new Point(x, y);
        }

        /// <summary>
        /// validate given file
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Boolean</returns>
        static public bool validateMapFilePath(String file)
        {
            return (File.Exists(file) && Path.GetExtension(file).Equals(".xmap"));
        }

        /// <summary>
        /// Resize toggle image to panel
        /// </summary>
        /// <param name="width">Panel width</param>
        /// <param name="height">Panel height</param>
        /// <returns>Bitmap of toggle image</returns>
        static public Bitmap getToggleBackground(Int32 width, Int32 height)
        {
            Bitmap bmp = new Bitmap(Properties.Resources.toggle_ufb, width, height);
            return bmp;
        }
    }
}
