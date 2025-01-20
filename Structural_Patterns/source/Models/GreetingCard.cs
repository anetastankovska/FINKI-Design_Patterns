using source.Models.Interfaces;

namespace source.Models
{
    public abstract class GreetingCard : IGreetingCard
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<Recipient> Recipients { get; set; }

        public List<string> _cardLines { get; set; }

        protected GreetingCard()
        {
            Id = Guid.NewGuid();
            Recipients = new List<Recipient>();
            _cardLines = new List<string>();
        }

        protected GreetingCard(string title, string body, List<Recipient> recipients)
        {
            Id = Guid.NewGuid();
            Title = title;
            Body = body;
            Recipients = recipients ?? new List<Recipient>();
            _cardLines = new List<string>();
        }

        public List<string> Presentation(string content = "")
        {
            if (string.IsNullOrEmpty(content))
            {
                var card_width = Math.Max(Title.Length, Body.Length) + 4;
                card_width += card_width % 2 == 0 ? 1 : 0;
                var title_padding = card_width / 2 + Title.Length / 2;
                var body_padding = card_width / 2 + Body.Length / 2;
                _cardLines.Add("\n");
                _cardLines.Add(string.Join("", Enumerable.Range(0, card_width).Select((x, i) => i % 2 == 0 ? "*" : " ")));
                _cardLines.Add($"*{Title.PadLeft(title_padding).PadRight(card_width - 2)}*");
                _cardLines.Add($"* {string.Join("", Enumerable.Range(0, card_width - 4).Select(x => "-"))} *");
                _cardLines.Add($"*{Body.PadRight(body_padding).PadLeft(card_width - 2)}*");
                _cardLines.Add(string.Join("", Enumerable.Range(0, card_width).Select((x, i) => i % 2 == 0 ? "*" : " ")));
                _cardLines.Add("\n");
            }
            else
            {
                int ix = _cardLines.Count - 2;      // index of last body line
                var cardWidth = _cardLines[1].Length;
                // handle longer input than current card size
                var contentLines = new List<string>();
                if (_cardLines[1].Length - 4 < content.Length)
                {
                    var words = content.Split(' ');
                    var line = new List<string>();
                    foreach (var word in words)
                    {
                        if (line.Sum(x => x.Length) + word.Length + line.Count < _cardLines[1].Length - 4)
                        {
                            line.Add(word);
                        }
                        else
                        {
                            contentLines.Add(string.Join(" ", line));
                            line.Clear();
                            line.Add(word);
                        }
                    }
                    contentLines.Add(string.Join(" ", line));
                }
                else { contentLines.Add(content); }
                _cardLines.Insert(ix++, $"* {string.Join("", Enumerable.Range(0, cardWidth - 4).Select(x => " "))} *");
                foreach (var line in contentLines)
                {
                    var linePadding = cardWidth / 2 + line.Length / 2;
                    _cardLines.Insert(ix++, $"*{line.PadRight(linePadding).PadLeft(cardWidth - 2)}*");
                }
            }
            return _cardLines;
        }

        public virtual string Render()
        {
            return string.Join("\n", _cardLines);
        }

        public void AddRecipient(Recipient recipient)
        {
            Recipients.Add(recipient);
        }
    }
}
