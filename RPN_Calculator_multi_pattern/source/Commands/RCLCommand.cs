namespace source.Commands
{
    // RCL is a recall operation (Recall)
    // This command retrieves the value from one of the memory registers (0–9) and pushes it onto the stack. It allows the user to bring back a value that was previously stored.
    public class RCLCommand : CalculatorCommand
    {
        private readonly int _registerIndex;

        public RCLCommand(int registerIndex)
        {
            _registerIndex = registerIndex;
        }

        public override void Execute(Calculator calc)
        {
            // Save the current state before modifying (for UNDO purposes).
            Backup(calc);

            // Push the value from the specified register onto the stack.
            calc.StackPush(calc.Registers[_registerIndex]);
        }

        public override void Unexecute(Calculator calc)
        {
            // Undo by restoring the previous state.
            Restore(calc);
        }
    }
}
