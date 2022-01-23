using Microsoft.VisualStudio.TestTools.UnitTesting;
using Race;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestRace
{
    [TestClass]
    public class UnitTestPolaire
    {
        [TestMethod]
        public void TestGetSpeed()
        {
            Dictionary<float, Dictionary<float, float>> test = new Dictionary<float, Dictionary<float, float>>();
            Dictionary<float, float> test1 = new Dictionary<float, float>();
            Dictionary<float, float> test2 = new Dictionary<float, float>();
            test1.Add(10, 28);
            test1.Add(20, 47);
            test1.Add(30, 66);
            test1.Add(40, 95);
            test1.Add(50, 51);
            test2.Add(10, 49);
            test2.Add(20, 31);
            test2.Add(30, 37);
            test2.Add(40, 12);
            test2.Add(50, 67);
            test.Add(100, test1);
            test.Add(200, test2);
            Polaire pol = new Polaire(test);
            Assert.AreEqual(pol.getSpeed(0, 0), 28);
            Assert.AreEqual(pol.getSpeed(-1, 17), 47);
            Assert.AreEqual(pol.getSpeed(101, 60), 51);
            Assert.AreEqual(pol.getSpeed(150, 17), 31);
            Assert.AreEqual(pol.getSpeed(999, 999), 67);
            Assert.AreEqual(pol.getSpeed(150, 15), 31);
        }
    }
}