namespace source.Commands
{
    // ExecuteProgramCommand triggers the execution of a stored program (macro) in the calculator via the PROG command.
    public class ExecuteProgramCommand : CalculatorCommand
    {
        public override void Execute(Calculator calc)
        {
            // Execute the stored program via the calculator's ProgramRecorder.
            // This will run through each recorded command in sequence.
            calc.ProgramRecorder.ExecuteStoredProgram(calc);
        }

        // Undoing a whole program execution can be complex since it involves reverting a series of state changes and is often not supported
        public override void Unexecute(Calculator calc)
        {
            // Undoing a macro execution is non-trivial.
            // Notify the user that macro execution is a “one-way” operation regarding undo functionality
            Console.WriteLine("Undo is not supported for program execution.");
        }
    }
}
