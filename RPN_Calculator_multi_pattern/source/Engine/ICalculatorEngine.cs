namespace source
{
    /// Defines the operations that a calculator engine should expose to the UI.
    public interface ICalculatorEngine
    {
        // Processes a line of input containing one or more tokens.
        /// <param name="input">A string of tokens (e.g., "5 6 +").</param>
        void ProcessInput(string input);

        //Display the stack.
        public void DisplayStack();
    }
}
