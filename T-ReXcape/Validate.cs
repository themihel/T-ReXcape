using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T_ReXcape
{
    class Validate
    {
        // mapFile
        private IniFile mapFile;

        /// <summary>
        /// initialise Validation class with mapfile
        /// </summary>
        /// <param name="mapFile">IniFile map</param>
        public Validate(IniFile mapFile)
        {
            // set mapFIle
            this.mapFile = mapFile;
        }

        /// <summary>
        /// validate head key pair in file
        /// </summary>
        /// <param name="head">head param</param>
        /// <param name="key">key param</param>
        /// <returns>returns true if valid</returns>
        public Boolean validateKey(String head, String key)
        {
            // set checkState
            Boolean checkState = false;

            // check if Length > 0 @TODO better validation 
            if (mapFile.IniReadValue(head, key).Length > 0)
            {
                checkState = true;
            }

            // return checkState
            return checkState;
        }

        /// <summary>
        /// validates head group with multiple keys
        /// </summary>
        /// <param name="head">head param</param>
        /// <param name="keys">array of key params</param>
        /// <returns>returns true if valid</returns>
        public Boolean validateKeyGroup(String head, String[] keys)
        {
            // set checkState
            Boolean checkState = true;

            // check all keys
            foreach (String key in keys)
            {
                // check key
                if (!validateKey(head, key))
                {
                    checkState = false;
                }
            }

            // return checkState
            return checkState;
        }

        /// <summary>
        /// validates head / key pair with multiple params and index
        /// </summary>
        /// <param name="head">head param</param>
        /// <param name="key">key param</param>
        /// <param name="index">index param</param>
        /// <param name="checkParams">array of check params</param>
        /// <returns>return true if valid</returns>
        public Boolean validateKeyParams(String head, String key, Int32 index, String[] checkParams)
        {
            // set checkState
            Boolean checkState = true;

            // check all params
            foreach (String checkParam in checkParams)
	        {
                // check key
		        if (!validateKey(head, key+index.ToString()+checkParam)) {
                    checkState = false;
                }
	        }

            // return value
            return checkState;
        }
    }
}
