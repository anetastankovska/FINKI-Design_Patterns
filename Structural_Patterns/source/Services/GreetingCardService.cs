using source.Models.Interfaces;
using source.Models;

namespace source.Services
{
    public class GreetingCardService
    {
        public void SendGreetingCard(IGreetingCard card, List<Recipient> recipients)
        {
            foreach (var recipient in recipients)
            {
                Console.WriteLine($"Sending to {recipient}:");
                Console.WriteLine(card.Render());
            }
        }
    }

}
