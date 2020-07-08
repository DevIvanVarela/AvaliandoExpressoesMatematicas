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
        public void Result_should_be_7()
        {
            var result = _calculator.Calculate("2 + 5");

            Assert.Equal("7", result);
        }

        [Fact]
        public void Result_should_be_2()
        {
            var result = _calculator.Calculate("4 - 2");

            Assert.Equal("2", result);
        }

        [Fact]
        public void Result_should_be_3()
        {
            var result = _calculator.Calculate("6 / 2");

            Assert.Equal("3", result);
        }

        [Fact]
        public void Result_should_be_13()
        {
            var result = _calculator.Calculate("3 + 2 * 5");

            Assert.Equal("13", result);
        }

        [Fact]
        public void Result_should_be_25()
        {
            var result = _calculator.Calculate("(3 + 2) * 5");

            Assert.Equal("25", result);
        }

        [Fact]
        public void Result_should_be_154()
        {
            var result = _calculator.Calculate("23 + 12 * (41 / 3) - 33");
            
            Assert.Equal("154", result);
        }

        [Fact]
        public void Result_should_be_805_4()
        {
            var result = _calculator.Calculate("23 + 12 * ((41 - 43) / 5 + 33) * 2");
            
            Assert.Equal("805,4", result);
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
