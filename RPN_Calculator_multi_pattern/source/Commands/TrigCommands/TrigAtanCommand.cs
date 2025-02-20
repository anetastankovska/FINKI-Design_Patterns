namespace source.Commands.TrigCommands
{
    // Executes the inverse tangent function.
    // Converts the result to degrees if necessary.
    public class TrigAtanCommand : CalculatorCommand
    {
        public override void Execute(Calculator calc)
        {
            if (calc.StackCount < 1)
                throw new InvalidOperationException("Not enough operands for ATAN.");

            Backup(calc);
            decimal value = calc.StackPop();
            double result = Math.Atan((double)value);

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
