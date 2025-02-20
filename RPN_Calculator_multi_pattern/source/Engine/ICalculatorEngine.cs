namespace source
{
    /// Defines the operations that a calculator engine should expose to the UI.
    public interface ICalculatorEngine
    {
        // Processes a line of input containing one or more tokens.
        /// <param name="input">A string of tokens (e.g., "5 6 +").</param>
        void ProcessInput(string input);

        // Gets the current contents of the stack for display.
        /// <returns>A read-only list of decimals representing the stack.</returns>
        IReadOnlyList<decimal> GetStackItems(int count);
    }
}
