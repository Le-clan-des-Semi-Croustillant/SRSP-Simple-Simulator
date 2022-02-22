using System.Text;
using Newtonsoft.Json;

namespace Model
{

    public class RaceModel
    {
        public RaceModel()
        {
            AskMode();
            AskForSavePath();
            if (savePath != null)
            {
                AquitisionCommunication.RaceSave acq = new AquitisionCommunication.RaceSave(savePath);
                race = new PRace.Race(this.mode, acq.loadfile());
            }
            else
            {
                race = new PRace.Race(this.mode);// to change to be chosen by the user
            }
        }
        public RaceModel(string path)
        {
            AskMode();
            this.savePath = path;
            if (savePath != null)
            {
                AquitisionCommunication.RaceSave acq = new AquitisionCommunication.RaceSave(savePath);
                race = new PRace.Race(this.mode, acq.loadfile());
            }
            else
            {
                race = new PRace.Race(this.mode);
            }
        }

        private string savePath = null;

        private PRace.Race race;

        private PRace.Mode mode;

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
