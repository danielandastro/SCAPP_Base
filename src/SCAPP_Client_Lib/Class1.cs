using System;
using Base_Data_Classes;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
namespace SCAPP_Client_Lib
{
    public class High
    {
        public List<Base_Data_Classes.ConfigFileItem> DecodeConfigFile(string filePath)
        {
            
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
