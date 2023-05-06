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
            Camera camera = new Camera()
            {
                LookFrom = new Vector(),
                LookAt = new Vector(),
                Up = new Vector(),
                FieldOfView = 1,
                AspectRatio = 1
            };
            Assert.IsNotNull(camera);
        }
    }
}
