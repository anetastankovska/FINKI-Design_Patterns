namespace source.Commands
{
    // Subtracts the top number from the next-to-top number on the stack.
    public class SubtractCommand: CalculatorCommand
    {
        public override void Execute(Calculator calc)
        {
            if (calc.StackCount < 2)
                throw new InvalidOperationException("Not enough operands for addition.");

            // Backup current state for UNDO.
            Backup(calc);

            // Pop the two operands.
            decimal b = calc.StackPop();
            decimal a = calc.StackPop();

            // Compute the result and push it onto the stack.
            calc.StackPush(a - b);
        }

        public override void Unexecute(Calculator calc)
        {
            // Restore previous state.
            Restore(calc);
        }
    }
}
