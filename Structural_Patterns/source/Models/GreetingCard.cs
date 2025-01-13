using source.Models.Interfaces;

namespace source.Models
{
    public abstract class GreetingCard : IGreetingCard
    {
        public Guid Id { get; protected set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<Recipient> Recipients { get; set; }

        protected GreetingCard()
        {
            Id = Guid.NewGuid();
            Recipients = new List<Recipient>();
        }

        protected GreetingCard(string title, string body, List<Recipient> recipients)
        {
            Id = Guid.NewGuid();
            Title = title;
            Body = body;
            Recipients = recipients ?? new List<Recipient>();
        }

        public virtual string Render()
        {
            return $"{Title}\n{Body}";
        }

        public void AddRecipient(Recipient recipient)
        {
            Recipients.Add(recipient);
        }
    }
}
