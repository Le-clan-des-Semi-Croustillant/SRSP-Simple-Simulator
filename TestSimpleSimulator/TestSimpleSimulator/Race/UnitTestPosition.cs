using Microsoft.VisualStudio.TestTools.UnitTesting;
using PRace;
namespace TestRace
{
    [TestClass]
    public class UnitTestPosition
    {
        [TestMethod]

        public void TestCreate()
        {
            var pos = new Position(1854.15F,194);
            Assert.AreEqual(pos.GetLongitude(), 1854.15F);
            Assert.AreEqual(pos.GetLatitude(), 194);
        }

        [TestMethod]
        public void TestUpdate()
        {

            var pos = new Position(0, 0);
            pos.Update(1854.15F, 194);
            Assert.AreEqual(pos.GetLongitude(), 1854.15F);
            Assert.AreEqual(pos.GetLatitude(), 194);
        }

    }
}