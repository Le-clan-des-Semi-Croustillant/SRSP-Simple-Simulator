
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace PRace
{
    public class Race {

        public Race(RaceModel model, Mode mode, AquitisionCommunication.RaceSave.JsonRace jrace = null) {
            this.model = model;
            Time acc = new Time();
            this.accFactor = acc;
            this.env = new Environement.Environment();
            this.clock = new Clock(this, acc);
            this.boat = new Boat();
            this.physics = new physicSimulator.physics_simulator(env,boat,acc);
            this.myAquisition = new AquitisionCommunication.Aquisition(this);
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
                this.accFactor.SetAccFactor(jrace.accelerationFactor);
                this.clock.SetCurrentMoment(jrace.RaceTime);
            }
            else
            {
                this.id = 1;
                this.wayPoints = new List<WayPoint>();
                Position pos = new Position(0, 90);
                List<Polaire> pols = new List<Polaire>();
                this.boat.init(1, pols, pos);
                this.boat.setCap(0);
                this.accFactor.SetAccFactor(1);
                this.clock.SetCurrentMoment(new DateTime());

            }

        }

        private int id = 0;

        private RaceModel model;

        private Mode mode;

        private AquitisionCommunication.Aquisition myAquisition;

        private physicSimulator.physics_simulator physics;

        private Clock clock;

        private Time accFactor;

        private Environement.Environment env;

        private Boat boat;

        private List<WayPoint> wayPoints;

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

        public void SetBoatCap(float cap)
        {
            this.boat.setCap((cap + 360)%360);
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

        public void SetAccFactor(float acc)
        {
            this.accFactor.SetAccFactor(acc);
        }

        public float GetAccFactor()
        {
            return accFactor.GetAccFactorValue();
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

        public (double longitude, double latitude) GetPosition()
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
            this.myAquisition.sentPosition(this.env.getEnvState(),this.physics.GetSOG(),this.physics.GetCOG(), this.boat.getCap(), pos.GetCoordLat(), pos.GetCoordLong(), clock.GetCurrentMoment(), this.physics.GetSTW(), this.physics.GetAWS(), this.physics.GetAWA());
        }

        public Mode getMode() {
            return this.mode;
        }

        /// <summary>
        /// @param int AccFac
        /// </summary>
        public void setacceleratorFactor(int AccFac) {
            this.accFactor.SetAccFactor(AccFac);
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
            //this.boat.UpdateCap(this.physics);
            sendPosition();
            Console.WriteLine(clock.GetCurrentMoment());
            Console.WriteLine(boat.GetPosition().ToString());
            model.Notify();
        }

        public bool GetisPause()
        {
            return clock.GetIsPause();
        }

        public List<double> GetBoatStatus()
        {
            List<double> status = new List<double>();
            (double lon, double lat) pos = GetPosition();
            status.Add(pos.lon);
            status.Add(pos.lat);
            status.Add(GetBoatCap());
            status.Add(physics.GetCOG());
            status.Add(physics.GetSOG());
            //ajouter by Dany
            status.Add(physics.GetSTW());
            status.Add(physics.GetAWS());
            status.Add(physics.GetAWA());
            //
            return status;
        }

        public AquitisionCommunication.Aquisition GetAquisition()
        {
            return myAquisition;
        }
    }

}