using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;

namespace DomainTest
{
    [TestClass]
    public class CameraTests
    {
        [TestMethod]
        public void CreateCameraSuccessfully()
        {
            Camera camera = new NoDefocusCamera()
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
            Camera testCamera = new NoDefocusCamera
            {
                LookFrom = new Vector { X = 4, Y = 2, Z = 8 },
                LookAt = new Vector { X = 0, Y = 0.5m, Z = -2 },
                FieldOfView = 40,
                AspectRatio = 600 / 600,
            };

            int fiveDecimals= 100000;
            Ray testRay = testCamera.GetRay(1, 1);
            Assert.AreEqual(4m, testRay.Origin.X);
            Assert.AreEqual(2m, testRay.Origin.Y);
            Assert.AreEqual(8m, testRay.Origin.Z);
            Assert.AreEqual(-0.04854m, Math.Truncate(testRay.Direction.X*fiveDecimals)/fiveDecimals);
            Assert.AreEqual(0.22255m, Math.Truncate(testRay.Direction.Y*fiveDecimals)/fiveDecimals);
            Assert.AreEqual(-1.10139m, Math.Truncate(testRay.Direction.Z * fiveDecimals) / fiveDecimals);

        }
        [TestMethod]
        public void GetRayFromDefocusCameraSuccessfully()
        {
            Camera testCamera = new DefocusCamera
            {
                LookFrom = new Vector { X = 4, Y = 2, Z = 8 },
                LookAt = new Vector { X = 0, Y = 1m, Z = -2 },
                FieldOfView = 30,
                AspectRatio = 75d / 50d,
                Aperture = 0.5,
                RandomGenerator = new Random(456)
            };

            int fiveDecimals = 100000;
            Ray testRay = testCamera.GetRay(1, 1);
            Assert.AreEqual(4.20792m, Math.Truncate(testRay.Origin.X * fiveDecimals)/fiveDecimals);
            Assert.AreEqual(2.05785m, Math.Truncate(testRay.Origin.Y* fiveDecimals)/fiveDecimals);
            Assert.AreEqual(7.91104m, Math.Truncate(testRay.Origin.Z * fiveDecimals) / fiveDecimals);
            Assert.AreEqual(-0.27091m, Math.Truncate(testRay.Direction.X * fiveDecimals) / fiveDecimals);
            Assert.AreEqual(1.82804m, Math.Truncate(testRay.Direction.Y * fiveDecimals) / fiveDecimals);
            Assert.AreEqual(-11.77443m, Math.Truncate(testRay.Direction.Z * fiveDecimals) / fiveDecimals);

        }

    }
}
