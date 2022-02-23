using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PRace;
using Model;
namespace physic
{
    [TestClass]
    public class UnitTestPhysicCompression
    {
        [TestMethod]
        public void TestCompresseMoveOnLat()
        {
            RaceModel model = new RaceModel("physicTest.json");
            model.GetRace().GetEnvironment().UpdateCurrent(20, 90);
            model.GetRace().GetBoat().GetPosition().Update(0, 90);
            model.GetRace().nextIteration();
            model.GetRace().nextIteration();
            Position WithoutComp = model.GetRace().GetBoat().GetPosition();

            model = new RaceModel("physicTest.json");
            model.GetRace().GetEnvironment().UpdateCurrent(20, 90);
            model.GetRace().GetBoat().GetPosition().Update(0, 90);
            model.GetRace().setacceleratorFactor(2);
            model.GetRace().nextIteration();
            Position WithComp = model.GetRace().GetBoat().GetPosition();

            double NCLong, NCLat, CLong, CLat;
            NCLong = WithoutComp.GetLongitudeAngle();
            NCLat = WithoutComp.GetLatitudeAngle();
            CLong = WithComp.GetLongitudeAngle();
            CLat = WithComp.GetLatitudeAngle();

            bool test = true;
            double tolerance = 0.0000001;
            if (NCLong == double.NaN || NCLat == double.NaN || CLong == double.NaN || CLat == double.NaN)
            {
                test = false;
            }
            else if (NCLong - tolerance >= CLong || CLong >= NCLong + tolerance ||
                NCLat - tolerance >= CLat || CLat >= NCLat + tolerance)
            {
                test = false;
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestCompresseMoveOnLon()
        {
            RaceModel model = new RaceModel("physicTest.json");
            model.GetRace().GetEnvironment().UpdateCurrent(20, 0);
            model.GetRace().GetBoat().GetPosition().Update(0, 90);
            model.GetRace().nextIteration();
            model.GetRace().nextIteration();
            Position WithoutComp = model.GetRace().GetBoat().GetPosition();

            model = new RaceModel("physicTest.json");
            model.GetRace().GetEnvironment().UpdateCurrent(20, 0);
            model.GetRace().GetBoat().GetPosition().Update(0, 90);
            model.GetRace().setacceleratorFactor(2);
            model.GetRace().nextIteration();
            Position WithComp = model.GetRace().GetBoat().GetPosition();

            double NCLong, NCLat, CLong, CLat;
            NCLong = WithoutComp.GetLongitudeAngle();
            NCLat = WithoutComp.GetLatitudeAngle();
            CLong = WithComp.GetLongitudeAngle();
            CLat = WithComp.GetLatitudeAngle();

            bool test = true;
            double tolerance = 0.0000001;
            if (NCLong == double.NaN || NCLat == double.NaN || CLong == double.NaN || CLat == double.NaN)
            {
                test = false;
            }
            else if (NCLong - tolerance >= CLong || CLong >= NCLong + tolerance ||
                NCLat - tolerance >= CLat || CLat >= NCLat + tolerance)
            {
                test = false;
            }
            Assert.IsTrue(test);
        }
    }
}