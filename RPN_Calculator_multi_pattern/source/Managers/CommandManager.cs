using source.Commands;

namespace source.Managers
{
    // The CommandManager class is a key part of the Command Pattern. It aacts as the invoker in the Command Pattern.
    // It doesn't implement the individual actions itself but implements the coordination (or "invoker") part of the Command Pattern by managing the lifecycle of command objects and providing undo/redo functionality.
    public class CommandManager
    {
        // Stack to hold executed commands that can be undone.
        private readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
        // Stack to hold commands that have been undone and can be redone.
        private readonly Stack<ICommand> _redoStack = new Stack<ICommand>();

        // Executes a command and updates the undo/redo history.
        /// <param name="command">The command to execute.</param>
        /// <param name="calc">The calculator on which to execute the command.</param>
        public void ExecuteCommand(ICommand command, Calculator calc)
        {
            // Execute the command.
            command.Execute(calc);
            // Add the command to the undo stack since it has been executed.
            _undoStack.Push(command);
            // Clear the redo stack because new operations invalidate the redo history.
            _redoStack.Clear();
        }

        // Undoes the most recent command.
        /// <param name="calc">The calculator whose state will be reverted.</param>
        public void Undo(Calculator calc)
        {
            if (_undoStack.Count == 0)
            {
                Console.WriteLine("Nothing to undo.");
                return;
            }
            // Pop the most recent command and undo it.
            ICommand command = _undoStack.Pop();
            command.Unexecute(calc);
            // Add the undone command to the redo stack.
            _redoStack.Push(command);
        }

        // Redoes the most recently undone command.
        /// <param name="calc">The calculator to which the command will be re-applied.</param>
        public void Redo(Calculator calc)
        {
            if (_redoStack.Count == 0)
            {
                Console.WriteLine("Nothing to redo.");
                return;
            }
            // Pop the most recent command from the redo stack and re-execute it.
            ICommand command = _redoStack.Pop();
            command.Execute(calc);
            // After re-execution, push the command back to the undo stack.
            _undoStack.Push(command);
        }
    }

}
