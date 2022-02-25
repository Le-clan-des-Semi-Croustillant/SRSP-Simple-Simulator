using Microsoft.VisualStudio.TestTools.UnitTesting;
using PRace;
using System;
namespace TestRace
{
    [TestClass]
    public class UnitTestClock
    {
        [TestMethod]
        public void TestDefaultIncrementTime()
        {
            Time time = new Time();
            Clock clock = new Clock(null, time);
            DateTime initDate =  clock.GetCurrentMoment();
            clock.IncrementTime();
            DateTime newDate = clock.GetCurrentMoment();
            double test = 1000;
            Assert.AreEqual((newDate - initDate).TotalMilliseconds, test);
        }

        [TestMethod]
        public void TestIncrementTimeSetCurrentTime()
        {
            Time time = new Time();
            Clock clock = new Clock(null, time);
            clock.SetCurrentMoment(DateTime.Now);
            DateTime initDate = clock.GetCurrentMoment();
            clock.IncrementTime();
            DateTime newDate = clock.GetCurrentMoment();
            double test = 1000;
            Assert.AreEqual((newDate - initDate).TotalMilliseconds, test);
        }

        [TestMethod]
        public void TestDefaultIncrementTimeSetTick()
        {
            Time time = new Time();
            Clock clock = new Clock(null, time);
            time.SetTick(50);
            clock.SetCurrentMoment(DateTime.Now);
            DateTime initDate = clock.GetCurrentMoment();
            clock.IncrementTime();
            DateTime newDate = clock.GetCurrentMoment();
            double test = 50;
            Assert.AreEqual((newDate - initDate).TotalMilliseconds, test);
        }
    }
}