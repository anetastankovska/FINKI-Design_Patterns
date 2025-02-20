using System.Globalization;
using source.Commands;
using source.Commands.TrigCommands;

namespace source.Utilities
{
    // TokenParser is responsible for interpreting input tokens and converting them into executable commands.
    public static class TokenParser
    {
        // Parses a single token and returns the corresponding command, if any.
        /// <param name="token">The user input token (e.g., "+", "SIN", "ASIN", "MODE").</param>
        /// <param name="calculator">The Calculator instance (in case we need its state).</param>
        /// <returns>An ICommand to execute, or null if the token is unrecognized.</returns>
        public static ICommand? ParseToken(string token, Calculator calculator)
        {
            if (string.IsNullOrWhiteSpace(token))
                return null;

            // 1. Check if token is a number.
            if (decimal.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal numericValue))
            {
                return new NumberCommand(numericValue);
            }

            // 2. Memory operations: "STO3", "RCL7", etc.
            if (token.StartsWith("STO", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(token.Substring(3), out int stoIndex) && stoIndex >= 0 && stoIndex <= 9)
                    return new STOCommand(stoIndex);
            }
            if (token.StartsWith("RCL", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(token.Substring(3), out int rclIndex) && rclIndex >= 0 && rclIndex <= 9)
                    return new RCLCommand(rclIndex);
            }

            // Convert token to uppercase for easier matching.
            string upperToken = token.Trim().ToUpperInvariant();

            // 3. Special commands: "EXE" => ExecuteProgramCommand
            if (upperToken == "EXE")
            {
                return new ExecuteProgramCommand();
            }

            // 4. Arithmetic and stack manipulation operators.
            switch (upperToken)
            {
                case "+":
                    return new AddCommand();
                case "-":
                    return new SubtractCommand();
                case "*":
                    return new MultiplyCommand();
                case "/":
                    return new DivideCommand();
                case "CHS":
                    return new CHSCommand();
                case "DROP":
                    return new DROPCommand();
                case "SWAP":
                    return new SWAPCommand();
            }

            // 5. Trigonometric functions (including inverse variants).
            //    For example: "SIN" => TrigSinCommand, "ASIN" => TrigAsinCommand, etc.
            switch (upperToken)
            {
                case "SIN":
                    return new TrigSinCommand();
                case "COS":
                    return new TrigCosCommand();
                case "TAN":
                    return new TrigTanCommand();
                case "ASIN":
                    return new TrigAsinCommand();
                case "ACOS":
                    return new TrigAcosCommand();
                case "ATAN":
                    return new TrigAtanCommand();
            }

            // 6. Toggle commands:
            //    "RAD/DEG" => ToggleAngleUnitCommand
            //    "MODE"    => ToggleModeCommand
            switch (upperToken)
            {
                case "RAD/DEG":
                    return new ToggleAngleUnitCommand();
                case "MODE":
                    return new ToggleInverseModeCommand();
            }

            // 7. Toggle commands:
            //    "PROG" => Starts Recording pacro
            //    "END" => Stops recording macro
            //    "EXE" => Executes macro
            switch (upperToken)
            {
                case "PROG":
                    return new StartRecordingCommand();
                case "END":
                    return new StopRecordingCommand();
                case "EXE":
                    return new ExecuteProgramCommand();
            }

            // If we reach here, the token wasn't recognized.
            Console.WriteLine($"Unknown token: {token}");
            return null;
        }
    }
}
