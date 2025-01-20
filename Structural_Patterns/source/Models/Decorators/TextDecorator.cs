using source.Models.Interfaces;

namespace source.Models.Decorators
{
    public class TextDecorator : GreetingCardDecorator
    {
        private string _additionalText;

        public TextDecorator(IGreetingCard card, string text) : base(card)
        {
            Body = _card.Body;
            Title = _card.Title;
            _additionalText = text;
            Presentation(text);
        }

        public override string Render()
        {
            return base.Render();
        }
    }

}
