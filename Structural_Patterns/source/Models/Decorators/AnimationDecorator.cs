using source.Models.Interfaces;
namespace source.Models.Decorators
{
    public class AnimationDecorator : GreetingCardDecorator
    {
        private string _animationUrl;

        public AnimationDecorator(IGreetingCard card, string animationUrl) : base(card)
        {
            _animationUrl = animationUrl;
        }

        public override string Render()
        {
            return $"{base.Render()}\n[Animation: {_animationUrl}]";
        }
    }
}
