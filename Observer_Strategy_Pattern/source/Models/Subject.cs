using source.Models.Interfaces;

namespace source.Models
{
    public abstract class Subject
    {
        public List<IObserver> Observers = new List<IObserver>();

        public static int RegisteredObservers = 0;

        public void Attach(IObserver observer)
        {
            Observers.Add(observer);
            Notify();
            RegisteredObservers++;
        }

        public void Detach(IObserver observer)
        {
            Observers.Remove(observer);
            Notify();
        }

        protected void Notify() => Observers.ForEach(o => o.Update(this));
    }
}
