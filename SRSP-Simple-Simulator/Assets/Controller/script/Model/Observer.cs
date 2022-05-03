using System.Text;
using Newtonsoft.Json;
using Communication.DataProcessing.Json;
using System.Collections.Generic;
using Unityscript;

namespace Model
{
    /// <summary>
    /// The is an observer(or interface) of <see cref="Model.RaceModel"/>
    /// </summary>
    public class Observer : IObserver
    {
        /// <summary>
        /// Create an instance of Observer
        /// </summary>
        /// <param name="creation"></param>
        public Observer(Creation creation)
        {
            this.creation = creation;
        }

        public Creation creation;

        /// <summary>
        /// Update the attribut 'creation' according to the subject status
        /// </summary>
        /// <param name="s"></param>
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
