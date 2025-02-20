namespace source.Commands.TrigCommands
{
    // Executes the inverse cosine function.
    // Converts the result to degrees if necessary.
    public class TrigAcosCommand : CalculatorCommand
    {
        public override void Execute(Calculator calc)
        {
            if (calc.StackCount < 1)
                throw new InvalidOperationException("Not enough operands for ACOS.");

            Backup(calc);
            decimal value = calc.StackPop();
            double result = Math.Acos((double)value);

            if (calc.CurrentAngleUnit.Equals("DEG", StringComparison.OrdinalIgnoreCase))
                result = result * 180.0 / Math.PI;

            calc.StackPush((decimal)result);
        }

        public override void Unexecute(Calculator calc)
        {
            Restore(calc);
        }
    }
}
