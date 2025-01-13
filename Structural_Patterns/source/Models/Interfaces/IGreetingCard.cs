namespace source.Models.Interfaces
{
    public interface IGreetingCard
    {
        string Render();
        void AddRecipient(Recipient recipient);
    }
}
