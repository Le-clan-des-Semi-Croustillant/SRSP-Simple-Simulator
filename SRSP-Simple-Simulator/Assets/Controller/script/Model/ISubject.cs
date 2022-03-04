using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Model
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Notify();
        Dictionary<BoatInfo, double> GetBoatStatus();
    }
}
