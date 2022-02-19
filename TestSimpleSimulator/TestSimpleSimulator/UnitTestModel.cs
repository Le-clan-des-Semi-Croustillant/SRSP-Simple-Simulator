using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;
using System;

namespace TestModel
{
    [TestClass]
    public class UnitTestModel
    {
        [TestMethod]
        public void TestSetPolaire()
        {

            RaceModel model = new RaceModel(null);
            model.Save();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestBoatInfo()
        {
            RaceModel model = new RaceModel(null);
            var status = model.GetBoatStatus();

            float[] exp = { 0, 0, 0, 0, 0};

            bool test = true;
            float val;
            int i = 0;

            var infos = Enum.GetValues(typeof(BoatInfo));
            foreach (BoatInfo info in infos)
            {
                status.TryGetValue(info, out val);
                test = (test && (val == exp[i]));
                i++;
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestBoatInfo2()
        {
            RaceModel model = new RaceModel(null);
            model.GetRace().GetBoat().setPosition(new PRace.Position(42, 14));
            model.GetRace().GetBoat().setCap(75);
            var status = model.GetBoatStatus();
            float[] exp = { 42, 14, 75, 0, 0 };

            bool test = true;
            float val;
            int i = 0;

            var infos = Enum.GetValues(typeof(BoatInfo));
            foreach (BoatInfo info in infos)
            {
                status.TryGetValue(info, out val);
                test = (test && (val == exp[i]));
                i++;
            }
            Assert.IsTrue(test);
        }
    }
}