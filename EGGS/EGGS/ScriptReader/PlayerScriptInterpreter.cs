using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


/// <summary>
/// Programmer: Kieran Madre
/// Date: 1/31/2024
/// Purpose: Allows for easy and automatic reading of a script which holds editable values of the player
/// </summary>

namespace EGGS.ScriptReader
{
    internal class PlayerScriptInterpreter : ScriptInterpreter
    {
        public PlayerScriptInterpreter(string json) : base(json)
        {
        }

        /// <summary>
        /// Programmer: Kieran Madre
        /// Date: 1/31/2024
        /// Purpose: Read a json and concat the values together, return all values in the json
        /// </summary>
        /// <returns></returns>
        public override string JsonInterpreter()
        {
            StringWriter sw = new StringWriter();
            try
            {
                sw.Write(curr.GetProperty("Lives").GetString() + ",");
                sw.Write(curr.GetProperty("Speed").GetString());
            }
            catch
            {
                //event to stop game due to file having wrong format
            }
            return sw.ToString();
        }
    }
}
