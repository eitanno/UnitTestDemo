using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Interfaces;

namespace UnitTestDemo.Services
{
    public class CalculatorService
    {
        private readonly ILoggerService _loggerService;

        public CalculatorService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public int Add(int a, int b)
        {
            int result = a + b;
            _loggerService.Log($"Add: {a} + {b} = {result}");
            return result;
        }

        public double Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Division by zero is not allowed.");
            }
            double result = (double)a / b;
            _loggerService.Log($"Divide: {a} / {b} = {result}");
            return result;
        }
    }
}
