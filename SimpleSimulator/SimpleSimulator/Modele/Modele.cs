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
                race = new Race.Race(this.mode, acq.loadfile());
            }
            else
            {
                race = new Race.Race(this.mode);// to change to be chosen by the user
            }
            race.Run();
        }
        public RaceModel(string path)
        {
            AskMode();
            this.savePath = path;
            if (savePath != null)
            {
                AquitisionCommunication.RaceSave acq = new AquitisionCommunication.RaceSave(savePath);
                race = new Race.Race(this.mode, acq.loadfile());
            }
            else
            {
                race = new Race.Race(this.mode);
            }
            race.Run();
        }

        private string savePath = null;

        private Race.Race race;

        private Race.Mode mode;

        public Race.Race GetRace()
        {
            return race;
        }

        public void AskMode()
        {
            this.mode = Race.Mode.Entrainement;// to change to be chosen by the user
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




    }
}
