using Microsoft.VisualStudio.TestTools.UnitTesting;
using Race;
namespace TestRace
{
    [TestClass]
    public class UnitTestWayPoint
    {
        [TestMethod]

        public void TestCreate()
        {
            WayPoint wp = new WayPoint(0, "test", 15.021F, 145.4F);
            Assert.AreEqual(wp.GetId(), 0);
            Assert.AreEqual(wp.Getnom(), "test");
            Assert.AreEqual(wp.GetPosition().GetLongitude(), 15.021F);
            Assert.AreEqual(wp.GetPosition().GetLatitude(), 145.4F);
        }

        [TestMethod]
        public void TestCreatePos()
        {
            Position pos = new Position(1854.15F, 194);
            WayPoint wp = new WayPoint(2, "", pos);
            Assert.AreEqual(wp.GetId(), 2);
            Assert.AreEqual(wp.Getnom(), "");
            Assert.AreEqual(wp.GetPosition().GetLongitude(), 1854.15F);
            Assert.AreEqual(wp.GetPosition().GetLatitude(), 194);
        }

        [TestMethod]
        public void TestUpdatePos()
        {
            WayPoint wp = new WayPoint(0, "test", 15.021F, 145.4F);
            Position pos = new Position(0, 0);
            wp.SetPosition(pos);
            Assert.AreEqual(wp.GetPosition().GetLongitude(), 0);
            Assert.AreEqual(wp.GetPosition().GetLatitude(), 0);

        }

        [TestMethod]
        public void TestUpdatePosLongLat()
        {
            WayPoint wp = new WayPoint(0, "test", 15.021F, 145.4F);
            wp.SetPosition(new Position(154,33));
            Assert.AreEqual(wp.GetPosition().GetLongitude(), 154);
            Assert.AreEqual(wp.GetPosition().GetLatitude(), 33);
        }

    }
}