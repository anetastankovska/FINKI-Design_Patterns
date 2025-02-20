namespace source.Modes
{
    // Defines the behavior for processing an operator token in a calculator mode.
    // Implementations can provide different processing strategies for various modes.
    public interface ICalculatorMode
    {
        // Processes the given operator token on the provided calculator instance.
        /// <param name="token">The operator token (e.g., "+", "STO3", "RCL5", etc.).</param>
        /// <param name="calc">The calculator instance on which the token will be processed.</param>
        void ProcessOperator(string token, Calculator calc);
    }
}
