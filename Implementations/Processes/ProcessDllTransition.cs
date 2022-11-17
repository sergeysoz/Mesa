using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mesa.Interfaces;

namespace Mesa.Implementations.Processes
{
    internal class ProcessDllTransition : IProcess
    {
        readonly string configPath;

        Dictionary<string, string> rules = new Dictionary<string, string>();
        // Parameters are necessary:

        public ProcessDllTransition(string configPath)
        {
            this.configPath = configPath;
        }
        public void ReadConfig()
        {
            try
            {
                using (StreamReader sr = new StreamReader(this.configPath))
                {
                    string? line = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] subs = line.Split("&");
                        this.rules.Add(subs[0], subs[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CONFIG READING ERROR: The file could not be read: {ex.Message}");
            }
        }
        public void FireProcess()
        {
            string sourceFilePath = $@"{rules["dllSource"]}{rules["dllFilename"]}";
            string destinationFilePath = $@"{rules["dllDestination"]}{rules["dllFilename"]}";
            if (File.Exists(sourceFilePath))
            {
                //Console.WriteLine("The DLL source file does exist");
                try
                {
                    File.Copy(sourceFilePath, destinationFilePath, true);
                    Console.WriteLine("SUCCESS: The file has been overwritten successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("The DLL source file doesnt exist");
            }

            //foreach (KeyValuePair<string, string> de in this.rules)
            //{
            //    Console.WriteLine($"{de.Key} & {de.Value}");
            //}
            //Console.WriteLine("Success: An output file has been successfully written.");

        }
    }
}
