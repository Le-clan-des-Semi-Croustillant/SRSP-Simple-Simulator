using Microsoft.VisualStudio.TestTools.UnitTesting;
using Race;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestRace
{
    [TestClass]
    public class UnitTestBoat
    {
        [TestMethod]
        public void TestSetPolaire()
        {
            Dictionary<float, Dictionary<float, float>> test = new Dictionary<float, Dictionary<float, float>>();
            Polaire pol1 = new Polaire("Pol1", test);
            Polaire pol2 = new Polaire("Pol2", test);
            Polaire pol3 = new Polaire("Pol3", test);
            Polaire pol = new Polaire("", test);
            List<Polaire> listpolaire = new List<Polaire>();
            listpolaire.Add(pol);
            listpolaire.Add(pol1);
            listpolaire.Add(pol2);
            listpolaire.Add(pol3);
            Position pos = new Position(12, 15);
            MyBoat boat = new MyBoat(12, listpolaire, pos);
            boat.SetPolaire("");
            Assert.AreEqual(boat.getcurrentPolaire().getName(), "");
            boat.SetPolaire("Pol1");
            Assert.AreEqual(boat.getcurrentPolaire().getName(), "Pol1");
            boat.SetPolaire("Pol2");
            Assert.AreEqual(boat.getcurrentPolaire().getName(), "Pol2");
            boat.SetPolaire("Pol3");
            Assert.AreEqual(boat.getcurrentPolaire().getName(), "Pol3");
            boat.SetPolaire("");
            Assert.AreEqual(boat.getcurrentPolaire().getName(), "");
        }

        [TestMethod]
        public void TestIncrementerCap()
        {
            Dictionary<float, Dictionary<float, float>> test = new Dictionary<float, Dictionary<float, float>>();
            Polaire pol = new Polaire("", test);
            Polaire pol1 = new Polaire("Pol1", test);
            List<Polaire> listpolaire = new List<Polaire>();
            listpolaire.Add(pol);
            listpolaire.Add(pol1);
            Position pos = new Position(12, 15);
            MyBoat boat = new MyBoat(12, listpolaire, pos);
            Assert.AreEqual(boat.getCap(), 0);
            boat.IncrementerCap(ModeCommande.cap, DegreeIncrement.One);
            Assert.AreEqual(boat.getCap(), 1);
            boat.IncrementerCap(ModeCommande.cap, DegreeIncrement.MinusTen);
            Assert.AreEqual(boat.getCap(), -9);
            boat.IncrementerCap(ModeCommande.cap, DegreeIncrement.MinusOne);
            Assert.AreEqual(boat.getCap(), -10);
            boat.IncrementerCap(ModeCommande.cap, DegreeIncrement.Ten);
            Assert.AreEqual(boat.getCap(), 0);
            boat.IncrementerCap(ModeCommande.RegulateurAmure, DegreeIncrement.Ten);
            Assert.AreEqual(boat.GetCapRegulateurAmure(), 10);
        }
    }
}