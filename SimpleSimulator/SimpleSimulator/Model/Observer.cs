using System.Text;
using Newtonsoft.Json;

namespace Model
{
    public class Observer : IObserver
    {
        public Observer()
        {

        }
        public void Update(ISubject s)
        {
            var test = s.GetBoatStatus();
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
        }
    }
}
