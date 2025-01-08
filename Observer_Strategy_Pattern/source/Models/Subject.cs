using source.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Models
{
    public abstract class Subject
    {
        public List<IObserver> Observers = new List<IObserver>();

        public void Attach(IObserver observer) => Observers.Add(observer);
        public void Detach(IObserver observer) => Observers.Remove(observer);
        protected void Notify() => Observers.ForEach(o => o.Update(this));
    }
}
