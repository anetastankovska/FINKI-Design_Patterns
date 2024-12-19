namespace source.Models.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public string Name { get; set; }
        public double Price { get; set; }
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        protected BaseEntity(string name, double price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }
    }
}
