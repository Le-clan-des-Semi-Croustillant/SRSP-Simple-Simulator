
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Communication.DataProcessing.Json;

namespace PRace
{
    /// <summary>
    /// This class represent a race
    /// </summary>
    public class Race {

        /// <summary>
        /// Create an instance of a race
        /// </summary>
        /// <param name="model">The <see cref="RaceModel"/> of the simultator</param>
        /// <param name="jrace">The <see cref="AquitisionCommunication.RaceSave.JsonRace"/> to use as a save to load the race</param>
        /// <param name="portQTVLM">port to us to connecte to QTVLM</param>
        /// <param name="ipQTVLM">IP to us to connecte to QTVLM</param>
        /// <param name="portRM">port to us to connecte to the Race Manager</param>
        /// <param name="ipRM">IP to us to connecte to The Race Manager</param>
        public Race(RaceModel model, AquitisionCommunication.RaceSave.JsonRace jrace, int portQTVLM, string ipQTVLM, int portRM, string ipRM) {
            this.model = model;
            Time acc = new Time();
            this.accFactor = acc;
            this.env = new Environement.Environment();
            this.clock = new Clock(this, acc);
            this.boat = new Boat();
            this.physics = new physicSimulator.physics_simulator(env,boat,acc);
            this.myAquisition = new AquitisionCommunication.Aquisition(this, portQTVLM, ipQTVLM, portRM, ipRM);
            this.mode = jrace.GetMode();

            switch (mode)
            {
                case Mode.Entrainement:
                    EntrainementSetUp(jrace);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Create an instance of a race
        /// </summary>
        /// <param name="model">The <see cref="RaceModel"/> of the simultator</param>
        /// <param name="selectedBoatType">The <see cref="Communication.DataProcessing.Json.BoatType"/> to use as model to create the 'boat' attribut</param>
        /// <param name="mode">The <see cref="Mode"/> of the race</param>
        /// <param name="portQTVLM">port to us to connecte to QTVLM</param>
        /// <param name="ipQTVLM">IP to us to connecte to QTVLM</param>
        /// <param name="portRM">port to us to connecte to the Race Manager</param>
        /// <param name="ipRM">IP to us to connecte to The Race Manager</param>
        public Race(RaceModel model, BoatType selectedBoatType,Mode mode, int portQTVLM, string ipQTVLM, int portRM, string ipRM)
        {
            this.model = model;
            Time acc = new Time();
            this.accFactor = acc;
            this.env = new Environement.Environment();
            this.clock = new Clock(this, acc);
            this.boat = new Boat(selectedBoatType);
            this.physics = new physicSimulator.physics_simulator(env, boat, acc);
            this.myAquisition = new AquitisionCommunication.Aquisition(this, portQTVLM, ipQTVLM, portRM, ipRM);
            this.mode = mode;
            switch (mode)
            {
                case Mode.Entrainement:
                    EntrainementSetUp(selectedBoatType);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Set up the race for the training mode
        /// </summary>
        /// <param name="jrace"><see cref="AquitisionCommunication.RaceSave.jrace"/> dynamique instance of the save  </param>
        private void EntrainementSetUp(AquitisionCommunication.RaceSave.JsonRace jrace)
        {
            this.id = jrace.RaceId;
            this.wayPoints = new List<WayPoint>();
            //retreive position from save
            Position pos = new Position(jrace.longitude, jrace.latitude);
            //load each polar
            List<Polaire> pols = MultiplePolaireAssimilation(jrace.polFiles, jrace.polNames);
            this.boat.init(jrace.BoatId, pols, pos,this);
            this.boat.SetCurrentPolaire(jrace.currentPol);
            this.boat.setCap(jrace.BoatCap);
            this.accFactor.SetAccFactor(jrace.accelerationFactor);
            this.clock.SetCurrentMoment(jrace.RaceTime);
        }

        /// <summary>
        /// Set up the race for the training mode
        /// </summary>
        /// <param name="jrace"></param>
        private void EntrainementSetUp(BoatType selectedBoatType)
        {
            this.id = 1;
            Position pos = new Position(0, 90);
            List<Polaire> polars = new List<Polaire>();
            AquitisionCommunication.AquisitionPolaire acq = new AquitisionCommunication.AquisitionPolaire();
            foreach (Polar pol in selectedBoatType.PolarFileList)
            {

                Polaire polar = new Polaire(pol.Name, acq.ReadPolaire(pol.File), pol.File);
                polars.Add(polar);
            }
            this.boat.init(1, polars, pos, this);
            this.boat.setCap(0);
            this.accFactor.SetAccFactor(1);
            this.clock.SetCurrentMoment(new DateTime());
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

        /// <summary>
        /// Create a <see cref="Polaire"/> correponding to the file targeted by the given path. This polar is named according to the input name
        /// </summary>
        /// <param name="path">path of the save file of the polar (.pol)</param>
        /// <param name="acq">a <see cref="AquitisionCommunication.AquisitionPolaire"/> instance (any instance will do the job)</param>
        /// <param name="name">name of the polar</param>
        /// <returns>return a <see cref="Polaire"/> correponding to the file targeted by the given path. This polar is named according to the input name</returns>
        private Polaire PolaireAssimilation(string path, AquitisionCommunication.AquisitionPolaire acq, string name)
        {
            Dictionary<float,Dictionary<float, float>> polaire = acq.ReadPolaire(path);
            Polaire pol = new Polaire(name, polaire, path);
            return pol;
        }

        /// <summary>
        /// Create a List of <see cref="Polaire"/> corresponding to the given list of path and name.
        /// </summary>
        /// <remarks>Call the fonction <see cref="Race.PolaireAssimilation(string, AquitisionCommunication.AquisitionPolaire, string)"/> for each path in the path list</remarks>
        /// <param name="path">List of path to the polar save (.pol)</param>
        /// <param name="names">List of polar name</param>
        /// <returns></returns>
        private List<Polaire> MultiplePolaireAssimilation(List<string> path, List<string> names)
        {
            AquitisionCommunication.AquisitionPolaire acq = new AquitisionCommunication.AquisitionPolaire();
            List<Polaire> allPol = new List<Polaire>();
            for(int i = 0; i < path.Count; i++)
            {
                allPol.Add(PolaireAssimilation(path.ElementAt(i), acq, names.ElementAt(i)));
            }
            return allPol;
        }

        public int GetId()
        {
            return id;
        }

        /// <summary>
        /// Return the time of the inner time of the simulation
        /// </summary>
        /// <returns>Return the time of the inner time of the simulation</returns>
        public DateTime GetCurrentInstant()
        {
            return this.clock.GetCurrentMoment();
        }

        public List<WayPoint> GetWayPoint()
        {
            return wayPoints;
        }

        /// <summary>
        /// Set the cap of the attribut 'boat' modulo 360
        /// </summary>
        /// <param name="cap">cap in degre</param>
        public void SetBoatCap(float cap)
        {
            this.boat.setCap((cap + 360)%360);
        }

        
        public Environement.Environment GetEnvironment()
        {
            return env;
        }

        /// <summary>
        /// Call the fonction <see cref="Boat.GetCurrentPolaire"/> and return its value
        /// </summary>
        /// <returns>return the polar currently used by the boat</returns>
        public Polaire GetCurrentPolaire()
        {
            return boat.GetCurrentPolaire();
        }

        /// <summary>
        /// Call the fonction <see cref="Boat.getAvailablePolaire"/> and return its value
        /// </summary>
        /// <returns>return all polars of the boat attribut</returns>
        public List<Polaire> GetAllPolaire() 
        {
            return boat.getAvailablePolaire();
        }

        /// <summary>
        /// Call the fonction <see cref="Boat.GetId"/> and return its value
        /// </summary>
        /// <returns>return the boat id</returns>
        public int GetBoatId()
        {
            return boat.GetId();
        }

        /// <summary>
        /// Call the fonction <see cref="Boat.getCap"/> and return its value
        /// </summary>
        /// <returns>return the boat cap</returns>
        public float GetBoatCap()
        {
            return boat.getCap();
        }

        public List<Competitor> GetCompetitors()
        {
            return this.competitors;
        }

        /// <summary>
        /// set the acceleration factor of the simulator
        /// </summary>
        /// <param name="acc"></param>
        public void SetAccFactor(float acc)
        {
            this.accFactor.SetAccFactor(acc);
        }

        /// <summary>
        /// get the acceleration factor of the simulation
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// return the Boat position
        /// </summary>
        /// <returns>return a double (flaot, float) containing the longitude and the latiude of the boat in radiant</returns>
        public (double longitude, double latitude) GetPosition()
        {
            Position pos = this.boat.GetPosition();
            return (pos.GetLongitude(), pos.GetLatitude());
        }

        
        public void SetWayPoint( List<WayPoint> wayPoints) {
            this.wayPoints=wayPoints;
        }

        /// <summary>
        /// Call the fonction <see cref="Environement.Environment.setEnvironment(Dictionary{Environement.Conditions, float})"/>
        /// </summary>
        /// <param name="env"></param>
        public void change_Env(Dictionary<Environement.Conditions,float> env) {
            this.env.setEnvironment(env);
        }

        /// <summary>
        /// send information about the race to QTVLM or OPENCPN
        /// </summary>
        public void sendPosition() {
            Position pos = this.boat.GetPosition();
            this.myAquisition.sentPosition(this.env.getEnvState(),this.physics.GetSOG(),this.physics.GetCOGDegre(), this.boat.getCap(), pos.GetCoordLat(), pos.GetCoordLong(), clock.GetCurrentMoment(), this.physics.GetSTW(), this.physics.GetAWS(), this.physics.GetAWADegre());
        }

        public Mode getMode() {
            return this.mode;
        }

        /// <summary>
        /// Set the acceleration factor of the race
        /// </summary>
        /// <param name="AccFac"></param>
        public void setacceleratorFactor(int AccFac) {
            this.accFactor.SetAccFactor(AccFac);
        }

        /// <summary>
        /// Pause the inner clock of the race
        /// </summary>
        /// <remarks>Call <see cref="Clock.pause"/></remarks>
        public void Pause()
        {
            clock.pause();
        }

        /// <summary>
        /// Run the inner clock of the race
        /// </summary>
        /// <remarks>Call <see cref="Clock.Run"/></remarks>
        public void Run()
        {
            var tIteration = Task.Run(() => clock.Run());
        }

        /// <summary>
        /// Do the next iteration of the race.
        /// Calculate and apply the physic motion of the boat.
        /// Uptate the heading of the boat for the wind mode.
        /// Send information about the race to QTVLM
        /// </summary>
        public void nextIteration() {
            this.physics.Move();
            this.boat.UpdateCap(this.env);
            try {
                sendPosition();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine(clock.GetCurrentMoment());
            Console.WriteLine(boat.GetPosition().ToString());
            model.Notify();
        }

        /// <summary>
        /// Return if the race is paused or not
        /// </summary>
        /// <returns>return true if the race is paused else return false</returns>
        public bool GetisPause()
        {
            return clock.GetIsPause();
        }

        /// <summary>
        /// Return a list of double summarizing the status of the boat (longitude, latitude, cap, cog, sog, stw, aws, awa)
        /// </summary>
        /// <returns>Return a list of double summarizing the status of the boat (longitude, latitude, cap, cog, sog, stw, aws, awa)</returns>
        public List<double> GetBoatStatus()
        {
            List<double> status = new List<double>();
            (double lon, double lat) pos = GetPosition();
            status.Add(pos.lon);
            status.Add(pos.lat);
            status.Add(GetBoatCap());
            status.Add(physics.GetCOG());
            status.Add(physics.GetSOG());
            status.Add(physics.GetSTW());
            status.Add(physics.GetAWS());
            status.Add(physics.GetAWADegre());
            return status;
        }

        public AquitisionCommunication.Aquisition GetAquisition()
        {
            return myAquisition;
        }

        public DateTime getCurrentMoment()
        {
            return clock.GetCurrentMoment();
        }
    }

}