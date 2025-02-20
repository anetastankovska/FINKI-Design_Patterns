namespace source.Commands.TrigCommands
{
    // Executes the tangent function.
    // Converts input to radians if necessary.
    public class TrigTanCommand : CalculatorCommand
    {
        public override void Execute(Calculator calc)
        {
            if (calc.StackCount < 1)
                throw new InvalidOperationException("Not enough operands for TAN.");

            Backup(calc);
            decimal value = calc.StackPop();
            double angle = (double)value;

            if (calc.CurrentAngleUnit.Equals("DEG", StringComparison.OrdinalIgnoreCase))
                angle = angle * Math.PI / 180.0;

            double result = Math.Tan(angle);
            calc.StackPush((decimal)result);
        }

        public override void Unexecute(Calculator calc)
        {
            Restore(calc);
        }
    }
}
