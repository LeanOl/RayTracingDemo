using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;

namespace DomainTest
{
    [TestClass]
    public class RayTests
    {
        [TestMethod]
        public void CreateRayObjectSuccessfully()
        {
            Ray testRay = new Ray
            {
                Origin = new Vector { X = 1, Y = 2, Z = 3 },
                Direction = new Vector { X = 4, Y = 5, Z = 6 }
            };
            Assert.IsNotNull(testRay);
            Assert.AreEqual(1, testRay.Origin.X);
            Assert.AreEqual(2, testRay.Origin.Y);
            Assert.AreEqual(3, testRay.Origin.Z);
            Assert.AreEqual(4, testRay.Direction.X);
            Assert.AreEqual(5, testRay.Direction.Y);
            Assert.AreEqual(6, testRay.Direction.Z);

        }
    }
}
