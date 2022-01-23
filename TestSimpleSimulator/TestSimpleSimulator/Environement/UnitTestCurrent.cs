using Microsoft.VisualStudio.TestTools.UnitTesting;
using Environement;
namespace TestEnvironement
{
    [TestClass]
    public class UnitTestPosition
    {
        [TestMethod]

        public void TestCreate()
        {
            var current = new Current();
            Assert.AreEqual(current.GetCurrentSpeed(), 0);
            Assert.AreEqual(current.GetCurrentDirection(), 0);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var current = new Current();
            current.Update(1, 1);
            Assert.AreEqual(current.GetCurrentSpeed(), 1);
            Assert.AreEqual(current.GetCurrentDirection(), 1);
        }

    }
}