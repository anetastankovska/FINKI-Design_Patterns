using System;
using System.Linq;
using source.Engine;
using source;

namespace source.Engine
{
    public class CalculatorEngine : ICalculatorEngine
    {
        private readonly Calculator _calculator;

        public CalculatorEngine()
        {
            _calculator = new Calculator();
        }

        public void ProcessInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return;

            // Split input into tokens and process each.
            string[] tokens = input.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
            foreach (var token in tokens)
            {
                _calculator.ProcessToken(token);
            }
        }

        public void DisplayStack()
        {
            _calculator.DisplayStack();
        }
    }
}
