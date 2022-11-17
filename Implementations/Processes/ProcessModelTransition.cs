using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mesa.Interfaces;

namespace Mesa.Implementations.Processes
{
    internal class ProcessModelTransition : IProcess
    {
        string configPath;
        //Parameters are necessary:
        //string dllSource, dllDestination;
        public ProcessModelTransition(string configPath)
        {
            this.configPath = configPath;
        }
        public void ReadConfig()
        {
            //
        }
        public void FireProcess() {
            Console.WriteLine("model process");
        }
    }
}
