using System;
using System.IO.Compression;
using System.IO;

namespace SCAPP_Launcher_Lib
{
    public class High //High level ops, facade class for easy normal usage, uses Low class
    {
        public void ExtractToWorkFolder(string File)
        {
            var low = new Low();
            var dirName = File + "-workdir";
            low.ExtractToDir(File, dirName);
        }

    }
    public class Low //bare metal, use only if required, used by High
    {
        public void ExtractToDir(string filePath, string dirPath)
        {
            ZipFile.ExtractToDirectory(filePath, dirPath);
        }
        public String[] DecodeScriptExecs(string scriptPath)
        {
            var dataToReturn = new string[1024];
            var count = -1;
            var lines = File.ReadAllLines(scriptPath);
                foreach (string lineToDecode in lines)
            {
                if (lineToDecode.Contains("exec="))
                {lineToDecode.Replace("exec=", ""); count++; }
                dataToReturn[count] = lineToDecode;
            }
            return dataToReturn;
        }
    }
}
