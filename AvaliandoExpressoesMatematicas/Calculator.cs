using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AvaliandoExpressoesMatematicas
{
    public class Calculator
    {
        private readonly Regex _regex;

        public Calculator()
        {
            _regex = new Regex(@"\(([^()]+|(?<Level>\()(?<-Level>\)))+(?(Level)(?!))\)", RegexOptions.IgnorePatternWhitespace);
        }

        public string Calculate(string input)
        {
            input = ClearWhiteSpaces(input);
            input = CalculateParenthesesPriority(input);
            input = Add(input);
            input = Subtract(input);
            input = Divide(input);
            input = Multiply(input);

            return string.Format("{0:G29}", decimal.Parse(input));
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

            if (_regex.Match(input).Success)
                input = CalculateParenthesesPriority(input);

            return input;
        }

        private static string ClearWhiteSpaces(string input) => input.Replace(" ", string.Empty);

        private string Divide(string input)
        {
            if (!input.Contains("/"))
                return input;
            
            var splited = input.Split("/");
            CalculateOperatorPriorities(splited);
            CalculateValue(splited, decimal.Divide);

            return splited[0];
        }

        private string Multiply(string input)
        {
            if (!input.Contains("*"))
                return input;
            
            var splited = input.Split("*");
            CalculateOperatorPriorities(splited);
            CalculateValue(splited, decimal.Multiply);

            return splited[0];
        }

        private string Add(string input)
        {
            if (!input.Contains("+"))
                return input;
            
            var splited = input.Split("+");
            CalculateOperatorPriorities(splited);
            CalculateValue(splited, decimal.Add);

            return splited[0];
        }

        private string Subtract(string input)
        {
            var splited = input.Split("-");
            if (!input.Contains("-") || NegativeNumber(splited))
                return input;
            
            CalculateOperatorPriorities(splited);
            CalculateValue(splited, decimal.Subtract);

            return splited[0];
        }

        private bool NegativeNumber(string[] splited) => splited.Any(x => string.IsNullOrWhiteSpace(x));

        private static void CalculateValue(string[] splited, Func<decimal, decimal, decimal> calc)
        {
            for (int i = 0; i < splited.Length - 1; i++)
                splited[0] = calc(decimal.Parse(splited[0]), decimal.Parse(splited[i + 1])).ToString();
        }

        private void CalculateOperatorPriorities(string[] splited)
        {
            for (int i = 0; i < splited.Length; i++)
                if (HasAnotherOperation(splited[i]))
                    splited[i] = Calculate(splited[i]);
        }

        private bool HasAnotherOperation(string split) => split.Contains("+") || split.Contains("-") || split.Contains("*") || split.Contains("/");
    }
}
