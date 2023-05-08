using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace DomainLogicTest
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

        [TestMethod]
        public void SphereHitReturnHitRecord()
        {
            Sphere aSphere = new Sphere()
            {
                Propietary = someClient,
                Name = validName,
                Radius = validRadius
            };
            Ray aRay = new Ray()
            {
                Origin = new Vector { X = 0, Y = 0, Z = 0 },
                Direction = new Vector { X = 1, Y = 1, Z = 1 }
            };
            Vector center = new Vector { X = 1, Y = 1, Z = 1 };
            HitRecord hit = aSphere.Hit(aRay, 0, 5, center);
            Assert.IsNotNull(hit);

        }
    }
}
