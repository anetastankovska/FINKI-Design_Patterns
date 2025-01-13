using source.Models.Interfaces;

namespace source.Models.Decorators
{
    public abstract class GreetingCardDecorator : GreetingCard
    {
        protected IGreetingCard _card;

        protected GreetingCardDecorator(IGreetingCard card)
        {
            _card = card;
        }

        public override string Render()
        {
            return _card.Render();
        }
    }
}
