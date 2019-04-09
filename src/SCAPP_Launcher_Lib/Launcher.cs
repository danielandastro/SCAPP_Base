using System;
using SharpCompress;

namespace SCAPP_Launcher_Lib
{
    public class High //High level ops, facade class for easy normal usage, uses Low class
    {
        public void extractToWorkFolder(string File)
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

        }
    }
}
