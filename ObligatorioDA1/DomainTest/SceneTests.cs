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
    }
}
