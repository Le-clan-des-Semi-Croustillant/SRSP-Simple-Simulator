using System.Text;
using Newtonsoft.Json;

namespace Model
{

    public class RaceModel : ISubject
    {
        public RaceModel()
        {
            AskMode();
            AskForSavePath();
            Set_Up();
        }
        public RaceModel(string path)
        {
            AskMode();
            this.savePath = path;
            Set_Up();
            
        }

        private void Set_Up()
        {
            ListObserver = new List<IObserver>();
            if (savePath != null)
            {
                AquitisionCommunication.RaceSave acq = new AquitisionCommunication.RaceSave(savePath);
                race = new PRace.Race(this, this.mode, acq.loadfile());
            }
            else
            {
                race = new PRace.Race(this, this.mode);
            }
        }

        private string savePath = null;

        private PRace.Race race;

        private PRace.Mode mode;

        private List<IObserver> ListObserver;

        public void Attach(IObserver obs)
        {
            ListObserver.Add(obs);
        }

        public void Notify()
        {
            ListObserver.ForEach(o => o.Update(this));
        }

        public PRace.Race GetRace()
        {
            return race;
        }

        public void AskMode()
        {
            this.mode = PRace.Mode.Entrainement;// to change to be chosen by the user
        }
        public void AskForSavePath()
        {
            this.savePath = "./test.json";// to change to be chosen by the user
        }

        public void Save()
        {
            race.Pause();
            while (!race.GetisPause())
            {
                Thread.Sleep(200);
            }
            if (savePath == null)
            {
                AskForSavePath();
            }
            AquitisionCommunication.RaceSave acq = new AquitisionCommunication.RaceSave(savePath);
            acq.Update(race);
            acq.savefile();
        }

        public void Run()
        {
            this.race.Run();
         } 

        public void Pause()
        {
            this.race.Pause();
        }

        public Dictionary<BoatInfo, double> GetBoatStatus()
        {
            Dictionary<BoatInfo, double> status = new Dictionary<BoatInfo, double>();
            List<double> values = race.GetBoatStatus();
            status.Add(BoatInfo.Longitude, values.ElementAt(0));
            status.Add(BoatInfo.Latitude, values.ElementAt(1));
            status.Add(BoatInfo.Cap, values.ElementAt(2));
            status.Add(BoatInfo.COG, values.ElementAt(3));
            status.Add(BoatInfo.SOG, values.ElementAt(4));

            return status;
        }



    }
}
