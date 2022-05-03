
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using PRace;

namespace AquitisionCommunication
{
    /// <summary>
    /// This class is used load and save a serilized vesion of the race
    /// </summary>
    public class RaceSave
    {

        /// <summary>
        /// Create an instance of RaceSave
        /// </summary>
        /// <param name="filePath">path to the save</param>
        public RaceSave(string filePath)
        {
            this.jrace = new JsonRace();
            this.filePath = filePath;
        }

        private JsonRace jrace;

        private string filePath;

        /// <summary>
        /// serilized vesion of the race
        /// </summary>
        public class JsonRace
        {
            public JsonRace()
            {
            }
            public Mode mode = Mode.Entrainement;
            public int RaceId = 0;
            public DateTime RaceTime = new DateTime();
            public string wayPointFile = "";
            public string currentPol = "";
            public List<string> polFiles = new List<string>();
            public List<string> polNames = new List<string>();
            public int BoatId = 1;
            public float BoatCap = 0F;
            public double longitude = 0F;
            public double latitude = 0F;
            public float accelerationFactor = 1;

            public Mode GetMode()
            {
                return mode;
            }
            public bool Equals(Object o)
            {
                string stirngthis = JsonConvert.SerializeObject(this);
                string stringo = JsonConvert.SerializeObject(o);
                return stirngthis.Equals(stringo);
            }
        }

        /// <summary>
        /// return the attribut 'jrace'
        /// </summary>
        /// <returns></returns>
        public JsonRace GetJsonRace()
        {
            return jrace;
        }

        /// <summary>
        /// update the attribut 'jrace' according to the input race
        /// </summary>
        /// <param name="race">race used to update jrace</param>
        public void Update(PRace.Race race)
        {
            jrace.mode = race.getMode();
            jrace.RaceId = race.GetId();
            jrace.RaceTime = race.GetCurrentInstant();
            jrace.BoatId = race.GetBoatId();
            jrace.BoatCap = race.GetBoatCap();
            foreach( Polaire pol in race.GetAllPolaire())
            {
                jrace.polFiles.Add(pol.getPath());
            }
            foreach (Polaire pol in race.GetAllPolaire())
            {
                jrace.polNames.Add(pol.getName());
            }
            if (race.GetCurrentPolaire() == null)
            {
                jrace.currentPol = null;
            }
            else
            {
                jrace.currentPol = race.GetCurrentPolaire().getName();
            }
            (jrace.longitude, jrace.latitude) = race.GetPosition();
        }

        /// <summary>
        /// load a <see cref="JsonRace"/> form the save at the path at the attribut 'filePath' and set 'jrace' accordingly
        /// </summary>
        /// <returns>the value of loaded form the save at the path at the attribut '<see cref="JsonRace"/> form the save at the path at the attribut 'filePath''</returns>
        public JsonRace loadfile()
        {
            string json = "";
            using (StreamReader r = new StreamReader(filePath))
            {
                json = r.ReadToEnd();
            }
            jrace = (JsonRace)JsonConvert.DeserializeObject(json, jrace.GetType());
            return jrace;
        }

        /// <summary>
        /// Save 'jrace' at 'filePath'
        /// </summary>
        public void savefile()
        {
            string json = JsonConvert.SerializeObject(this.jrace);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            using (FileStream fs = File.Create(filePath))
            {
                byte[] jsonUTF = new UTF8Encoding(true).GetBytes(json);
                fs.Write(jsonUTF, 0, jsonUTF.Length);
            }
        }
    }
}