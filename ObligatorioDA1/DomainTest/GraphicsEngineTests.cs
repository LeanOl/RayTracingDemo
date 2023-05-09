using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        [TestMethod]
        public void ObtainColorSuccessfully()
        {
            Material aLamberitan = new Lambertian { Color = Color.FromArgb(25, 51, 127) };
            Figure aSphere = new Sphere { Radius = 0.5m};
            Model aModel=new Model { Figure=aSphere,Material=aLamberitan};
            PositionedModel aPositionedModel=new PositionedModel { Model=aModel,Position=new Vector { X=0,Y=0.5m,Z=-2}};
            List<PositionedModel> elements = new List<PositionedModel>
            {
                aPositionedModel
            };
            GraphicsEngine engine = new GraphicsEngine();
            Ray ray = new Ray{Origin=new Vector{X=4,Y=2,Z=8},Direction=new Vector{X=-0.37470m,Y=-0.09534m,Z=-0.92324m}};

            Color color = engine.ObtainColor(ray,2,elements);
            Assert.IsNotNull(color);
            int tolerance=5;
            Assert.IsTrue(Math.Abs(color.R - 13) < tolerance);
            Assert.IsTrue(Math.Abs(color.G - 36) < tolerance);
            Assert.IsTrue(Math.Abs(color.B - 127) < tolerance);
        }
        

    }
}
