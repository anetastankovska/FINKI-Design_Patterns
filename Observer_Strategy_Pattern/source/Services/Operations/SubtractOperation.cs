using source.Models.Interfaces;

namespace source.Services.Operations
{
    public class SubtractOperation : IOperation
    {
        public decimal Execute(decimal value, decimal operand) => value - operand;
    }
}
