using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Policy;
using Domain;

namespace DomainTest
{
    [TestClass]
    public class CameraTests
    {
        [TestMethod]
        public void CreateCameraSuccessfully()
        {
            Camera camera = new Camera()
            {
                LookFrom = new Vector{X=0,Y=0,Z=0},
                LookAt = new Vector { X = 0, Y = 0, Z = 0 },
                FieldOfView = 1,

            };
            Assert.IsNotNull(camera);
        }

        [TestMethod]
        public void GetRayFromCameraSuccessfully()
        {
            Camera testCamera = new Camera
            (
                aspectRatio:  600 / 600,
                fieldOfView:  40,
                lookAt: new Vector { X = 0, Y = 0.5m, Z = -2 },
                lookFrom: new Vector { X = 4, Y = 2, Z = 8 },
                up: new Vector { X = 0, Y = 1, Z = 0 }
            );
            int fiveDecimals= 100000;
            Ray testRay = testCamera.GetRay(1, 1);
            Assert.AreEqual(4m, testRay.Origin.X);
            Assert.AreEqual(2m, testRay.Origin.Y);
            Assert.AreEqual(8m, testRay.Origin.Z);
            Assert.AreEqual(-0.04854m, Math.Truncate(testRay.Direction.X*fiveDecimals)/fiveDecimals);
            Assert.AreEqual(0.22255m, Math.Truncate(testRay.Direction.Y*fiveDecimals)/fiveDecimals);
            Assert.AreEqual(-1.10139m, Math.Truncate(testRay.Direction.Z * fiveDecimals) / fiveDecimals);

        }

    }
}
