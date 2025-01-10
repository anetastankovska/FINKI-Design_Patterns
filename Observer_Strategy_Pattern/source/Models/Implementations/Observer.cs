using source.Models.Interfaces;

namespace source.Models.Implementations
{
    public class Observer : IObserver
    {
        private IOperation Operation;
        private decimal Operand;
        private decimal LastResult;
        public int ID { get; }

        public Observer(IOperation operation, decimal operand, int iD)
        {
            Operation = operation;
            Operand = operand;
            ID = iD;

        }

        public void Update(Subject subject)
        {
            if (subject is Register register)
            {
                decimal result = Operation.Execute(register.Value, Operand);
                Console.WriteLine($"Observer #{ID}: New value is {result}");
            }
        }

        public decimal GetLastResult()
        {
            return LastResult;
        }
    }
}
