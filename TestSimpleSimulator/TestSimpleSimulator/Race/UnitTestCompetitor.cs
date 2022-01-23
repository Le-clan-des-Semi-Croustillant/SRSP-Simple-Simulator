using Microsoft.VisualStudio.TestTools.UnitTesting;
using Race;
namespace TestRace
{
    [TestClass]
    public class UnitTestCompetitor
    {
        [TestMethod]

        public void TestCreate()
        {
            Competitor comp = new Competitor(1);
            Assert.AreEqual(comp.GetPosition().GetLongitude(), 0);
            Assert.AreEqual(comp.GetPosition().GetLatitude(), 0);
            Assert.AreEqual(comp.GetId(), 1);
        }

        [TestMethod]

        public void TestCreatePos()
        {
            Position pos = new Position(1854.15F, 194);
            Competitor comp = new Competitor(1, pos);
            Assert.AreEqual(comp.GetPosition().GetLongitude(), 1854.15F);
            Assert.AreEqual(comp.GetPosition().GetLatitude(), 194);
            Assert.AreEqual(comp.GetId(), 1);
        }

        [TestMethod]
        public void TestUpdate()
        {
            Competitor comp = new Competitor(1);
            Position pos = new Position(1854.15F, 194);
            comp.SetPosition(pos);
            Assert.AreEqual(comp.GetPosition().GetLongitude(), 1854.15F);
            Assert.AreEqual(comp.GetPosition().GetLatitude(), 194);
            Assert.AreEqual(comp.GetId(), 1);
        }
    }
}