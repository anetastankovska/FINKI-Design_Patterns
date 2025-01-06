namespace source.Models.Interfaces
{
    public interface IOperation
    {
        decimal Execute(decimal value, decimal operand);
    }

}
