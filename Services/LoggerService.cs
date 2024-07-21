using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Interfaces;

namespace UnitTestDemo.Services
{
    public class LoggerService : ILoggerService
    {
        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }
}
