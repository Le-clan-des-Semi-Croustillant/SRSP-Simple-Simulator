
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Race{
    public class Race {

        public Race() {
            this.myAquisition = new AquitisionCommunication.Aquisition(this);
            this.env = new Environement.Environment();
            this.competitors = new List<Competitor>();
            this.clock = new Clock();
            this.physics = new physicSimulator.physics_simulator();
            this.wayPoints = new List<WayPoint> ();
            List<Polaire> pol = new List<Polaire>();
            Position pos = new Position(0,0);
            this.boat = new MyBoat(50, pol, pos);

        }

        private int id = 0;

        private DateTime DeltaT;

        private float acceleratorFactor;

        private Mode mode;

        private Environement.Environment env;

        private MyBoat boat;

        private physicSimulator.physics_simulator physics;

        private List<WayPoint> wayPoints;

        private AquitisionCommunication.Aquisition myAquisition;

        private Clock clock;
        
        private List<Competitor> competitors;


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

        public List<Competitor> GetCompetitors()
        {
            return this.competitors;
        }

        public void initialisation() {
            // TODO implement here
        }

        /// <summary>
        /// @param List WayPoint wayPoints
        /// </summary>
        public void SetWayPoint( List<WayPoint> wayPoints) {
            this.wayPoints=wayPoints;
        }

        /// <summary>
        /// @param float id 
        /// @param float latitude 
        /// @param float longitude
        /// </summary>
        public void SetCompetitors(List<int> id, List<float> latitude, List<float> longitude) 
        {
            competitors = new List<Competitor>();
            for(int i = 0; i<id.Count; i++)
            {
                Competitor comp = new Competitor(id.ElementAt(i));
                Position pos = new Position(latitude.ElementAt(i), longitude.ElementAt(i));
                comp.SetPosition(pos);
                competitors.Add(comp);
            }    
        }

        /// <summary>
        /// @param float env
        /// </summary>
        public void change_Env(Dictionary<Environement.Conditions,float> env) {
            this.env.setEnvironment(env);
        }

        public void sendPosition() {
            Position pos = this.boat.GetPosition();
            this.myAquisition.sentPosition(this.boat.GetId(), pos.GetLongitude(), pos.GetLatitude());
        }

        public Mode getMode() {
            return this.mode;
        }

        /// <summary>
        /// @param int AccFac
        /// </summary>
        public void setacceleratorFactor(int AccFac) {
            this.physics.SetAccelerationFactor(AccFac);
        }

        public void nextIteration() {
            // TODO implement here
        }

    }
}