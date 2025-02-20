namespace source.Commands
{
    public class DivideCommand: CalculatorCommand
    {
        // Divides the next-to-top number by the top number on the stack.
        public override void Execute(Calculator calc)
        {
            if (calc.StackCount < 2)
                throw new InvalidOperationException("Not enough operands for addition.");

            // Backup current state for UNDO.
            Backup(calc);

            // Pop the two operands.
            decimal b = calc.StackPop();
            decimal a = calc.StackPop();

            // Since state has been backed up, throw an exception to signal division by zero.
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            // Compute the result and push it onto the stack.
            calc.StackPush(a / b);
        }

        public override void Unexecute(Calculator calc)
        {
            // Restore previous state.
            Restore(calc);
        }
    }
}

