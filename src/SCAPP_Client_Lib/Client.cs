using System;
using Base_Data_Classes;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using Newtonsoft;
namespace SCAPP_Client_Lib
{
    public class High
    {
        Low low = new Low();
        public List<ConfigFileItem> DecodeConfigFile(string filePath)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConfigFileItem>>(low.ReadConfigFile(filePath));
        }

    }
    public class Low
    {
        public string ReadConfigFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }
        public void WriteConfigFile()
        {

        }
    }
}
