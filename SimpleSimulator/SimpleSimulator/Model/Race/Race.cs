
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRace
{
    public class Race {

        public Race(Mode mode, AquitisionCommunication.RaceSave.JsonRace jrace = null) {
            this.env = new Environement.Environment();
            this.clock = new Clock(this);
            this.boat = new Boat();
            this.physics = new physicSimulator.physics_simulator();
            this.physics.init(this.env, this.boat);
            switch (mode)
            {
                case Mode.Entrainement:
                    EntrainementSetUp(jrace);
                    break;
                default:
                    break;
            }
        }

        private void EntrainementSetUp(AquitisionCommunication.RaceSave.JsonRace jrace)
        {
            if (jrace != null)
            {
                this.id = jrace.RaceId;
                this.wayPoints = new List<WayPoint>();
                Position pos = new Position(jrace.longitude, jrace.latitude);
                List<Polaire> pols = MultiplePolaireAssimilation(jrace.polFiles);
                this.boat.init(jrace.BoatId, pols, pos);
                this.boat.SetCurrentPolaire(jrace.currentPol);
                this.boat.setCap(jrace.BoatCap);
                this.physics.SetAccelerationFactor(jrace.accelerationFactor);
                this.clock.SetCurrentMoment(jrace.RaceTime);
            }
            else
            {
                this.id = 1;
                this.wayPoints = new List<WayPoint>();
                Position pos = new Position(0, 0);
                List<Polaire> pols = new List<Polaire>();
                this.boat = new Boat();
                this.boat.init(1, pols, pos);
                this.boat.setCap(0);
                this.physics.SetAccelerationFactor(0);
                this.clock.SetCurrentMoment(new DateTime());

            }

        }

        private int id = 0;

        private Mode mode;

        private Environement.Environment env;

        private Boat boat;

        private physicSimulator.physics_simulator physics;

        private List<WayPoint> wayPoints;

        private AquitisionCommunication.Aquisition myAquisition;

        private Clock clock;
        
        private List<Competitor> competitors;

        private Polaire PolaireAssimilation(string path, AquitisionCommunication.AquisitionPolaire acq)
        {
            string name = path;
            Dictionary<float,Dictionary<float, float>> polaire = acq.ReadPolaire(path);
            Polaire pol = new Polaire(name, polaire);
            return pol;
        }

        private List<Polaire> MultiplePolaireAssimilation(List<string> path)
        {
            AquitisionCommunication.AquisitionPolaire acq = new AquitisionCommunication.AquisitionPolaire();
            List<Polaire> allPol = new List<Polaire>();
            foreach(string file in path)
            {
                allPol.Add(PolaireAssimilation(file, acq));
            }
            return allPol;
        }

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

        public Environement.Environment GetEnvironment()
        {
            return env;
        }

        public Polaire GetCurrentPolaire()
        {
            return boat.GetCurrentPolaire();
        }

        public List<Polaire> GetAllPolaire() 
        {
            return boat.GetAllPolaire();
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

        public void SetCompetitors(List<int> id, List<float> latitude, List<float> longitude)
        {
            competitors = new List<Competitor>();
            for (int i = 0; i < id.Count; i++)
            {
                Competitor comp = new Competitor(id.ElementAt(i));
                Position pos = new Position(latitude.ElementAt(i), longitude.ElementAt(i));
                comp.SetPosition(pos);
                competitors.Add(comp);
            }
        }

        public Boat GetBoat()
        {
            return this.boat;
        }

        public (float longitude,float latitude) GetPosition()
        {
            Position pos = this.boat.GetPosition();
            return (pos.GetLongitude(), pos.GetLatitude());
        }

        /// <summary>
        /// @param List WayPoint wayPoints
        /// </summary>
        public void SetWayPoint( List<WayPoint> wayPoints) {
            this.wayPoints=wayPoints;
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


        public void Pause()
        {
            clock.pause();
        }

        public void Run()
        {
            var tIteration = Task.Run(() => clock.Run());
        }

        public void nextIteration() {
            this.physics.Move();
            Console.Write(boat.GetPosition().ToString());
        }

        public bool GetisPause()
        {
            return clock.GetIsPause();
        }

        public List<float> GetBoatStatus()
        {
            List<float> status = new List<float>();
            (float lon, float lat) pos = GetPosition();
            status.Add(pos.lon);
            status.Add(pos.lat);
            status.Add(GetBoatCap());
            status.Add(physics.GetCOG());
            status.Add(physics.GetCOG());
            return status;
        }

    }
}