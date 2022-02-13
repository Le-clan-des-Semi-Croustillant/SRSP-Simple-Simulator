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
            System.Threading.Thread.Sleep(1000);
            model.Save();
            Assert.IsTrue(true);
        }
    }
}