using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Models
{
    public abstract class GreetingCard
    {
        public Guid Id { get; protected set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<string> Addresses { get; set; }

        protected GreetingCard()
        {
            Id = Guid.NewGuid();
        }

        protected GreetingCard(string title, string body, List<string> addresses)
        {
            Id = Guid.NewGuid();
            Title = title;
            Body = body;
            Addresses = addresses;
        }
    }
}
