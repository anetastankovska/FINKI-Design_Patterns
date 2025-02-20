using source.Commands;
using source.Managers;

namespace source.Modes
{
    // The DefaultMode class is part of a Strategy/State Pattern implementation. It encapsulates the behavior for processing operators in the default (decimal) mode.
    public class DefaultMode : ICalculatorMode
    {
        public void ProcessOperator(string token, Calculator calc)
        {
            CommandManager cmdManager = calc.CommandManager;

            // Check for memory operations.
            // For tokens like "STO3" or "RCL5", we extract the register number.
            if (token.StartsWith("STO", StringComparison.OrdinalIgnoreCase))
            {
                string regStr = token.Substring(3);
                if (int.TryParse(regStr, out int regIndex) && regIndex >= 0 && regIndex <= 9)
                {
                    cmdManager.ExecuteCommand(new STOCommand(regIndex), calc);
                }
                else
                {
                    throw new InvalidOperationException("Invalid memory register index for STO: " + token);
                }
                return;
            }
            if (token.StartsWith("RCL", StringComparison.OrdinalIgnoreCase))
            {
                string regStr = token.Substring(3);
                if (int.TryParse(regStr, out int regIndex) && regIndex >= 0 && regIndex <= 9)
                {
                    cmdManager.ExecuteCommand(new RCLCommand(regIndex), calc);
                }
                else
                {
                    throw new InvalidOperationException("Invalid memory register index for RCL: " + token);
                }
                return;
            }
            // Process other operators via switch.
            switch (token)
            {
                case "+":
                    cmdManager.ExecuteCommand(new AddCommand(), calc);
                    break;
                case "-":
                    cmdManager.ExecuteCommand(new SubtractCommand(), calc);
                    break;
                case "*":
                    cmdManager.ExecuteCommand(new MultiplyCommand(), calc);
                    break;
                case "/":
                    cmdManager.ExecuteCommand(new DivideCommand(), calc);
                    break;
                case "CHS":
                    cmdManager.ExecuteCommand(new CHSCommand(), calc);
                    break;
                case "DROP":
                    cmdManager.ExecuteCommand(new DROPCommand(), calc);
                    break;
                case "SWAP":
                    cmdManager.ExecuteCommand(new SWAPCommand(), calc);
                    break;
                default:
                    throw new InvalidOperationException("Unsupported operator in default mode: " + token);
            }
        }
    }
}
