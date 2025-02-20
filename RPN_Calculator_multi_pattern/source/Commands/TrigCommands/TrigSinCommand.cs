namespace source.Commands.TrigCommands
{
    // Executes the sine function.
    // Converts input to radians if necessary.
    public class TrigSinCommand : CalculatorCommand
    {
        public override void Execute(Calculator calc)
        {
            if (calc.StackCount < 1)
                throw new InvalidOperationException("Not enough operands for SIN.");

            Backup(calc);
            decimal value = calc.StackPop();
            double angle = (double)value;

            // Convert degrees to radians if needed.
            if (calc.CurrentAngleUnit.Equals("DEG", StringComparison.OrdinalIgnoreCase))
                angle = angle * Math.PI / 180.0;

            double result = Math.Sin(angle);
            calc.StackPush((decimal)result);
        }

        public override void Unexecute(Calculator calc)
        {
            Restore(calc);
        }
    }
}
