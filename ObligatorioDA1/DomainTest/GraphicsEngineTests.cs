using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using Domain.Utilities;
using System.IO;
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
            int tolerance=10;
            Assert.IsTrue(Math.Abs(color.R - 13) < tolerance);
            Assert.IsTrue(Math.Abs(color.G - 36) < tolerance);
            Assert.IsTrue(Math.Abs(color.B - 127) < tolerance);
        }

        [TestMethod]
        public void RenderModelSuccessfully()
        {
            Figure testSphere = new Sphere { Radius = 0.5m };
            Material testLambertian = new Lambertian { Color = Color.FromArgb(25, 51, 127) };
            Model testModel = new Model { Figure = testSphere, Material = testLambertian };
            PositionedModel testPositionedModel = new PositionedModel { Model = testModel, Position = new Vector { X = 0, Y = 0.5m, Z = -2 } };
            GraphicsEngine engine = new GraphicsEngine
            {
                MaxDepth = 25,
                Resolution=75,
                SamplesPerPixel=10
            };
            string reneredPpm = engine.RenderModel(testPositionedModel);
            
            Bitmap bitmap = Domain.Utilities.ImageConverter.PpmToBitmap(reneredPpm);
            Assert.IsNotNull(bitmap);
        }
       

        [TestMethod]
        public void RenderSceneSuccessfully()
        {

            Material aLamberitan = new Lambertian { Color = Color.FromArgb(178, 178, 25) };
            Figure aSphere = new Sphere { Radius = 2000 };
            Model aModel = new Model { Figure = aSphere, Material = aLamberitan };
            PositionedModel aPositionedModel = new PositionedModel { Model = aModel, Position = new Vector { X = 0, Y = -2000m, Z = -1 } };
            List<PositionedModel> elements = new List<PositionedModel>
            {
                aPositionedModel
            };
            Camera testCamera = new NoDefocusCamera();
            Scene testScene= new Scene { ModelList= elements,ActiveCamera = testCamera};
            
            GraphicsEngine engine = new GraphicsEngine{MaxDepth = 3,Resolution = 45,SamplesPerPixel = 10};
            string renderedPpm = engine.RenderScene(testScene);
            Bitmap bitmap = Domain.Utilities.ImageConverter.PpmToBitmap(renderedPpm);
            Bitmap expectedBitmap = PpmToBitmap("resources/expectedPpm.ppm");
            double acceptedDifference=300;
            Assert.IsTrue(BitmapCompare(bitmap, expectedBitmap) < acceptedDifference); ;
        }
        [TestMethod]
        public void RenderMetallicMaterial()
        {
            
            Material aLamberitan = new Lambertian { Color = Color.FromArgb(178, 178, 25) };
            Figure aSphere = new Sphere { Radius = 2000 };
            Model aModel = new Model { Figure = aSphere, Material = aLamberitan };
            PositionedModel aPositionedModel = new PositionedModel { Model = aModel, Position = new Vector { X = 0, Y = -2000m, Z = -1 } };

            Material aMetallic = new Metallic { Color = Color.FromArgb(25, 51, 127), Roughness= 0.0m };
            Figure aSphere1 = new Sphere { Radius = 1.15m };
            Model aModel1 = new Model { Figure = aSphere1, Material = aMetallic };
            PositionedModel aPositionedModel1 = new PositionedModel { Model = aModel1, Position = new Vector { X = 0, Y = 2, Z = 5 } };

            List<PositionedModel> elements = new List<PositionedModel>
            {
                aPositionedModel,
                aPositionedModel1
                
            };
            Camera testCamera = new NoDefocusCamera();
            Scene testScene = new Scene { ModelList = elements, ActiveCamera = testCamera };

            GraphicsEngine engine = new GraphicsEngine { MaxDepth = 50, Resolution = 45, SamplesPerPixel = 20 };
            string renderedPpm = engine.RenderScene(testScene);
            Bitmap bitmap = Domain.Utilities.ImageConverter.PpmToBitmap(renderedPpm);
            Bitmap expectedBitmap = PpmToBitmap("resources/expectedPpmMetallic.ppm");
            double acceptedDifference = 300;
            Assert.IsTrue(BitmapCompare(bitmap, expectedBitmap) < acceptedDifference); ;
        }

        double BitmapCompare(Bitmap bmp1, Bitmap bmp2)
            {
                if (bmp1.Width != bmp2.Width || bmp1.Height != bmp2.Height)
                    throw new ArgumentException("Bitmaps are not of equal dimensions.");

                double mse = 0;
                for (int i = 0; i < bmp1.Width; i++)
                {
                    for (int j = 0; j < bmp1.Height; j++)
                    {
                        Color pixel1 = bmp1.GetPixel(i, j);
                        Color pixel2 = bmp2.GetPixel(i, j);

                        mse += Math.Pow(pixel1.R - pixel2.R, 2);
                        mse += Math.Pow(pixel1.G - pixel2.G, 2);
                        mse += Math.Pow(pixel1.B - pixel2.B, 2);
                    }
                }

                mse /= (bmp1.Width * bmp1.Height * 3);
                return mse;
        }
        Bitmap PpmToBitmap(string ppm)
        {
            using (var reader = new StreamReader(ppm))
            {

                string magicNumber = reader.ReadLine();

                string size = reader.ReadLine();
                string maxColorValue = reader.ReadLine();


                string[] sizeParts = size.Split(' ');
                int width = int.Parse(sizeParts[0]);
                int height = int.Parse(sizeParts[1]);


                Bitmap bitmap = new Bitmap(width, height);


                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        string pixelColor = reader.ReadLine();
                        string[] pixelColorParts = pixelColor.Split(' ');
                        int r = int.Parse(pixelColorParts[0]);
                        int g = int.Parse(pixelColorParts[1]);
                        int b = int.Parse(pixelColorParts[2]);


                        bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                return bitmap;
            }

        }
    }
    





}
