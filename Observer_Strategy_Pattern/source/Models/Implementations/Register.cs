using source.Models.Interfaces;

namespace source.Models.Implementations
{
    public class Register : Subject
    {
        private decimal value; // Backing field - stores the actual data
        public decimal Value   // Property - provides controlled access
        {
            get => value;  // Returns the backing field value
            set  // Sets the backing field value and notifies observers
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
