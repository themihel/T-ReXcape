using System;
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
        /// Removes digits from String
        /// </summary>
        /// <param name="s">Parse string</param>
        /// <returns>Returns string without digits</returns>
        static public String removeDigitsFromString(String s)
        {
            return Regex.Replace(s, @"\d$", "");
        }

        static public bool validateMapFilePath(String file)
        {
            Debug.WriteLine(Path.GetExtension(file));
            if (File.Exists(file) && Path.GetExtension(file).Equals(".xmap")) {
                return true;
            }
            return false;
        }
    }
}
