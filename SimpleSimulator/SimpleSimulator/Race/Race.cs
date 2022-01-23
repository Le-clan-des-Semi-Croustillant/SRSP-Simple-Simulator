
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Race{
    public class Race {

        public Race() {
            this.myAquisition = null;
        }

        public DateTime DeltaT;

        public DateTime InstantT;

        public float acceleratorFactor;










        public AquitisionCommunication.Aquisition myAquisition;

        public void initialisation() {
            // TODO implement here
        }

        /// <summary>
        /// @param List WayPoint wayPoints
        /// </summary>
        public void SetWayPoint( List<WayPoint> wayPoints) {
            // TODO implement here
        }

        /// <summary>
        /// @param float id 
        /// @param float latitude 
        /// @param float longitude
        /// </summary>
        public void change_competitors(float id, float latitude, float longitude) {
            // TODO implement here
        }

        /// <summary>
        /// @param float env
        /// </summary>
        public void change_Env(float env) {
            // TODO implement here
        }

        public void sendPosition() {
            // TODO implement here
        }

        public Mode getMode() {
            // TODO implement here
            return new Mode();
        }

        /// <summary>
        /// @param int AccFac
        /// </summary>
        public void setacceleratorFactor(int AccFac) {
            // TODO implement here
        }

        public void nextIteration() {
            // TODO implement here
        }

    }
}