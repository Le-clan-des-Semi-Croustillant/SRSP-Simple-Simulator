using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public void SetCurrent(float currentspeed, float currentdir)
        {
            race.GetEnvironment().UpdateCurrent(currentspeed, (currentdir+180) % 360);
        }
        public void SetWave(float wavesampl, float wavedir, float wavelength)
        {
            race.GetEnvironment().UpdateWave(wavesampl, (wavedir+180) % 360, wavelength);
        }
        public void SetWind(float windspeed, float winddir)
        {
            race.GetEnvironment().UpdateWind(windspeed, (winddir+180) % 360);
        }
        public void SetFactor(float acc)
        {
            race.SetAccFactor(acc);
        }

        public float GetAccFactor()
        {
            
            return race.GetAccFactor();
        }

        public void IncrementCap(PRace.ModeCommande commande, PRace.DegreeIncrement degre)
        {
            this.race.GetBoat().IncrementCap(commande, degre);
        }

        public void SwitchCommande()
        {
            race.GetBoat().switchCommande();
        }
        public float getModelCap()
        {
            return race.GetBoatCap();
        }
        public PRace.ModeCommande getCommandeMode()
        {
            return race.GetBoat().GetModeCommande();
        }

        
        public float getWindSpeed()
        {
            return race.GetEnvironment().getEnvState()[Environement.Conditions.WindSpeed];
        }
        
        
        public float getWindDir()
        {
            return race.GetEnvironment().getEnvState()[Environement.Conditions.WindDirection];
        }
        public float getWaveAmpl()
        {
            return race.GetEnvironment().getEnvState()[Environement.Conditions.WaveAmplitude];
        }
        public float getWaveDir()
        {
            return race.GetEnvironment().getEnvState()[Environement.Conditions.WaveDirection];
        }
        public float getWaveLength()
        {
            return race.GetEnvironment().getEnvState()[Environement.Conditions.WaveLength];
        }
        public float getWaterSpeed()
        {
            return race.GetEnvironment().getEnvState()[Environement.Conditions.CurrentSpeed];
        }
        public float getWaterDir()
        {
            return race.GetEnvironment().getEnvState()[Environement.Conditions.CurrentDirection];
        }
        
    }
}
