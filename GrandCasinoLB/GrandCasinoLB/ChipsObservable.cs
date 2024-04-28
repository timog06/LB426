using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCasinoLB
{
    using System.Collections.Generic;

    public class ChipsObservable
    {
        private List<IChipsObserver> _observers = new List<IChipsObserver>();
        private int _chips;

        public int Chips
        {
            get { return _chips; }
            set
            {
                if (_chips != value)
                {
                    _chips = value;
                    NotifyObservers();
                }
            }
        }

        public void AddObserver(IChipsObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IChipsObserver observer)
        {
            _observers.Remove(observer);
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.ChipsUpdated(_chips);
            }
        }
    }
}
