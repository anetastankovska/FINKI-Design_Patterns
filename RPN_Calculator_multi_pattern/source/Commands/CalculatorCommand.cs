using source.Mementos;

namespace source.Commands
{
    // A helper base class that saves a memento before executing.
    public abstract class CalculatorCommand : ICommand
    {
        protected CalculatorMemento _backup;

        // Capture the state before execution.
        protected void Backup(Calculator calc)
        {
            _backup = calc.CreateMemento();
        }

        // Restore the state.
        protected void Restore(Calculator calc)
        {
            calc.SetMemento(_backup);
        }

        public abstract void Execute(Calculator calc);
        public abstract void Unexecute(Calculator calc);
    }
}
