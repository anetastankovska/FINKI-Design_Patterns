using source.Models.Interfaces;
using System;
using System.Collections.Generic;
namespace source.Models.Decorators
{
    internal class AnimationDecorator : GreetingCardDecorator
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
