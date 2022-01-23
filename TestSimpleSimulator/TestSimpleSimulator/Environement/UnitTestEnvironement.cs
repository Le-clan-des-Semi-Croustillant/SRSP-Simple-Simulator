using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Environement;
namespace TestEnvironement
{
    [TestClass]
    public class UnitTestEnvironment
    {

        [TestMethod]

        public void TestCreate()
        {
            var env = new Environement.Environment();
            Dictionary<Conditions, float> envState = new Dictionary<Conditions, float>();

            var conds = Enum.GetValues(typeof(Conditions));
            float value;
            foreach (Conditions cond in conds)
            {
                envState.TryGetValue(cond, out value);
                Assert.AreEqual(value, 0);
            }
        }

        [TestMethod]
        public void TestUpdateCurrent()
        {
            var env = new Environement.Environment();
            env.UpdateCurrent(17, 24.9F);
            var envState = env.getEnvState();
            float[] exp = { 0, 0, 24.9F, 17, 0, 0, 0 };

            bool test = true;
            float val;
            int i = 0;

            var conds = Enum.GetValues(typeof(Conditions));
            foreach (Conditions cond in conds)
            {
                envState.TryGetValue(cond, out val);
                test = (test && (val == exp[i]));
                i++;
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestUpdateWave()
        {
            var env = new Environement.Environment();
            env.UpdateWave(24.9F, 17, 19);
            var envState = env.getEnvState();
            float[] exp = { 0, 0, 0, 0, 24.9F, 17, 19 };

            bool test = true;
            float val;
            int i = 0;

            var conds = Enum.GetValues(typeof(Conditions));
            foreach (Conditions cond in conds)
            {
                envState.TryGetValue(cond, out val);
                test = (test && (val == exp[i]));
                i++;
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestUpdateWind()
        {
            var env = new Environement.Environment();
            env.UpdateWind(17, 24.9F);
            var envState = env.getEnvState();
            float[] exp = { 17, 24.9F, 0, 0, 0, 0, 0};

            bool test = true;
            float val;
            int i = 0;

            var conds = Enum.GetValues(typeof(Conditions));
            foreach (Conditions cond in conds)
            {
                envState.TryGetValue(cond, out val);
                test = (test && (val == exp[i]));
                i++;
            }
            Assert.IsTrue(test);
        }

    }
}