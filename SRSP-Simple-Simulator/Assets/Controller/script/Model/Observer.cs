using System.Text;
using Newtonsoft.Json;

namespace Model
{
    public class Observer : IObserver
    {

        public Observer(Creation creation)
        {
            this.creation = creation;
        }

        public Creation creation; 

        public void Update(ISubject s)
        {
            var test = s.GetBoatStatus();
            double cap, COG, SOG;
            test.TryGetValue(BoatInfo.Cap, out cap);
            test.TryGetValue(BoatInfo.COG, out COG);
            test.TryGetValue(BoatInfo.SOG, out SOG);
            creation.changeBoatInfo((float)cap, (float)COG, (float)SOG);
        }
    }
}
