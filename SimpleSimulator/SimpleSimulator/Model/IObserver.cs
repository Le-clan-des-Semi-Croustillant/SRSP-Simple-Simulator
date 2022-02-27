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

    public interface IObserver
    {
        void Update(ISubject subject);
    }
    
}
