using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Retribution.ScriptReader
{
    internal class StageScriptInterpreter : ScriptInterpreter
    {

        public StageScriptInterpreter(string json) : base(json)
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
                foreach(JsonProperty waveObj in curr.EnumerateObject())
                {
                    JsonElement wave = waveObj.Value;
                    sw.Write(wave.GetProperty("duration").GetString() + ",");
                    sw.Write(wave.GetProperty("EnemyAmountTotal").GetString() + ",");
                    sw.Write(wave.GetProperty("isBoss").GetBoolean() + ",");
                    sw.Write(wave.GetProperty("BackColor").GetString() + ",");
                    sw.Write(wave.GetProperty("ForeColor").GetString() + ",");
                    sw.Write(wave.GetProperty("SceneSpeed").GetString() + ",");
                }
            }
            catch
            {
                //event to stop game due to file having wrong format
            }
            return sw.ToString();
        }

    }
}
