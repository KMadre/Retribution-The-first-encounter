﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.ScriptReader
{
    public class MidBossInterpreter : ScriptInterpreter
    {

        public MidBossInterpreter(string json) : base(json)
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
                sw.Write(curr.GetProperty("Health").GetString() + ",");
                sw.Write(curr.GetProperty("Speed").GetString() + ",");
                sw.Write(curr.GetProperty("Height").GetString() + ",");
                sw.Write(curr.GetProperty("Width").GetString() + ",");
                sw.Write(curr.GetProperty("initX").GetString() + ",");
                sw.Write(curr.GetProperty("initY").GetString() + ",");
                sw.Write(curr.GetProperty("BaseCD").GetString() + ",");
            }
            catch
            {
                //event to stop game due to file having wrong format
            }
            return sw.ToString();
        }

    }
}
