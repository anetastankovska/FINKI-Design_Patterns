using source.Models.Implementations;

namespace source.Models.Interfaces
{
    public interface IObserver
    {
        void Update(Subject subject);
    }
}
