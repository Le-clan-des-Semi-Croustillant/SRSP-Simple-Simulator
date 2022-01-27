
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Race{
    public class Race {

        public Race() {
            this.myAquisition = new AquitisionCommunication.Aquisition(this);
            this.clock = new Clock();
            this.wayPoints = new List<WayPoint> ();
            List<Polaire> pol = new List<Polaire>();
            Position pos = new Position(0,0);
            this.boat = new MyBoat(50, pol, pos);

        }

        private int id = 0;

        private DateTime DeltaT;

        private float acceleratorFactor;

        private MyBoat boat;

        private List<WayPoint> wayPoints;

        private AquitisionCommunication.Aquisition myAquisition;

        private Clock clock;


        public int GetId()
        {
            return id;
        }

        public DateTime GetCurrentInstant()
        {
            return this.clock.GetCurrentMoment();
        }

        public List<WayPoint> GetWayPoint()
        {
            return wayPoints;
        }

        public int GetBoatId()
        {
            return boat.GetId();
        }
        public float GetBoatCap()
        {
            return boat.getCap();
        }

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