using source.Models.Interfaces;

namespace source.Models.Decorators
{
    public class ImageDecorator : GreetingCardDecorator
    {
        private string _imageUrl;

        public ImageDecorator(IGreetingCard card, string imageUrl) : base(card)
        {
            Body = card.Body;
            Title = card.Title;
            _imageUrl = imageUrl;
            Presentation($"[{imageUrl}]");
        }

        public override string Render()
        {
            return base.Render();
        }
    }

}
