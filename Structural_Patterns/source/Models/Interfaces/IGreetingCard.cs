namespace source.Models.Interfaces
{
    public interface IGreetingCard
    {
        public Guid Id { get; protected set; }
        public string Title { get; set; }
        public string Body { get; set; }
        string Render();
        List<string> Presentation(string content = "");
        void AddRecipient(Recipient recipient);
    }
}
