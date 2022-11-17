using System;
using Mesa.Implementations;
using Mesa.Interfaces;

namespace Mesa
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                ISession session = new SessionSingleCommand(args[0]);
                session.SelectProcessByCommand();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return 0;
        }
    }
}