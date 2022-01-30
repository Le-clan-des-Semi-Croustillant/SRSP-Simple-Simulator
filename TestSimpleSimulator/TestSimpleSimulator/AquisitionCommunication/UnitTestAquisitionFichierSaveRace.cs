using Microsoft.VisualStudio.TestTools.UnitTesting;
using AquitisionCommunication;
namespace AquitisionCommunicationTest
{
    [TestClass]
    public class UnitTestPosition
    {
        
        [TestMethod]
        public void TestSaveAndReload()
        {
            AquisitionFichierSaveRace acq = new AquisitionFichierSaveRace("./test");
            acq.savefile();
            AquisitionFichierSaveRace.JsonRace test = acq.loadfile();
            Assert.IsTrue(acq.GetJsonRace().Equals(test));
        }

        [TestMethod]
        public void TestUpdate()
        {
            Race.Race race = new Race.Race();
            AquisitionFichierSaveRace acq = new AquisitionFichierSaveRace("./test");
            acq.Update(race);
            string expect = "{\"IdRace\":0,\"RaceTime\":\"0001-01-01T00:00:00\",\"wayPoints\":[],\"BoatId\":50,\"BoatCap\":0.0}";
            string value = Newtonsoft.Json.JsonConvert.SerializeObject(acq.GetJsonRace());
            Assert.IsTrue((expect==value));
        }
    }
}