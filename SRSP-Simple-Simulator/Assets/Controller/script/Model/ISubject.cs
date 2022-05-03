using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Model
{
    /// <summary>
    /// Interface for a model pattern
    /// </summary>
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Notify();
        Dictionary<BoatInfo, double> GetBoatStatus();
    }
}
