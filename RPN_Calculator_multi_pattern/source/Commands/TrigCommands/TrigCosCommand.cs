namespace source.Commands.TrigCommands
{
    // Executes the cosine function.
    // Converts input to radians if needed.
    public class TrigCosCommand : CalculatorCommand
    {
        public override void Execute(Calculator calc)
        {
            if (calc.StackCount < 1)
                throw new InvalidOperationException("Not enough operands for COS.");

            Backup(calc);
            decimal value = calc.StackPop();
            double angle = (double)value;

            if (calc.CurrentAngleUnit.Equals("DEG", StringComparison.OrdinalIgnoreCase))
                angle = angle * Math.PI / 180.0;

            double result = Math.Cos(angle);
            calc.StackPush((decimal)result);
        }

        public override void Unexecute(Calculator calc)
        {
            Restore(calc);
        }
    }
}
