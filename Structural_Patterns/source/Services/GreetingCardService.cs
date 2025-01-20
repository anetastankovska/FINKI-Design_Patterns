using source.Models.Interfaces;
using source.Models;
using source.Models.Decorators;

namespace source.Services
{
    public class GreetingCardService
    {
        public void SendGreetingCard(IGreetingCard card, List<Recipient> recipients)
        {
            Console.WriteLine(card.Render());
            foreach (var recipient in recipients)
            {
                Console.WriteLine($"Sending to {recipient}:");
            }
        }

        public void Start()
        {
            string input = "";
            while (true)
            {
                Console.Write("Would you like to create a Card (Y)es/(N)o: ");
                input = Console.ReadLine();
                if (new List<string> { "y", "n" }.All(x => x != input.ToLower())) { Console.Clear(); continue; }
                if (input.ToLower() == "n") { break; }
                IGreetingCard card = new BasicGreetingCard("", "");
                Console.Write("Please enter your Card Title: ");
                card.Title = Console.ReadLine();
                Console.Write("Please enter your Card Message: ");
                card.Body = Console.ReadLine();
                while (true)
                {
                    Console.Write("Would you like to add (T)ext, (I)mage or (N)othing: ");
                    input = Console.ReadLine();
                    if (new List<string> { "t", "n", "i" }.All(x => x != input.ToLower())) { continue; }
                    if (input.ToLower() == "n") { break; }
                    if (input.ToLower() == "i")
                    {
                        Console.Write("Please type/paste the URL to the image: ");
                        card = new ImageDecorator(card, Console.ReadLine());
                        continue;
                    }
                    if (input.ToLower() == "t")
                    {
                        Console.Write("Please type/paste the additional message: ");
                        card = new TextDecorator(card, Console.ReadLine());
                        continue;
                    }
                }
                List<Recipient> recipients = new List<Recipient>();
                while (true)
                {
                    Console.Write("Would you like to add (C)heck Card, (A)dd Recepient, (S)end Card or (Q)uit: ");
                    input = Console.ReadLine();
                    if (new List<string> { "s", "a", "q", "c" }.All(x => x != input.ToLower())) { continue; }
                    if (input.ToLower() == "q") { return; }
                    if (input.ToLower() == "c") { Console.WriteLine(card.Render()); continue; }
                    if (input.ToLower() == "s" && recipients.Count == 0)
                    {
                        Console.WriteLine("No recipients added yet");
                        continue;
                    }
                    if (input.ToLower() == "a")
                    {
                        var recipient = new Recipient();
                        Console.WriteLine("--- Adding recipient ---");
                        Console.Write("First Name: "); recipient.FirstName = Console.ReadLine();
                        Console.Write("Last Name: "); recipient.LastName = Console.ReadLine();
                        Console.Write("Street: "); recipient.Street = Console.ReadLine();
                        Console.Write("Street Number: "); recipient.Number = Console.ReadLine();
                        Console.Write("City: "); recipient.City = Console.ReadLine();
                        Console.Write("Zip Code: "); recipient.ZipCode = Console.ReadLine();
                        Console.Write("Country: "); recipient.Country = Console.ReadLine();
                        card.AddRecipient(recipient);
                        recipients.Add(recipient);
                        Console.WriteLine("Recipient Added");
                        continue;
                    }
                    if (input.ToLower() == "s")
                    {
                        SendGreetingCard(card, recipients);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
            }
        }
    }

}
