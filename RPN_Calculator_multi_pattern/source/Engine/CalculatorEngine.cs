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
            // Optionally: _calculator.Mode = new TrigMode();
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

        public IReadOnlyList<decimal> GetStackItems(int count = 4)
        {
            // Retrieve the calculator’s stack contents.
            var stackContents = _calculator.GetStackContents();
            int stackCount = stackContents.Count;
            
            if (stackCount == 0)
                return Array.Empty<decimal>();

            int start = Math.Max(0, stackCount - count);
            // Skip/Take/Reverse require using System.Linq
            return stackContents
                .Skip(start)
                .Take(stackCount - start)
                .Reverse()
                .ToArray();
        }
    }
}
