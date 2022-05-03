using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using Communication;
using Communication.DataProcessing;
using System.Net;
using Communication.DataProcessing.Json;
using PRace;


namespace Model
{
    /// <summary>
    /// This class plays the role of model(pattern model-observer) for the class <see cref="Race"/>.
    /// It's also manage the save process
    /// </summary>
    public class RaceModel : ISubject
    {
        /// <summary>
        /// Create an instance of RaceModel
        /// </summary>
        public RaceModel()
        {
            ListObserver = new List<IObserver>();
        }
        

        /// <summary>
        /// Set up this instance by loading a save or creating a new race based on mode an boat type.
        /// In order to this fonction to work path or (mode and IDBoatType) need to be provided        
        /// </summary>
        /// <remarks>this fonction priorizes the initialisation with the path</remarks>
        /// <param name="mode">the <see cref=""/> for the new race</param>
        /// <param name="IDBoatType">the <see cref="Communication.DataProcessing.Json.BoatType"/> which will be used to create the boat of the new race</param>
        /// <param name="path">the path at with be used to load the save</param>
        /// <param name="portQTVLM">the port that will be used to connect to QTVLM</param>
        /// <param name="ipQTVLM">the ip that will be used to connect to QTVLM</param>
        /// <param name="portRM">the port that will be used to connect to the Race Manager</param>
        /// <param name="ipRM">the ip that will be used to connect to the Race Manager</param>
        public void Set_Up(PRace.Mode? mode = null, string? IDBoatType = null, string path = null, int portQTVLM = 10113, string ipQTVLM = "127.0.0.1", int portRM = 0, string ipRM = "0")
        {
            //if an input save is provided
            if (path != null)
            {
                string SavePath = path + "/save.json";
                //remenber the save used to create the race
                this.savePath = path;
                //instanciate the object to load the save
                AquitisionCommunication.RaceSave acq = new AquitisionCommunication.RaceSave(SavePath);
                //create the new race
                race = new PRace.Race(this, acq.loadfile(), portQTVLM, ipQTVLM, portRM, ipRM);
            }
            //if a mode and a boat type id is provide
            else if(mode != null || IDBoatType != null)
            {
                //convert the string in an int
                Int64 ID = Int64.Parse(IDBoatType.Split(':')[0]);
                BoatType selectedType = null;
                //list of BoatType retreive during the last call to the race manager
                List<BoatType> boatTypesListT = BoatType.BoatTypesList;
                //select the corresponding BoatType
                foreach(BoatType boatType in boatTypesListT)
                {
                    if(boatType.ID == ID)
                    {
                        selectedType = boatType;
                    }
                }

                //create the new race
                race = new PRace.Race(this, selectedType, (PRace.Mode)mode, portQTVLM, ipQTVLM, portRM, ipRM);
            }
        }

        private string savePath = null;

        private PRace.Race race;

        private PRace.Mode mode;

        private List<IObserver> ListObserver;

        /// <summary>
        /// Attach a new <see cref="IObserver"/> to the model
        /// </summary>
        /// <param name="obs"></param>
        public void Attach(IObserver obs)
        {
            ListObserver.Add(obs);
        }

        /// <summary>
        /// Notify all the added observer (all observer in 'ListObserver' attribut
        /// </summary>
        public void Notify()
        {
            ListObserver.ForEach(o => o.Update(this));
        }

        public PRace.Race GetRace()
        {
            return race;
        }

        /// <summary>
        /// return the list the path of all available saves
        /// </summary>
        /// <returns>return the list the path of all available saves</returns>
        public string[] ListSavePath()
        {
            string saveDir = Directory.GetCurrentDirectory() + "/Saves";
            string[] listSave = Directory.GetDirectories(saveDir);
            return listSave;
        }

