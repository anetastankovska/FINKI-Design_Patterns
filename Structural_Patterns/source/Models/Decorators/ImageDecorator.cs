using source.Models.Interfaces;

namespace source.Models.Decorators
{
    public class ImageDecorator : GreetingCardDecorator
    {
        private string _imageUrl;

        public ImageDecorator(IGreetingCard card, string imageUrl) : base(card)
        {
            _imageUrl = imageUrl;
        }

        public override string Render()
        {
            return $"{base.Render()}\n[Image: {_imageUrl}]";
        }
    }

}
