using AvaliandoExpressoesMatematicas;
using Xunit;

namespace AvaliandoExpressoesMatematicasTests
{
    public class TestExpressions
    {
        private readonly Calculator _calculator = new Calculator();

        [Fact]
        public void Result_should_be_6()
        {
            var result = _calculator.Calculate("3 * 2");

            Assert.Equal("6", result);
        }

        [Fact]
        public void Result_should_be_21()
        {
            var result = _calculator.Calculate("3 * ( 2 + 5 )");

            Assert.Equal("21", result);
        }

        [Fact]
        public void Result_should_be_36()
        {
            var result = _calculator.Calculate("3 * ( 2 + 5 * 2)");

            Assert.Equal("36", result);
        }

        [Fact]
        public void Result_should_be_15()
        {
            var result = _calculator.Calculate("3 + 2 * 8 - 4");

            Assert.Equal("15", result);
        }

        [Fact]
        public void Result_should_be_18()
        {
            var result = _calculator.Calculate("3 + 2 * 8 - 4 / 4");

            Assert.Equal("18", result);
        }

        [Fact]
        public void Result_should_be_27()
        {
            var result = _calculator.Calculate("3 * 3 * 3");

            Assert.Equal("27", result);
        }

        [Fact]
        public void Result_should_be_0()
        {
            var result = _calculator.Calculate("10-5-5");

            Assert.Equal("0", result);
        }

        [Fact]
        public void Result_should_be_minus_5()
        {
            var result = _calculator.Calculate("10-5-5-5");

            Assert.Equal("-5", result);
        }
    }
}
