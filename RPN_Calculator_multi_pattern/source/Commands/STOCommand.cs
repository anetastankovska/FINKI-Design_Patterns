namespace source.Commands
{
    // STO is a store operation (Store)
    // This command takes the value at the top of the calculator’s stack and stores it into one of the dedicated memory registers (0–9).
    // It essentially saves a number so that it can be used later.
    public class STOCommand : CalculatorCommand
    {
        private readonly int _registerIndex;

        public STOCommand(int registerIndex)
        {
            _registerIndex = registerIndex;
        }

        public override void Execute(Calculator calc)
        {
            // Ensure there is at least one element on the stack.
            if (calc.StackCount < 1)
                throw new InvalidOperationException("Cannot store: the stack is empty.");

            // Save the current state before modifying (for UNDO purposes).
            Backup(calc);

            // Store the top value (peek, not pop) into the register.
            calc.Registers[_registerIndex] = calc.StackPeek();
        }

        public override void Unexecute(Calculator calc)
        {
            // Undo by restoring the previous state.
            Restore(calc);
        }
    }
}
