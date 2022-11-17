using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mesa.Implementations.Processes;
using Mesa.Interfaces;

namespace Mesa.Implementations
{
    internal class SessionSingleCommand : ISession
    {
        string command;
        IProcess process = new ProcessDllTransition("");
        public SessionSingleCommand(string command)
        {
            this.command = command;
        }
        public void SelectProcessByCommand()
        {
            switch (this.command)
            {
                case "dll":
                    this.process = new ProcessDllTransition(@"D:\\Mesa\dll_transition.mesa");
                    break;
                case "model":
                    this.process = new ProcessModelTransition(@"D:\\Mesa\model_overriding.mesa");
                    break;
                default:
                    break;
            }
            this.process.ReadConfig();
            this.process.FireProcess();
        }

        public void Exit() { }
    }
}
