using source.Models.Interfaces;

namespace source.Models.Decorators
{
    public class TextDecorator : GreetingCardDecorator
    {
        private string _additionalText;

        public TextDecorator(IGreetingCard card, string text) : base(card)
        {
            _additionalText = text;
        }

        public override string Render()
        {
            return $"{base.Render()}\n{_additionalText}";
        }
    }

}
