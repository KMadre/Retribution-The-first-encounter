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
/// Purpose: Abstract class which all other interpreters will inherit from
/// </summary>

namespace Retribution.ScriptReader
{
    public abstract class ScriptInterpreter
    {
        public string _script;
        public JsonDocument jsonFile;
        public JsonElement curr;

        /// <summary>
        /// Makes the correct path to a file automatically
        /// </summary>
        /// <param name="json">the script file name that is targeted by the user</param>
        public ScriptInterpreter(string json)
        {
            //The worst code I have ever written, the getcurrent directory returns the debug folder with the .exe, but I step out into the Retribution folder to grab the scripts
            string inBin = Directory.GetCurrentDirectory();
            string overBin = Directory.GetParent(inBin).FullName;
            string overOverBin = Directory.GetParent(overBin).FullName;
            string scriptPath = Directory.GetParent(overOverBin).FullName;
            this._script = Path.Combine(scriptPath, @"Scripts\"+json);

            string readJson= File.ReadAllText(_script);// read contents
            jsonFile= JsonDocument.Parse(readJson);
            JsonElement root= jsonFile.RootElement;// get first entry (only one so nothing complicated, can maybe use this as difficulty selection? 3 profiles)

            this.curr = root[0];// set root for the specific first parsed item in the list that was  created
        }

        virtual public string JsonInterpreter()
        {
            return String.Empty;
        }
    }
}
