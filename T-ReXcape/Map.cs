using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_ReXcape
{
    class Map
    {
        String mapFileName;
        IniFile config;

        public void loadMap()
        {
        }

        public void setMapFileName(String fileName)
        {
            mapFileName = fileName;
        }

        private void loadConfig()
        {
            if (mapFileName == null)
                throw new Exception("no map filename");

            config = new IniFile(mapFileName);

            if(!checkConfig())
                throw new Exception("config is not valid");
        }

        private bool checkConfig()
        {
            // @TODO: checks config for values
            return true;
        }

        // @TODO: public only for debuging and test
        public List<Dictionary<string, string>> getWalls()
        {
            List<Dictionary<string, string>> wallList = new List<Dictionary<string, string>>();
            String value;
            int i = 1;
            while (!(value = config.IniReadValue("map", "wall." + i + ".posx")).Equals(""))
            {
                Dictionary<string, string> wall = new Dictionary<string, string>();
                wall["posx"] = config.IniReadValue("map", "wall." + i + ".posx");
                wall["posy"] = config.IniReadValue("map", "wall." + i + ".posy");
                wall["direction"] = config.IniReadValue("map", "wall." + i + ".direction");
                wallList.Add(wall);
                i++;
            }

            return wallList;
        }
    }
}
