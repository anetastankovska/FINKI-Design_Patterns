using source.Models.Implementations;

namespace source.Models.Interfaces
{
    public interface IObserver
    {
        public int ID { get; }
        void Update(Subject subject);
    }
}
