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
            Assert.AreEqual(300, engine.Resolution);
            Assert.AreEqual(50, engine.SamplesPerPixel);
            Assert.AreEqual(20,engine.MaxDepth);
        }

        [TestMethod]
        public void GraphicsEngineResolutionLessThan1_Exception()
        {
            GraphicsEngine engine = new GraphicsEngine();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => engine.Resolution = 0);
        }
        [TestMethod]
        public void GraphicsEngineSamplesPerPixelLessThan1_Exception()
        {
            GraphicsEngine engine = new GraphicsEngine();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => engine.SamplesPerPixel = 0);
        }

        [TestMethod]
        public void GraphicsEngineMaxDepthLessThan1_Exception()
        {
            GraphicsEngine engine = new GraphicsEngine();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => engine.MaxDepth = 0);
        }
        
    }
}
