using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;
using System;
using PRace;

namespace physic
{
    [TestClass]
    public class UnitTestPhysicValue
    {
        Position Cu0 = new Position(0,0);
        Position Cu45Cap0 = new Position(0, 0);
        Position Cu45Cap45 = new Position(0, 0);
        Position Cu90 = new Position(0, 0);
        Position Cu0Wi0 = new Position(0, 0);
        Position Cu45Wi45 = new Position(0, 0);
        Position Cu90Wi45 = new Position(0, 0);



        [TestInitialize]
        public void init()
        {
            
        }

        [TestMethod]
        public void TestSetMoveCu0()
        {
            RaceModel model = new RaceModel("physicTest.json");
            model.GetRace().GetEnvironment().UpdateCurrent(20, 0);
            model.GetRace().GetBoat().GetPosition().Update(0, 90);
            model.GetRace().nextIteration();
            Cu0 = model.GetRace().GetBoat().GetPosition();

            bool test = true;
            double tolerance = 0.000000001;
            double lon = Cu0.GetLongitudeAngle();
            double lat = Cu0.GetLatitudeAngle();
            double expectLon = 0.0 / 360 * 2 * MathF.PI;
            double expectLat = 90.00017986431811 / 360 * 2 * MathF.PI;
            if (lat == double.NaN || lon == double.NaN)
            {
                test = false;
            }
            else if (expectLon - tolerance >= lon || lon >= expectLon + tolerance ||
                expectLat - tolerance >= lat || lat >= expectLat + tolerance)
            {
                test = false;
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestSetMoveCu45Cap0()
        {
            RaceModel model = new RaceModel("physicTest.json");
            model.GetRace().GetEnvironment().UpdateCurrent(20, 45);
            model.GetRace().GetBoat().GetPosition().Update(0, 90);
            model.GetRace().nextIteration();
            Cu45Cap0 = model.GetRace().GetBoat().GetPosition(); 
            bool test = true;
            double tolerance = 0.000000001;
            double lon = Cu45Cap0.GetLongitudeAngle();
            double lat = Cu45Cap0.GetLatitudeAngle();
            double expectLon = 0.00012718327763084573 / 360 * 2 * MathF.PI;
            double expectLat = 90.00019283374081 / 360 * 2 * MathF.PI; 
            if (lat == double.NaN || lon == double.NaN)
            {
                test = false;
            }
            else if (expectLon - tolerance >= lon || lon >= expectLon + tolerance ||
                expectLat - tolerance >= lat || lat >= expectLat + tolerance)
            {
                test = false;
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestSetMoveCu45Cap45()
        {
            RaceModel model = new RaceModel("physicTest.json");
            model.GetRace().GetEnvironment().UpdateCurrent(20, 45);
            model.GetRace().GetBoat().GetPosition().Update(0, 90);
            model.GetRace().GetBoat().setCap(45);
            model.GetRace().nextIteration();
            Cu45Cap45 = model.GetRace().GetBoat().GetPosition(); 
            bool test = true;
            double tolerance = 0.000000001;
            double lon = Cu45Cap45.GetLongitudeAngle();
            double lat = Cu45Cap45.GetLatitudeAngle();
            double expectLon = 0.00018441574570344713 / 360 * 2 * MathF.PI;
            double expectLat = 90.00018441574082 / 360 * 2 * MathF.PI;
            if (lat == double.NaN || lon == double.NaN)
            {
                test = false;
            }
            else if (expectLon - tolerance >= lon || lon >= expectLon + tolerance ||
                expectLat - tolerance >= lat || lat >= expectLat + tolerance)
            {
                test = false;
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestSetMoveCu90()
        {
            RaceModel model = new RaceModel("physicTest.json");
            model.GetRace().GetEnvironment().UpdateCurrent(20, 90);
            model.GetRace().GetBoat().GetPosition().Update(0, 90);
            model.GetRace().nextIteration();
            Cu90 = model.GetRace().GetBoat().GetPosition(); 
            bool test = true;
            double tolerance = 0.00001;
            double lon = Cu90.GetLongitudeAngle();
            double lat = Cu90.GetLatitudeAngle();
            double expectLon = 0.00017986431617856568 / 360 * 2 * MathF.PI;
            double expectLat = 90.0 / 360 * 2 * MathF.PI;
            if (lat == double.NaN || lon == double.NaN)
            {
                test = false;
            }
            else if (expectLon - tolerance >= lon || lon >= expectLon + tolerance ||
                expectLat - tolerance >= lat || lat >= expectLat + tolerance)
            {
                test = false;
            }
            Console.WriteLine(lon);
            Console.WriteLine(expectLon);
            Console.WriteLine(lat);
            Console.WriteLine(expectLat);
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestSetMoveCu0Wi0()
        {
            RaceModel model = new RaceModel("physicTest.json");
            model.GetRace().GetEnvironment().UpdateCurrent(20, 0);
            model.GetRace().GetEnvironment().UpdateWind(60, 0);
            model.GetRace().GetBoat().GetPosition().Update(0, 90);
            model.GetRace().nextIteration();
            Cu0Wi0 = model.GetRace().GetBoat().GetPosition(); 
            bool test = true;
            double tolerance = 0.000000001;
            double lon = Cu0Wi0.GetLongitudeAngle();
            double lat = Cu0Wi0.GetLatitudeAngle();
            double expectLon = 0.0 / 360 * 2 * MathF.PI;
            double expectLat = 90.00030846730508 / 360 * 2 * MathF.PI;
            if (lat == double.NaN || lon == double.NaN)
            {
                test = false;
            }
            else if (expectLon - tolerance >= lon || lon >= expectLon + tolerance ||
                expectLat - tolerance >= lat || lat >= expectLat + tolerance)
            {
                test = false;
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestSetMoveCu45Wi45()
        {
            RaceModel model = new RaceModel("physicTest.json");
            model.GetRace().GetEnvironment().UpdateCurrent(20, 45);
            model.GetRace().GetEnvironment().UpdateWind(60, 45);
            model.GetRace().GetBoat().GetPosition().Update(0, 90);
            model.GetRace().nextIteration();
            Cu45Wi45 = model.GetRace().GetBoat().GetPosition(); 
            bool test = true;
            double tolerance = 0.000000001;
            double lon = Cu45Wi45.GetLongitudeAngle();
            double lat = Cu45Wi45.GetLatitudeAngle();
            double expectLon = 0.00012718327763084573 / 360 * 2 * MathF.PI;
            double expectLat = 90.00026208150902 / 360 * 2 * MathF.PI;
            if (lat == double.NaN || lon == double.NaN)
            {
                test = false;
            }
            else if (expectLon - tolerance >= lon || lon >= expectLon + tolerance ||
                expectLat - tolerance >= lat || lat >= expectLat + tolerance)
            {
                test = false;
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestSetMoveCu90Wi45()
        {
            RaceModel model = new RaceModel("physicTest.json");
            model.GetRace().GetEnvironment().UpdateCurrent(20, 90);
            model.GetRace().GetEnvironment().UpdateWind(60, 45);
            model.GetRace().GetBoat().GetPosition().Update(0, 90);
            model.GetRace().nextIteration();
            Cu90Wi45 = model.GetRace().GetBoat().GetPosition(); 
            bool test = true;
            double tolerance = 0.000000001;
            double lon = Cu90Wi45.GetLongitudeAngle();
            double lat = Cu90Wi45.GetLatitudeAngle();
            double expectLon = 0.00017986431617856568 / 360 * 2 * MathF.PI;
            double expectLat = 90.00009532807975 / 360 * 2 * MathF.PI;
            if (lat == double.NaN || lon == double.NaN)
            {
                test = false;
            }
            else if (expectLon - tolerance >= lon || lon >= expectLon + tolerance ||
                expectLat - tolerance >= lat || lat >= expectLat + tolerance)
            {
                test = false;
            }
            Assert.IsTrue(test);
        }
    }
}