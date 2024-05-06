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
                sw.Write(curr.GetProperty("Difficulty").GetString() + ",");
                foreach (JsonProperty waveObj in curr.EnumerateObject())
                {
                    if (waveObj.Name.StartsWith("Wave"))
                    {
                        JsonElement wave = waveObj.Value;
                        sw.Write(wave.GetProperty("duration").GetString() + ",");
                        sw.Write(wave.GetProperty("GruntACount").GetString() + ",");
                        sw.Write(wave.GetProperty("GruntABulletType").GetString() + ",");
                        sw.Write(wave.GetProperty("GruntAInterval").GetString() + ",");
                        sw.Write(wave.GetProperty("GruntALeft").GetBoolean() + ",");
                        sw.Write(wave.GetProperty("GruntAYAxis").GetString() + ",");
                        sw.Write(wave.GetProperty("GruntBCount").GetString() + ",");
                        sw.Write(wave.GetProperty("GruntBBulletType").GetString() + ",");
                        sw.Write(wave.GetProperty("GruntBInterval").GetString() + ",");
                        sw.Write(wave.GetProperty("GruntBLeft").GetBoolean() + ",");
                        sw.Write(wave.GetProperty("GruntBYAxis").GetString() + ",");
                        sw.Write(wave.GetProperty("isMidBoss").GetBoolean() + ",");
                        sw.Write(wave.GetProperty("isFinalBoss").GetBoolean() + ",");
                        sw.Write(wave.GetProperty("BackColor").GetString() + ",");
                        sw.Write(wave.GetProperty("ForeColor").GetString() + ",");
                        sw.Write(wave.GetProperty("SceneSpeed").GetString() + ",");
                    }
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
