using Microsoft.VisualStudio.TestTools.UnitTesting;
using Environement;
namespace TestEnvironement
{
    [TestClass]
    public class UnitTestWave
    {
        [TestMethod]
        public void TestCreate()
        {
            var wave = new Wave();
            Assert.AreEqual(wave.GetDirection(), 0);
            Assert.AreEqual(wave.GetAmplitude(), 0);
            Assert.AreEqual(wave.GetWaveLength(), 0);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var wave = new Wave();
            wave.Update(1, 2, -1);
            Assert.AreEqual(wave.GetDirection(), 1);
            Assert.AreEqual(wave.GetAmplitude(), 2);
            Assert.AreEqual(wave.GetWaveLength(), -1);
        }
    }
}