namespace source.Commands.TrigCommands
{
    // Toggles the inverse mode.
    // When inverse mode is active, tokens like SIN will be interpreted as ASIN, etc.
    public class ToggleInverseModeCommand : CalculatorCommand
    {
        public override void Execute(Calculator calc)
        {
            if (calc == null)
                throw new ArgumentNullException(nameof(calc));

            Backup(calc);
            calc.IsInverseMode = !calc.IsInverseMode;
            Console.WriteLine("Inverse mode is now: " + (calc.IsInverseMode ? "ON" : "OFF"));
        }

        public override void Unexecute(Calculator calc)
        {
            Restore(calc);
        }
    }
}