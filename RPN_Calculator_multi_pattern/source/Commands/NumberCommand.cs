namespace source.Commands
{
    public class NumberCommand : CalculatorCommand
    {
        private readonly decimal _number;
        // Initializes a new instance of the NumberCommand with the specified number and pushes the number onto the stack
        // The constructor takes a decimal number as a parameter and stores it in a private field (_number).
        // This is the value that will be pushed onto the stack when the command is executed.
        public NumberCommand(decimal number)
        {
            _number = number; // the number to push onto the stack
        }

        public override void Execute(Calculator calc)
        {
            // Backup the current state for UNDO/REDO functionality.
            Backup(calc);

            // Push the number onto the stack.
            calc.StackPush(_number);
        }

        public override void Unexecute(Calculator calc)
        {
            // Restore the previous state.
            Restore(calc);
        }
    }
}
