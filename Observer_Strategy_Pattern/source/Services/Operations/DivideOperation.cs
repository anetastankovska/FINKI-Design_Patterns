using source.Models.Interfaces;

namespace source.Services.Operations
{
    public class DivideOperation : IOperation
    {
        public decimal Execute(decimal value, decimal operand)
        {
            if (operand == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return value / operand;
        }
    }
}
