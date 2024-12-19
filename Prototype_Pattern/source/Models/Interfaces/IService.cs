namespace source.Models.Interfaces
{
    public interface IService : ICloneable
    {
        Guid Id { get; }
        string Name { get; set; }
        double Price { get; set; }
        void Configure(Dictionary<string, object> parameters);
    }
}
