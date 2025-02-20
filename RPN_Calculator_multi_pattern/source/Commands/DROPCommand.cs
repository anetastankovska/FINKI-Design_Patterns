namespace source.Commands
{
    // DROP command removes the top element from the stack.
    public class DROPCommand : CalculatorCommand
    {
        public override void Execute(Calculator calc)
        {
            if (calc.StackCount < 1)
                throw new InvalidOperationException("Stack is empty. Cannot DROP an element.");

            // Backup the current state for UNDO/REDO.
            Backup(calc);

            // Remove the top element from the stack.
            calc.StackPop();
        }

        public override void Unexecute(Calculator calc)
        {
            // Restore the previous state using the Memento pattern.
            Restore(calc);
        }
    }
}
