using source.Models.Interfaces;

namespace source.Services.Operations
{
    public class AddOperation : IOperation
    {
        public decimal Execute(decimal value, decimal operand) => value + operand;
    }
}
