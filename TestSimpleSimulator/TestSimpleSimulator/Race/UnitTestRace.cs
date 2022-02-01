using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Race;
namespace TestRace
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]

        public void TestSetCompetitors()
        {
            Race.Race race = new Race.Race(Mode.Entrainement);
            List<int> idComp = new List<int> { 1,2,3,4,5,6,7};
            List<float> longitude = new List<float> { 1, 2, 3, 4, 5, 6, 7 };
            List<float> latitude = new List<float> { 1, 2, 3, 4, 5, 6, 7 };
            race.SetCompetitors(idComp, longitude, latitude);

            List<Competitor> competitors = race.GetCompetitors();
            Competitor comp = new Competitor(1);
            bool equals = true;
            bool assert1, assert2, assert3;
            for(int i = 0; i < competitors.Count; i++)
            {
                comp = competitors[i];
                assert1 = (comp.GetId() == idComp[i]);
                assert2 = (comp.GetPosition().GetLongitude() == longitude[i]);
                assert3 = (comp.GetPosition().GetLatitude() == latitude[i]);
                equals = equals && assert1 && assert2 && assert3;
            }
            Assert.IsTrue(equals);
        }

    }
}