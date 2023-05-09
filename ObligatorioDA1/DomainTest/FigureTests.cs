using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace LogicTest
{
    [TestClass]

    public class FigureTests
    {
        private Client someClient;
        private const string validName = "Ball";
        private const int validRadius = 10;
        private const string someUsername = "Pepito";

        [TestInitialize]
        public void TestInit()
        {            
            someClient = new Client()
            {
                Username = someUsername
            };
        }

        [TestMethod]
        public void CreateSphereObjectSuccesfully()
        {
            Sphere aSphere = new Sphere()
            {
                Propietary = someClient,
                Name = validName,
                Radius = validRadius
            };

            Assert.IsNotNull(aSphere);
            Assert.AreEqual(someClient, aSphere.Propietary);
            Assert.AreEqual(validName, aSphere.Name);
            Assert.AreEqual(validRadius, aSphere.Radius);
        }
    }
}
