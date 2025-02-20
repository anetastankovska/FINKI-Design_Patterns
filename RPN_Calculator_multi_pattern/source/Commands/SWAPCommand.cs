namespace source.Commands
{
    // SWAP command exchanges (SWAPS) the two topmost elements on the stack.
    public class SWAPCommand : CalculatorCommand
    {
        public override void Execute(Calculator calc)
        {
            if (calc.StackCount < 2)
                throw new InvalidOperationException("Not enough elements to swap.");

            // Backup current state for UNDO/REDO.
            Backup(calc);

            // Pop the top two elements.
            decimal top = calc.StackPop();
            decimal second = calc.StackPop();

            // Push them in reverse order to swap.
            calc.StackPush(top);
            calc.StackPush(second);
        }

        public override void Unexecute(Calculator calc)
        {
            // Restore previous state for UNDO.
            Restore(calc);
        }
    }
}
