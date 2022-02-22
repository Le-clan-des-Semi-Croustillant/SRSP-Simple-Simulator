using Microsoft.VisualStudio.TestTools.UnitTesting;
using Environement;
namespace TestEnvironement
{
    [TestClass]
    public class UnitTestWind
    {
        [TestMethod]

        public void TestCreate()
        {
            var wind = new Wind();
            Assert.AreEqual(wind.GetWindDirection(), 0);
            Assert.AreEqual(wind.GetWindSpeed(), 0);
        }
    }
}