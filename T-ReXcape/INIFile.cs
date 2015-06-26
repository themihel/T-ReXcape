using System;
using System.Runtime.InteropServices;
using System.Text;

namespace T_ReXcape
{
    public class IniFile
    {
        // path variable
        public string path;

        // import DLLs
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key,string val,string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key,string def,
                                                            StringBuilder retVal, int size,string filePath);

        /// <summary>
        /// set file in constructor
        /// </summary>
        /// <param name="INIPath"></param>
        public IniFile(string INIPath)
        {
            path = INIPath;
        }

        /// <summary>
        /// writes ini data in file
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public void IniWriteValue(string Section,string Key,string Value)
        {
            WritePrivateProfileString(Section,Key,Value,this.path);
        }
        
        /// <summary>
        /// gets ini data in string format
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string IniReadValue(string Section,string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            return temp.ToString();
        }
    }
}