using System;
using System.Text.RegularExpressions;

namespace AvaliandoExpressoesMatematicas
{
    public class Calculator
    {
        private readonly Regex _regex;

        public Calculator()
        {
            _regex = new Regex(@"\(.*?\)");
        }

        public string Calculate(string input)
        {
            input = ClearWhiteSpaces(input);
            input = CalculateParenthesesPriority(input);
            input = Add(input);
            input = Subtract(input);
            input = Divide(input);
            input = Multiply(input);

            return input;
        }

        private string CalculateParenthesesPriority(string input)
        {
            var match = _regex.Match(input);
            if (match.Success)
            {
                var expressionToCalculate = match.Value.Replace("(", string.Empty).Replace(")", string.Empty);
                var result = Calculate(expressionToCalculate);
                input = input.Replace(match.Value, result);
            }

            return input;
        }

        private static string ClearWhiteSpaces(string input)
        {
            return input.Replace(" ", string.Empty);
        }

        private static string Divide(string input)
        {
            if (input.Contains("/"))
            {
                var splited = input.Split("/");
                CalculateValue(splited, decimal.Divide);

                return splited[0];
            }

            return input;
        }

        private static string Multiply(string input)
        {
            if (input.Contains("*"))
            {
                var splited = input.Split("*");
                CalculateValue(splited, decimal.Multiply);

                return splited[0];
            }

            return input;
        }

        private string Add(string input)
        {
            if (input.Contains("+"))
            {
                var splited = input.Split("+");
                CalculateOperatorPriorities(splited);
                CalculateValue(splited, decimal.Add);

                return splited[0];
            }

            return input;
        }

        private string Subtract(string input)
        {
            if (input.Contains("-"))
            {
                var splited = input.Split("-");
                CalculateOperatorPriorities(splited);
                CalculateValue(splited, decimal.Subtract);

                return splited[0];
            }

            return input;
        }

        private static void CalculateValue(string[] splited, Func<decimal, decimal, decimal> calc)
        {
            for (int i = 0; i < splited.Length - 1; i++)
                splited[0] = calc(decimal.Parse(splited[0]), decimal.Parse(splited[i + 1])).ToString();
        }

        private void CalculateOperatorPriorities(string[] splited)
        {
            for (int i = 0; i < splited.Length; i++)
                if (HasPriority(splited[i]))
                    splited[i] = Calculate(splited[i]);
        }

        private static bool HasPriority(string split) => split.Contains("*") || split.Contains("/");
    }
}
