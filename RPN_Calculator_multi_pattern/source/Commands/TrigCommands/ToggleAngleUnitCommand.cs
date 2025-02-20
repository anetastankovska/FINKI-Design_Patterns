namespace source.Commands.TrigCommands
{
    // Toggles the angle unit between RAD and DEG.
    public class ToggleAngleUnitCommand : CalculatorCommand
    {
        public override void Execute(Calculator calc)
        {
            if (calc == null)
                throw new ArgumentNullException(nameof(calc));

            Backup(calc);

            // Toggle the angle unit.
            if (calc.CurrentAngleUnit.Equals("RAD", StringComparison.OrdinalIgnoreCase))
                calc.CurrentAngleUnit = "DEG";
            else
                calc.CurrentAngleUnit = "RAD";

            Console.WriteLine("Angle unit changed to: " + calc.CurrentAngleUnit);
        }

        public override void Unexecute(Calculator calc)
        {
            Restore(calc);
        }
    }
}
