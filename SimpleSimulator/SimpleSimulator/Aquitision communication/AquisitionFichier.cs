
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace AquitisionCommunication
{
    public class AquisitionFichierSaveRace
    {

        public AquisitionFichierSaveRace(string filePath)
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
            public int IdRace = 0;
            public DateTime RaceTime = new DateTime();
            public List<Race.WayPoint> wayPoints = new List<Race.WayPoint>();
            public int BoatId = 1;
            public float BoatCap = 0F;

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

        public void Update(Race.Race race)
        {
            jrace.IdRace = race.GetId();
            jrace.RaceTime = race.GetCurrentInstant();
            jrace.wayPoints = race.GetWayPoint();
            jrace.BoatId = race.GetBoatId();
            jrace.BoatCap = race.GetBoatCap();
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