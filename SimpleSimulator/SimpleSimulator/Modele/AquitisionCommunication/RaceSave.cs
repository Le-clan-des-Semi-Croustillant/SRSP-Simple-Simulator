
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Model.Race;

namespace AquitisionCommunication
{
    public class RaceSave
    {

        public RaceSave(string filePath)
        {
            this.jrace = new JsonRace();
            this.filePath = filePath;
        }

        private JsonRace jrace;

        private string filePath;

        public class JsonRace
        {
            public JsonRace()
            {
            }
            public int RaceId = 0;
            public DateTime RaceTime = new DateTime();
            public string wayPointFile = "";
            public List<string> polFiles = new List<string>(); 
            public int BoatId = 1;
            public float BoatCap = 0F;
            public float longitude = 0F;
            public float latitude = 0F;
            public float accelerationFactor = 1;

            
            public bool Equals(Object o)
            {
                string stirngthis = JsonConvert.SerializeObject(this);
                string stringo = JsonConvert.SerializeObject(o);
                return stirngthis.Equals(stringo);
            }
        }

        public JsonRace GetJsonRace()
        {
            return jrace;
        }

        public void Update(Model.Race.Race race)
        {
            jrace.RaceId = race.GetId();
            jrace.RaceTime = race.GetCurrentInstant();
            jrace.BoatId = race.GetBoatId();
            jrace.BoatCap = race.GetBoatCap();
            (jrace.longitude, jrace.latitude) = race.GetPosition();
        }

        public JsonRace loadfile()
        {
            string json = "";
            using (StreamReader r = new StreamReader(filePath))
            {
                json = r.ReadToEnd();
            }
            return (JsonRace)JsonConvert.DeserializeObject(json, jrace.GetType());
        }

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