using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Domain;

namespace DomainTest
{
    [TestClass]
    public class SceneTests
    {
        [TestMethod]
        public void CreateSceneSuccessfully()
        {
            Image preview = null;
            Scene scene = new Scene()
            {
                Proprietary = new Client(),
                Name = "Scene",
                CreationDate = DateTime.Now,
                ModelList = new List<PositionedModel>(),
                LastModified = DateTime.Now,
                LastRendered = DateTime.Now,
                Preview = preview

            };
            Assert.IsNotNull(scene);
        }

        [TestMethod]
        public void AddPositionedModelToScene()
        {
            Image preview = null;
            Scene scene = new Scene()
            {
                Proprietary = new Client(),
                Name = "Scene",
                CreationDate = DateTime.Now,
                ModelList = new List<PositionedModel>(),
                LastModified = DateTime.Now,
                LastRendered = DateTime.Now,
                Preview = preview
            };
            Model testModel = new Model();
            Vector testPosition = new Vector();
            scene.AddPositionedModel(testModel, testPosition);
            Assert.IsTrue(scene.ModelList.Count > 0);

        }

        [TestMethod]
        public void DeletePositionedModelFromScene()
        {
            Image preview = null;
            Scene scene = new Scene()
            {
                Proprietary = new Client(),
                Name = "Scene",
                CreationDate = DateTime.Now,
                ModelList = new List<PositionedModel>(),
                LastModified = DateTime.Now,
                LastRendered = DateTime.Now,
                Preview = preview
            };
            Model testModel = new Model { Name = "model", Proprietary = new Client { Username = "John" } };

            Vector position = new Vector { X = 0, Y = 0, Z = 0 };
            PositionedModel testPositionedModel = new PositionedModel
            {
                Model = testModel,
                Position = position
            };
            scene.AddPositionedModel(testModel, position);

            scene.RemovePositionedModel(testPositionedModel);
            Assert.IsTrue(scene.ModelList.Count == 0);
        }

        [TestMethod]
        public void ChangeCameraSettings()
        {
            Image preview = null;
            Scene scene = new Scene()
            {
                Proprietary = new Client(),
                Name = "Scene",
                CreationDate = DateTime.Now,
                ModelList = new List<PositionedModel>(),
                LastModified = DateTime.Now,
                LastRendered = DateTime.Now,
                Preview = preview
            };
            Vector lookFrom = new Vector { X = 2, Y = 2, Z = 2 };
            Vector lookAt = new Vector { X = 3, Y = 3, Z = 3 };
            int fov = 45;
            double aperture = 1;
            scene.UpdateCameraSettings(lookFrom, lookAt, fov, aperture);
            Assert.IsTrue(scene.CameraLookFrom.X == lookFrom.X &&
                          scene.CameraLookFrom.Y == lookFrom.Y &&
                          scene.CameraLookFrom.Z == lookFrom.Z
                          && scene.CameraLookAt.X == lookAt.X
                          && scene.CameraLookAt.Y == lookAt.Y
                          && scene.CameraLookAt.Z == lookAt.Z
                          && scene.CameraFov == fov
                          && scene.CameraAperture == aperture);
        }
        [TestMethod]
        public void SavePreviewAsPpmOk(){
            Bitmap preview = new Bitmap(1, 1);
            preview.SetPixel(0, 0, Color.FromArgb(255, 255, 255));
            Scene scene = new Scene()
            {
                Proprietary = new Client(),
                Name = "Scene",
                CreationDate = DateTime.Now,
                ModelList = new List<PositionedModel>(),
                LastModified = DateTime.Now,
                LastRendered = DateTime.Now,
                Preview = preview
            };
            scene.SavePreviewAsPpm("test.ppm");
            Assert.IsTrue(File.Exists("test.ppm"));
            string ppmExpectedString = "P3\n1 1\n255\n255 255 255 \n";
            string ppmActualString= File.ReadAllText("test.ppm");
            Assert.AreEqual(ppmExpectedString, ppmActualString);
            File.Delete("test.ppm");
        }
}
}
