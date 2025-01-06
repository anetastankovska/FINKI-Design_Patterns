using source.Models.Interfaces;

namespace source.Models.Implementations
{
    public class Observer : IObserver
    {
        private IOperation operation;
        private decimal operand;
        private decimal lastResult;

        public Observer(IOperation operation, decimal operand)
        {
            this.operation = operation;
            this.operand = operand;
        }

        public void Update(Subject subject)
        {
            if (subject is Register register)
            {
                decimal result = operation.Execute(register.Value, operand);
                Console.WriteLine($"Observer: New value is {result}");
            }
        }

        public decimal GetLastResult()
        {
            return lastResult;
        }
    }
}
