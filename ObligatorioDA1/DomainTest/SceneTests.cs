using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                ModelList= new List<PositionedModel>(),
                Camera = new Camera(),
                LastModified= DateTime.Now,
                LastRendered= DateTime.Now,
                Preview= preview
                
            };
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
                Camera = new Camera(),
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
                Camera = new Camera(),
                LastModified = DateTime.Now,
                LastRendered = DateTime.Now,
                Preview = preview
            };
            Model testModel = new Model{Name = "model",Proprietary = new Client{Username="John"} };
            
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
                Camera = new Camera(),
                LastModified = DateTime.Now,
                LastRendered = DateTime.Now,
                Preview = preview
            };
            Vector lookFrom = new Vector { X = 2, Y = 2, Z = 2 };
            Vector lookAt = new Vector { X = 3, Y = 3, Z = 3 };
            int fov = 45;
            scene.UpdateCameraSettings(lookFrom, lookAt,fov);
            Assert.IsTrue(scene.Camera.LookFrom.X == lookFrom.X && 
                          scene.Camera.LookFrom.Y == lookFrom.Y && 
                          scene.Camera.LookFrom.Z == lookFrom.Z
                          && scene.Camera.LookAt.X == lookAt.X 
                          && scene.Camera.LookAt.Y == lookAt.Y 
                          && scene.Camera.LookAt.Z == lookAt.Z
                          && scene.Camera.FieldOfView == fov);
        }

    }
}
