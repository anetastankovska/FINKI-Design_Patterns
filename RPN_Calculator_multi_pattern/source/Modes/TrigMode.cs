using source.Commands;
using source.Commands.TrigCommands;
using source.Managers;

namespace source.Modes
{
    // TrigMode supports trigonometric operations and memory operations (STO, RCL).
    // It also supports toggling between degrees/radians and inverse mode.
    public class TrigMode : ICalculatorMode
    {
        public void ProcessOperator(string token, Calculator calc)
        {
            if (calc == null)
                throw new ArgumentNullException(nameof(calc));

            CommandManager cmdManager = calc.CommandManager;

            // 1. Check for memory operations first (STO, RCL).
            if (token.StartsWith("STO", StringComparison.OrdinalIgnoreCase))
            {
                string regStr = token.Substring(3);
                if (int.TryParse(regStr, out int regIndex) && regIndex >= 0 && regIndex <= 9)
                {
                    cmdManager.ExecuteCommand(new STOCommand(regIndex), calc);
                    return;
                }
                else
                {
                    throw new InvalidOperationException("Invalid memory register index for STO: " + token);
                }
            }

            if (token.StartsWith("RCL", StringComparison.OrdinalIgnoreCase))
            {
                string regStr = token.Substring(3);
                if (int.TryParse(regStr, out int regIndex) && regIndex >= 0 && regIndex <= 9)
                {
                    cmdManager.ExecuteCommand(new RCLCommand(regIndex), calc);
                    return;
                }
                else
                {
                    throw new InvalidOperationException("Invalid memory register index for RCL: " + token);
                }
            }

            // 2. Handle trigonometric tokens and toggles.
            switch (token.ToUpperInvariant())
            {
                case "SIN":
                    cmdManager.ExecuteCommand(new TrigSinCommand(), calc);
                    break;
                case "COS":
                    cmdManager.ExecuteCommand(new TrigCosCommand(), calc);
                    break;
                case "TAN":
                    cmdManager.ExecuteCommand(new TrigTanCommand(), calc);
                    break;

                case "ASIN":
                    cmdManager.ExecuteCommand(new TrigAsinCommand(), calc);
                    break;
                case "ACOS":
                    cmdManager.ExecuteCommand(new TrigAcosCommand(), calc);
                    break;
                case "ATAN":
                    cmdManager.ExecuteCommand(new TrigAtanCommand(), calc);
                    break;

                case "INV":
                    // Toggles inverse mode in the calculator.
                    cmdManager.ExecuteCommand(new ToggleInverseModeCommand(), calc);
                    break;
                case "RAD/DEG":
                    // Toggles angle unit between radians and degrees.
                    cmdManager.ExecuteCommand(new ToggleAngleUnitCommand(), calc);
                    break;

                default:
                    throw new InvalidOperationException("Unsupported operator in trig mode: " + token);
            }
        }
    }
}
