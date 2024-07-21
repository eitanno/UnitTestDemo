using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    public class LoggerService : ILoggerService
    {
        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }
}
