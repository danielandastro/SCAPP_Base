using System;//YOu should know
using System.IO.Compression;//for extracting SCAPP files
using System.IO;//for reading files to memory
using System.Diagnostics;//for launching stuff
namespace SCAPP_Launcher_Lib
{
    public class High //High level ops, facade class for easy normal usage, uses Low class
    {
        private Low low = new Low();//instance of class Low
        public void ExtractToWorkFolder(string file)//auto extracts a file to a working folder
        {
           
            var dirName = file + "-workdir";//name of workdir
            low.ExtractToDir(file, dirName);//call method from class Low
        }
        public string[] ListCachedPrograms()
        {
            var dataToReturn = new string[1024];
            count = 0;
            var list = low.ListWorkingFolders();
            foreach(var dir in list)
            {
                dataToReturn[count] = dir.Replace("-workdir", "");
                count++
            }
            return dataToReturn;
        }
        public void ExecAndCache(string FilePath)
        {
            ExtractToWorkFolder(FilePath);
            var dir = FilePath + "-workdir";

            var scriptPath = dir + "/default.scas";

            var execFiles =
            low.DecodeScriptExecs(scriptPath);

            foreach(var executable in execFiles)
            {
                low.ExecuteFile(executable);
            }
        }
        public void ExecAndClear(string filePath)
        {
            ExtractToWorkFolder(filePath);
            var dir = filePath + "-workdir";

            var scriptPath = dir + "/default.scas";

            var execFiles =
            low.DecodeScriptExecs(scriptPath);

            foreach (var executable in execFiles)
            {
                low.ExecuteFile(executable);
            }
            System.Threading.Thread.Sleep(10000);
            Directory.Delete(dir, true);
        }
    }
    public class Low //bare metal, use only if required, used by High
    {
        public string[] ListWorkingFolders()
        {
            var dataToReturn = new string[1024];
            var count = -1;
            string[] subdirectoryEntries = Directory.GetDirectories(Directory.GetCurrentDirectory());
            foreach(string subdir in subdirectoryEntries)
            {
                if subdir.Contains("-workdir"){
                    count++; //adds one to count
                    dataToReturn[count] = lineToDecode;
                }
            }
        }
        public void ExecuteFile(string filePath)//reads filepath and executes, a wrapper for Process.Start() 
        {
            Process.Start(filePath);
        }

        public void ExtractToDir(string filePath, string dirPath)//Extracting a file, simply a wrapper for ZipFile method
        {
            ZipFile.ExtractToDirectory(filePath, dirPath);//Extracts file
        }
        public String[] DecodeScriptExecs(string scriptPath)//returns executables to be run
        {
            var dataToReturn = new string[1024];//stores data that must be returned
            var count = -1;//count, -1 cause the first exec will add to it, causing it to increase to 0
            var lines = File.ReadAllLines(scriptPath);//reads script to memory
            foreach (string lineToDecode in lines)//reads and processes script, line by line
            {
                if (lineToDecode.Contains("exec="))//checks for keyword
                {
                    lineToDecode.Replace("exec=", ""); //removes keyword, exposing executable path
                    count++; //adds one to count
                    dataToReturn[count] = lineToDecode;//adds executable path to variable
                }
            }
            return dataToReturn;//returns data
        }
    }
}
