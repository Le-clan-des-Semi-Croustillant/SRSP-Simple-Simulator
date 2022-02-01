using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
namespace TestModel
{
    [TestClass]
    public class UnitTestModel
    {
        
        [TestMethod]
        public void TestSaveAndReload()
        {
            RaceModel model = new RaceModel();
            model.Save();
            RaceModel model2 = new RaceModel("./test.json");
            model2.Load();

        }

        
    }
}