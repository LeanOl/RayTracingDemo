using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;

namespace DomainTest
{
    [TestClass]
    public class GraphicsEngineTests
    {
        [TestMethod]
        public void CreateGraphicsEngineDefaultValuesOk()
        {
            GraphicsEngine engine = new GraphicsEngine();
            Assert.IsNotNull(engine);
            Assert.AreEqual(200, engine.Resolution);
            Assert.AreEqual(50, engine.SamplesPerPixel);
            Assert.AreEqual(20,engine.MaxDepth);
        }
    }
}
