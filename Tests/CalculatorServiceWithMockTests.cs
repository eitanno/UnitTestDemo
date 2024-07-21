using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace UnitTestDemo.Tests
{
    public class CalculatorServiceWithMockTests
    {
        private readonly Mock<ILoggerService> _mockLoggerService;
        private readonly CalculatorService _calculatorService;

        public CalculatorServiceWithMockTests()
        {
            _mockLoggerService = new Mock<ILoggerService>();
            _calculatorService = new CalculatorService(_mockLoggerService.Object);
        }

        [Fact]
        public void Add_CallsLoggerService()
        {
            // Arrange
            int a = 2;
            int b = 3;

            // Act
            int result = _calculatorService.Add(a, b);

            // Assert
            Assert.Equal(5, result);
            _mockLoggerService.Verify(logger => logger.Log(It.Is<string>(s => s.Contains("Add: 2 + 3 = 5"))), Times.Once);
        }

        [Fact]
        public void Divide_CallsLoggerService()
        {
            // Arrange
            int a = 10;
            int b = 2;

            // Act
            double result = _calculatorService.Divide(a, b);

            // Assert
            Assert.Equal(5.0, result);
            _mockLoggerService.Verify(logger => logger.Log(It.Is<string>(s => s.Contains("Divide: 10 / 2 = 5"))), Times.Once);
        }
    }
}
