using source.Models.Interfaces;

namespace source.Models.Implementations
{
    public class Observer : IObserver
    {
        private IOperation Operation;
        private decimal Operand;
        private decimal LastResult;

        public Observer(IOperation operation, decimal operand)
        {
            this.Operation = operation;
            this.Operand = operand;
        }

        public void Update(Subject subject)
        {
            if (subject is Register register)
            {
                decimal result = Operation.Execute(register.Value, Operand);
                Console.WriteLine($"Observer: New value is {result}");
            }
        }

        public decimal GetLastResult()
        {
            return LastResult;
        }
    }
}