        /// <summary>
        /// Create a save of the race
        /// </summary>
        /// <param name="inputSavePath">Name of the save</param>
        public void Save(string inputSavePath)
        {
            //pause the inner clock of the race during the save
            race.Pause();
            //verify that the model paused
            while (!race.GetisPause())
            {
                Thread.Sleep(200);
            }
            //check if an input save is provided
            if (inputSavePath != null)
            {
                //check if the save is going to overwrite the save used to initially load the race
                string currentDirectory = Directory.GetCurrentDirectory();
                string saveDirectory = currentDirectory.Replace("\\", "/") + "/Saves/" + inputSavePath;
                //if a save has been used to create race
                if (this.savePath != null)
                {
                    this.savePath = this.savePath.Replace("\\", "/");
                }


                //if the save is not going to overwrite the save used to initially load the race
                if (this.savePath == null || !this.savePath.Equals(saveDirectory))
                {
                    try
                    {
                        // delete the directory if it exists
                        if (Directory.Exists(saveDirectory))
                        {
                            Directory.Delete(saveDirectory, true);
                        }

                        //create the save directory
                        DirectoryInfo di = Directory.CreateDirectory(saveDirectory);

                        //create the polar directory
                        DirectoryInfo dip = Directory.CreateDirectory(saveDirectory + "/polar");
                        int i = 0;
                        //copy all the polar file in the polar directory
                        foreach (Polaire pol in race.GetAllPolaire())
                        {
                            i++;
                            //add the position to the file name in case there is two polar with the same name
                            string polPath = saveDirectory + "/polar/" + i.ToString() + pol.getName() + ".pol";
                            File.Copy(pol.getPath(), polPath);
                            pol.setPath("./Saves/" + inputSavePath + "/polar/" + i.ToString() + pol.getName() + ".pol");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The process failed: {0}", e.ToString());
                    }
                }
                //save the race
                AquitisionCommunication.RaceSave acq = new AquitisionCommunication.RaceSave(saveDirectory + "/save.json");
                acq.Update(race);
                acq.savefile();
            }
            race.Run();
        }

        public List<string> getBoatList(string ip, int port)
        {
            //asks to the Race Manager the available Boat Type
            IMessageType info = IMessageType.BOATLISTREQUEST;
            List<BoatType> boatTypesListT = BoatType.BoatTypesList;
            AsynchronousClient.StartClient(ip, port, info);
            
            List<string> listBoatType = new List<string>();
            foreach (BoatType boat in boatTypesListT)
            {
                listBoatType.Add(boat.ID + ": " + boat.Name);
            }
            
            return listBoatType;
        }

        /// <summary>
        /// Run the race
        /// </summary>
        public void Run()
        {
            this.race.Run();
         } 

        /// <summary>
        /// pause the race
        /// </summary>
        public void Pause()
        {
            this.race.Pause();
        }

        /// <summary>
        /// Return a dictionary with as key <see cref="BoatInfo"/> and as value the corresponding value of the race
        /// </summary>
        /// <returns>Return a dictionary with as key <see cref="BoatInfo"/> and as value the corresponding value of the race</returns>
        public Dictionary<BoatInfo, double> GetBoatStatus()
        {
            Dictionary<BoatInfo, double> status = new Dictionary<BoatInfo, double>();
            List<double> values = race.GetBoatStatus();
            status.Add(BoatInfo.Longitude, values.ElementAt(0));
            status.Add(BoatInfo.Latitude, values.ElementAt(1));
            status.Add(BoatInfo.Cap, values.ElementAt(2));
            status.Add(BoatInfo.COG, values.ElementAt(3));
            status.Add(BoatInfo.SOG, values.ElementAt(4));
            status.Add(BoatInfo.STW, values.ElementAt(5));
            status.Add(BoatInfo.AWS, values.ElementAt(6));

            return status;
        }

        /// <summary>
        /// set the current of the race
        /// </summary>
        /// <param name="currentspeed">current speed</param>
        /// <param name="currentdir">current direction</param>
        public void SetCurrent(float currentspeed, float currentdir)
        {
            race.GetEnvironment().UpdateCurrent(currentspeed, (currentdir+180) % 360);
        }

        /// <summary>
        /// set the waves of th simulation
        /// </summary>
        /// <param name="wavesampl"></param>
        /// <param name="wavedir"></param>
        /// <param name="wavelength"></param>
        public void SetWave(float wavesampl, float wavedir, float wavelength)
        {
            race.GetEnvironment().UpdateWave(wavesampl, (wavedir+180) % 360, wavelength);
        }

        /// <summary>
        /// set the wind of the simulation
        /// </summary>
        /// <param name="windspeed">wind speed</param>
        /// <param name="winddir">wind direction</param>
        public void SetWind(float windspeed, float winddir)
        {
            race.GetEnvironment().UpdateWind(windspeed, (winddir+180) % 360);
        }

        /// <summary>
        /// set the acceleration factor of the simulation
        /// </summary>
        /// <param name="acc"></param>
        public void SetFactor(float acc)
        {
            race.SetAccFactor(acc);
        }

        /// <summary>
        /// return the acceleration factor of the simulation
        /// </summary>
        /// <returns>return the acceleration factor of the simulation</returns>
        public float GetAccFactor()
        {
            
            return race.GetAccFactor();
        }

        /// <summary>
        /// Increment the cap the commande mode
        /// </summary>
        /// <param name="commande">Commande mode to increment</param>
        /// <param name="degre">value of the increment</param>
        public void IncrementCap(PRace.ModeCommande commande, PRace.DegreeIncrement degre)
        {
            this.race.GetBoat().IncrementCap(commande, degre);
        }


        /// <summary>
        /// If the attrubit commande is 'cap' switch to 'RegulateurAmure'.
        /// If the attrubit commande is 'RegulateurAmure' switch to 'cap'.
        /// </summary>
        public void SwitchCommande()
        {
            race.GetBoat().switchCommande();
        }

        /// <summary>
        /// return boat heading
        /// </summary>
        /// <returns></returns>
        public float getModelCap()
        {
            return race.GetBoatCap();
        }

        /// <summary>
        /// return the cap of the wind mode
        /// </summary>
        /// <returns></returns>
        public float getAllureCap()
        {
            return race.GetBoat().GetCapRegulateurAmure();
        }

        /// <summary>
        /// return the active commande mode
        /// </summary>
        /// <returns></returns>
        public PRace.ModeCommande getCommandeMode()
        {
            return race.GetBoat().GetModeCommande();
        }

        /// <summary>
        /// return the wind speed of the simulation
        /// </summary>
        /// <returns></returns>
        public float getWindSpeed()
        {
            return race.GetEnvironment().getEnvState()[Environement.Conditions.WindSpeed];
        }
        
        /// <summary>
        /// return the wind direction of the simulation
        /// </summary>
        /// <returns></returns>
        public float getWindDir()
        {
            return race.GetEnvironment().getEnvState()[Environement.Conditions.WindDirection];
        }

        /// <summary>
        /// return Wave Amplitude of the simulation
        /// </summary>
        /// <returns></returns>
        public float getWaveAmpl()
        {
            return race.GetEnvironment().getEnvState()[Environement.Conditions.WaveAmplitude];
        }

        /// <summary>
        /// return Wave direction of the simulation
        /// </summary>
        /// <returns></returns>
        public float getWaveDir()
        {
            return race.GetEnvironment().getEnvState()[Environement.Conditions.WaveDirection];
        }

        /// <summary>
        /// return Wave length of the simulation
        /// </summary>
        /// <returns></returns>
        public float getWaveLength()
        {
            return race.GetEnvironment().getEnvState()[Environement.Conditions.WaveLength];
        }

        /// <summary>
        /// return current speed of the simulation
        /// </summary>
        /// <returns></returns>
        public float getWaterSpeed()
        {
            return race.GetEnvironment().getEnvState()[Environement.Conditions.CurrentSpeed];
        }

        /// <summary>
        /// return current direction of the simulation
        /// </summary>
        /// <returns></returns>
        public float getWaterDir()
        {
            return race.GetEnvironment().getEnvState()[Environement.Conditions.CurrentDirection];
        }

        /// <summary>
        /// return the speed throw water of the boat
        /// </summary>
        /// <returns></returns>
        public float getSTW()
        { 
            return float.Parse(race.GetBoatStatus()[5].ToString());
        }

        /// <summary>
        /// Set the IP and port of QTVLN
        /// </summary>
        /// <param name="port"></param>
        /// <param name="ip"></param>
        public void setNMEA(int port, string ip)
        {
            race.GetAquisition().SetNMEA(port, ip);
        }

        /// <summary>
        /// return the port use for QTVLM
        /// </summary>
        /// <returns></returns>
        public int getportNMEA()
        {
            return race.GetAquisition().getPortNMEA();
        }

        /// <summary>
        /// return the ip use for QTVLM
        /// </summary>
        /// <returns></returns>
        public string getipNMEA()
        {
            return race.GetAquisition().getIpNMEA();
        }

        /// <summary>
        /// Return the list of all available polars of the boat
        /// </summary>
        /// <returns></returns>
        public List<String> getListPolaire()
        {
            List<String> polarNames = new List<string>();
            List<Polaire> polars = race.GetBoat().getAvailablePolaire();
            foreach (Polaire pol in polars)
            {
                polarNames.Add(pol.getName());
            }
            return polarNames;
        }

        /// <summary>
        /// Set the current polar of the boat to the polars with the corresponding name amoung all available polars
        /// </summary>
        /// <param name="polaireName"></param>
        public void setPolaire(string polaireName)
        {
            race.GetBoat().SetCurrentPolaire(polaireName);
        }

        /// <summary>
        /// lower the sails
        /// </summary>
        public void setNoneCurrentPolar()
        {
            race.GetBoat().setNullCurrentPolar();
        }

        /// <summary>
        /// Set the position of the boat
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public void setPositionDeDepart(float latitude, float longitude)
        {

            try
            {
                race.GetBoat().GetPosition().Update(longitude, latitude + 90f);
            }
            catch (Exception ex)
            {

            }
        }
        public DateTime getTime()
        {
            return race.getCurrentMoment();
        }
    }
}
