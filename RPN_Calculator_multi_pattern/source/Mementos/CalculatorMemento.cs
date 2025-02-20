namespace source.Mementos
{
    // The CalculatorMemento class captures the state of the calculator(its stack and registers) at a specific moment in time.Later, if an operation needs to be undone, the saved state can be restored from the memento.
    // This class represents a snapshot of the calculator's state, including a copy of the stack and the registers.
    // I made the class sealed, since it is not intended to be inherited
    public sealed class CalculatorMemento
    {
        // Gets the deep copy of the calculator's stack.
        public List<decimal> StackSnapshot { get; }

        // Gets the deep copy of the calculator's registers.
        public decimal[] RegistersSnapshot { get; }

        // Initializes a new instance of the CalculatorMemento class,
        // making deep copies of the provided stack and registers.
        /// <param name="stack">The current stack of decimal values.</param>
        /// <param name="registers">The current array of registers.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when either the stack or registers is null.
        /// </exception>
        public CalculatorMemento(List<decimal> stack, decimal[] registers)
        {
            // Validate input parameters.
            ArgumentNullException.ThrowIfNull(stack);
            ArgumentNullException.ThrowIfNull(registers);

            // Make a deep copy of the stack.
            StackSnapshot = new List<decimal>(stack);

            // Make a deep copy of the registers array.
            // The Clone method creates a shallow copy, but since the array contains value types (decimal),
            // this effectively gives us a deep copy.
            RegistersSnapshot = (decimal[])registers.Clone();
        }
    }
}
