namespace source.Commands
{
    // The command classess represent the Command Design Pattern
    // Every calculator operation (pushing a number, performing an arithmetic operation, CHS, DROP, SWAP etc.) is a concrete command implementing this interface.
    public interface ICommand
    {
        void Execute(Calculator calc);
        void Unexecute(Calculator calc);
    }
}
