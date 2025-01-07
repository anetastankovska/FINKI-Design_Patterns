using source.Models.Interfaces;

namespace source.Models.Implementations
{
    public class Register : Subject
    {
        private decimal value;
        public decimal Value
        {
            get => value;
            set
            {
                this.value = value;
                Notify();
            }
        }

        public List<IObserver> GetObservers()
        {
            return new List<IObserver>(Observers);
        }
    }
}
