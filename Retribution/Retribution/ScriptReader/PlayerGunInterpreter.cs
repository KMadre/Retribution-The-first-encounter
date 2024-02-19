using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.ScriptReader
{
    internal class PlayerGunInterpreter : ScriptInterpreter
    {

        public PlayerGunInterpreter(string json) : base(json)
        {
        }

        /// <summary>
        /// Programmer: Kieran Madre
        /// Date: 2/1/2024
        /// Purpose: Read a json and concat the values together, return all values in the json
        /// </summary>
        /// <returns></returns>
        public override string JsonInterpreter()
        {
            StringWriter sw = new StringWriter();
            try
            {
                sw.Write(curr.GetProperty("Spread").GetString() + ",");
                sw.Write(curr.GetProperty("Damage").GetString() + ",");
                sw.Write(curr.GetProperty("FireRate").GetString() + ",");
                sw.Write(curr.GetProperty("ProjectileSize").GetString() + ",");
                sw.Write(curr.GetProperty("ProjectileSpeed").GetString());
            }
            catch
            {
                //event to stop game due to file having wrong format
            }
            return sw.ToString();
        }
    }

}
