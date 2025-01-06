using source.Models.Interfaces;

namespace source.Models.Implementations
{
    public abstract class Subject
    {
        public List<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver observer) => observers.Add(observer);
        public void Detach(IObserver observer) => observers.Remove(observer);
        protected void Notify() => observers.ForEach(o => o.Update(this));
    }
}
