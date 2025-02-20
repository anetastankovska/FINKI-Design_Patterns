namespace source.Commands
{
    // CHS (Change Sign) command negates the top value on the stack.
    public class CHSCommand : CalculatorCommand
    {
        public override void Execute(Calculator calc)
        {
            // Ensure there is at least one element on the stack.
            if (calc.StackCount < 1)
                throw new InvalidOperationException("Stack is empty. Cannot change sign.");

            // Backup current state for UNDO.
            Backup(calc);

            // Pop the top element, negate it, and push it back.
            decimal top = calc.StackPop();
            calc.StackPush(-top);
        }

        public override void Unexecute(Calculator calc)
        {
            // Restore previous state using the Memento pattern.
            Restore(calc);
        }
    }
}
