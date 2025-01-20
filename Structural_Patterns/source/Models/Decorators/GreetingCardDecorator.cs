using source.Models.Interfaces;

namespace source.Models.Decorators
{
    public abstract class GreetingCardDecorator : GreetingCard
    {
        protected IGreetingCard _card;

        protected GreetingCardDecorator(IGreetingCard card)
        {
            _card = card;
            _cardLines = (card as GreetingCard)._cardLines.Count > 0 ? (card as GreetingCard)._cardLines : card.Presentation();
        }

        public override string Render()
        {
            return _card.Render();
        }
    }
}
