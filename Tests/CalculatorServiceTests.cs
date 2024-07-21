using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Services;

namespace UnitTestDemo.Tests
{
    public class CalculatorServiceTests
    {
        private readonly CalculatorService _calculatorService;

        public CalculatorServiceTests()
        {
            var loggerService = new LoggerService(); // Use a real logger for basic tests
            _calculatorService = new CalculatorService(loggerService);
        }
        /// <summary> 
        ///     Fact tests
        ///     Fact tests are used when you have a single test case that doesn't require any parameters.
        /// </summary>

        [Fact]
        public void Add_ReturnsCorrectSum()
        {
            // Arrange
            int a = 2;
            int b = 3;

            // Act
            int result = _calculatorService.Add(a, b);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Divide_ReturnsCorrectQuotient()
        {
            // Arrange
            int a = 10;
            int b = 2;

            // Act
            double result = _calculatorService.Divide(a, b);

            // Assert
            Assert.Equal(5.0, result);
        }

        /// <summary>  
        /// Theory tests
        /// Theory tests are used when you have multiple test cases that require parameters.
        /// </summary>

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -1, -2)]
        [InlineData(0, 0, 0)]
        [InlineData(100, 200, 300)]
        public void Add_ReturnsCorrectSum_MultipleCases(int a, int b, int expected)
        {
            // Act
            int result = _calculatorService.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 2, 5.0)]
        [InlineData(9, 3, 3.0)]
        [InlineData(1, 1, 1.0)]
        [InlineData(-10, -2, 5.0)]
        [InlineData(-10, 2, -5.0)]
        public void Divide_ReturnsCorrectQuotient_MultipleCases(int a, int b, double expected)
        {
            // Act
            double result = _calculatorService.Divide(a, b);

            // Assert
            Assert.Equal(expected, result, 1);
        }

        /// <summary>
        /// Exception handling tests
        /// </summary>

        [Fact]
        public void Divide_ThrowsArgumentException_OnDivisionByZero()
        {
            // Arrange
            int a = 10;
            int b = 0;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _calculatorService.Divide(a, b));
            Assert.Equal("Division by zero is not allowed.", exception.Message);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(100, 0)]
        [InlineData(-100, 0)]
        public void Divide_ThrowsArgumentException_OnDivisionByZero_MultipleCases(int a, int b)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _calculatorService.Divide(a, b));
        }


        /// <summary>
        ///    InlineData, MemberData, and ClassData tests
        ///    InlineData is used to pass test data directly to the test method.
        ///    MemberData is used to pass test data from a property in the test class.
        ///    ClassData is used to pass test data from a class that implements IEnumerable<object[]>.
        ///   </summary>
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -1, -2)]
        [InlineData(0, 0, 0)]
        [InlineData(100, 200, 300)]
        public void Add_ReturnsCorrectSum_InlineData(int a, int b, int expected)
        {
            // Arrange
            var calculatorService = new CalculatorService(new LoggerService());

            // Act
            int result = calculatorService.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> AddTestData =>
            new List<object[]>
            {
                new object[] { 1, 2, 3 },
                new object[] { -1, -1, -2 },
                new object[] { 0, 0, 0 },
                new object[] { 100, 200, 300 }
            };

        [Theory]
        [MemberData(nameof(AddTestData))]
        public void Add_ReturnsCorrectSum_MemberData(int a, int b, int expected)
        {
            // Arrange
            var calculatorService = new CalculatorService(new LoggerService());

            // Act
            int result = calculatorService.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(AddTestDataClass))]
        public void Add_ReturnsCorrectSum_ClassData(int a, int b, int expected)
        {
            // Arrange
            var calculatorService = new CalculatorService(new LoggerService());

            // Act
            int result = calculatorService.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }
    }

    public class AddTestDataClass : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { -1, -1, -2 };
            yield return new object[] { 0, 0, 0 };
            yield return new object[] { 100, 200, 300 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
